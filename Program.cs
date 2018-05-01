using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bilinmeyen = new Bilesik();
            bilinmeyen.Display();

            var su = new ZenginBilesik(Kimyasal.Su);
            su.Display();

            var benzen = new ZenginBilesik(Kimyasal.Benzen);
            benzen.Display();

            var etanol = new ZenginBilesik(Kimyasal.Etanol);
            etanol.Display();

            Console.Read();

        }
    }

    public enum Kimyasal
    {
        Su,
        Etanol,
        Benzen
    }

    public enum Durum
    {
        KaynamaNoktasi,
        DonmaNoktasi
    }

    public class Bilesik
    {
        public Kimyasal Kimyasal { get; set; }
        public float KaynamaNoktasi { get; set; }
        public float DonmaNoktasi { get; set; }
        public double MolekulAgirligi { get; set; }
        public string MolekulFormulu { get; set; }
        public virtual void Display()
        {
            Console.WriteLine("Kimyasallar");
        }
    }

    public class KimyaVeriBankasi
    {
        
        public float DurumGetir(Kimyasal k, Durum d)
        {
            if (d == Durum.KaynamaNoktasi)
            {
                switch (k)
                {
                    case Kimyasal.Su:
                        return 100.0f;
                    case Kimyasal.Etanol:
                        return 80.1f;
                    case Kimyasal.Benzen:
                        return 78.3f;
                    default:
                        return 0.0f;
                }
            }
            else
            {
                switch (k)
                {
                    case Kimyasal.Su:
                        return 0.0f;
                    case Kimyasal.Etanol:
                        return 5.5f;
                    case Kimyasal.Benzen:
                        return -114.1f;
                    default:
                        return 0.0f;
                }
            }
        }
        public string MolekulFormuluGetir(Kimyasal k)
        {
            switch (k)
            {
                case Kimyasal.Su:
                    return "H2O";
                case Kimyasal.Etanol:
                    return "C2H5OH";
                case Kimyasal.Benzen:
                    return "C6H6";
                default:
                    return "";
            }
        }
        public double MolekulAgirligiGetir(Kimyasal k)
        {
            switch (k)
            {
                case Kimyasal.Su:
                    return 18;
                case Kimyasal.Etanol:
                    return 78;
                case Kimyasal.Benzen:
                    return 46;
                default:
                    return 0;
            }
        }
    }

    class ZenginBilesik : Bilesik
    {
        private KimyaVeriBankasi _banka;

        public ZenginBilesik(Kimyasal k)
        {
            Kimyasal = k;
            _banka = new KimyaVeriBankasi();
        }

        public override void Display()
        {
            KaynamaNoktasi = _banka.DurumGetir(Kimyasal, Durum.KaynamaNoktasi);
            DonmaNoktasi = _banka.DurumGetir(Kimyasal, Durum.DonmaNoktasi);
            MolekulAgirligi = _banka.MolekulAgirligiGetir(Kimyasal);
            MolekulFormulu = _banka.MolekulFormuluGetir(Kimyasal);

            Console.WriteLine("\n Bileşik: {0}", Kimyasal);
            Console.WriteLine(" Formül: {0}", MolekulFormulu);
            Console.WriteLine(" Ağırlık: {0}", MolekulAgirligi);
            Console.WriteLine(" Donma Noktası: {0}", DonmaNoktasi);
            Console.WriteLine(" Kaynama Noktası: {0}", KaynamaNoktasi);
        }
    }
}
