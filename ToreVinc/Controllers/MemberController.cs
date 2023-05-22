using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{
	public class MemberController : Controller
	{

		//Üye işlemleri bu bölümden yapılacak
		public IActionResult Index()
		{
			TempData["UserName"] = null;
			TempData["UserId"] = null;
			TempData["Rol"] = null;
			TempData["Userimg"] = null;

			return RedirectToAction("Login", "Admin");
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
