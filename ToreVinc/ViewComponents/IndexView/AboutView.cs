using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class AboutView : ViewComponent
	{
		private readonly IService<Hakkimizda> _serviceHak;

		public AboutView(IService<Hakkimizda> serviceHak)
		{
			_serviceHak = serviceHak;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var list = await _serviceHak.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			return View(veri);
		}
	}
}
