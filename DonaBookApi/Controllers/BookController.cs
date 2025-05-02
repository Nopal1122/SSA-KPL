using Microsoft.AspNetCore.Mvc;
using Kpl_tubes;
using Kpl_tubes.Model;

namespace DonaBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
           new Book("Jalani Langkah", "PT Gramedia", Genre.Romance, "Ahmad Yudha Manuhuttu", Category.Dewasa, BookCondition.Baru, 2, 1),
            new Book("Cinta Segitiga", "PT Telkom", Genre.Romance, "Yuki Kato", Category.Remaja, BookCondition.BekasRusak, 2, 1)

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
