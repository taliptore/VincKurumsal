using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using KurumsalWebVinc.Models.ModelArac;
using KurumsalWebVinc.Services.IService;
using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AracMarkasController : BaseController
	{
		private readonly IService<AracModel> _serviceModel;
		private readonly IService<AracMarka> _service;

		public AracMarkasController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager = null, IMapper mapper = null, IService<AracMarka> service = null, IService<AracModel> serviceModel = null)
			: base(userManager, signInManager, roleManager, mapper)
		{
			_service = service;
			_serviceModel = serviceModel;
		}


		// GET: AracMarkas
		public async Task<IActionResult> Index()
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";
			var veri = await _service.GetAllIncluding(x => x.AracModels);
			var snc = veri.OrderBy(a => a.MarkaAdi).ToList();
			return View(snc);
		}
		public IActionResult ModelEkle(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";
			var veri = _serviceModel.Where(x => x.AracMarkaKodu == id);
			TempData["MarkaKod"] = id;
			var markaadi = _service.Where(x => x.MarkaKodu == id).FirstOrDefault();
			TempData["MarkaAdi"] = markaadi.MarkaAdi;
			return View(veri.OrderBy(x => x.ModelAdi).ToList());
		}

		// GET: AracMarkas/Create
		public IActionResult CreateModel()
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";
			AracModel model = new AracModel();
			model.AracMarkaKodu = int.Parse(TempData["MarkaKod"].ToString());
			return View(model);
		}

		// POST: AracMarkas/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateModel(AracModel model)
		{
			if (ModelState.IsValid)
			{
				var veri = await _serviceModel.GetAllAsycn();
				var max = veri.Max(x => x.ModelKodu);
				model.ModelKodu = max + 1;
				await _serviceModel.AddAsync(model);
				// return RedirectToAction("ModelEkle/"+model.AracMarkaKodu.ToString());
				return RedirectToAction(nameof(ModelEkle), new { id = model.AracMarkaKodu.ToString() });
			}
			return View(model);
		}

		// GET: AracMarkas/Details/5
		public async Task<IActionResult> Details(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";

			var aracMarka = await _service.GetByIdAscy(id);
			if (aracMarka == null)
			{
				return NotFound();
			}

			return View(aracMarka);
		}

		// GET: AracMarkas/Create
		public IActionResult Create()
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";
			return View();
		}

		// POST: AracMarkas/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AracMarka aracMarka)
		{
			if (ModelState.IsValid)
			{
				await _service.AddAsync(aracMarka);

				return RedirectToAction(nameof(Index));
			}
			return View(aracMarka);
		}

		// GET: AracMarkas/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";

			var aracMarka = await _service.GetByIdAscy(id);
			if (aracMarka == null)
			{
				return NotFound();
			}
			return View(aracMarka);
		}

		// POST: AracMarkas/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, AracMarka aracMarka)
		{
			if (id != aracMarka.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _service.UpdateAsync(aracMarka);

				}
				catch (DbUpdateConcurrencyException)
				{


				}
				return RedirectToAction(nameof(Index));
			}
			return View(aracMarka);
		}

		// GET: AracMarkas/Delete/5
		public async Task<IActionResult> Delete(int id)
		{

			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";
			var aracMarka = await _service.GetByIdAscy(id);

			if (aracMarka == null)
			{
				return NotFound();
			}

			return View(aracMarka);
		}

		// POST: AracMarkas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";
			var aracMarka = await _service.GetByIdAscy(id);
			if (aracMarka != null)
			{
				aracMarka.IsDeleted = true;
				await _service.UpdateAsync(aracMarka);
			}


			return RedirectToAction(nameof(Index));
		}

		// GET: AracMarkas/Delete/5
		public async Task<IActionResult> DeleteModel(int id)
		{
			TempData["dropdown"] = "arac";
			TempData["Menu"] = "AracMarkas";

			var aracM = await _serviceModel.GetByIdAscy(id);
			aracM.IsDeleted = !aracM.IsDeleted;
			aracM.Durum = !aracM.Durum;
			await _serviceModel.UpdateAsync(aracM);
			if (aracM == null)
			{
				return NotFound();
			}

			TempData["Alert"] = $"İşlem Yapıldı";
			return RedirectToAction(nameof(ModelEkle), new { id = aracM.AracMarkaKodu });


		}

		// POST: AracMarkas/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteModel(int id)
		//{

		//    var aracMarka = await _service.GetByIdAscy(id);
		//    if (aracMarka != null)
		//    {
		//        aracMarka.IsDeleted = true;
		//        await _service.UpdateAsync(aracMarka);
		//    }


		//    return RedirectToAction(nameof(ModelEkle));
		//}


	}
}
