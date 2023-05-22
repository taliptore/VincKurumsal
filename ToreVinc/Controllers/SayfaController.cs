using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;


namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SayfaController : BaseController
	{
		private readonly IService<Icerik> _srvcIcerik;
		private readonly IService<AltMenu> _srvcAltMenu;
		private readonly IService<Menu> _srvcMenu;


		string SayfaAdi = "Sayfa İşlemleri";
		public SayfaController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Icerik> srvcIcerik, IService<AltMenu> srvcAltMenu, IService<Menu> srvcMenu)
	   : base(userManager, signInManager, roleManager, mapper)
		{
			_srvcIcerik = srvcIcerik;
			_srvcAltMenu = srvcAltMenu;
			_srvcMenu = srvcMenu;

		}

		// GET: SayfaController
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "Sayfa";
			ViewBag.SayfaAdi = SayfaAdi;

			var icerik = await _srvcIcerik.GetAllAsycn();

			var altMenu = await _srvcAltMenu.GetAllAsycn();
			ViewBag.AltMenu = altMenu;
			var menu = await _srvcMenu.GetAllAsycn();
			ViewBag.Menu = menu;
			var veri = icerik.OrderByDescending(x => x.Id).ToList();

			return View(veri);
		}

		// GET: SayfaController/Details/5
		public ActionResult Details(int id)
		{
			TempData["Menu"] = "Sayfa";
			return View();
		}
		public async Task<IActionResult> MenuEkle(int id)
		{
			TempData["Menu"] = "Sayfa";
			var icerik = await _srvcIcerik.GetByIdAscy(id);
			var menu = await _srvcMenu.GetAllAsycn();
			var menuAktif = menu.Where(x => x.Durum == true);
			List<SelectListItem> menuLst = (from x in menuAktif.ToList()
											select new SelectListItem
											{
												Text = x.MenuAdi,
												Value = x.Id.ToString(),
												Selected = icerik.MenuId == x.Id ? true : false,
											}
									).ToList();
			ViewBag.MenuList = menuLst;
			ViewBag.MenuSelected = icerik.MenuId;

			var menualt = await _srvcAltMenu.GetAllIncluding();
			var menuAltAktif = menualt.Where(x => x.Durum == true && x.Id == icerik.AltMenuId);
			List<SelectListItem> menuAltLst = (from x in menuAltAktif.ToList()
											   select new SelectListItem
											   {
												   Text = x.AltMenuAdi,
												   Value = x.Id.ToString(),
												   Selected = icerik.AltMenuId == x.Id ? true : false,
											   }
										).ToList();
			ViewBag.MenuAltList = menuAltLst;
			ViewBag.MenuAltSelected = icerik.AltMenuId;




			return View(icerik);
		}
		[HttpPost]
		public async Task<IActionResult> MenuEkle(int id, Icerik icerik)
		{
			TempData["Menu"] = "Sayfa";
			try
			{
				Icerik getir = await _srvcIcerik.GetByIdAscy(icerik.Id);
				getir.AltMenuId = icerik.AltMenuId;
				getir.MenuId = icerik.MenuId;
				await _srvcIcerik.UpdateAsync(getir);
				if (icerik.MenuId > 0 && icerik.AltMenuId == 0)
				{
					var menugetir = await _srvcMenu.GetByIdAscy(icerik.MenuId);
					menugetir.MenuYol = "Home/SayfaGetir/" + icerik.Id;
					await _srvcMenu.UpdateAsync(menugetir);
				}
				if (icerik.MenuId > 0 && icerik.AltMenuId > 0)
				{
					var altMenu = await _srvcAltMenu.GetByIdAscy(icerik.AltMenuId);
					altMenu.AltMenuYol = "Home/SayfaGetir/" + icerik.Id;
					await _srvcAltMenu.UpdateAsync(altMenu);
				}

				return RedirectToAction(nameof(Index));


			}
			catch
			{

				return View(icerik);
			}



		}
		[HttpPost]
		public async Task<JsonResult> AltMenuGetir(int id)
		{
			TempData["Menu"] = "Sayfa";
			var altmenu = await _srvcAltMenu.GetAllIncluding();
			var almenusuz = altmenu.Where(x => x.MenuId == id).ToList();
			List<SelectListItem> veri = (from x in almenusuz.ToList()
										 select new SelectListItem
										 { Text = x.AltMenuAdi, Value = x.Id.ToString() }).ToList();
			return Json(veri);
		}
		// GET: SayfaController/Create
		public ActionResult Create()
		{
			TempData["Menu"] = "Sayfa";
			ViewBag.SayfaAdi = "Yeni Sayfa Oluşturma";
			return View();
		}

		// POST: SayfaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(IcerikDto icerik)
		{
			TempData["Menu"] = "Sayfa";
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;
				if (icerik.KucukResimFile is not null)
				{
					if (icerik.KucukResimFile.Length > 0)
					{


						var resim = await FileBaseUpload.HizliUpload(icerik.KucukResimFile);
						if (resim.Uploaded == 1)
						{
							icerik.KucukResim = resim.Url;
						}
						if (resim.Uploaded == -1)
						{

							ModelState.AddModelError("KucukResim", "Resim Hatalı");
							return View(icerik);

						}
					}
				}

				if (ModelState.IsValid)
				{


					try
					{

						var model = _mapper.Map<Icerik>(icerik);
						var result = _srvcIcerik.AddAsync(model);
					}
					catch (Exception ex)
					{
						var message = ex.Message;
					}




				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						return View(icerik);
					}
				}
				TempData["Alert"] = $"{icerik.Baslik} Sayfası Eklendi.";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(icerik);
			}
		}

		// GET: SayfaController/Create
		public ActionResult CreateCK()
		{
			TempData["Menu"] = "Sayfa";
			return View();
		}

		// POST: SayfaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateCK(IcerikDto icerik)
		{
			TempData["Menu"] = "Sayfa";
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{


					try
					{
						//  var result = _srvcIcerik.AddAsync(icerik);
					}
					catch (Exception ex)
					{
						var message = ex.Message;
					}




				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						return View(icerik);
					}
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(icerik);
			}
		}

		// GET: SayfaController/Create
		public ActionResult CreateEditor()
		{
			TempData["Menu"] = "Sayfa";
			return View();
		}

		// POST: SayfaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateEditor(IcerikDto icerik)
		{
			TempData["Menu"] = "Sayfa";
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{
					//var deltaOps = JArray.FromObject(icerik.MetinObj) ;
					//var htmlConverter = new HtmlConverter(deltaOps);
					//string html = htmlConverter.Convert();
					//icerik.Metin = html;
					//try
					//{
					//   // var result = _srvcIcerik.AddAsync(icerik);
					//}
					//catch (Exception ex)
					//{
					//    var message = ex.Message;
					//}




				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						return View(icerik);
					}
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(icerik);
			}
		}


		[HttpPost]
		[IgnoreAntiforgeryToken]
		public async Task<IActionResult> upload_ckeditor([FromForm] IFormFile upload)
		{
			if (upload.Length <= 0) return null;
			var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

			//save file under wwwroot/CKEditorImages folder

			var filePath = Path.Combine(
				Directory.GetCurrentDirectory(), "wwwroot/upload/images",
				fileName);

			using (var stream = System.IO.File.Create(filePath))
			{
				await upload.CopyToAsync(stream);
			}

			var url = $"{"/upload/images/"}{fileName}";

			var success = new UploadSuccessDto
			{
				Uploaded = 1,
				FileName = fileName,
				Url = url
			};
			//FileBaseUpload n = new FileBaseUpload();
			//var success = n.CKEditorUpload(upload);


			return new JsonResult(success);
			//return new JsonResult(new { path = "/upload/images/ttt.jpg" });
		}


		// GET: SayfaController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			TempData["Menu"] = "Sayfa";
			var veri = await _srvcIcerik.GetByIdAscy(id);

			if (veri == null)
			{
				return NotFound();
			}

			return View(_mapper.Map<IcerikDto>(veri));
		}

		// POST: SayfaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, IcerikDto dto)
		{
			if (id != dto.Id)
			{
				return NotFound();
			}
			if (dto.KucukResimFile is not null)
			{
				if (dto.KucukResimFile.Length > 0)
				{

					var resim = await FileBaseUpload.HizliUpload(dto.KucukResimFile);
					if (resim.Uploaded == 1)
					{
						dto.KucukResim = resim.Url;
					}
					if (resim.Uploaded == -1)
					{

						ModelState.AddModelError("KucukResim", "Resim Hatalı");
						return View(dto);

					}
				}
			}

			try
			{
				if (ModelState.IsValid)
				{
					var model = _mapper.Map<Icerik>(dto);
					await _srvcIcerik.UpdateAsync(model);
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(dto);
			}
		}

		// GET: SayfaController/Delete/5


		// POST: SayfaController/Delete/5


		public async Task<ActionResult> Delete(int id)
		{
			TempData["Menu"] = "Sayfa";
			var knt = await _srvcIcerik.GetByIdAscy(id);
			if (knt == null)
			{
				return Problem("Entity set 'icerik id'  is null.");
			}

			if (knt != null)
			{
				await _srvcIcerik.RomeveAsync(knt);
				// _context.Resimlers.Remove(resimler);
			}


			return RedirectToAction(nameof(Index));
		}
	}
}
