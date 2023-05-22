using System.ComponentModel;

namespace KurumsalWebVinc.Models
{
	public class ServisTalep : BaseEntity
	{
		[DisplayName("Hizmetin Alınacağı Şehir Seçilsin mi?")]
		public bool BulSehirDurum { get; set; }
		[DisplayName("Hizmetin Götürülecegi Şehir Seçilsin mi?")]

		public bool GidSehirDurum { get; set; }
		public Servisler Servisler { get; set; }
		public int ServislerId { get; set; }
	}
}
