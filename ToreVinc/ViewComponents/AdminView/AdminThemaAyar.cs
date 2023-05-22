using KurumsalWebVinc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.AdminView
{
	public class AdminThemaAyar : ViewComponent
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<AppUser> userManager;
		public AdminThemaAyar(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
		{
			_httpContextAccessor = httpContextAccessor;
			this.userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var username = _httpContextAccessor.HttpContext.User.Identity.Name;
			AppUser appUser = await userManager.FindByNameAsync(username);

			TempData["UserName"] = username;
			TempData["UserId"] = appUser.Id;
			if (TempData["Userimg"] is null)
			{
				TempData["Userimg"] = appUser.Picture;
			}
			// TempData["Userimg"] = CurrentUser.Picture;

			//var menus = _serviceMenu.GetAllAsycn().Result;
			//var aktifmenu = menus.Where(x => x.MenuDurum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			return View();
		}
	}
}
