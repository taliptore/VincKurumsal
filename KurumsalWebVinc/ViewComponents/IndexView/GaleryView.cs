using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{

	public class GaleryView : ViewComponent
	{
		private readonly IService<Resimler> _service;

		public GaleryView(IService<Resimler> service)
		{
			_service = service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			var list = await _service.GetAllAsycn();
			var veri = list.OrderByDescending(x => x.CreateDate).Take(8).ToList();
			return View(veri);
		}
	}
}
