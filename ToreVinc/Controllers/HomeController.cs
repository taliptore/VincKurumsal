using AutoMapper;
using KurumsalWebVinc.Halper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Models.ModelArac;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Globalization;

namespace KurumsalWebVinc.Controllers
{
	public class HomeController : HomeBaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IService<GenelBilgiler> _serviceGB;
		private readonly IService<Hakkimizda> _serviceHak;
		private readonly IService<Vizyon> _serviceVizyon;
		private readonly IService<Icerik> _srvcIcerik;
		private readonly IService<IletisimBilgisi> _srvcIletisim;
		private readonly IService<SSS> _srvcSSS;
		private readonly IService<Kadromuz> _srvcKadro;
		private readonly IService<Blog> _srvcBlog;
		private readonly IService<BlogKategory> _srvcBlogKat;
		private readonly IService<Videolar> _srvcVideo;
		private readonly IService<Resimler> _srvcRes;
		private readonly IService<TalepFormu> _srvcTlp;
		private readonly IService<Servisler> _srvcServis;

		protected readonly IEmailService _mailyolla;



		private readonly IService<AracBilgisi> _srvcArac;
		protected readonly IService<AracDurum> _AracDurums;
		protected readonly IService<AracMarka> _AracMarkas;
		protected readonly IService<AracModel> _AracModels;
		protected readonly IService<AracRenk> _AracRenks;
		protected readonly IService<KasaTipi> _KasaTipis;
		protected readonly IService<Kimden> _Kimdens;

		protected readonly IService<SehirilBilgisi> _SehirilBilgisis;
		protected readonly IService<SehirilceBilgisi> _SehirilceBilgisis;
		protected readonly IService<VitesTip> _VitesTips;
		protected readonly IService<AracResim> _AracResim;
		protected readonly IService<YakitTipi> _YakitTipis;
		protected readonly IService<AracRapor> _AracRapor;
		protected readonly IService<ServisTalep> _HizmetTalep;
		protected readonly UserManager<AppUser> _userManager;

		public HomeController(ILogger<HomeController> logger, IService<GenelBilgiler> serviceGB,
			IService<Hakkimizda> serviceHak, IService<Vizyon> serviceVizyon,
			IService<Icerik> srvcIcerik, IService<IletisimBilgisi> srvcIletisim,
			IService<SSS> srvcSSS, IService<Kadromuz> srvcKadro, IService<Blog> srvcBlog,
			IService<Videolar> srvcVideo, IService<Resimler> srvcRes, IService<BlogKategory> srvcBlogKat,
			IService<TalepFormu> srvcTlp, IService<AracBilgisi> srvcArac, IService<AracDurum> aracDurums,
			IService<AracMarka> aracMarkas, IService<AracModel> aracModels, IService<AracRenk> aracRenks, IService<KasaTipi>
			kasaTipis, IService<Kimden> kimdens, IService<AracDurum> aracDurum, IService<SehirilBilgisi> sehirilBilgisis,
			IService<SehirilceBilgisi> sehirilceBilgisis, IService<VitesTip> vitesTips, IService<AracResim> aracResim,
			IService<YakitTipi> yakitTipis, UserManager<AppUser> userManager, IService<Servisler> srvcServis,
			IService<AracRapor> aracRapor, IService<ServisTalep> hizmetTalep,
			 SignInManager<AppUser> signInManager,
			RoleManager<AppRole> roleManager = null, IMapper mapper = null, IEmailService mailyolla = null) : base(userManager, signInManager, roleManager, mapper)
		{
			_logger = logger;
			_serviceGB = serviceGB;
			_serviceHak = serviceHak;
			_serviceVizyon = serviceVizyon;
			_srvcIcerik = srvcIcerik;
			_srvcIletisim = srvcIletisim;
			_srvcSSS = srvcSSS;
			_srvcKadro = srvcKadro;
			_srvcBlog = srvcBlog;
			_srvcVideo = srvcVideo;
			_srvcRes = srvcRes;
			_srvcBlogKat = srvcBlogKat;
			_srvcTlp = srvcTlp;
			//_mapper = mapper;
			_srvcArac = srvcArac;
			_AracDurums = aracDurums;
			_AracMarkas = aracMarkas;
			_AracModels = aracModels;
			_AracRenks = aracRenks;
			_KasaTipis = kasaTipis;
			_Kimdens = kimdens;

			_SehirilBilgisis = sehirilBilgisis;
			_SehirilceBilgisis = sehirilceBilgisis;
			_VitesTips = vitesTips;
			_AracResim = aracResim;
			_YakitTipis = yakitTipis;
			_userManager = userManager;
			_srvcServis = srvcServis;
			_AracRapor = aracRapor;
			_HizmetTalep = hizmetTalep;
			_mailyolla = mailyolla;
		}



		public async Task<IActionResult> Hakkimizda()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _serviceHak.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();

			return View(veri);
		}

		public async Task<IActionResult> Hizmetler()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcServis.GetAllAsycn();
			var veri = list.Where(x => x.Durum == true).ToList();

			return View(veri);
		}
		public async Task<IActionResult> SSS()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcSSS.GetAllAsycn();
			var veri = list.ToList().Where(x => x.Durum == true);

			return View(veri.ToList());
		}
		public async Task<IActionResult> Gallery()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcRes.GetAllAsycn();
			var veri = list.ToList().Where(x => x.Durum == true);

			return View(veri.ToList());
		}
		public async Task<IActionResult> BlogSayfa()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcBlog.GetAllAsycn();
			var veri = list.ToList().Where(x => x.Durum == true);

			return View(veri.OrderByDescending(x => x.CreateDate).ToList());
		}
		public async Task<IActionResult> Videolar()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcVideo.GetAllAsycn();
			var veri = list.ToList().Where(x => x.Durum == true);

			return View(veri.OrderByDescending(x => x.CreateDate).ToList());
		}
		public async Task<IActionResult> Kadromuz()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcKadro.GetAllAsycn();
			var veri = list.ToList().Where(x => x.Durum == true);

			return View(veri.ToList());
		}
		public async Task<IActionResult> Vizyon()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _serviceVizyon.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();

			return View(veri);
		}
		public async Task<IActionResult> aracdetay(int id)
		{


			var aracBilgisi = await _srvcArac.GetByIdAscy(id);

			if (aracBilgisi == null)
			{
				return NotFound();
			}
			if (!aracBilgisi.Durum)
			{
				return NotFound();
			}
			aracBilgisi.AracRapors = _AracRapor.Where(x => x.AracBilgisiId == aracBilgisi.Id).FirstOrDefault();
			aracBilgisi.AracResims = _AracResim.Where(x => x.AracBilgisiId == aracBilgisi.Id).ToList();
			aracBilgisi.AracDurum = await _AracDurums.GetByIdAscy(aracBilgisi.AracDurumId);
			aracBilgisi.AracMarka = await _AracMarkas.GetByIdAscy(aracBilgisi.AracMarkaId);
			aracBilgisi.AracModel = await _AracModels.GetByIdAscy(aracBilgisi.AracModelId);
			aracBilgisi.AracRenk = await _AracRenks.GetByIdAscy(aracBilgisi.AracRenkId);
			aracBilgisi.KasaTipi = await _KasaTipis.GetByIdAscy(aracBilgisi.KasaTipiId);
			aracBilgisi.Kimden = await _Kimdens.GetByIdAscy(aracBilgisi.KimdenId);
			aracBilgisi.SehirilBilgisi = await _SehirilBilgisis.GetByIdAscy(aracBilgisi.SehirilBilgisiId);
			aracBilgisi.SehirilceBilgisi = await _SehirilceBilgisis.GetByIdAscy(aracBilgisi.SehirilceBilgisiId);
			aracBilgisi.VitesTip = await _VitesTips.GetByIdAscy(aracBilgisi.VitesTipId);
			aracBilgisi.YakitTipi = await _YakitTipis.GetByIdAscy(aracBilgisi.YakitTipiId);
			aracBilgisi.User = await _userManager.FindByIdAsync(aracBilgisi.UserId);
			// aracBilgisi.User = _userManager.GetUserIdAsync(aracBilgisi.UserId);




			return View(aracBilgisi);
		}
		public async Task<IActionResult> Arabalar()
		{

			var appDbContext = await _srvcArac.GetAllIncluding(
				a => a.AracDurum,
				a => a.AracMarka,
				a => a.AracModel,
				a => a.AracRenk,
				a => a.KasaTipi,
				a => a.Kimden,
				a => a.AracResims,
				a => a.SehirilBilgisi,
				a => a.SehirilceBilgisi,
				a => a.VitesTip,
				a => a.YakitTipi);
			var veri = appDbContext.Where(x => x.Durum == true && x.IsDeleted == false
			&& x.CreateDate.AddDays(35) > DateTime.Now)
				;



			ComboDoldur(veri);

			AracSearcDto d = new AracSearcDto();
			d.aracBilgisis = veri.OrderByDescending(x => x.CreateDate).ToList();
			d.MinKM = 0; d.MaxKM = 0;
			d.MaxFiyat = 0; d.MinFiyat = 0;

			return View(d);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Arabalar(AracSearcDto f)
		{

			var appDbContext = await _srvcArac.GetAllIncluding(
				a => a.AracDurum,
				a => a.AracMarka,
				a => a.AracModel,
				a => a.AracRenk,
				a => a.KasaTipi,
				a => a.Kimden,
				a => a.AracResims,
				a => a.SehirilBilgisi,
				a => a.SehirilceBilgisi,
				a => a.VitesTip,
				a => a.YakitTipi);
			var veri = appDbContext.Where(x => x.Durum == true && x.IsDeleted == false
			&& x.CreateDate.AddDays(35) > DateTime.Now
			);

			var fiyat = f.FiyatAralik.Replace(" ", "").Replace("-", "").Split("TL");
			int fiyatMin = int.Parse(fiyat[0]);
			int fiyatMax = int.Parse(fiyat[1]);

			var Kilometre = f.KmAralik.Replace(" ", "").Replace("-", "").Split("KM");
			int KmMin = int.Parse(Kilometre[0]);
			int KmMax = int.Parse(Kilometre[1]);

			var datasearc = veri;
			if (!(f.Arama is null && f.AracMarkaId == -1 && f.AracModelId == -1 && f.AracRenkId == -1
				&& f.VitesTipId == -1
				&& f.SehirilBilgisiId == -1 && f.SehirilceBilgisiId == 0 && f.YakitTipiId == -1))
			{


				if (f.Arama is not null)
				{
					datasearc = veri.Where(
							x => x.AracMarka.MarkaKodu == (f.AracMarkaId == -1 ? x.AracMarka.MarkaKodu : f.AracMarkaId)
							&& x.AracModel.ModelKodu == (f.AracModelId == -1 ? x.AracModel.ModelKodu : f.AracDurumId)
							&& x.AracDurum.Id == (f.AracDurumId == -1 ? x.AracDurum.Id : f.AracModelId)
							&& x.SehirilBilgisi.ilKod == (f.SehirilBilgisiId == -1 ? x.SehirilBilgisi.ilKod : f.SehirilBilgisiId)
							&& x.SehirilceBilgisi.ilceKodu == (f.SehirilceBilgisiId == -1 ? x.SehirilceBilgisi.ilceKodu : f.SehirilceBilgisiId)
							&& x.AracRenk.Id == (f.AracRenkId == -1 ? x.AracRenk.Id : f.AracRenkId)
							&& x.KasaTipi.Id == (f.KasaTipiId == -1 ? x.KasaTipi.Id : f.KasaTipiId)
							&& x.Kimden.Id == (f.KimdenId == -1 ? x.Kimden.Id : f.KimdenId)
							&& x.YakitTipi.Id == (f.YakitTipiId == -1 ? x.YakitTipi.Id : f.YakitTipiId)
							&& x.VitesTip.Id == (f.VitesTipId == -1 ? x.VitesTip.Id : f.VitesTipId)
							&& x.Fiyat >= (fiyatMin == 100000 ? x.Fiyat : fiyatMin) &&
							x.Fiyat <= (fiyatMax == 5000000 ? x.Fiyat : fiyatMax)
							&& x.KM >= (KmMin == 0 ? x.KM : KmMin) &&
							x.KM <= (KmMax == 750000 ? x.KM : KmMax)

							&& (x.Baslik.ToLowerInvariant().Contains(f.Arama.ToLowerInvariant())
							|| x.Aciklama.ToLowerInvariant().Contains(f.Arama.ToLowerInvariant()))
							|| x.AracModel.ModelAdi.ToLowerInvariant().Contains(f.Arama.ToLowerInvariant())
							|| x.AracMarka.MarkaAdi.ToLowerInvariant().Contains(f.Arama.ToLowerInvariant())



							)
						;
				}
				else
				{
					datasearc = veri.Where(
										   x => x.AracMarka.MarkaKodu == (f.AracMarkaId == -1 ? x.AracMarka.MarkaKodu : f.AracMarkaId)
											 && x.AracDurum.Id == (f.AracDurumId == -1 ? x.AracDurum.Id : f.AracDurumId)
										   && x.AracModel.ModelKodu == (f.AracModelId == -1 ? x.AracModel.ModelKodu : f.AracModelId)
										   && x.SehirilBilgisi.ilKod == (f.SehirilBilgisiId == -1 ? x.SehirilBilgisi.ilKod : f.SehirilBilgisiId)
										   && x.SehirilceBilgisi.ilceKodu == (f.SehirilceBilgisiId == -1 ? x.SehirilceBilgisi.ilceKodu : f.SehirilceBilgisiId)
										   && x.AracRenk.Id == (f.AracRenkId == -1 ? x.AracRenk.Id : f.AracRenkId)
										   && x.KasaTipi.Id == (f.KasaTipiId == -1 ? x.KasaTipi.Id : f.KasaTipiId)
										   && x.Kimden.Id == (f.KimdenId == -1 ? x.Kimden.Id : f.KimdenId)
										   && x.YakitTipi.Id == (f.YakitTipiId == -1 ? x.YakitTipi.Id : f.YakitTipiId)
										   && x.VitesTip.Id == (f.VitesTipId == -1 ? x.VitesTip.Id : f.VitesTipId)
										   && x.Fiyat >= (fiyatMin == 100000 ? x.Fiyat : fiyatMin) &&
												x.Fiyat <= (fiyatMax == 5000000 ? x.Fiyat : fiyatMax)
												&& x.KM >= (KmMin == 0 ? x.KM : KmMin) &&
												x.KM <= (KmMax == 750000 ? x.KM : KmMax)


									   );
				}
			}



			//< option value = "1" > İlan Tarihine Göre</ option >
			//< option value = "2" > Fiyatı Küçükten Büyüğe</ option >
			//< option value = "3" > KiloMetresi Küçükten Büyüğe </ option >

			AracSearcDto d = new AracSearcDto();
			if (f.ListemeId == 1)
			{
				d.aracBilgisis = datasearc.OrderByDescending(x => x.CreateDate).ToList();
			}
			else if (f.ListemeId == 2)
			{
				d.aracBilgisis = datasearc.OrderBy(x => x.Fiyat).ToList();
			}
			else if (f.ListemeId == 3)
			{
				d.aracBilgisis = datasearc.OrderBy(x => x.KM).ToList();
			}
			else if (f.ListemeId == 4)
			{
				d.aracBilgisis = datasearc.OrderByDescending(x => x.Fiyat).ToList();
			}
			else
			{
				d.aracBilgisis = datasearc.OrderByDescending(x => x.CreateDate).ToList();
			}
			d.ListemeId = f.ListemeId;
			d.MinKM = f.MinKM; d.MaxKM = f.MaxKM;
			d.MaxFiyat = f.MaxFiyat; d.MinFiyat = f.MinFiyat;
			ComboDoldur(veri);


			return View(d);
		}
		public List<SelectListItem> Yillar()
		{
			var selectList = new List<SelectListItem>();
			for (int i = 1970; i <= DateTime.Now.Year; i++)
			{
				selectList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
			}
			return selectList.OrderByDescending(x => x.Text).ToList();
		}
		public void ComboDoldur(IEnumerable<AracBilgisi> veri)
		{
			#region Marka
			var groupMarka = from v in veri.OrderBy(x => x.AracMarka.MarkaAdi)
							 group v.AracMarka by v.AracMarka.MarkaKodu into g
							 select new { markakey = g.Key, markalar = g };

			var MarkaList = new List<SelectListItem>();
			foreach (var item in groupMarka)
			{
				var v = item.markalar.FirstOrDefault();
				MarkaList.Add(new SelectListItem { Text = v.MarkaAdi.ToString() + " (" + item.markalar.Count() + ")", Value = v.MarkaKodu.ToString() });
			}
			ViewData["AracMarkaId"] = new SelectList(MarkaList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region Model
			var groupModel = from v in veri.Where(x => x.AracMarkaKOD.ToString() == MarkaList[0].Value).ToList()
							 group v.AracModel by v.AracModel.ModelKodu into g
							 select new { modelKey = g.Key, modeller = g };

			var ModelList = new List<SelectListItem>();
			foreach (var item in groupModel)
			{
				var v = item.modeller.FirstOrDefault();
				ModelList.Add(new SelectListItem { Text = v.ModelAdi.ToString() + " (" + item.modeller.Count() + ")", Value = v.ModelKodu.ToString() });
			}
			ViewData["AracModelId"] = new SelectList(ModelList.OrderBy(x => x.Text).ToList(), "Value", "Text");

			#endregion
			#region Yil
			var groupYil = from v in veri.OrderByDescending(y => y.Yil)
						   group v.Yil by v.Yil into g
						   select new { modelKey = g.Key, yillar = g };
			var YilList = new List<SelectListItem>();
			foreach (var item in groupYil)
			{
				var v = item.yillar.FirstOrDefault();
				YilList.Add(new SelectListItem { Text = v.ToString() + " (" + item.yillar.Count() + ")", Value = v.ToString() });
			}
			ViewData["Yil"] = new SelectList(YilList.OrderByDescending(x => x.Text), "Value", "Text");
			#endregion

			#region Durum
			var groupDurum = from v in veri.OrderBy(x => x.AracDurum.AracinDurum)
							 group v.AracDurum by v.AracDurum.Id into g
							 select new { key = g.Key, degerler = g };

			var DurumaList = new List<SelectListItem>();
			foreach (var item in groupDurum)
			{
				var v = item.degerler.FirstOrDefault();
				DurumaList.Add(new SelectListItem { Text = v.AracinDurum.ToString() + " (" + item.degerler.Count() + ")", Value = v.Id.ToString() });
			}
			ViewData["AracDurumId"] = new SelectList(DurumaList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region Renk
			var groupRenk = from v in veri.OrderBy(x => x.AracRenk.Renk)
							group v.AracRenk by v.AracRenk.Id into g
							select new { key = g.Key, degerler = g };

			var RenkList = new List<SelectListItem>();
			foreach (var item in groupRenk)
			{
				var v = item.degerler.FirstOrDefault();
				RenkList.Add(new SelectListItem { Text = v.Renk.ToString() + " (" + item.degerler.Count() + ")", Value = v.Id.ToString() });
			}
			ViewData["AracRenkId"] = new SelectList(RenkList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region Kasa
			var groupKasa = from v in veri.OrderBy(x => x.KasaTipi.KasaTip)
							group v.KasaTipi by v.KasaTipi.Id into g
							select new { key = g.Key, degerler = g };

			var KasaList = new List<SelectListItem>();
			foreach (var item in groupKasa)
			{
				var v = item.degerler.FirstOrDefault();
				KasaList.Add(new SelectListItem { Text = v.KasaTip.ToString() + " (" + item.degerler.Count() + ")", Value = v.Id.ToString() });
			}
			ViewData["KasaTipiId"] = new SelectList(KasaList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region Kimden
			var groupKim = from v in veri.OrderBy(x => x.Kimden.Tur)
						   group v.Kimden by v.Kimden.Id into g
						   select new { key = g.Key, degerler = g };

			var KimList = new List<SelectListItem>();
			foreach (var item in groupKim)
			{
				var v = item.degerler.FirstOrDefault();
				KimList.Add(new SelectListItem { Text = v.Tur.ToString() + " (" + item.degerler.Count() + ")", Value = v.Id.ToString() });
			}
			ViewData["KimdenId"] = new SelectList(KimList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region iller
			var groupil = from v in veri.OrderBy(x => x.SehirilBilgisi.ilAdi)
						  group v.SehirilBilgisi by v.SehirilBilgisi.ilKod into g
						  select new { key = g.Key, degerler = g };

			var ilList = new List<SelectListItem>();
			foreach (var item in groupil)
			{
				var v = item.degerler.FirstOrDefault();
				ilList.Add(new SelectListItem { Text = v.ilAdi.ToString() + " (" + item.degerler.Count() + ")", Value = v.ilKod.ToString() });
			}
			ViewData["SehirilBilgisiId"] = new SelectList(ilList.OrderBy(x => x.Text), "Value", "Text");

			#endregion
			#region ilçeler
			var groupilce = from v in veri.OrderBy(x => x.SehirilceBilgisi.ilceAdi)
							group v.SehirilceBilgisi by v.SehirilceBilgisi.ilceKodu into g
							select new { key = g.Key, degerler = g };

			var ilceList = new List<SelectListItem>();
			foreach (var item in groupilce)
			{
				var v = item.degerler.FirstOrDefault();
				ilceList.Add(new SelectListItem { Text = v.ilceAdi.ToString() + " (" + item.degerler.Count() + ")", Value = v.ilceAdi.ToString() });
			}
			ViewData["SehirilceBilgisiId"] = new SelectList(ilceList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region VitesTip
			var groupVites = from v in veri.OrderBy(x => x.VitesTip.VitesTipi)
							 group v.VitesTip by v.VitesTip.Id into g
							 select new { key = g.Key, degerler = g };

			var VitesList = new List<SelectListItem>();
			foreach (var item in groupVites)
			{
				var v = item.degerler.FirstOrDefault();
				VitesList.Add(new SelectListItem { Text = v.VitesTipi.ToString() + " (" + item.degerler.Count() + ")", Value = v.Id.ToString() });
			}
			ViewData["VitesTipId"] = new SelectList(VitesList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region yakittip
			var groupYakit = from v in veri.OrderBy(x => x.YakitTipi.YakitTip)
							 group v.YakitTipi by v.YakitTipi.Id into g
							 select new { key = g.Key, degerler = g };

			var YakitList = new List<SelectListItem>();
			foreach (var item in groupYakit)
			{
				var v = item.degerler.FirstOrDefault();
				YakitList.Add(new SelectListItem { Text = v.YakitTip.ToString() + " (" + item.degerler.Count() + ")", Value = v.Id.ToString() });
			}
			ViewData["YakitTipiId"] = new SelectList(YakitList.OrderBy(x => x.Text), "Value", "Text");

			#endregion

			#region Eski hali
			//ViewData["Yil"] = new SelectList(Yillar(), "Value", "Text");
			//ViewData["AracDurumId"] = new SelectList(_AracDurums.GetAllAsycn().Result.ToList(), "Id", "AracinDurum");
			// ViewData["AracMarkaId"] = new SelectList(_AracMarkas.GetAllAsycn().Result.OrderBy(x => x.MarkaAdi).ToList(), "MarkaKodu", "MarkaAdi");
			//ViewData["AracModelId"] = new SelectList(_AracModels.GetAllAsycn().Result.Where(x => x.AracMarkaKodu == 3).OrderBy(x => x.ModelAdi).ToList(), "ModelKodu", "ModelAdi");
			//ViewData["AracRenkId"] = new SelectList(_AracRenks.GetAllAsycn().Result.ToList(), "Id", "Renk");
			//ViewData["KasaTipiId"] = new SelectList(_KasaTipis.GetAllAsycn().Result.ToList(), "Id", "KasaTip");
			//ViewData["KimdenId"] = new SelectList(_Kimdens.GetAllAsycn().Result.ToList(), "Id", "Tur");
			//ViewData["MotorGucuId"] = new SelectList(_MotorGucus.GetAllAsycn().Result.ToList(), "Id", "HP");
			// ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi");
			//ViewData["SehirilceBilgisiId"] = new SelectList(_SehirilceBilgisis.GetAllAsycn().Result.ToList(), "ilceKodu", "ilceAdi");
			// ViewData["VitesTipId"] = new SelectList(_VitesTips.GetAllAsycn().Result.ToList(), "Id", "VitesTipi");
			//ViewData["YakitTipiId"] = new SelectList(_YakitTipis.GetAllAsycn().Result.ToList(), "Id", "YakitTip");
			#endregion

		}
		public async Task<IActionResult> iletisim()
		{


			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;
			Random random = new Random();


			var list = await _srvcIletisim.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			ViewBag.iletisim = veri;
			Random rnd = new Random();
			int say1 = rnd.Next(99);
			int say2 = rnd.Next(99);
			TalepFormuDto talepFormu = new TalepFormuDto();
			talepFormu.GuvenlikKoduCevap = (say1 + say2).ToString();
			ViewBag.gvSoru = $"{say1} + {say2}";

			var talepcek = await _HizmetTalep.GetAllIncluding(x => x.Servisler);
			var talepMadde = talepcek.Where(x => x.Durum == true);
			if (talepMadde.Any())
			{
				var maddeler = new List<SelectListItem>();
				foreach (var item in talepMadde.ToList())
				{

					maddeler.Add(new SelectListItem
					{
						Text = item.Servisler.ServisAdi.ToString(),
						Value = item.Id + "*" + item.BulSehirDurum + "*" + item.GidSehirDurum
					});
				}
				ViewData["TalepMadde"] = new SelectList(maddeler.OrderBy(x => x.Text), "Value", "Text");
				ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi");
			}
			//ViewBag.gvSonuc = (say1 + say1).ToString();
			return View(talepFormu);
		}
		// POST: TalepController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> iletisim(TalepFormuDto talepFormu)
		{
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
					var genelbilgidb = await _serviceGB.GetAllAsycn();
					var tekcek = genelbilgidb.FirstOrDefault();
					ViewBag.GenelBilgiler = tekcek;



					var list = await _srvcIletisim.GetAllAsycn();
					var veri = list.ToList().FirstOrDefault();
					ViewBag.iletisim = veri;
					Random rnd = new Random();
					int say1 = rnd.Next(99);
					int say2 = rnd.Next(99);

					var talepcek = await _HizmetTalep.GetAllIncluding(x => x.Servisler);
					var talepMadde = talepcek.Where(x => x.Durum == true);
					if (!talepMadde.Any())
					{
						var maddeler = new List<SelectListItem>();
						foreach (var item in talepMadde.ToList())
						{

							maddeler.Add(new SelectListItem
							{
								Text = item.Servisler.ServisAdi.ToString(),
								Value = item.Id + "@" + item.BulSehirDurum + "@" + item.GidSehirDurum
							});
						}
						ViewData["TalepMadde"] = new SelectList(maddeler.OrderBy(x => x.Text), "Value", "Text");
						ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi");
					}

					return RedirectToAction(nameof(iletisim));
				}
				if (talepFormu.GuvenlikKoduCevap != talepFormu.GuvenlikKodu)
				{
					var genelbilgidb = await _serviceGB.GetAllAsycn();
					var tekcek = genelbilgidb.FirstOrDefault();
					ViewBag.GenelBilgiler = tekcek;


					var talepcek = await _HizmetTalep.GetAllIncluding(x => x.Servisler);
					var talepMadde = talepcek.Where(x => x.Durum == true);
					if (!talepMadde.Any())
					{
						var maddeler = new List<SelectListItem>();
						foreach (var item in talepMadde.ToList())
						{

							maddeler.Add(new SelectListItem
							{
								Text = item.Servisler.ServisAdi.ToString(),
								Value = item.Id + "@" + item.BulSehirDurum + "@" + item.GidSehirDurum
							});
						}
						ViewData["TalepMadde"] = new SelectList(maddeler.OrderBy(x => x.Text), "Value", "Text");
						ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi");
					}

					var list = await _srvcIletisim.GetAllAsycn();
					var veri = list.ToList().FirstOrDefault();
					ViewBag.iletisim = veri;
					Random rnd = new Random();
					int say1 = rnd.Next(99);
					int say2 = rnd.Next(99);

					talepFormu.GuvenlikKoduCevap = (say1 + say2).ToString();
					ViewBag.gvSoru = $"{say1} + {say2}";

					ModelState.AddModelError("", "Güvenlik kodu hatalı");

					return View(talepFormu);

				}
				if (ModelState.IsValid)
				{

					var genelbilgidb = await _serviceGB.GetAllAsycn();
					var tekcek = genelbilgidb.FirstOrDefault();
					ViewBag.GenelBilgiler = tekcek;

					var list = await _srvcIletisim.GetAllAsycn();
					var veri = list.ToList().FirstOrDefault();
					ViewBag.iletisim = veri;
					Random rnd = new Random();
					int say1 = rnd.Next(99);
					int say2 = rnd.Next(99);

					talepFormu.GuvenlikKoduCevap = (say1 + say2).ToString();
					ViewBag.gvSoru = $"{say1} + {say2}";

					var model = _mapper.Map<TalepFormu>(talepFormu);

					model.ServislerId = int.Parse(talepFormu.ServislerIdKod.Split("*")[0]);




					await _srvcTlp.AddAsync(model);
					_mailyolla.Send("", "Talep Girişi Yapılıdı.",
					  "Hizmet Taleb Eden Müşteri : " + model.Ad + " " + model.Soyad + "<br>" +
					  "Talep Detayı :" + model.Mesaj + "<br>" +
					  "Talep eden Tel:" + model.iletisimNo);

					_mailyolla.Send(model.Mail.Trim().ToString(), "Hizmet Talebi",
					 "Hizmet talebiniz alındı. En kısa sürede size dönüş yapacagız.<br> İyi günler");

					//   ModelState.AddModelError("", "Talebiniz Alınmıştır. En kısa sürede sizinle irtibata geçeceğiz.");
					return RedirectToAction(nameof(iletisimSonuc));
				}
				else
				{
					var talepcek = await _HizmetTalep.GetAllIncluding(x => x.Servisler);
					var talepMadde = talepcek.Where(x => x.Durum == true);
					if (!talepMadde.Any())
					{
						var maddeler = new List<SelectListItem>();
						foreach (var item in talepMadde.ToList())
						{

							maddeler.Add(new SelectListItem
							{
								Text = item.Servisler.ServisAdi.ToString(),
								Value = item.Id + "@" + item.BulSehirDurum + "@" + item.GidSehirDurum
							});
						}
						ViewData["TalepMadde"] = new SelectList(maddeler.OrderBy(x => x.Text), "Value", "Text");
						ViewData["SehirilBilgisiId"] = new SelectList(_SehirilBilgisis.GetAllAsycn().Result.ToList(), "ilKod", "ilAdi");
					}
					var genelbilgidb = await _serviceGB.GetAllAsycn();
					var tekcek = genelbilgidb.FirstOrDefault();
					ViewBag.GenelBilgiler = tekcek;



					var list = await _srvcIletisim.GetAllAsycn();
					var veri = list.ToList().FirstOrDefault();
					ViewBag.iletisim = veri;
					Random rnd = new Random();
					int say1 = rnd.Next(99);
					int say2 = rnd.Next(99);
					talepFormu.GuvenlikKoduCevap = (say1 + say2).ToString();
					ViewBag.gvSoru = $"{say1} + {say2}";
					ModelState.AddModelError("", "Güvenlik kodu hatalı");

					return View(talepFormu);
				}

			}
			catch
			{


				return RedirectToAction(nameof(iletisim));
			}

		}
		public async Task<IActionResult> iletisimSonuc()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var list = await _srvcIletisim.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			//ViewBag.gvSonuc = (say1 + say1).ToString();
			return View();
		}
		public async Task<IActionResult> Blog(int id)
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var kat = await _srvcBlogKat.GetAllAsycn();
			var katcek = kat.Where(x => x.Durum == true).ToList();
			ViewBag.BlogKategory = katcek;

			var blog = await _srvcBlog.GetAllIncluding(x => x.BlogKategory);
			var blokkat = blog.Where(x => x.BlogKategory.Durum == true).GroupBy(x => x.BlogKategory.Adi).Select(vv => new BlogKategory { Adi = vv.Key, Id = vv.Count() }).ToList();
			ViewBag.BlogKatedetay = blokkat;

			var yeniblog = blog.Where(x => x.Durum == true).OrderByDescending(x => x.CreateDate).Take(5).ToList();
			ViewBag.sonyazi = yeniblog;


			var blokkatarsiv = blog.Where(x => x.BlogKategory.Durum == true).GroupBy(x => x.BlogKategory.CreateDate.ToString("MMM yyyy")).Select(vv => new BlogKategory { Adi = vv.Key, Id = vv.Count() }).ToList();
			ViewBag.blokkatarsiv = blokkatarsiv;

			Icerik veri = await _srvcIcerik.GetByIdAscy(id);


			return View(veri);
		}
		public async Task<IActionResult> SayfaGetir(int id)
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			Icerik veri = await _srvcIcerik.GetByIdAscy(id);


			return View(veri);
		}
		public async Task<IActionResult> Index()
		{
			var genelbilgidb = await _serviceGB.GetAllAsycn();
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;
			if (User.Identity.Name is not null)
			{
				ViewBag.CurrentUser = userManager.FindByNameAsync(User.Identity.Name).Result;

			}


			return View();
		}
		public PartialViewResult Talep()
		{

			return PartialView();
		}

		[HttpPost]
		public JsonResult AracModelGetir(int id)
		{


			var veri = _srvcArac.Where(a => a.AracMarkaKOD == id).ToList();

			var groupMarka = from v in veri.OrderBy(x => x.AracModelKOD)
							 group v.AracModelKOD by v.AracModelKOD into g
							 select new { markakey = g.Key, data = g };

			var modelList = new List<SelectListItem>();
			foreach (var item in groupMarka)
			{
				var v = item.data.FirstOrDefault();
				var modelsecim = _AracModels.Where(x => x.ModelKodu == item.markakey && x.AracMarkaKodu == id).FirstOrDefault();
				modelList.Add(new SelectListItem { Text = modelsecim.ModelAdi.ToString() + " (" + item.data.Count() + ")", Value = modelsecim.ModelKodu.ToString() });
			}

			return Json(modelList);
		}

		[HttpPost]
		public JsonResult ilcegetirGetir(int id)
		{

			var veri = _srvcArac.Where(a => a.SehirilBilgisiilKOD == id).ToList();
			var groupMarka = from v in veri.OrderBy(x => x.SehirilceBilgisiilceKOD)
							 group v.SehirilceBilgisiilceKOD by v.SehirilceBilgisiilceKOD into g
							 select new { markakey = g.Key, data = g };

			var modelList = new List<SelectListItem>();
			foreach (var item in groupMarka)
			{
				var v = item.data.FirstOrDefault();
				var modelsecim = _SehirilceBilgisis.Where(x => x.ilceKodu == item.markakey).FirstOrDefault();
				modelList.Add(new SelectListItem { Text = modelsecim.ilceAdi.ToString() + " (" + item.data.Count() + ")", Value = modelsecim.ilceKodu.ToString() });
			}

			//var ilceler = await _SehirilceBilgisis.GetAllAsycn();
			//var ilcesec = _SehirilceBilgisis.Where(x => x.ilKod == id).ToList();
			//List<SelectListItem> veri = (from x in ilcesec.ToList()
			//                             select new SelectListItem
			//                             { Text = x.ilceAdi, Value = x.ilceKodu.ToString() }).ToList();
			return Json(modelList);
		}

		[HttpPost]
		public JsonResult MesajGönder(
			string Name, string Email, string Mesaj, string Id, string UserId)
		{

			Thread.Sleep(2000); //az dur
			var veri = _srvcArac.Where(a => a.SehirilBilgisiilKOD == 1).ToList();


			//var ilceler = await _SehirilceBilgisis.GetAllAsycn();
			//var ilcesec = _SehirilceBilgisis.Where(x => x.ilKod == id).ToList();
			//List<SelectListItem> veri = (from x in ilcesec.ToList()
			//                             select new SelectListItem
			//                             { Text = x.ilceAdi, Value = x.ilceKodu.ToString() }).ToList();
			return Json(veri);
		}





		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}