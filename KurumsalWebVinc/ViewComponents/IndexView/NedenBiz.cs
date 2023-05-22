using Microsoft.AspNetCore.Mvc;

namespace KurumsalWebVinc.ViewComponents.IndexView
{
	public class NedenBiz : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			//var appDbContext = await _service.GetAllIncluding(
			//     a => a.AracDurum,
			//     a => a.AracMarka,
			//     a => a.AracModel,

			//     a => a.KasaTipi,
			//     a => a.SehirilBilgisi,
			//     a => a.SehirilceBilgisi,

			//     a => a.AracResims,
			//     a => a.VitesTip,
			//     a => a.YakitTipi);

			//var veri = appDbContext.Where(x => x.Durum == true && x.IsDeleted == false)
			//    .OrderByDescending(x => x.CreateDate).Where(x => x.CreateDate.AddDays(35) > DateTime.Now).ToList();
			return View("~/Views/Shared/Components/NedenBiz.cshtml");
		}
	}
}
