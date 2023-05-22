using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class PortfolioView : ViewComponent
	{
		private readonly IService<Kadromuz> _srvcKadro;

		public PortfolioView(IService<Kadromuz> srvcKadro)
		{
			_srvcKadro = srvcKadro;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menus = await _srvcKadro.GetAllAsycn();
			var aktifmenu = menus.Where(x => x.Durum == true).OrderBy(x => x.Id).ToList();

			return View(aktifmenu);
		}
	}
}
