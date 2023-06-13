namespace ToreVinc.Models.Muhasebe
{
    public class TBL_SANTIYETANIM
    {
        public int ID { get; set; }
        public string SANTIYEKODU { get; set; }
        public string SANTIYEADI { get; set; }
        public string YETKILI { get; set; }
        public string TEL1 { get; set; }
        public string TEL2 { get; set; }
        public string ACIKLMA { get; set; }
        public string VERGIDAIRESI { get; set; }
        public string VERGINO { get; set; }
        public string FATURAADRESI { get; set; }
        public bool DURUM { get; set; }
        public bool SIL { get; set; }
        public int SAVEUSER { get; set; }
        public DateTime SAVEDATE { get; set; } 
        public int EDITUSER { get; set; }
        public DateTime EDITDATE { get; set; }

    }
}
