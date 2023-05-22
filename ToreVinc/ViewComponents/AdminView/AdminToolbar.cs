using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.AdminView
{
	public class AdminToolbar : ViewComponent
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<AppUser> userManager;

		protected readonly IService<TalepFormu> service;
		protected readonly IService<AracBilgisi> serviceAracB;

		public AdminToolbar(IService<TalepFormu> service, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IService<AracBilgisi> serviceAracB)
		{
			this.service = service;
			_httpContextAccessor = httpContextAccessor;
			this.userManager = userManager;
			this.serviceAracB = serviceAracB;
		}

		public async Task<IViewComponentResult> InvokeAsync()
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

			var veri = await service.GetAllAsycn();
			var al = veri.OrderByDescending(x => x.CreateDate).ToList();
			var veriArac = await serviceAracB.GetAllAsycn();
			var alArac = veriArac.Where(x => x.Durum == false && x.UpdateDate is null).ToList();

			BildirimListDto dto = new BildirimListDto();
			dto.TalepFormus = al;
			dto.aracBilgisis = alArac;
			//var menus = _serviceMenu.GetAllAsycn().Result;
			//var aktifmenu = menus.Where(x => x.MenuDurum == true && x.AdminMenusuMu == false).OrderBy(x => x.MenuSirasi).ToList();

			return View(dto);
		}
	}
}
