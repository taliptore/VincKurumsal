using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Models.ModelArac;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Halper;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AracBilgisisController : BaseController
	{
		protected readonly IService<AracBilgisi> _serviceArac;
		protected readonly IService<AracDurum> _AracDurums;
		protected readonly IService<AracMarka> _AracMarkas;
		protected readonly IService<AracModel> _AracModels;
		protected readonly IService<AracRenk> _AracRenks;
		protected readonly IService<KasaTipi> _KasaTipis;
		protected readonly IService<Kimden> _Kimdens;
		protected readonly IService<AracDurum> _serviceADurum;
		protected readonly IService<SehirilBilgisi> _SehirilBilgisis;
		protected readonly IService<SehirilceBilgisi> _SehirilceBilgisis;
		protected readonly IService<VitesTip> _VitesTips;
		protected readonly IService<AracResim> _AracResim;
		protected readonly IService<YakitTipi> _YakitTipis;
		protected readonly IService<AracRapor> _AracRapor;
		protected readonly IService<GenelBilgiler> _GB;
		protected readonly IEmailService _mailyolla;
		public AracBilgisisController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager = null, IMapper mapper = null, IService<AracBilgisi> serviceArac = null, IService<AracDurum> aracDurums = null, IService<AracMarka> aracMarkas = null, IService<AracModel> aracModels = null,
			IService<AracRenk> aracRenks = null, IService<KasaTipi> kasaTipis = null,
			IService<Kimden> kimdens = null, IService<AracDurum> serviceADurum = null, IService<SehirilBilgisi> sehirilBilgisis = null, IService<SehirilceBilgisi> sehirilceBilgisis = null, IService<VitesTip> vitesTips = null, IService<YakitTipi> yakitTipis = null, IService<AracResim> aracResim = null, IService<AracRapor> aracRapor = null, IService<GenelBilgiler> gB = null, IEmailService mailyolla = null)
			: base(userManager, signInManager, roleManager, mapper)
		{
			_serviceArac = serviceArac;
			_AracDurums = aracDurums;
			_AracMarkas = aracMarkas;
			_AracModels = aracModels;
			_AracRenks = aracRenks;
			_KasaTipis = kasaTipis;
			_Kimdens = kimdens;

			_serviceADurum = serviceADurum;
			_SehirilBilgisis = sehirilBilgisis;
			_SehirilceBilgisis = sehirilceBilgisis;
			_VitesTips = vitesTips;
			_YakitTipis = yakitTipis;
			_AracResim = aracResim;
			_AracRapor = aracRapor;
			_GB = gB;
			_mailyolla = mailyolla;
		}


		// GET: AracBilgisis

		public List<SelectListItem> Yillar()
		{
			var selectList = new List<SelectListItem>();
			for (int i = 1970; i <= DateTime.Now.Year; i++)
			{
				selectList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
			}
			return selectList.OrderByDescending(x => x.Text).ToList();
		}
		public void ComboDoldur()
		{
			ViewData["Yil"] = new SelectList(Yillar(), "Value", "Text");
			ViewData["AracDurumId"] = new SelectList(_AracDurums.GetAllAsycn().Result.ToList(), "Id", "AracinDurum");
			ViewData["AracMarkaId"] = new SelectList(_AracMarkas.GetAllAsycn().Result.OrderBy(x => x.MarkaAdi).ToList(), "MarkaKodu", "MarkaAdi");
			ViewData["AracModelId"] = new SelectList(_AracModels.GetAllAsycn().Result.Where(x => x.AracMarkaKodu == 3).OrderBy(x => x.ModelAdi).ToList(), "ModelKodu", "ModelAdi");
			ViewData["AracRenkId"] = new SelectList(_AracRenks.GetAllAsycn().Result.ToList(), "Id", "Renk");
			ViewData["KasaTipiId"] = new SelectList(_KasaTipis.GetAllAsycn().Result.ToList(), "Id", "KasaTip");
			ViewData["KimdenId"] = new SelectList(_Kimdens.GetAllAsycn().Result.ToList(), "Id", "Tur");
			//ViewData["MotorGucuId"] = new SelectList(_MotorGucus.GetAllAsycn().Result.ToList(), "Id", "HP");
			ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi");
			ViewData["SehirilceBilgisiId"] = new SelectList(_SehirilceBilgisis.GetAllAsycn().Result.ToList(), "ilceKodu", "ilceAdi");
			ViewData["VitesTipId"] = new SelectList(_VitesTips.GetAllAsycn().Result.ToList(), "Id", "VitesTipi");
			ViewData["YakitTipiId"] = new SelectList(_YakitTipis.GetAllAsycn().Result.ToList(), "Id", "YakitTip");
		}
		public void ComboDoldurSelect(AracBilgisi aracBilgisi)
		{
			ViewData["Yil"] = new SelectList(Yillar(), "Value", "Text", aracBilgisi.Yil);
			ViewData["AracDurumId"] = new SelectList(_AracDurums.GetAllAsycn().Result.ToList(), "Id", "AracinDurum", aracBilgisi.AracDurumId);
			ViewData["AracMarkaId"] = new SelectList(_AracMarkas.GetAllAsycn().Result.OrderBy(x => x.MarkaAdi).ToList(), "MarkaKodu", "MarkaAdi", aracBilgisi.AracMarkaKOD);
			ViewData["AracModelId"] = new SelectList(_AracModels.GetAllAsycn().Result.Where(x => x.AracMarkaKodu == aracBilgisi.AracMarkaKOD).OrderBy(x => x.ModelAdi).ToList(), "ModelKodu", "ModelAdi", aracBilgisi.AracModelKOD);
			ViewData["AracRenkId"] = new SelectList(_AracRenks.GetAllAsycn().Result.ToList(), "Id", "Renk", aracBilgisi.AracRenkId);
			ViewData["KasaTipiId"] = new SelectList(_KasaTipis.GetAllAsycn().Result.ToList(), "Id", "KasaTip", aracBilgisi.KasaTipiId);
			ViewData["KimdenId"] = new SelectList(_Kimdens.GetAllAsycn().Result.ToList(), "Id", "Tur", aracBilgisi.KasaTipiId);

			ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi", aracBilgisi.SehirilBilgisiId);
			ViewData["SehirilceBilgisiId"] = new SelectList(_SehirilceBilgisis.GetAllAsycn().Result.ToList(), "ilceKodu", "ilceAdi", aracBilgisi.SehirilceBilgisiId);
			ViewData["VitesTipId"] = new SelectList(_VitesTips.GetAllAsycn().Result.ToList(), "Id", "VitesTipi", aracBilgisi.VitesTipId);
			ViewData["YakitTipiId"] = new SelectList(_YakitTipis.GetAllAsycn().Result.ToList(), "Id", "YakitTip", aracBilgisi.YakitTipiId);
		}
		public async Task<IActionResult> Index()
		{
			//TempData["UserId"]=CurrentUser.Id;
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";

			var appDbContext = await _serviceArac.GetAllIncluding(
				a => a.AracDurum,
				a => a.AracMarka,
				a => a.AracModel,
				a => a.AracRenk,
				a => a.KasaTipi,
				a => a.Kimden,
				a => a.AracResims,
				a => a.AracRapors,
				a => a.User,

				a => a.SehirilBilgisi,
				a => a.SehirilceBilgisi,
				a => a.VitesTip,
				a => a.YakitTipi);
			var veri = appDbContext.Where(x => x.IsDeleted == false);
			var biraygeceniptal = veri.Where(x => x.CreateDate.AddDays(35) > DateTime.Now)
				.OrderByDescending(x => x.CreateDate).ToList();
			return View(biraygeceniptal);
		}
		public async Task<IActionResult> Index2()
		{
			//TempData["UserId"]=CurrentUser.Id;
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";

			var appDbContext = await _serviceArac.GetAllIncluding(
				a => a.AracDurum,
				a => a.AracMarka,
				a => a.AracModel,
				a => a.AracRenk,
				a => a.KasaTipi,
				a => a.Kimden,
				a => a.AracResims,
				a => a.AracRapors,
				a => a.User,

				a => a.SehirilBilgisi,
				a => a.SehirilceBilgisi,
				a => a.VitesTip,
				a => a.YakitTipi);
			var veri = appDbContext.Where(x => x.IsDeleted == false);
			var biraygeceniptal = veri.OrderByDescending(x => x.CreateDate).Where(x => x.CreateDate.AddDays(35) > DateTime.Now).ToList();
			return View(biraygeceniptal);
		}
		// GET: AracBilgisis/Details/5
		public async Task<IActionResult> Details(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";

			var aracBilgisi = await _serviceArac.GetByIdAscy(id);
			aracBilgisi.AracResims = _AracResim.Where(x => x.AracBilgisiId == aracBilgisi.Id).ToList();

			if (aracBilgisi == null)
			{
				return NotFound();
			}

			ComboDoldurSelect(aracBilgisi);

			return View(aracBilgisi);
		}

		// GET: AracBilgisis/Create
		public IActionResult Create()
		{

			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";

			ViewData["Tel"] = CurrentUser.PhoneNumber;
			ComboDoldur();
			return View();
		}

		// POST: AracBilgisis/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AracBilgisi aracBilgisi, List<IFormFile> resim)
		{
			if (ModelState.IsValid)
			{
				SehirilBilgisi al = _SehirilBilgisis.Where(x => x.ilKod == aracBilgisi.SehirilBilgisiilKOD)
					.FirstOrDefault();
				aracBilgisi.SehirilBilgisi = al;
				aracBilgisi.SehirilBilgisiId = al.Id;

				SehirilceBilgisi alilce = _SehirilceBilgisis.
					Where(_x => _x.ilceKodu == aracBilgisi.SehirilceBilgisiilceKOD)
					.FirstOrDefault();
				aracBilgisi.SehirilceBilgisiId = alilce.Id;
				aracBilgisi.SehirilceBilgisi = alilce;

				AracMarka aracMarka = _AracMarkas.Where(x => x.MarkaKodu == aracBilgisi.AracMarkaKOD)
					.FirstOrDefault();
				aracBilgisi.AracMarkaId = aracMarka.Id;
				aracBilgisi.AracMarka = aracMarka;

				AracModel aracModel = _AracModels.Where(x => x.ModelKodu == aracBilgisi.AracModelKOD)
					.FirstOrDefault();
				aracBilgisi.AracModelId = aracModel.Id;
				aracBilgisi.AracModel = aracModel;

				aracBilgisi.UserId = CurrentUser.Id;


				var snc = await _serviceArac.AddAsync(aracBilgisi);
				TempData["Alert"] = $"Araç  Eklendi.";
				_mailyolla.Send(CurrentUser.Email, "İlan Ekleme", "Araç ilanınız Oluşturulmuştur<br>" +
					"Sisteme Girip inceleye bilirsiniz.");
				#region Resim Yükle
				var gb = await _GB.GetAllAsycn();

				if (resim is not null)
				{
					if (resim.Count > 0)
					{
						UploadSuccessDto resimyol;
						List<AracResim> ListAracResim = new List<AracResim>();
						foreach (var item in resim)
						{
							resimyol = new UploadSuccessDto();

							resimyol = await FileBaseUpload.HizliUpload(item);


							//var resimyol = await FileBaseUpload.HizliUploadWater(item," Tlptr.com");
							if (resimyol.Uploaded == 1)
							{
								string resimurl = resimyol.Url;
								#region Resim Ekle
								AracResim aracResim = new AracResim();
								aracResim.AracBilgisiId = snc.Id;
								aracResim.ResimYolu = resimurl;
								aracResim.Durum = true;
								aracResim.Id = 0;
								//aracResim.AracBilgisi = snc;
								//  await _AracResim.AddAsync(aracResim);
								ListAracResim.Add(aracResim);
								#endregion
							}
							if (resimyol.Uploaded == -1)
							{

								ModelState.AddModelError("Resim", "Resim Hatalı");
								return View(aracBilgisi);

							}
						}
						if (ListAracResim.Count > 0)
						{
							await _AracResim.AddRangeAsycn(ListAracResim);
						}



					}
				}
				#endregion

				return RedirectToAction(nameof(Index));
			}

			SehirilBilgisi al1 = _SehirilBilgisis.Where(x => x.ilKod == aracBilgisi.SehirilBilgisiilKOD)
					.FirstOrDefault();
			aracBilgisi.SehirilBilgisi = al1;
			aracBilgisi.SehirilBilgisiId = al1.Id;

			SehirilceBilgisi alilce1 = _SehirilceBilgisis.
				Where(_x => _x.ilceKodu == aracBilgisi.SehirilceBilgisiilceKOD)
				.FirstOrDefault();
			aracBilgisi.SehirilceBilgisiId = alilce1.Id;
			aracBilgisi.SehirilceBilgisi = alilce1;

			AracMarka aracMarka1 = _AracMarkas.Where(x => x.MarkaKodu == aracBilgisi.AracMarkaKOD)
				.FirstOrDefault();
			aracBilgisi.AracMarkaId = aracMarka1.Id;
			aracBilgisi.AracMarka = aracMarka1;

			AracModel aracModel1 = _AracModels.Where(x => x.ModelKodu == aracBilgisi.AracModelKOD)
				.FirstOrDefault();
			aracBilgisi.AracModelId = aracModel1.Id;
			aracBilgisi.AracModel = aracModel1;

			ViewData["Tel"] = CurrentUser.PhoneNumber;
			ComboDoldur();

			return View(aracBilgisi);
		}

		// GET: AracBilgisis/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";

			var aracBilgisi = await _serviceArac.GetByIdAscy(id);
			aracBilgisi.AracResims = _AracResim.Where(x => x.AracBilgisiId == aracBilgisi.Id).ToList();
			if (aracBilgisi == null)
			{
				return NotFound();
			}




			ComboDoldurSelect(aracBilgisi);

			return View(aracBilgisi);
		}

		// POST: AracBilgisis/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, AracBilgisi aracBilgisi, List<IFormFile> resim)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";
			if (id != aracBilgisi.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{

					SehirilBilgisi al1 = _SehirilBilgisis.Where(x => x.ilKod == aracBilgisi.SehirilBilgisiilKOD)
					.FirstOrDefault();
					aracBilgisi.SehirilBilgisi = al1;
					aracBilgisi.SehirilBilgisiId = al1.Id;

					SehirilceBilgisi alilce1 = _SehirilceBilgisis.
						Where(_x => _x.ilceKodu == aracBilgisi.SehirilceBilgisiilceKOD)
						.FirstOrDefault();
					aracBilgisi.SehirilceBilgisiId = alilce1.Id;
					aracBilgisi.SehirilceBilgisi = alilce1;

					AracMarka aracMarka1 = _AracMarkas.Where(x => x.MarkaKodu == aracBilgisi.AracMarkaKOD)
						.FirstOrDefault();
					aracBilgisi.AracMarkaId = aracMarka1.Id;
					aracBilgisi.AracMarka = aracMarka1;

					AracModel aracModel1 = _AracModels.Where(x => x.ModelKodu == aracBilgisi.AracModelKOD)
						.FirstOrDefault();
					aracBilgisi.AracModelId = aracModel1.Id;
					aracBilgisi.AracModel = aracModel1;


					await _serviceArac.UpdateAsync(aracBilgisi);
					TempData["Alert"] = $"Araç  Güncellendi.";
					#region Resim Yükle
					if (resim is not null)
					{
						if (resim.Count > 0)
						{
							var gb = await _GB.GetAllAsycn();

							UploadSuccessDto resimyol;
							List<AracResim> ListAracResim = new List<AracResim>();
							foreach (var item in resim)
							{

								resimyol = await FileBaseUpload.HizliUpload(item);



								if (resimyol.Uploaded == 1)
								{
									string resimurl = resimyol.Url;
									#region Resim Ekle
									AracResim aracResim = new AracResim();
									aracResim.AracBilgisiId = id;
									aracResim.ResimYolu = resimurl;
									aracResim.Durum = true;
									aracResim.Id = 0;
									//aracResim.AracBilgisi = snc;
									//  await _AracResim.AddAsync(aracResim);
									ListAracResim.Add(aracResim);
									#endregion
								}
								if (resimyol.Uploaded == -1)
								{

									ModelState.AddModelError("Resim", "Resim Hatalı");
									TempData["Alert"] = $"{resimyol.Mesaj}";
									ComboDoldurSelect(aracBilgisi);
									return View(aracBilgisi);

								}
							}
							if (ListAracResim.Count > 0)
							{
								await _AracResim.AddRangeAsycn(ListAracResim);
							}



						}
					}
					#endregion
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AracBilgisiExists(aracBilgisi.Id))
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
			ComboDoldurSelect(aracBilgisi);
			return View(aracBilgisi);
		}

		// GET: AracBilgisis/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";

			var aracBilgisi = await _serviceArac.GetByIdAscy(id);
			aracBilgisi.AracResims = _AracResim.Where(x => x.AracBilgisiId == aracBilgisi.Id).ToList();

			ComboDoldurSelect(aracBilgisi);
			if (aracBilgisi == null)
			{
				return NotFound();
			}

			return View(aracBilgisi);
		}

		// POST: AracBilgisis/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";
			var aracBilgisi = await _serviceArac.GetByIdAscy(id);
			var aracresm = _AracResim.Where(x => x.AracBilgisiId == id);
			if (aracBilgisi != null)
			{
				await _serviceArac.RomeveAsync(aracBilgisi);
			}
			if (aracresm != null)
			{
				await _AracResim.RomeveRangeAsync(aracresm);
			}


			return RedirectToAction(nameof(Index));
		}

		private bool AracBilgisiExists(int id)
		{

			return _serviceArac.AnyAsync(x => x.Id == id).Result;
		}
		[HttpPost]
		public JsonResult AracModelGetir(int id)
		{
			var modelsecim = _AracModels.Where(x => x.AracMarkaKodu == id).ToList();
			//var modelsecim = model.Where(x => x.AracMarkaKodu == id).ToList();
			List<SelectListItem> veri = (from x in modelsecim.ToList()
										 select new SelectListItem
										 { Text = x.ModelAdi, Value = x.ModelKodu.ToString() }).ToList();
			return Json(veri);
		}

		[HttpPost]
		public JsonResult ilcegetirGetir(int id)
		{
			//var ilceler = await _SehirilceBilgisis.GetAllAsycn();
			var ilcesec = _SehirilceBilgisis.Where(x => x.ilKod == id).ToList();
			List<SelectListItem> veri = (from x in ilcesec.ToList()
										 select new SelectListItem
										 { Text = x.ilceAdi, Value = x.ilceKodu.ToString() }).ToList();
			return Json(veri);
		}
		[HttpPost]
		public async Task<JsonResult> aracresimsil(int id)
		{
			var al = await _AracResim.GetByIdAscy(id);
			var userbilgi = await _serviceArac.GetByIdAscy(al.AracBilgisiId);
			//if (CurrentUser.Id!=userbilgi.UserId)
			//{
			//    return Json(-1);
			//}
			if (al is null)
			{
				return Json(0);
			}
			await _AracResim.RomeveAsync(al);
			return Json(1);
		}
		public IActionResult RaporEkleDuzenle(int id)
		{

			var rapor = _AracRapor.Where(x => x.AracBilgisiId == id).FirstOrDefault();
			if (rapor is null)
			{
				AracRapor rr = new AracRapor();
				rr.AracBilgisiId = id;
				rr.RaporVerilisTarihi = DateTime.Now;
				rr.Durum = true;
				return View(rr);
			}
			return View(rapor);
		}
		[HttpPost]
		public async Task<IActionResult> RaporEkleDuzenle(AracRapor rapor, IFormFile pdffile)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracBilgisis";
			if (ModelState.IsValid)
			{
				if (pdffile is not null)
				{
					if (pdffile.Length > 0) // 15 magabaytı geçemez
					{

						var resim = await FileBaseUpload.HizliUploadPdf(pdffile);
						if (resim.Uploaded == 1)
						{
							rapor.RaporYolu = resim.Url;
						}
						if (resim.Uploaded == -1)
						{

							ModelState.AddModelError("Rapor", "Pdf Dosyası Hatalı. Pdf boyutu 15 MB geçmemeli.");
							return View(rapor);

						}
					}
				}

				await _AracRapor.AddAsync(rapor);
			}

			TempData["Alert"] = $"Araç  Güncellendi.";
			return RedirectToAction(nameof(Index));
			//return View(rapor);
		}

		[HttpPost]
		public async Task<JsonResult> DurumDegis(int id, bool durum)
		{
			int sonuc = 0;
			var service = await _serviceArac.GetByIdAscy(id);
			if (service != null)
			{
				service.Durum = !service.Durum;
				await _serviceArac.UpdateAsync(service);
				sonuc = service.Durum == true ? 1 : 0;
			}

			return Json(sonuc);
		}
	}
}
