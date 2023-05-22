using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ServislerController : BaseController
	{
		private readonly IService<Icerik> _srvcIcerik;
		private readonly IService<Servisler> _srvcServis;
		private readonly IService<ServisTalep> _srvcTalep;



		public ServislerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Servisler> srvcServis, IService<Icerik> srvcIcerik, IService<ServisTalep> srvcTalep)
		 : base(userManager, signInManager, roleManager, mapper)
		{
			_srvcServis = srvcServis;
			_srvcIcerik = srvcIcerik;
			_srvcTalep = srvcTalep;
		}

		// GET: ServislerController
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "servisler";
			ViewBag.SayfaAdi = "Hizmet Listesi";
			var list = await _srvcServis.GetAllAsycn();
			var veri = list.ToList();

			return View(veri);
		}
		public ActionResult HizmetTalep(int id)
		{

			var servis = _srvcServis.GetByIdAscy(id).Result;
			var al = _srvcTalep.Where(x => x.ServislerId == id).FirstOrDefault();


			if (al is not null)
			{
				al.ServislerId = servis.Id;
				al.Servisler = servis;
				return View(al);
			}



			ServisTalep servisTalep = new ServisTalep();
			//servisTalep.Id = id;
			servisTalep.Servisler = servis;
			servisTalep.ServislerId = servis.Id;
			return View(servisTalep);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> HizmetTalep(int id, ServisTalep talep)
		{



			if (ModelState.IsValid)
			{
				var al = await _srvcTalep.GetByIdAscy(id);
				if (al is not null)
				{
					al.Servisler = talep.Servisler;
					al.Id = id;
					al.BulSehirDurum = talep.BulSehirDurum;
					al.GidSehirDurum = talep.GidSehirDurum;
					al.Durum = talep.Durum;
					await _srvcTalep.UpdateAsync(al);



				}
				else
				{
					await _srvcTalep.AddAsync(talep);
				}
				@TempData["Alert"] = "Kayıt İşlemi Yapıldı.";
				return RedirectToAction(nameof(Index));

			}

			return View(talep);
		}
		// GET: ServislerController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ServislerController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ServislerController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ServislerDto servisler)
		{
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{



					try
					{
						#region resim yükle
						if (servisler.ServisResimFile is not null)
						{
							if (servisler.ServisResimFile.Length > 0)
							{


								var resim = await FileBaseUpload.HizliUpload(servisler.ServisResimFile);
								if (resim.Uploaded == 1)
								{
									servisler.ServisResim = resim.Url;
								}
								if (resim.Uploaded == -1)
								{

									ModelState.AddModelError("Resim", "Resim Hatalı");
									return View(servisler);

								}
							}
						}
						#endregion

						#region Servise Ait Page Oluşturma 
						Icerik icerik = new Icerik()
						{
							Baslik = servisler.ServisAdi,
							KisaYazi = servisler.ServisAciklama,
							Durum = true,
							Etiket = servisler.ServisAdi,
							Id = 0,
							KucukResim = servisler.ServisResim,
							Metin = servisler.ServisAciklama,
							SeoAciklama = "",
							SeoBaslik = "",
							Url = "",
							Yazar = "",
							SayfaMi = true



						};

						var resultic = await _srvcIcerik.AddAsync(icerik);
						int icerikid = resultic.Id;
						#endregion
						servisler.ServisUrl = "Home/SayfaGetir/" + icerikid;
						servisler.SayfaId = icerikid;



						var model = _mapper.Map<Servisler>(servisler);
						var result = await _srvcServis.AddAsync(model);
						var snc = result;

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
						return View(servisler);
					}
				}
				@TempData["Alert"] = "Kayıt Eklendi.";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(servisler);
			}
		}

		// GET: ServislerController/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var veri = await _srvcServis.GetByIdAscy(id);

			if (veri == null)
			{
				return NotFound();
			}

			return View(_mapper.Map<ServislerDto>(veri));
		}

		// POST: ServislerController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, ServislerDto dto)
		{

			if (dto.ServisResimFile is not null)
			{
				if (dto.ServisResimFile.Length > 0)
				{

					var resim = await FileBaseUpload.HizliUpload(dto.ServisResimFile);
					if (resim.Uploaded == 1)
					{
						dto.ServisResim = resim.Url;
					}
					if (resim.Uploaded == -1)
					{

						ModelState.AddModelError("Resim", "Resim Hatalı");
						return View(dto);

					}
				}
			}

			try
			{
				if (ModelState.IsValid)
				{
					var sayfacek = await _srvcIcerik.GetByIdAscy(dto.SayfaId);
					if (sayfacek is not null)
					{

						sayfacek.Baslik = dto.ServisAdi;
						sayfacek.KisaYazi = dto.ServisAciklama;
						sayfacek.Durum = true;
						sayfacek.Etiket = dto.ServisAdi;

						sayfacek.KucukResim = dto.ServisResim;
						sayfacek.Metin = dto.ServisAciklama;
						sayfacek.SayfaMi = true;




						await _srvcIcerik.UpdateAsync(sayfacek);

					}

					var model = _mapper.Map<Servisler>(dto);
					await _srvcServis.UpdateAsync(model);
				}
				@TempData["Alert"] = "Kayıt Güncellendi.";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(dto);
			}
		}

		// GET: ServislerController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var veri = await _srvcServis.GetByIdAscy(id);
			if (veri != null)
			{
				await _srvcServis.RomeveAsync(veri);

			}
			@TempData["Alert"] = "Kayıt Siliindi.";
			return RedirectToAction(nameof(Index));
		}

		// POST: ServislerController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
