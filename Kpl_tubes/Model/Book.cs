using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpl_tubes.Model
{

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public int Quantity { get; set; }
        public bool IsVerified { get; set; }
        public string? Review { get; set; }
        public int Rating { get; set; }

        // table untuk rating default berdasarkan genre
        private static readonly Dictionary<string,int> GenreDefaultRatings = new()
                    {
            { "Fiction", 5 },
            { "Non-Fiction", 4 },
            { "Science Fiction", 4 },
            { "Fantasy", 5 },
            { "Mystery", 4 },
            { "Romance", 3 },
            { "Horror", 4 },
            { "Biography", 4 },
            { "Self-Help", 3 },
            { "History", 4 }
        };
        public Book(string title, string publisher, string genre, string author, string category, string condition, int quantity, int donorId)
        {
            title = title;
            publisher = publisher;
            genre = genre;
            author = author;
            category = category;
            condition = condition;
            quantity = quantity;
            donorId = donorId;
            IsVerified = false;

            //logic digunakan di constructor
            Rating = GenreDefaultRatings.ContainsKey(genre) ? GenreDefaultRatings[genre] : 0; // default rating is 0 if genre not found


        }
    }
}
