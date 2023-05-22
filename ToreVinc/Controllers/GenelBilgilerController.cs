using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class GenelBilgilerController : BaseController
	{
		private readonly IService<GenelBilgiler> _service;
		private readonly IWebHostEnvironment _webHost;


		public GenelBilgilerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<GenelBilgiler> service, IWebHostEnvironment webHost)
		: base(userManager, signInManager, roleManager, mapper)
		{
			_service = service;
			_webHost = webHost;

		}

		// GET: GenelBilgilerController
		public async Task<ActionResult> Index()
		{
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "GenelBilgilerIndex";
			var list = await _service.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			var snc = _mapper.Map<GenelBilgilerDto>(veri);
			return View(snc);

		}

		// GET: GenelBilgilerController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: GenelBilgilerController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: GenelBilgilerController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(GenelBilgilerDto genelBilgilerDto)
		{
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{
					if (genelBilgilerDto.Id > 0)
					{
						var g = await _service.GetByIdAscy(genelBilgilerDto.Id);
						try
						{

							// GenelBilgiler g = new GenelBilgiler();
							g.SiteBasligi = genelBilgilerDto.SiteBasligi;
							g.Durum = genelBilgilerDto.Durum;
							g.FirmaAdi = genelBilgilerDto.FirmaAdi;
							g.SiteAciklama = genelBilgilerDto.SiteAciklama;
							g.SiteAdresi = genelBilgilerDto.SiteAdresi;
							g.SiteBasligi = genelBilgilerDto.SiteBasligi.ToString();
							g.SiteAnahtarKelime = genelBilgilerDto.SiteAnahtarKelime;
							g.FiligramYazi = genelBilgilerDto.FiligramYazi;
							g.FiligramYaziEklensinmi = genelBilgilerDto.FiligramYaziEklensinmi;

							if (genelBilgilerDto.SiteLogorsm is not null)
							{

								UploadSuccessDto rlogo = await FileBaseUpload.HizliUpload(genelBilgilerDto.SiteLogorsm);

								g.SiteLogo = rlogo.Url;
							}
							// if (genelBilgilerDto.SiteFavicon is not null)
							//{

							//   ResimVeriDto rFav = FileBaseUpload.Upload2(genelBilgilerDto.SiteFaviconrsm, $"{_webHost.WebRootPath}");

							g.SiteFavicon = "/logopng.png";
							//}


							await _service.UpdateAsync(g);
							TempData["Alert"] = $"Kayıt Güncellendi.";
						}
						catch (Exception ex)
						{
							var message = ex.Message;
						}


					}
					else
					{
						GenelBilgiler g = new GenelBilgiler();
						g.SiteBasligi = genelBilgilerDto.SiteBasligi;
						g.Durum = genelBilgilerDto.Durum;
						g.FirmaAdi = genelBilgilerDto.FirmaAdi;
						g.SiteAciklama = genelBilgilerDto.SiteAciklama;
						g.SiteAdresi = genelBilgilerDto.SiteAdresi;
						g.SiteBasligi = genelBilgilerDto.SiteBasligi.ToString();
						g.SiteAnahtarKelime = genelBilgilerDto.SiteAnahtarKelime;
						g.FiligramYazi = genelBilgilerDto.FiligramYazi;
						g.FiligramYaziEklensinmi = genelBilgilerDto.FiligramYaziEklensinmi;

						if (genelBilgilerDto.SiteLogorsm is not null)
						{

							UploadSuccessDto rlogo = await FileBaseUpload.HizliUpload(genelBilgilerDto.SiteLogorsm);

							g.SiteLogo = rlogo.Url;
						}
						// if (genelBilgilerDto.SiteFavicon is not null)
						//{

						//   ResimVeriDto rFav = FileBaseUpload.Upload2(genelBilgilerDto.SiteFaviconrsm, $"{_webHost.WebRootPath}");

						g.SiteFavicon = "/logopng.png";
						//}
						var result = await _service.AddAsync(g);
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
				return View(genelBilgilerDto);
			}
		}

		// GET: GenelBilgilerController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: GenelBilgilerController/Edit/5
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

		// GET: GenelBilgilerController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: GenelBilgilerController/Delete/5
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
