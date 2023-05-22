using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ImageController : BaseController
	{
		private readonly IWebHostEnvironment _webHost;
		private readonly IService<Resimler> _serviceImg;

		public ImageController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Resimler> serviceImg, IWebHostEnvironment webHost)
					: base(userManager, signInManager, roleManager, mapper)
		{
			_serviceImg = serviceImg;
			_webHost = webHost;
		}

		// GET: ImageController
		public async Task<IActionResult> Index()
		{
			ViewBag.SayfaAdi = "Hakkımızda";
			var list = await _serviceImg.GetAllAsycn();
			var veri = list.ToList();

			return View(veri);
		}

		// GET: ImageController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ImageController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ImageController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ResimlerDto rr)
		{
			if (ModelState.IsValid)
			{

				if (rr.Resimler.Count > 0)
				{
					foreach (var item in rr.Resimler)
					{

						ResimVeriDto yeniResData = FileBaseUpload.Upload2(item, $"{_webHost.WebRootPath}");
						Resimler r = new Resimler()
						{
							Aciklama = rr.Aciklama,
							Baslik = rr.Baslik,
							Durum = rr.Durum,
							FileName = yeniResData.FileName,
							Id = rr.Id,
							Path = yeniResData.Path
						};
						await _serviceImg.AddAsync(r);
					}
				}





				return RedirectToAction(nameof(Index));
			}
			return View(rr);
		}

		// GET: ImageController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ImageController/Edit/5
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

		// GET: ImageController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ImageController/Delete/5
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
