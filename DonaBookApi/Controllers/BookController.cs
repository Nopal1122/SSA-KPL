using Microsoft.AspNetCore.Mvc;
using Kpl_tubes.API.Model;

namespace DonaBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book("Jalani Langkah", "PT Gramedia", "Romance", "Ahmad Yudha Manuhuttu", "Kategori A", "Bagus", 2, 1, true),
            new Book("Cinta Segitiga", "PT Telkom", "Romance", "Yuki Kato", "Kategori B", "Tidak Layak", 2, 1, false),

        };

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        [HttpGet("{index}")]
        public Book Get(int index)
        {
            return books[index];
        }

        [HttpPost]

        public void Post([FromBody] Book book)
        {
            books.Add(book);
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            books.RemoveAt(index);
        }
    }
}
