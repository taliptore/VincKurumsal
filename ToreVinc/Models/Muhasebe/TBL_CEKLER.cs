namespace ToreVinc.Models.Muhasebe
{
    public class TBL_CEKLER
    {
        public int ID { get; set; }
        public string BELGENO { get; set; }
        public string CEKNO { get; set; }
        public string ASILBORCLU { get; set; }
        public string TIPI { get; set; }
        public int ALINANCARIID { get; set; }
        public int VERILENCARIID { get; set; }
        public string ACKODU { get; set; }
        public DateTime VADETARIHI { get; set; }
        public string BANKA { get; set; }
        public string SUBE { get; set; }
        public string HESAPNO { get; set; }
        public decimal TUTAR { get; set; }
        public string ACIKLAMA { get; set; }
        public DateTime VERILENBANKA_TARIHI { get; set; }
        public string VERILENBANKA_BELGENO { get; set; }
        public DateTime VERILENCARI_TARIHI { get; set; }
        public string VERILENCARI_BELGENO { get; set; }
        public string VERILENBANKA_ID { get; set; }
        public string DURUM { get; set; }
        public string TAHSIL { get; set; }
        public int BORDROID { get; set; }
        public DateTime TARIH { get; set; }
        public int SAVEUSER { get; set; }
        public DateTime SAVEDATE { get; set; }
        public int EDITUSER { get; set; }
        public DateTime EDITDATE { get; set; }
    }
}
