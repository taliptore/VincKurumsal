using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.AdminView
{
	public class AdminNavbar : ViewComponent
	{
		private readonly IService<Menu> _serviceMenu;

		public AdminNavbar(IService<Menu> serviceMenu)
		{
			_serviceMenu = serviceMenu;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menus = await _serviceMenu.GetAllIncluding(x => x.AltMenus);
			var aktifmenu = menus.Where(x => x.Durum == true && x.AdminMenusuMu == true)
			   .OrderBy(x => x.MenuSirasi).ToList();
			//var menus = _serviceMenu.GetAllAsycn().Result;
			//var aktifmenu = menus.Where(x => x.MenuDurum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			return View(aktifmenu);
		}
	}
}
