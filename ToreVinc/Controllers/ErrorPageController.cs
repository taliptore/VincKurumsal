using KurumsalWebVinc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KurumsalWebVinc.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Error(int? statusCode = null)
		{
			if (statusCode.HasValue)
			{
				if (statusCode == 404 || statusCode == 500)
				{
					var viewName = statusCode.ToString();
					ViewBag.StatusCode = statusCode;
					//return View(viewName);
					return View();
				}
			}

			return View();

		}

		public IActionResult Error404()
		{
			return View();
		}
	}
}
