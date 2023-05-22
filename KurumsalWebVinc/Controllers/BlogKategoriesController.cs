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
using System.Data;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class BlogKategoriesController : BaseController
	{
		private readonly IService<BlogKategory> _context;

		public BlogKategoriesController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<BlogKategory> context)
								: base(userManager, signInManager, roleManager, mapper)
		{
			_context = context;
		}

		// GET: BlogKategories
		public async Task<IActionResult> Index()
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";
			var veri = await _context.GetAllAsycn();
			return View(veri.Where(x => x.Durum == true).ToList());
		}

		// GET: BlogKategories/Details/5
		public async Task<IActionResult> Details(int id)
		{

			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";
			var blogKategory = await _context.GetByIdAscy(id);
			// .FirstOrDefaultAsync(m => m.Id == id);
			if (blogKategory == null)
			{
				return NotFound();
			}

			return View(blogKategory);
		}

		// GET: BlogKategories/Create
		public IActionResult Create()
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";
			return View();
		}

		// POST: BlogKategories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BlogKategory blogKategory)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";
			if (ModelState.IsValid)
			{
				await _context.AddAsync(blogKategory);

				return RedirectToAction(nameof(Index));
			}
			return View(blogKategory);
		}

		// GET: BlogKategories/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";

			var blogKategory = await _context.GetByIdAscy(id);
			if (blogKategory == null)
			{
				return NotFound();
			}
			return View(blogKategory);
		}

		// POST: BlogKategories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, BlogKategory blogKategory)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";
			if (id != blogKategory.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _context.UpdateAsync(blogKategory);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BlogKategoryExists(blogKategory.Id))
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
			return View(blogKategory);
		}

		// GET: BlogKategories/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";

			var blogKategory = await _context.GetByIdAscy(id);

			if (blogKategory == null)
			{
				return NotFound();
			}

			return View(blogKategory);
		}

		// POST: BlogKategories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "BlogKategories";
			var blogKategory = await _context.GetByIdAscy(id);
			if (blogKategory == null)
			{
				return Problem("Entity set 'AppDbContext.BlogKategories'  is null.");
			}

			if (blogKategory != null)
			{
				await _context.RomeveAsync(blogKategory);
			}


			return RedirectToAction(nameof(Index));
		}

		private bool BlogKategoryExists(int id)
		{
			return _context.AnyAsync(x => x.Id == id).Result;
		}
	}
}
