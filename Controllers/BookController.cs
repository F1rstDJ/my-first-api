using MyFirstApi.Models;

namespace MyFirstApi.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController ]

[Route("api/[controller]") ]
public class BookController : ControllerBase
{
   

    
    public static List<Book>  books =new List<Book>
    {
        new Book { Id = 1, Title = "Война и Мир", Author = "Толстой" },
        new Book { Id = 2, Title = "Преступление и Наказание", Author = "Достоевский" }
        
    };

    [HttpGet("piska")]
    public IEnumerable<Book> Get()
    {
        return  books;
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
        books.Add(book);
        return Ok(book);
    }
    
}