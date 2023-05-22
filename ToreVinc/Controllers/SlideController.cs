using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SlideController : BaseController
	{
		private readonly IService<SlideModel> _srvcSlide;

		public SlideController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<SlideModel> srvcSlide)
		: base(userManager, signInManager, roleManager, mapper)
		{
			_srvcSlide = srvcSlide;
		}


		// GET: Slide
		public async Task<IActionResult> Index()
		{
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "slide";
			var veri = await _srvcSlide.GetAllAsycn();
			var list = veri.ToList();
			//  var list = veri.Where(x => x.Durum = true &&
			// x.BitisTarihi <= DateTime.Now && x.BaslamaTarihi >= DateTime.Now).ToList();
			return View(list.OrderByDescending(x => x.CreateDate)); ;
		}

		// GET: Slide/Details/5
		public async Task<IActionResult> Details(int id)
		{


			var slideModel = await _srvcSlide.GetByIdAscy(id);

			if (slideModel == null)
			{
				return NotFound();
			}

			return View(slideModel);
		}

		// GET: Slide/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Slide/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SlideModel slideModel, IFormFile ResimFile)
		{
			if (ModelState.IsValid)
			{
				if (ResimFile is not null)
				{
					if (ResimFile.Length > 0)
					{

						var resim = await FileBaseUpload.HizliUpload(ResimFile);
						if (resim.Uploaded == 1)
						{
							slideModel.Resim = resim.Url;
						}
						if (resim.Uploaded == -1)
						{

							ModelState.AddModelError("Resim", "Resim Hatalı");
							return View(slideModel);

						}
					}
				}

				await _srvcSlide.AddAsync(slideModel);
				return RedirectToAction(nameof(Index));
			}
			return View(slideModel);
		}

		// GET: Slide/Edit/5
		public async Task<IActionResult> Edit(int id)
		{


			var slideModel = await _srvcSlide.GetByIdAscy(id);
			if (slideModel == null)
			{
				return NotFound();
			}
			return View(slideModel);
		}

		// POST: Slide/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, SlideModel slideModel, IFormFile ResimFile)
		{
			if (id != slideModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					if (ResimFile is not null)
					{
						if (ResimFile.Length > 0)
						{

							var resim = await FileBaseUpload.HizliUpload(ResimFile);
							if (resim.Uploaded == 1)
							{
								slideModel.Resim = resim.Url;
							}
							if (resim.Uploaded == -1)
							{

								ModelState.AddModelError("Resim", "Resim Hatalı");
								return View(slideModel);

							}
						}
					}

					var veri = await _srvcSlide.GetByIdAscy(id);
					veri.UpdateDate = DateTime.Now;
					veri.BitisTarihi = slideModel.BitisTarihi;
					veri.Durum = slideModel.Durum;
					veri.Aciklama = slideModel.Aciklama;
					veri.Baslik = slideModel.Baslik;
					veri.BaslamaTarihi = slideModel.BaslamaTarihi;
					veri.Resim = slideModel.Resim;
					await _srvcSlide.UpdateAsync(veri);
				}
				catch
				{

				}
				return RedirectToAction(nameof(Index));
			}
			return View(slideModel);
		}

		// GET: Slide/Delete/5
		public async Task<IActionResult> Delete(int id)
		{


			var slideModel = await _srvcSlide.GetByIdAscy(id);
			if (slideModel == null)
			{
				return NotFound();
			}

			return View(slideModel);
		}

		// POST: Slide/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var knt = await _srvcSlide.GetByIdAscy(id);
			if (knt == null)
			{
				return Problem("Entity set 'slideModel Boş '  is null.");
			}
			var slideModel = knt;
			if (slideModel != null)
			{
				await _srvcSlide.RomeveAsync(knt);
			}


			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> SlideModelExists(int id)
		{
			var knt = await _srvcSlide.AnyAsync(x => x.Id == id);
			return knt;
		}
	}
}
