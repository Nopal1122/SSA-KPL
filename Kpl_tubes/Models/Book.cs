using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpl_tubes.Models
{
    public class Book
    {
        public int IdBuku { get; set; }
        public string Judul { get; set; }
        public string Penerbit { get; set; }
        public string Genre { get; set; }
        public string Penulis { get; set; }
        public string Kategori { get; set; }
        public string Kondisi { get; set; }
        public int JumlahBuku { get; set; }
        public int DonaturId { get; set; }
        public bool IsVerified { get; set; }
        public string Ulasan { get; set; }
        public int Rating { get; set; }

        public Book(string judul, string penerbit, string genre, string penulis,
                   string kategori, string kondisi, int jumlahBuku, int donaturId,
                   bool isVerified)
        {
            Judul = judul;
            Penerbit = penerbit;
            Genre = genre;
            Penulis = penulis;
            Kategori = kategori;
            Kondisi = kondisi;
            JumlahBuku = jumlahBuku;
            DonaturId = donaturId;
            IsVerified = isVerified;
            Ulasan = string.Empty;
            Rating = 0;
        }
    }
}
