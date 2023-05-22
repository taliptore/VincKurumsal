namespace KurumsalWebVinc.Models.ModelArac
{
	public class KasaTipi : BaseAracEntity
	{
		public string KasaTip { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}

}
