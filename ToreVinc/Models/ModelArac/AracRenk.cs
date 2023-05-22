namespace KurumsalWebVinc.Models.ModelArac
{
	public class AracRenk
	{
		public int Id { get; set; }
		public string Renk { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
