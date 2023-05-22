using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class iletisimController : BaseController
	{
		private readonly IService<IletisimBilgisi> _srvcIletisim;
		private readonly IService<SosyalMedyaBilgileri> _srvcSos;

		public iletisimController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<IletisimBilgisi> srvcIletisim, IService<SosyalMedyaBilgileri> srvcSos)
		: base(userManager, signInManager, roleManager, mapper)
		{
			_srvcIletisim = srvcIletisim;
			_srvcSos = srvcSos;
		}

		string SayfaAdi = "Sayfa İşlemleri";
		// GET: iletisimController
		public async Task<IActionResult> Index()
		{
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "Iletisim";
			ViewBag.SayfaAdi = SayfaAdi;
			var list = await _srvcIletisim.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			return View(veri);
		}
		public async Task<IActionResult> SosyalMedyaAdmin()
		{
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "SosyalMedyaAdmin";
			ViewBag.SayfaAdi = "Sosyal Medya Linkleri";
			var list = await _srvcSos.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			return View(veri);
		}

		// GET: iletisimController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: iletisimController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: iletisimController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(IletisimBilgisi bilgisi)
		{
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{
					if (bilgisi.Id > 0)
					{
						//var data=await _service.GetByIdAscy(genelBilgiler.Id);
						try
						{
							var result = _srvcIletisim.UpdateAsync(bilgisi);
							TempData["Alert"] = $"Kayıt Güncellendi.";
						}
						catch (Exception ex)
						{
							var message = ex.Message;
						}


					}
					else
					{
						var result = await _srvcIletisim.AddAsync(bilgisi);
						TempData["Alert"] = $"Kayıt Ekledi.";
					}

				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						//return View(genelBilgiler);
					}
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(bilgisi);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateSosyalMedya(SosyalMedyaBilgileri bilgisi)
		{
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{
					if (bilgisi.Id > 0)
					{
						//var data=await _service.GetByIdAscy(genelBilgiler.Id);
						try
						{
							var result = _srvcSos.UpdateAsync(bilgisi);
							TempData["Alert"] = $"Kayıt Güncellendi.";

						}
						catch (Exception ex)
						{
							var message = ex.Message;
						}


					}
					else
					{
						var result = await _srvcSos.AddAsync(bilgisi);
						TempData["Alert"] = $"Kayıt Ekledi.";

					}

				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						//return View(genelBilgiler);
					}
				}

				return RedirectToAction(nameof(SosyalMedyaAdmin));
			}
			catch
			{
				return View(bilgisi);
			}
		}


		// GET: iletisimController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: iletisimController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
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

		// GET: iletisimController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: iletisimController/Delete/5
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
