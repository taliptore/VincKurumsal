using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class FooterView : ViewComponent
	{
		private readonly IService<GenelBilgiler> _serviceGB;
		private readonly IService<IletisimBilgisi> _srvcIletisim;
		private readonly IService<SosyalMedyaBilgileri> _srvcSos;


		public FooterView(IService<GenelBilgiler> serviceGB, IService<IletisimBilgisi> srvcIletisim, IService<SosyalMedyaBilgileri> srvcSos)
		{
			_serviceGB = serviceGB;
			_srvcIletisim = srvcIletisim;
			_srvcSos = srvcSos;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var genelbilgidb = _serviceGB.GetAllAsycn().Result;
			var tekcek = genelbilgidb.FirstOrDefault();
			ViewBag.GenelBilgiler = tekcek;

			var sos = _srvcSos.GetAllAsycn().Result;
			var sostkl = sos.ToList().FirstOrDefault();
			ViewBag.SOS = sostkl;
			var list = await _srvcIletisim.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();

			return View(veri);
		}
	}
}
