using System;

namespace SosyalYardimApi.Models
{
    public class SosyalYardim
    {
        public int Id { get; set; }
        public string ?TcKimlikNo { get; set; }
        public string ?MusteriAd { get; set; }
        public string ?MusteriSoyad { get; set; }
        public int OdemeKd { get; set; }
        public decimal OdenecekTtr { get; set; }
        public DateTime OdemeTr { get; set; }
        public string ?OdemeAck { get; set; }
    }
}
