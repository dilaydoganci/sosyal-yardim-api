using SosyalYardimApi.Models;

namespace SosyalYardimApi.Data
{
    public static class Seed
    {
        public static void SeedData(SosyalYardimContext context)
        {
            var yeniVeriler = new List<SosyalYardim>
            {
                new SosyalYardim
                {
                    TcKimlikNo = "12345678901",
                    MusteriAd = "Ali",
                    MusteriSoyad = "Demir",
                    OdemeKd = 0,
                    OdenecekTtr = 1200, 
                    OdemeTr = DateTime.Now.AddDays(-5),
                    OdemeAck = "Kira yardımı"
                },
                new SosyalYardim
                {
                    TcKimlikNo = "12345678902",
                    MusteriAd = "Ayşe",
                    MusteriSoyad = "Yılmaz",
                    OdemeKd = 0,
                    OdenecekTtr = 1600,
                    OdemeTr = DateTime.Now.AddDays(10),
                    OdemeAck = "Gıda yardımı"
                },
                new SosyalYardim
                {
                    TcKimlikNo = "12345678903",
                    MusteriAd = "Burak",
                    MusteriSoyad = "Can",
                    OdemeKd = 0,
                    OdenecekTtr = 2100, 
                    OdemeTr = DateTime.Now.AddDays(15),
                    OdemeAck = "Eğitim yardımı"
                },

                new SosyalYardim
                {
                    TcKimlikNo = "12345678904",
                    MusteriAd = "Dilay",
                    MusteriSoyad = "Doğancı",
                    OdemeKd = 0,
                    OdenecekTtr = 2000,
                    OdemeTr = DateTime.Now.AddDays(15),
                    OdemeAck = "Fatura yardımı"
                }
            };

            foreach (var yeniVeri in yeniVeriler)
            {
                var mevcutVeri = context.SosyalYardimlar
                    .FirstOrDefault(x => x.TcKimlikNo == yeniVeri.TcKimlikNo);

                if (mevcutVeri != null)
                {
                    // Mevcut veriyi günceller
                    mevcutVeri.MusteriAd = yeniVeri.MusteriAd;
                    mevcutVeri.MusteriSoyad = yeniVeri.MusteriSoyad;
                    mevcutVeri.OdemeKd = yeniVeri.OdemeKd;
                    mevcutVeri.OdenecekTtr = yeniVeri.OdenecekTtr;
                    mevcutVeri.OdemeTr = yeniVeri.OdemeTr;
                    mevcutVeri.OdemeAck = yeniVeri.OdemeAck;
                }
                else
                {
                    // Yeni veriyi ekler
                    context.SosyalYardimlar.Add(yeniVeri);
                }
            }

            context.SaveChanges();
        }
    }
}
