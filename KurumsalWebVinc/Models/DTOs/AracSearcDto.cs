namespace KurumsalWebVinc.Models.DTOs
{
	public class AracSearcDto : BaseDto
	{
		public AppUser User { get; set; }
		public string UserId { get; set; }

		public string Baslik { get; set; }
		public string Arama { get; set; }
		public string Aciklama { get; set; }
		public string HasarKaydiAciklama { get; set; }
		public string DegisenAciklama { get; set; }
		public string BoyaAciklama { get; set; }
		public decimal MaxFiyat { get; set; }
		public decimal MinFiyat { get; set; }
		public int MaxKM { get; set; }
		public int MinKM { get; set; }
		public int Yil { get; set; }

		public bool Garanti { get; set; }
		public bool AgirHararKayitliMi { get; set; }
		public bool Takasli { get; set; }


		public int AracDurumId { get; set; }

		public int AracRenkId { get; set; }

		public int KasaTipiId { get; set; }

		public int KimdenId { get; set; }



		public int VitesTipId { get; set; }

		public int YakitTipiId { get; set; }


		public int AracMarkaId { get; set; }
		public int AracMarkaKOD { get; set; }


		public int AracModelId { get; set; }
		public int AracModelKOD { get; set; }


		public int SehirilBilgisiId { get; set; }
		public int SehirilBilgisiilKOD { get; set; }


		public int SehirilceBilgisiId { get; set; }
		public int SehirilceBilgisiilceKOD { get; set; }
		public string ilanCep { get; set; }
		public string MapKordinat { get; set; }
		public string FiyatAralik { get; set; }
		public string KmAralik { get; set; }
		public int ListemeId { get; set; }

		public ICollection<AracBilgisi> aracBilgisis { get; set; }

	}
}
