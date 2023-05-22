﻿namespace KurumsalWebVinc.Models.DTOs
{
	public class TalepFormuDto : BaseDto
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string Mail { get; set; }
		public string Adres { get; set; }
		public string iletisimNo { get; set; }
		public string Mesaj { get; set; }
		public string GuvenlikKodu { get; set; }
		public string GuvenlikKoduCevap { get; set; }
		public int ServislerId { get; set; }

		public int BulSehirId { get; set; }
		public int GitSehirId { get; set; }
		public string ServislerIdKod { get; set; }

	}
}
