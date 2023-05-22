using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class SlideView : ViewComponent
	{
		private readonly IService<SlideModel> _serviceSilde;

		public SlideView(IService<SlideModel> serviceSilde)
		{
			_serviceSilde = serviceSilde;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var slide = await _serviceSilde.GetAllAsycn();
			var slideAktif = slide.Where(x => x.Durum == true && x.BitisTarihi > DateTime.Now).ToList();


			return View(slideAktif);
		}
	}
}
