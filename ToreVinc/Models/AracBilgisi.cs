using KurumsalWebVinc.Models.ModelArac;

namespace KurumsalWebVinc.Models
{
	public class AracBilgisi : BaseEntity
	{
		public AppUser User { get; set; }
		public string UserId { get; set; }

		public string Baslik { get; set; }
		public string Aciklama { get; set; }
		public string HasarKaydiAciklama { get; set; }
		public string DegisenAciklama { get; set; }
		public string BoyaAciklama { get; set; }
		public decimal Fiyat { get; set; }
		public int KM { get; set; }
		public int Yil { get; set; }

		public bool Garanti { get; set; }
		public bool AgirHararKayitliMi { get; set; }
		public bool Takasli { get; set; }

		public AracDurum AracDurum { get; set; }
		public int AracDurumId { get; set; }
		public AracRenk AracRenk { get; set; }
		public int AracRenkId { get; set; }
		public KasaTipi KasaTipi { get; set; }
		public int KasaTipiId { get; set; }
		public Kimden Kimden { get; set; }
		public int KimdenId { get; set; }


		public VitesTip VitesTip { get; set; }
		public int VitesTipId { get; set; }
		public YakitTipi YakitTipi { get; set; }
		public int YakitTipiId { get; set; }

		public AracMarka AracMarka { get; set; }
		public int AracMarkaId { get; set; }
		public int AracMarkaKOD { get; set; }

		public AracModel AracModel { get; set; }
		public int AracModelId { get; set; }
		public int AracModelKOD { get; set; }

		public SehirilBilgisi SehirilBilgisi { get; set; }
		public int SehirilBilgisiId { get; set; }
		public int SehirilBilgisiilKOD { get; set; }

		public SehirilceBilgisi SehirilceBilgisi { get; set; }
		public int SehirilceBilgisiId { get; set; }
		public int SehirilceBilgisiilceKOD { get; set; }
		public string ilanCep { get; set; }
		public string MapKordinat { get; set; }

		public ICollection<AracResim> AracResims { get; set; }
		public AracRapor AracRapors { get; set; }

	}
}
