using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.AdminView
{
	public class AdminPageBaslik : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			//var menus = _serviceMenu.GetAllAsycn().Result;
			//var aktifmenu = menus.Where(x => x.MenuDurum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			return View();
		}
	}
}
