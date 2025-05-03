using Microsoft.AspNetCore.Mvc;
using Kpl_tubes.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DonaBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly string dataPath = Path.Combine("Data", "Books.json");

        // JSON option global untuk enum & formatting
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        // GET all books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            if (!System.IO.File.Exists(dataPath))
                return new List<Book>();

            var json = System.IO.File.ReadAllText(dataPath);
            var books = JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions);

            return books ?? new List<Book>();
        }

        // GET book by index
        [HttpGet("{index}")]
        public ActionResult<Book> Get(int index)
        {
            var books = Get().ToList();
            if (index < 0 || index >= books.Count)
                return NotFound();

            return books[index];
        }

        // POST book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            var books = Get().ToList();

            // Generate ID otomatis
            book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;

            books.Add(book);

            var json = JsonSerializer.Serialize(books, _jsonOptions);
            System.IO.File.WriteAllText(dataPath, json);

            return CreatedAtAction(nameof(Get), new { index = books.Count - 1 }, book);
        }

        // DELETE book by index
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            var books = Get().ToList();
            if (index < 0 || index >= books.Count)
                return NotFound();

            books.RemoveAt(index);

            var json = JsonSerializer.Serialize(books, _jsonOptions);
            System.IO.File.WriteAllText(dataPath, json);

            return NoContent();
        }
    }
}
