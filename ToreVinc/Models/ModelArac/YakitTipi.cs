namespace KurumsalWebVinc.Models.ModelArac
{
	public class YakitTipi : BaseAracEntity
	{
		public string YakitTip { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
