using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class ServiceView : ViewComponent
	{
		private readonly IService<Servisler> _service;

		public ServiceView(IService<Servisler> service)
		{
			_service = service;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menus = await _service.GetAllAsycn();
			var aktifmenu = menus.Where(x => x.Durum == true
			).OrderBy(x => x.Id).ToList();


			return View(aktifmenu);
		}
	}
}
