namespace ToreVinc.Models.Muhasebe
{
    public class TBL_BANKABILGILERI
    {
        public int ID { get; set; }
        public string BANKAADI { get; set; }
        public string HESAPTURU { get; set; }
        public string HESAPNO { get; set; }
        public string IBAN { get; set; }
        public string BANKASUBESI { get; set; }
        public string SUBETELEFONU { get; set; }
        public string ADRES { get; set; }
        public string YETKILI { get; set; }
        public string EMAIL { get; set; }
        public bool DURUM { get; set; }
        public bool SIL { get; set; }
        public int SAVEUSER { get; set; }
        public DateTime SAVEDATE { get; set; }
        public int EDITUSER { get; set; }
        public DateTime EDITDATE { get; set; }
    }
}
