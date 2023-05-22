using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class MenuController : BaseController
	{
		private readonly IService<Menu> _service;
		private readonly IService<AltMenu> _serviceAlt;

		public MenuController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Menu> service, IService<AltMenu> serviceAlt)
					: base(userManager, signInManager, roleManager, mapper)
		{
			_service = service;
			_serviceAlt = serviceAlt;
		}

		// GET: MenuController
		public async Task<IActionResult> Index()
		{
			@ViewBag.SayfaAdi = "Menü Listesi";
			var menu = await _service.GetAllIncluding(x => x.AltMenus);
			return View(menu.Where(x => x.AdminMenusuMu == true).OrderBy(x => x.MenuSirasi));
		}
		public async Task<IActionResult> AnaSayfaMenu()
		{
			TempData["Menu"] = "AnaSayfaMenu";
			@ViewBag.SayfaAdi = "AnaSayfa Menü Listesi";
			var menu = await _service.GetAllIncluding(x => x.AltMenus);
			return View(menu.Where(x => x.AdminMenusuMu == false));
		}

		// GET: MenuController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: MenuController/Create
		public ActionResult Create()
		{
			ViewBag.SayfaAdi = "Menü Ekle";
			return View();
		}


		// POST: MenuController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Menu menu)
		{
			if (ModelState.IsValid)
			{

				var result = await _service.AddAsync(menu);
				return RedirectToAction("AnaSayfaMenu");
			}


			return View(menu);
		}

		public async Task<IActionResult> AltMenuEkle(int id)
		{
			ViewBag.SayfaAdi = "Alt Menü Ekle";

			ViewBag.MenuId = id;

			var menusadi = await _service.GetByIdAscy(id);
			ViewBag.MenuAdi = menusadi.MenuAdi;

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AltMenuEkle(AltMenu altMenu)
		{
			if (ModelState.IsValid)
			{

				var result = await _serviceAlt.AddAsync(altMenu);
				return RedirectToAction("AnaSayfaMenu");
			}


			return View(altMenu);
		}

		// GET: MenuController/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var veri = await _service.GetByIdAscy(id);
			if (veri == null)
			{
				return NotFound();
			}
			return View(veri);
		}

		// POST: MenuController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Menu menu)
		{
			if (id != menu.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var veri = await _service.GetByIdAscy(id);
					veri.MenuYol = menu.MenuYol;
					veri.AdminMenusuMu = menu.AdminMenusuMu;
					veri.Durum = menu.Durum;
					veri.MenuAdi = menu.MenuAdi;
					veri.MenuIcon = menu.MenuIcon;
					veri.MenuSirasi = menu.MenuSirasi;


					await _service.UpdateAsync(veri);
				}
				catch
				{

				}
				return RedirectToAction(nameof(AnaSayfaMenu));
			}
			return View(menu);
		}

		// GET: MenuController/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var veri = await _service.GetByIdAscy(id);

			if (veri == null)
			{
				return NotFound();
			}

			return View(veri);
		}

		// POST: MenuController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var veri = await _service.GetByIdAscy(id);
			if (veri == null)
			{
				return Problem("Entity set 'AppDbContext.Videolars'  is null.");
			}

			if (veri != null)
			{
				await _service.RomeveAsync(veri);
			}


			return RedirectToAction(nameof(AnaSayfaMenu));
		}

		[HttpPost]
		public async Task<JsonResult> MenuDurumDegis(int id, bool durum)
		{
			int sonuc = 0;
			var service = await _service.GetByIdAscy(id);
			if (service != null)
			{
				service.Durum = !service.Durum;
				await _service.UpdateAsync(service);
				sonuc = 1;
			}

			return Json(sonuc);
		}

		[HttpPost]
		public async Task<JsonResult> MenuAdminDurumDegis(int id, bool durum)
		{
			int sonuc = 0;
			var service = await _service.GetByIdAscy(id);
			if (service != null)
			{
				service.AdminMenusuMu = !service.AdminMenusuMu;
				var update = _service.UpdateAsync(service);
				sonuc = 1;
			}

			return Json(sonuc);
		}
		[HttpPost]
		public async Task<JsonResult> MenuAltMenuDurumDegis(int id, bool durum)
		{
			int sonuc = 0;
			var service = await _serviceAlt.GetByIdAscy(id);
			if (service != null)
			{
				service.Durum = !service.Durum;
				var update = _serviceAlt.UpdateAsync(service);
				sonuc = 1;
			}

			return Json(sonuc);
		}

		#region Altmenüeditdelete
		// GET: MenuController/Edit/5
		public async Task<IActionResult> AltMenuEdit(int id)
		{
			var veri = await _serviceAlt.GetByIdAscy(id);
			if (veri == null)
			{
				return NotFound();
			}
			return View(veri);
		}

		// POST: MenuController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AltMenuEdit(int id, AltMenu menu = null)
		{
			if (id != menu.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var veri = await _serviceAlt.GetByIdAscy(id);
					veri.AltMenuYol = menu.AltMenuYol;

					veri.Durum = menu.Durum;
					veri.AltMenuAdi = menu.AltMenuAdi;
					veri.AltMenuSirasi = menu.AltMenuSirasi;
					veri.AltMenuIcon = menu.AltMenuIcon;



					await _serviceAlt.UpdateAsync(veri);
				}
				catch
				{

				}
				return RedirectToAction(nameof(AnaSayfaMenu));
			}
			return View(menu);
		}

		// GET: MenuController/Delete/5
		public async Task<IActionResult> AltMenuDelete(int id)
		{
			var veri = await _serviceAlt.GetByIdAscy(id);

			if (veri == null)
			{
				return NotFound();
			}

			return View(veri);
		}

		// POST: MenuController/Delete/5
		[HttpPost, ActionName("AltMenuDelete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AltMenuDeleteConfirmed(int id)
		{
			var veri = await _serviceAlt.GetByIdAscy(id);
			if (veri == null)
			{
				return Problem("Entity set 'Alt Menü'  is null.");
			}

			if (veri != null)
			{
				await _serviceAlt.RomeveAsync(veri);
			}


			return RedirectToAction(nameof(AnaSayfaMenu));
		}
		#endregion

	}
}
