using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SSSesController : BaseController
	{
		private readonly IService<SSS> _srvSSS;

		public SSSesController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<SSS> srvSSS)
		: base(userManager, signInManager, roleManager, mapper)
		{
			_srvSSS = srvSSS;
		}



		// GET: SSSes
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "sss";
			ViewBag.SayfaAdi = "Sık Sorulan Sorular Listesi";
			var veri = await _srvSSS.GetAllAsycn();
			var list = veri.ToList();
			return View(list);
		}

		//  GET: SSSes/Details/5
		public async Task<IActionResult> Details(int id)
		{
			TempData["Menu"] = "sss";
			var knt = await _srvSSS.GetByIdAscy(id);
			if (knt is null)
			{
				return NotFound();
			}


			if (knt == null)
			{
				return NotFound();
			}

			return View(knt);
		}

		// GET: SSSes/Create
		public IActionResult Create()
		{
			TempData["Menu"] = "sss";
			return View();
		}

		// POST: SSSes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SSS sSS)
		{
			TempData["Menu"] = "sss";
			if (ModelState.IsValid)
			{
				await _srvSSS.AddAsync(sSS);
				return RedirectToAction(nameof(Index));
			}
			return View(sSS);
		}

		// GET: SSSes/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["Menu"] = "sss";
			var knt = await _srvSSS.GetByIdAscy(id);

			if (knt == null)
			{
				return NotFound();
			}

			return View(knt);
		}

		// POST: SSSes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, SSS sSS)
		{
			TempData["Menu"] = "sss";

			if (id != sSS.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var knt = await _srvSSS.GetByIdAscy(id);

				try
				{
					knt.Cevap = sSS.Cevap;
					knt.Soru = sSS.Soru;
					knt.Durum = sSS.Durum;
					await _srvSSS.UpdateAsync(knt);

				}
				catch
				{
					if (!SSSExists(sSS.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(sSS);
		}

		// GET: SSSes/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			TempData["Menu"] = "sss";
			var knt = await _srvSSS.GetByIdAscy(id);
			if (knt == null)
			{
				return NotFound();
			}



			return View(knt);
		}

		// POST: SSSes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["Menu"] = "sss";
			var knt = await _srvSSS.GetByIdAscy(id);
			if (knt == null)
			{
				return Problem("Entity set 'SSS'  is null.");
			}
			var sSS = knt;
			if (sSS != null)
			{
				await _srvSSS.RomeveAsync(sSS);

			}


			return RedirectToAction(nameof(Index));
		}

		private bool SSSExists(int id)
		{
			var knt = _srvSSS.AnyAsync(x => x.Id == id).Result;
			return knt;
		}
	}
}
