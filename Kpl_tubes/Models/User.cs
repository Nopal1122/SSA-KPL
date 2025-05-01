using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpl_tubes.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Alamat {  get; set; }
        public string Password { get; set; }
        public string Kontak {  get; set; }
        public string Role { get; set; }

        protected User(string nama, string email, string alamat,
                      string password, string kontak, string role)
        {
            Nama = nama;
            Email = email;
            Alamat = alamat;
            Password = password;
            Kontak = kontak;
            Role = role;
        }

        protected User(int id, string nama, string email, string alamat,
                       string password, string kontak, string role)
             : this(nama, email, alamat, password, kontak, role)
        {
            Id = id;
        }
    }
}
