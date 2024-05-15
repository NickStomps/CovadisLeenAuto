using CovadisAPI.Entities;
namespace DemoCovadis.Entities
{
    public class Auto
    {
        //test
        public string kenteken { get; set; }
        public int beginStandKm { get; set; }
        public int eindStandKm { get; set; }
        public User bestuurder { get; set; }
        public string beginAdres { get; set; }
        public string eindAdres { get; set; }
        public string vertrekTijd { get; set; }
        public string aankomstTijd { get; set; }
    }
}
