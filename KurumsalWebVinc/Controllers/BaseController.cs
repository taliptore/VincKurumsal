using AutoMapper;
using KurumsalWebVinc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{

	[Authorize(Roles = "Admin,Üye")]
	public class BaseController : Controller
	{
		protected UserManager<AppUser> userManager { get; set; }
		protected SignInManager<AppUser> signInManager { get; set; }
		protected RoleManager<AppRole> roleManager { get; set; }
		protected readonly IMapper _mapper;


		protected AppUser CurrentUser => userManager.FindByNameAsync(User.Identity.Name).Result;


		public BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager = null, IMapper mapper = null)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
			_mapper = mapper;



		}


		public void AddModelError(IdentityResult result)
		{
			foreach (var item in result.Errors)
			{
				ModelState.AddModelError("", item.Description);
			}
		}
	}
}
