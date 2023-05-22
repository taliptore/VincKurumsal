using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class BanneriletisimView : ViewComponent
	{
		private readonly IService<IletisimBilgisi> _serviceiel;
		private readonly IService<SosyalMedyaBilgileri> _srvcSos;

		public BanneriletisimView(IService<IletisimBilgisi> serviceiel, IService<SosyalMedyaBilgileri> srvcSos)
		{
			_serviceiel = serviceiel;
			_srvcSos = srvcSos;
		}
		public IViewComponentResult Invoke()
		{
			var sos = _srvcSos.GetAllAsycn().Result;
			var sostkl = sos.ToList().FirstOrDefault();
			ViewBag.SOS = sostkl;

			var list = _serviceiel.GetAllAsycn().Result;
			var veri = list.ToList().FirstOrDefault();
			return View(veri);
		}
	}
}
