using KurumsalWebVinc.Models;

namespace KurumsalWebVinc.Models.ModelArac
{
	public class Kimden
	{
		public int Id { get; set; }
		public string Tur { get; set; }
		public ICollection<AracBilgisi> AracBilgisis { get; set; }
	}
}
