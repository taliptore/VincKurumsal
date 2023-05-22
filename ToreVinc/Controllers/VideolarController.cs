using AutoMapper;
using KurumsalWebVinc.Migrations;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class VideolarController : BaseController
	{
		private readonly IService<Videolar> _srvcV;

		public VideolarController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Videolar> srvcV)
	   : base(userManager, signInManager, roleManager, mapper)
		{
			_srvcV = srvcV;
		}



		// GET: Videolar
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "videolar";
			var veri = await _srvcV.GetAllAsycn();
			var lst = veri.Where(x => x.Durum == true).ToList();
			return View(lst);
		}

		// GET: Videolar/Details/5
		public async Task<IActionResult> Details(int id)
		{

			TempData["Menu"] = "videolar";
			var videolar = await _srvcV.GetByIdAscy(id);

			if (videolar == null)
			{
				return NotFound();
			}

			return View(videolar);
		}

		// GET: Videolar/Create
		public IActionResult Create()
		{
			TempData["Menu"] = "videolar";
			return View();
		}

		// POST: Videolar/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Videolar videolar)
		{
			TempData["Menu"] = "videolar";
			if (ModelState.IsValid)
			{
				await _srvcV.AddAsync(videolar);
				return RedirectToAction(nameof(Index));
			}
			return View(videolar);
		}

		// GET: Videolar/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["Menu"] = "videolar";

			var videolar = await _srvcV.GetByIdAscy(id);
			if (videolar == null)
			{
				return NotFound();
			}
			return View(videolar);
		}

		// POST: Videolar/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Videolar videolar)
		{
			TempData["Menu"] = "videolar";
			if (id != videolar.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var veri = await _srvcV.GetByIdAscy(id);
					veri.VideoBaslik = videolar.VideoBaslik;
					veri.YoutubeLink = videolar.YoutubeLink;
					veri.Durum = videolar.Durum;
					veri.VideoAciklama = videolar.VideoAciklama;
					veri.VideoYol = videolar.VideoYol;

					await _srvcV.UpdateAsync(veri);
				}
				catch
				{

				}
				return RedirectToAction(nameof(Index));
			}
			return View(videolar);
		}

		// GET: Videolar/Delete/5
		public async Task<IActionResult> Delete(int id)
		{

			TempData["Menu"] = "videolar";
			var videolar = await _srvcV.GetByIdAscy(id);

			if (videolar == null)
			{
				return NotFound();
			}

			return View(videolar);
		}

		// POST: Videolar/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["Menu"] = "videolar";
			var veri = await _srvcV.GetByIdAscy(id);
			if (veri == null)
			{
				return Problem("Entity set 'AppDbContext.Videolars'  is null.");
			}
			var videolar = veri;
			if (videolar != null)
			{
				await _srvcV.RomeveAsync(videolar);
			}


			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> VideolarExists(int id)
		{
			TempData["Menu"] = "videolar";
			var veri = await _srvcV.AnyAsync(x => x.Id == id);
			return veri;
		}
	}
}
