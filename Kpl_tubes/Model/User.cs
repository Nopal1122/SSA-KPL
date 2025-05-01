using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpl_tubes.Model
{

    namespace BookDonation.Models
    {
        public abstract class User
        {
            public int Id { get; }
            public string Name { get; }
            public string Email { get; }
            public string Address { get; }
            public string Password { get; }
            public string Contact { get; }
            public string Role { get; }

            protected User(int id, string name, string email, string address, string password, string contact, string role)
            {
                Id = id;
                Name = name;
                Email = email;
                Address = address;
                Password = password;
                Contact = contact;
                Role = role;
            }
        }

        public class Donor : User
        {
            public Donor(int id, string name, string email, string address, string password, string contact)
                : base(id, name, email, address, password, contact, "donatur") { }
        }

        public class Recipient : User
        {
            public Recipient(int id, string name, string email, string address, string password, string contact)
                : base(id, name, email, address, password, contact, "penerima") { }

            public string? Review { get; set; }
            public int Rating { get; set; }
        }

        public class Volunteer : User
        {
            public Volunteer(int id, string name, string email, string address, string password, string contact)
                : base(id, name, email, address, password, contact, "volunteer") { }
        }
    }
s