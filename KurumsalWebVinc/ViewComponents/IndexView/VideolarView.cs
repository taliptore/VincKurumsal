using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class VideolarView : ViewComponent
	{
		private readonly IService<Videolar> _service;

		public VideolarView(IService<Videolar> service)
		{
			_service = service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			var list = await _service.GetAllAsycn();
			var veri = list.OrderByDescending(x => x.CreateDate).ToList();
			return View(veri);
		}
	}
}
