using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class NavbarList : ViewComponent
	{
		private readonly IService<GenelBilgiler> _GB;
		private readonly IService<Menu> _serviceMenu;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<AppUser> userManager;
		public NavbarList(IService<Menu> serviceMenu, IService<GenelBilgiler> gB, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
		{
			_serviceMenu = serviceMenu;
			_GB = gB;
			_httpContextAccessor = httpContextAccessor;
			this.userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
			{
				var username = _httpContextAccessor.HttpContext.User.Identity.Name;


				TempData["UserName"] = username;



				if (TempData["UserId"] is null || TempData["Rol"] is null)
				{
					AppUser appUser = await userManager.FindByNameAsync(username);
					TempData["UserId"] = appUser.Id;
					TempData["Userimg"] = appUser.Picture;

					if (TempData["Rol"] is null)
					{
						IList<string> roles;
						roles = await userManager.GetRolesAsync(appUser);
						TempData["Rol"] = roles.FirstOrDefault();
					}
				}
			}


			var veriGb = _GB.GetAllAsycn().Result.FirstOrDefault();
			if (veriGb != null) { ViewBag.GB = veriGb; }
			//  var menus = _serviceMenu.GetAllAsycn().Result;
			//var aktifmenu = menus.Where(x => x.Durum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			var menusa = await _serviceMenu.GetAllIncluding(x => x.AltMenus);
			var veri = menusa
				.Where(x => x.Durum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			return View(veri);
		}
	}
}
