namespace MyFirstApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]

[Route("api/[controller]")]
public class ShopController : ControllerBase
{
    [HttpGet]
    public string GetShop()
    {
        return "Добро пожаловать в магазин!";
    }

    [HttpPost("(product)")]
    public IActionResult CreateProduct([FromBody] ProductDto product)
    {
        return Ok(new
        {
            Message = "Товар создан",
            Id = 1,
            Product = product

        });
    }

    [HttpGet("{username}/{id}")]

    public string GetShop(string username, int id)
    {
        return "Привет, " + username + ", " + id.ToString();
    }
}

public class ProductDto
{
    public string Name { get; set; }
    public int Price { get; set; }
}