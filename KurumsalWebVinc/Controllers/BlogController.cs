using AutoMapper;
using KurumsalWebVinc.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class BlogController : BaseController
	{
		private readonly IService<Blog> _srvcBlg;
		private readonly IService<BlogKategory> _srvcKategry;
		private readonly IService<Icerik> _srvcIcerik;


		public BlogController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Blog> srvcBlg, IService<Icerik> srvcIcerik, IService<BlogKategory> srvcKategry)
			  : base(userManager, signInManager, roleManager, mapper)
		{
			_srvcBlg = srvcBlg;
			_srvcIcerik = srvcIcerik;
			_srvcKategry = srvcKategry;
		}

		// GET: Blog
		public async Task<IActionResult> Index()
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";
			var veri = await _srvcBlg.GetAllIncluding(x => x.BlogKategory);
			var getir = veri.ToList().Where(x => x.Durum == true);
			return View(getir.OrderByDescending(x => x.CreateDate).ToList());
		}

		// GET: Blog/Details/5
		public async Task<IActionResult> Details(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";

			var blog = await _srvcBlg.GetByIdAscy(id);

			if (blog == null)
			{
				return NotFound();
			}

			return View(blog);
		}

		// GET: Blog/Create
		public async Task<IActionResult> Create()
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";


			var bkat = await _srvcKategry.GetAllAsycn();

			ViewBag.BlogKategory = (from x in bkat.Where(x => x.Durum == true).ToList()
									select new SelectListItem { Text = x.Adi, Value = x.Id.ToString() }
								   ).ToList();

			return View();
		}

		// POST: Blog/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Blog blog, IFormFile ResimFile)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";
			if (ModelState.IsValid)
			{
				#region Servise Ait Page Oluşturma 


				#region resimyükleme
				if (ResimFile is not null)
				{
					if (ResimFile.Length > 0)
					{

						var resim = await FileBaseUpload.HizliUpload(ResimFile);
						if (resim.Uploaded == 1)
						{
							blog.BlogResim = resim.Url;
						}
						if (resim.Uploaded == -1)
						{

							ModelState.AddModelError("Resim", "Resim Hatalı");
							return View(blog);

						}
					}
				}
				#endregion

				Icerik icerik = new Icerik()
				{
					Baslik = blog.BlogBaslik,
					KisaYazi = blog.BlogAciklama,
					Durum = true,
					Etiket = blog.BlogBaslik,
					Id = 0,
					KucukResim = blog.BlogResim,
					Metin = blog.BlogAciklama,
					SeoAciklama = "",
					SeoBaslik = "",
					Url = "",
					Yazar = "",
					SayfaMi = true


				};

				var resultic = await _srvcIcerik.AddAsync(icerik);
				int icerikid = resultic.Id;
				#endregion
				blog.SayfaUrl = "Home/Blog/" + icerikid;
				blog.SayfaId = icerikid;
				await _srvcBlg.AddAsync(blog);

				return RedirectToAction(nameof(Index));
			}
			var bkat = await _srvcKategry.GetAllAsycn();



			ViewBag.BlogKategory = (from x in bkat.Where(x => x.Durum == true).ToList()
									select new SelectListItem { Text = x.Adi, Value = x.Id.ToString() }
								   ).ToList();

			return View(blog);
		}

		// GET: Blog/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";
			var blog = await _srvcBlg.GetByIdAscy(id);
			if (blog == null)
			{
				return NotFound();
			}
			var bkat = await _srvcKategry.GetAllAsycn();

			ViewBag.BlogKategory = (from x in bkat.Where(x => x.Durum == true).ToList()
									select new SelectListItem { Text = x.Adi, Value = x.Id.ToString() }
								   ).ToList();
			return View(blog);
		}

		// POST: Blog/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Blog blog, IFormFile ResimFile)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";

			if (ModelState.IsValid)
			{
				try
				{

					#region resimyükleme
					if (ResimFile is not null)
					{
						if (ResimFile.Length > 0)
						{

							var resim = await FileBaseUpload.HizliUpload(ResimFile);
							if (resim.Uploaded == 1)
							{
								blog.BlogResim = resim.Url;

							}
							if (resim.Uploaded == -1)
							{

								ModelState.AddModelError("Resim", "Resim Hatalı");
								return View(blog);

							}
						}
					}
					#endregion
					var sayfacek = await _srvcIcerik.GetByIdAscy(blog.SayfaId);
					if (sayfacek is not null)
					{

						sayfacek.Baslik = blog.BlogBaslik;
						sayfacek.KisaYazi = blog.BlogAciklama;
						sayfacek.Durum = true;
						sayfacek.Etiket = blog.BlogBaslik;

						sayfacek.KucukResim = blog.BlogResim;
						//sayfacek.Metin = blog.BlogAciklama; // var olan açıklamayı koru
						sayfacek.SayfaMi = true;




						await _srvcIcerik.UpdateAsync(sayfacek);

					}

					var veri = await _srvcBlg.GetByIdAscy(id);
					veri.SayfaUrl = blog.SayfaUrl;
					veri.Durum = blog.Durum;
					veri.BlogAciklama = blog.BlogAciklama;
					veri.BlogBaslik = blog.BlogBaslik;
					veri.BlogKategoryId = blog.BlogKategoryId;
					veri.BlogResim = blog.BlogResim;

					await _srvcBlg.UpdateAsync(veri);
					//_context.Update(veri);
					// _context.SaveChangesAsync();
				}
				catch
				{
					if (!BlogExists(blog.Id))
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
			var bkat = await _srvcKategry.GetAllAsycn();

			ViewBag.BlogKategory = (from x in bkat.Where(x => x.Durum == true).ToList()
									select new SelectListItem { Text = x.Adi, Value = x.Id.ToString() }
								   ).ToList();
			return View(blog);
		}

		// GET: Blog/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";

			var blog = await _srvcBlg.GetByIdAscy(id);

			if (blog == null)
			{
				return NotFound();
			}

			return View(blog);
		}

		// POST: Blog/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["dropdown"] = "blog";
			TempData["Menu"] = "blog";
			var knt = _srvcBlg.GetByIdAscy(id);
			if (knt == null)
			{
				return Problem("Entity set ' Blog Yok '  is null.");
			}
			var blog = knt;
			if (blog != null)
			{
				await _srvcBlg.RomeveAsync(blog.Result);
			}


			return RedirectToAction(nameof(Index));
		}

		private bool BlogExists(int id)
		{
			var knt = _srvcBlg.AnyAsync(x => x.Id == id).Result;
			return knt;
		}
	}
}
