using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Kpl_tubes.Model;
using BookDonationConsole.Models;
using kpl_tubes.Services;

namespace Kpl_tubes.Services
{
    public class UserService : IUserService 
    {
        private readonly string filePath = "data/users.json";
        private List<User> users = new();

        public UserService()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                users = new List<User>();
                return;
            }

            var json = File.ReadAllText(filePath);
            var rawData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

            users = rawData.Select(u =>
            {
                var role = u["Role"].ToString();
                int id = Convert.ToInt32(u["Id"]);
                string name = u["Name"].ToString();
                string email = u["Email"].ToString();
                string address = u["Address"].ToString();
                string password = u["Password"].ToString();
                string contact = u["Contact"].ToString();

                return role switch
                {
                    "donatur" => new Donatur(id, name, email, address, password, contact),
                    "penerima" => new Penerima(id, name, email, address, password, contact),
                    "volunteer" => new Volunteer(id, name, email, address, password, contact),
                    _ => null
                };
            }).Where(u => u != null).ToList()!;
        }

        public User? Authenticate(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<User> GetAllUsers() => users;
    }
}
