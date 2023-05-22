namespace KurumsalWebVinc.Models.ModelArac
{
	public class VitesTip : BaseAracEntity
	{
		public string VitesTipi { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
