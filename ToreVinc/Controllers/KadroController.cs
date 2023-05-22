using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class KadroController : BaseController
	{
		private readonly IService<Kadromuz> _srvcKadro;
		private readonly IService<Icerik> _srvcIcerik;


		public KadroController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Kadromuz> srvcKadro, IService<Icerik> srvcIcerik)
	   : base(userManager, signInManager, roleManager, mapper)
		{
			_srvcKadro = srvcKadro;
			_srvcIcerik = srvcIcerik;

		}

		// GET: KadroController
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "Kadro";
			ViewBag.SayfaAdi = "Liste";
			var list = await _srvcKadro.GetAllAsycn();
			//TempData["Alert"] = $"Toplam {list.Count()} kayıt listelendi.";
			return View(list.ToList());
		}

		// GET: KadroController/Details/5
		public ActionResult Details(int id)
		{
			TempData["Menu"] = "Kadro";
			return View();
		}

		// GET: KadroController/Create
		public ActionResult Create()
		{
			TempData["Menu"] = "Kadro";
			return View();
		}

		// POST: KadroController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(KadromuzDto kadromuz)
		{
			TempData["Menu"] = "Kadro";
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{

					if (kadromuz.ResimFile is not null)
					{
						if (kadromuz.ResimFile.Length > 0)
						{

							var resim = await FileBaseUpload.HizliUpload(kadromuz.ResimFile);
							if (resim.Uploaded == 1)
							{
								kadromuz.Resim = resim.Url;
							}
							if (resim.Uploaded == -1)
							{

								ModelState.AddModelError("Resim", "Resim Hatalı");
								return View(kadromuz);

							}
						}
					}

					try
					{

						#region Servise Ait Page Oluşturma 
						Icerik icerik = new Icerik()
						{
							Baslik = kadromuz.Isim,
							KisaYazi = kadromuz.Aciklama,
							Durum = true,
							Etiket = kadromuz.Isim,
							Id = 0,
							KucukResim = kadromuz.Resim,
							Metin = kadromuz.Aciklama,
							SeoAciklama = "",
							SeoBaslik = "",
							Url = "",
							Yazar = "",
							SayfaMi = true


						};


						var model = _mapper.Map<Kadromuz>(kadromuz);

						var resultic = await _srvcIcerik.AddAsync(icerik);
						int icerikid = resultic.Id;
						#endregion
						model.SayfaUrl = "Home/SayfaGetir/" + icerikid;
						model.SayfaId = icerikid;

						var result = await _srvcKadro.AddAsync(model);
						var snc = result;

						TempData["Alert"] = $"Kayıt Yapıldı.";

					}
					catch (Exception ex)
					{
						var message = ex.Message;
					}




				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						return View(kadromuz);
					}
				}
				@TempData["Alert"] = "Kayıt Eklendi.";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(kadromuz);
			}
		}

		// GET: KadroController/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["Menu"] = "Kadro";
			var knt = await _srvcKadro.GetByIdAscy(id);
			var dto = _mapper.Map<KadromuzDto>(knt);

			if (knt == null)
			{
				return NotFound();
			}

			return View(dto);
		}

		// POST: KadroController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, KadromuzDto kadromuz)
		{

			TempData["Menu"] = "Kadro";
			if (ModelState.IsValid)
			{
				var knt = await _srvcKadro.GetByIdAscy(id);
				if (knt.Id != kadromuz.Id)
				{
					TempData["Alert"] = $"Id ler eşleşmiyor";
					return RedirectToAction(nameof(Index));
				}


				try
				{
					if (kadromuz.ResimFile is not null)
					{
						if (kadromuz.ResimFile.Length > 0)
						{

							var resim = await FileBaseUpload.HizliUpload(kadromuz.ResimFile);
							if (resim.Uploaded == 1)
							{
								kadromuz.Resim = resim.Url;
							}
							if (resim.Uploaded == -1)
							{

								ModelState.AddModelError("Resim", "Resim Hatalı");
								return View(kadromuz);

							}
						}
					}
					var sayfacek = await _srvcIcerik.GetByIdAscy(kadromuz.SayfaId);
					if (sayfacek is not null)
					{

						sayfacek.Baslik = kadromuz.Isim;
						sayfacek.KisaYazi = kadromuz.Aciklama;
						sayfacek.Durum = true;
						sayfacek.Etiket = kadromuz.Isim;

						sayfacek.KucukResim = kadromuz.Resim;
						sayfacek.Metin = kadromuz.Aciklama;
						sayfacek.SayfaMi = true;




						await _srvcIcerik.UpdateAsync(sayfacek);

					}

					// knt= _mapper.Map<Kadromuz>(kadromuz);
					knt.Aciklama = kadromuz.Aciklama;
					knt.Uzmanlik = kadromuz.Uzmanlik;
					knt.Durum = kadromuz.Durum;
					knt.Resim = kadromuz.Resim;
					knt.Facebok = kadromuz.Facebok;
					knt.Google = kadromuz.Google;
					knt.Isim = kadromuz.Isim;
					knt.Instagram = kadromuz.Instagram;
					knt.Twiter = kadromuz.Twiter;
					knt.Mail = kadromuz.Mail;
					//knt.SayfaId = kadromuz.SayfaId;



					await _srvcKadro.UpdateAsync(knt);

				}
				catch
				{

				}
				TempData["Alert"] = $"Kayıt Güncellendi";
				return RedirectToAction(nameof(Index));
			}
			return View(kadromuz);
		}

		// GET: KadroController/Delete/5
		public ActionResult Delete(int id)
		{
			TempData["Menu"] = "Kadro";
			return View();
		}

		// POST: KadroController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			TempData["Menu"] = "Kadro";
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
