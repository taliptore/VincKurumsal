using AutoMapper;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;
using KurumsalWebVinc.Services.FileUpload;
using KurumsalWebVinc.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

namespace KurumsalWebVinc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ResimlerController : BaseController
	{
		private readonly IService<Resimler> _srvRes;
		private readonly IWebHostEnvironment _webHost;

		public ResimlerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IService<Resimler> srvRes, IWebHostEnvironment webHostEnvironment, IWebHostEnvironment webHost)
		: base(userManager, signInManager, roleManager, mapper)
		{
			_srvRes = srvRes;
			_webHost = webHost;
		}



		// GET: Resimler
		public async Task<IActionResult> Index()
		{
			TempData["Menu"] = "Resimler";
			var veri = await _srvRes.GetAllAsycn();
			return View(veri.OrderByDescending(x => x.CreateDate).ToList());
		}

		// GET: Resimler/Details/5
		public async Task<IActionResult> Details(int id)
		{
			TempData["Menu"] = "Resimler";


			var resimler = await _srvRes.GetByIdAscy(id);

			if (resimler == null)
			{
				return NotFound();
			}

			return View(resimler);
		}

		// GET: Resimler/Create
		public IActionResult Create()
		{
			TempData["Menu"] = "Resimler";
			return View();
		}

		// POST: Resimler/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ResimlerDto rr)
		{
			TempData["Menu"] = "Resimler";

			if (ModelState.IsValid)
			{
				if (rr.Resimler.Count > 0)
				{
					foreach (var item in rr.Resimler)
					{
						//ResimVeriDto yeniResData2 = null;
						//string value = "watertext";
						//string file=Path.GetFileNameWithoutExtension(item.FileName)+".png";
						//using (Bitmap oBitmap = new Bitmap(item.OpenReadStream(),true))
						//{
						//    using (Graphics oGrap=Graphics.FromImage(oBitmap))
						//    {
						//        Brush oBrush = new SolidBrush(Color.Blue);
						//        Font oFont = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
						//        SizeF oSize = new SizeF();
						//        oSize = oGrap.MeasureString(value, oFont);
						//        Point oPoint=new Point(oBitmap.Width-((int)oSize.Width+10),
						//            oBitmap.Height-((int)oSize.Height+10));
						//        oGrap.DrawString(value, oFont, oBrush, oPoint);
						//        string source_path = "upload/images";
						//        var filePath = Path.Combine(
						//                  Directory.GetCurrentDirectory(), $"wwwroot/{source_path}",     file);
						//        using (MemoryStream ms=new MemoryStream())
						//        {
						//            oBitmap.Save(ms, ImageFormat.Png);
						//            ms.Position = 0;
						//            //item.CopyTo(ms);
						//            //var myfile = System.IO.File.ReadAllBytes($"wwwroot/{source_path}/test.png");

						//           // return new FileContentResult(ms.ToArray(), "image/png");
						//           // return File(ms.ToArray(), filePath);
						//            yeniResData2 = FileBaseUpload.Upload2(new FormFile(ms, 0, ms.Length, item.Name, item.FileName), $"{_webHost.WebRootPath}");

						//        }
						//    }
						//}



						//UploadSuccessDto yeniResData2 = FileBaseUpload.HizliUploadWater2(item, "tlptr test yazı").Result;
						UploadSuccessDto yeniResData2 = await FileBaseUpload.HizliUpload(item);
						//UploadSuccessDto yeniResData2 =  FileBaseUpload.HizliUploadWater5(item).Result;
						//ResimVeriDto yeniResData = FileBaseUpload.Upload2(item, $"{_webHost.WebRootPath}");
						Resimler r = new Resimler()
						{
							Aciklama = rr.Aciklama,
							Baslik = rr.Baslik,
							Durum = rr.Durum,
							FileName = yeniResData2.FileName,
							Id = rr.Id,
							Path = yeniResData2.Url
						};
						// string path = $"{_webHost.WebRootPath}/{yeniResData2.Url}";



						//using (var image = Image.FromStream(imgdata)
						//    {
						//        image.Scale(600,200).AddAnimatedTextWatermark("test").SaveAs(yeniResData2.Url);
						//    }

						await _srvRes.AddAsync(r);
					}
				}



				return RedirectToAction(nameof(Index));
			}
			return View(rr);
		}

		// GET: Resimler/Create
		public IActionResult CreateTek()
		{
			TempData["Menu"] = "Resimler";
			return View();
		}

		// POST: Resimler/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateTek(ResimlerDto rr)
		{
			TempData["Menu"] = "Resimler";
			if (ModelState.IsValid)
			{
				if (rr.Resimler.Count > 0)
				{
					foreach (var item in rr.Resimler)
					{

						ResimVeriDto yeniResData = FileBaseUpload.Upload2(item, $"{_webHost.WebRootPath}");
						Resimler r = new Resimler()
						{
							Aciklama = rr.Aciklama,
							Baslik = rr.Baslik,
							Durum = rr.Durum,
							FileName = yeniResData.FileName,
							Id = rr.Id,
							Path = yeniResData.Path
						};
						await _srvRes.AddAsync(r);
					}
				}
				else
				{
					if (rr.TekResim is not null)
					{

						ResimVeriDto yeniResData = FileBaseUpload.Upload2(rr.TekResim, $"{_webHost.WebRootPath}");
						Resimler r = new Resimler()
						{
							Aciklama = rr.Aciklama,
							Baslik = rr.Baslik,
							Durum = rr.Durum,
							FileName = yeniResData.FileName,
							Id = rr.Id,
							Path = yeniResData.Path
						};
						await _srvRes.AddAsync(r);
					}
				}



				return RedirectToAction(nameof(Index));
			}
			return View(rr);
		}

		// GET: Resimler/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			TempData["Menu"] = "Resimler";

			var resimler = await _srvRes.GetByIdAscy(id);
			if (resimler == null)
			{
				return NotFound();
			}
			return View(resimler);
		}

		// POST: Resimler/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Resimler resimler)
		{
			TempData["Menu"] = "Resimler";
			if (id != resimler.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var veri = await _srvRes.GetByIdAscy(id);
					veri.Path = resimler.Path;
					veri.Durum = resimler.Durum;
					veri.Aciklama = resimler.Aciklama;
					veri.Baslik = resimler.Baslik;
					veri.FileName = resimler.FileName;
					await _srvRes.UpdateAsync(veri);
				}
				catch
				{
					return View(resimler);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(resimler);
		}

		// GET: Resimler/Delete/5
		public async Task<IActionResult> Delete(int id)
		{

			TempData["Menu"] = "Resimler";
			var resimler = await _srvRes.GetByIdAscy(id);

			if (resimler == null)
			{
				return NotFound();
			}

			return View(resimler);
		}

		// POST: Resimler/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			TempData["Menu"] = "Resimler";
			var knt = await _srvRes.GetByIdAscy(id);
			if (knt == null)
			{
				return Problem("Entity set 'Resimlers'  is null.");
			}
			var resimler = knt;
			if (resimler != null)
			{
				await _srvRes.RomeveAsync(knt);
				// _context.Resimlers.Remove(resimler);
			}


			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> ResimlerExists(int id)
		{

			return await _srvRes.AnyAsync(x => x.Id == id);
		}
	}
}
