using System;
using System.Collections.Generic;

class Kitap
{
    public string Ad { get; set; }
    public string Yazar { get; set; }
    public string ISBN { get; set; }
    public int YayınYılı { get; set; }

    public Kitap(string ad, string yazar, string isbn, int yayınYılı)
    {
        Ad = ad;
        Yazar = yazar;
        ISBN = isbn;
        YayınYılı = yayınYılı;
    }

    public override string ToString()
    {
        return $"Kitap Adı: {Ad}, Yazar: {Yazar}, ISBN: {ISBN}, Yayın Yılı: {YayınYılı}";
    }
}

class Kütüphane
{
    private List<Kitap> kitaplar = new List<Kitap>();

    public void KitapEkle()
    {
        Console.Write("Kitap Adı: ");
        string ad = Console.ReadLine();
        Console.Write("Yazar Adı: ");
        string yazar = Console.ReadLine();
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Yayın Yılı: ");
        int yayınYılı = int.Parse(Console.ReadLine());

        Kitap yeniKitap = new Kitap(ad, yazar, isbn, yayınYılı);
        kitaplar.Add(yeniKitap);
        Console.WriteLine("Kitap başarıyla eklendi!\n");
    }

    public void KitaplarıListele()
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("Hiç kitap bulunmamaktadır.\n");
        }
        else
        {
            foreach (Kitap kitap in kitaplar)
            {
                Console.WriteLine(kitap);
            }
            Console.WriteLine();
        }
    }

    public void KitapAra()
    {
        Console.Write("Aramak istediğiniz kitabın adı: ");
        string ad = Console.ReadLine();
        Kitap bulunanKitap = kitaplar.Find(k => k.Ad.ToLower() == ad.ToLower());

        if (bulunanKitap != null)
        {
            Console.WriteLine(bulunanKitap + "\n");
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.\n");
        }
    }

    public void KitapSil()
    {
        Console.Write("Silmek istediğiniz kitabın ISBN numarasını girin: ");
        string isbn = Console.ReadLine();
        Kitap silinecekKitap = kitaplar.Find(k => k.ISBN == isbn);

        if (silinecekKitap != null)
        {
            kitaplar.Remove(silinecekKitap);
            Console.WriteLine("Kitap başarıyla silindi!\n");
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Kütüphane kütüphane = new Kütüphane();
        int secim;

        do
        {
            Console.WriteLine("--- Kütüphane Yönetim Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Sil");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    kütüphane.KitapEkle();
                    break;
                case 2:
                    kütüphane.KitaplarıListele();
                    break;
                case 3:
                    kütüphane.KitapAra();
                    break;
                case 4:
                    kütüphane.KitapSil();
                    break;
                case 5:
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!\n");
                    break;
            }
        } while (secim != 5);
    }
}
