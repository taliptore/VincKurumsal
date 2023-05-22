using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.ModelArac;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class TalepController : BaseController
	{
		private readonly IService<TalepFormu> _srvcTlp;
		private readonly IService<ServisTalep> _srvHizmet;
		private readonly IService<SehirilBilgisi> _srvSehir;

		public TalepController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<TalepFormu> srvcTlp, IService<ServisTalep> srvHizmet, IService<SehirilBilgisi> srvSehir)
		: base(userManager, signInManager, roleManager, mapper)
		{
			_srvcTlp = srvcTlp;
			_srvHizmet = srvHizmet;
			_srvSehir = srvSehir;
		}

		// GET: TalepController
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "talep";
			ViewBag.SayfaAdi = "Talep Listesi";

			var veri = await _srvcTlp.GetAllAsycn();
			var order = veri.ToList();

			ViewData["TalepMadde"] = _srvHizmet.GetAllIncluding(x => x.Servisler).Result.ToList();
			//if (veri.Count()>0)
			//{
			return View(order.OrderByDescending(x => x.Id));
			//}



			// return View(order);
		}

		// GET: TalepController/Details/5
		public async Task<IActionResult> Details(int id)
		{
			TempData["Menu"] = "talep";
			var veri = await _srvcTlp.GetByIdAscy(id);
			if (veri is not null)
			{
				ViewData["TalepMadde"] = _srvHizmet.GetAllIncluding(x => x.Servisler).Result.ToList();
				ViewData["BulSehir"] = null;
				ViewData["GitSehir"] = null;
				if (veri.BulSehirId > 0)
				{
					ViewData["BulSehir"] = _srvSehir.GetByIdAscy(veri.BulSehirId).Result.ilAdi;
				}
				if (veri.GitSehirId > 0)
				{
					ViewData["GitSehir"] = _srvSehir.GetByIdAscy(veri.GitSehirId).Result.ilAdi;
				}


				return View(veri);
			}


			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Details(int id, bool Durum)
		{
			TempData["Menu"] = "talep";
			var veri = await _srvcTlp.GetByIdAscy(id);
			if (veri is not null)
			{
				ViewData["TalepMadde"] = _srvHizmet.GetAllIncluding(x => x.Servisler).Result.ToList();
				if (veri.BulSehirId > 0)
				{
					ViewData["BulSehir"] = _srvSehir.GetByIdAscy(veri.BulSehirId).Result.ilAdi;
				}
				if (veri.GitSehirId > 0)
				{
					ViewData["GitSehir"] = _srvSehir.GetByIdAscy(veri.GitSehirId).Result.ilAdi;
				}
				veri.Durum = true;
				await _srvcTlp.UpdateAsync(veri);
			}

			return RedirectToAction(nameof(Index));
		}

		// GET: TalepController/Create
		public ActionResult Create()
		{
			TempData["Menu"] = "talep";
			return View();
		}

		// POST: TalepController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(TalepFormu talepFormu)
		{
			TempData["Menu"] = "talep";
			try
			{
				if (!ModelState.IsValid)
				{
					//return BadRequest(ModelState.Values
					// .SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
					var modelErrors = new List<string>();
					foreach (var modelState in ModelState.Values)
					{
						foreach (var modelError in modelState.Errors)
						{
							modelErrors.Add(modelError.ErrorMessage);
						}
					}
					return RedirectToRoute("~/Home/iletisim");
				}

				if (ModelState.IsValid)
				{
					await _srvcTlp.AddAsync(talepFormu);
					return RedirectToRoute("~/Home/iletisim");
				}
				else
				{
					return Problem("Entity set ' Blog Yok '  is null.");
				}

			}
			catch
			{
				return RedirectToRoute("Home/iletisim");
			}

		}

		// GET: TalepController/Edit/5
		public ActionResult Edit(int id)
		{
			TempData["Menu"] = "talep";
			return View();
		}

		// POST: TalepController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			TempData["Menu"] = "talep";
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TalepController/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			TempData["Menu"] = "talep";
			var veri = await _srvcTlp.GetByIdAscy(id);
			if (veri is not null)
			{
				return View(veri);
			}
			return View();
		}

		// POST: TalepController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id, IFormCollection collection)
		{
			TempData["Menu"] = "talep";
			try
			{
				var veri = await _srvcTlp.GetByIdAscy(id);
				if (veri is not null)
				{
					await _srvcTlp.RomeveAsync(veri);
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
