using System;
using System.Collections.Generic;

namespace PendaftaranPesilat
{
    class Atlet
    {
        public string Nama { get; set; }
        public int Umur { get; set; }
        public string JenisKelamin { get; set; }
        public string KelasTanding { get; set; }
    }

    class Program
    {
        static void Garis(int panjang)
        {
            Console.WriteLine(new string('=', panjang));
        }

        static void Main(string[] args)
        {
            List<Atlet> daftarAtlet = new List<Atlet>();
            Console.Title = "Aplikasi Pendaftaran Atlet Pencak Silat";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Garis(45);
            Console.WriteLine("   PENDAFTARAN ATLET PENCAK SILAT");
            Garis(45);
            Console.ResetColor();

            Console.Write("Berapa atlet yang ingin didaftarkan? ");
            int jumlah = int.Parse(Console.ReadLine());

            for (int i = 0; i < jumlah; i++)
            {
                Atlet atlet = new Atlet();

                Console.WriteLine($"\n[Data Atlet ke-{i + 1}]");

                Console.Write("Nama            : ");
                atlet.Nama = Console.ReadLine();

                Console.Write("Umur            : ");
                atlet.Umur = int.Parse(Console.ReadLine());

                Console.Write("Jenis Kelamin (L/P): ");
                atlet.JenisKelamin = Console.ReadLine();

                Console.Write("Kelas Tanding   : ");
                atlet.KelasTanding = Console.ReadLine();

                daftarAtlet.Add(atlet);
            }

            // Tampilkan data atlet
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== DAFTAR ATLET TERDAFTAR ===");
            Console.ResetColor();

            Garis(70);
            Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-10} {4,-15}",
                "No", "Nama", "Umur", "Gender", "Kelas");
            Garis(70);

            int no = 1;
            foreach (var atlet in daftarAtlet)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-10} {4,-15}",
                    no++, atlet.Nama, atlet.Umur, atlet.JenisKelamin, atlet.KelasTanding);
            }

            Garis(70);
            Console.WriteLine("Total Atlet Terdaftar: " + daftarAtlet.Count);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Terima kasih telah mendaftar dan semoga sukses! 🥋");
            Console.ResetColor();

            Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
            Console.ReadKey();
        }
    }
}

