using AutoMapper;
using KurumsalWebVinc.Migrations;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class HakkimizdaController : BaseController
	{
		private readonly IService<Hakkimizda> _service;
		private readonly IService<Vizyon> _serviceViz;




		public HakkimizdaController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Hakkimizda> service, IService<Vizyon> serviceViz)
					: base(userManager, signInManager, roleManager, mapper)
		{
			_service = service;
			_serviceViz = serviceViz;

		}

		// GET: HakkimizdaController
		public async Task<IActionResult> Index()
		{
			ViewBag.SayfaAdi = "Hakkımızda";
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "Hakkimizda";
			var list = await _service.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			var model = _mapper.Map<HakkimizdaDto>(veri);
			return View(model);
		}
		public async Task<IActionResult> AdminVizyon()
		{
			TempData["dropdown"] = "Genel";
			TempData["Menu"] = "AdminVizyon";
			ViewBag.SayfaAdi = "Vizyon";
			var list = await _serviceViz.GetAllAsycn();
			var veri = list.ToList().FirstOrDefault();
			var model = _mapper.Map<VizyonDto>(veri);
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AdminVizyon(VizyonDto vizyon)
		{
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{
					if (vizyon.Id > 0)
					{
						//var data=await _service.GetByIdAscy(genelBilgiler.Id);
						try
						{
							if (vizyon.ResimFile is not null)
							{
								if (vizyon.ResimFile.Length > 0)
								{


									var resim = await FileBaseUpload.HizliUpload(vizyon.ResimFile);
									if (resim.Uploaded == 1)
									{
										vizyon.Resim = resim.Url;
									}
									if (resim.Uploaded == -1)
									{

										ModelState.AddModelError("Resim", "Resim Hatalı");
										return View(vizyon);

									}
								}
							}
							var model = _mapper.Map<Vizyon>(vizyon);
							var result = _serviceViz.UpdateAsync(model);
							TempData["Alert"] = $"Kayıt Güncellendi.";
						}
						catch (Exception ex)
						{
							var message = ex.Message;
						}


					}
					else
					{
						var model = _mapper.Map<Vizyon>(vizyon);
						var result = await _serviceViz.AddAsync(model);
						TempData["Alert"] = $"Kayıt Ekledi.";
					}

				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						//return View(genelBilgiler);
					}
				}

				return RedirectToAction(nameof(AdminVizyon));
			}
			catch
			{
				return View(vizyon);
			}
		}

		// GET: HakkimizdaController/Details/5
		public ActionResult Details(int id)
		{

			return View();
		}

		// GET: HakkimizdaController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HakkimizdaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(HakkimizdaDto hakkimizda)
		{
			try
			{
				//genelBilgiler.UpdateDate = DateTime.Now;

				if (ModelState.IsValid)
				{
					if (hakkimizda.Id > 0)
					{
						//var data=await _service.GetByIdAscy(hakkimizda.Id);
						try
						{
							if (hakkimizda.ResimFile is not null)
							{
								if (hakkimizda.ResimFile.Length > 0)
								{


									var resim = await FileBaseUpload.HizliUpload(hakkimizda.ResimFile);
									if (resim.Uploaded == 1)
									{
										hakkimizda.Resim = resim.Url;
									}
									if (resim.Uploaded == -1)
									{

										ModelState.AddModelError("Resim", "Resim Hatalı");
										return View(hakkimizda);

									}
								}
							}
							var model = _mapper.Map<Hakkimizda>(hakkimizda);
							await _service.UpdateAsync(model);
							TempData["Alert"] = $"Kayıt Güncellendi.";

						}
						catch (Exception ex)
						{
							var message = ex.Message;
						}


					}
					else
					{
						var model = _mapper.Map<Hakkimizda>(hakkimizda);
						var result = await _service.AddAsync(model);
						TempData["Alert"] = $"Kayıt Ekledi.";

					}

				}
				else
				{
					foreach (var item in ModelState)
					{
						ModelState.AddModelError("", item.Key);
						//return View(genelBilgiler);
					}
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(hakkimizda);
			}
		}

		// GET: HakkimizdaController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: HakkimizdaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HakkimizdaController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: HakkimizdaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
