using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class SurecView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			//var menus = _serviceMenu.GetAllAsycn().Result;
			//var aktifmenu = menus.Where(x => x.MenuDurum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			return View();
		}
	}
}
