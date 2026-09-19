using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;
namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    
    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        var products = await _context.Products
            .Where(p => p.Category == category)
            .ToListAsync();
        return Ok(products);
    }

   
    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Created($"/api/product/{product.Id}", product);
    }

    // PUT /api/product/5 — обновление
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product product)
    {
        if (id != product.Id) return BadRequest();
        
        var existing = await _context.Products.FindAsync(id);
        if (existing == null) return NotFound();
        
        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Category = product.Category;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();

    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("price/{minprice}")]
    public async Task<IActionResult> GetByPrice(decimal minPrice)
    {
        var pr =await  _context.Products.Where(p => p.Price > minPrice).ToListAsync();
        
        if(pr ==null) return NoContent();
        
        return Ok(pr);
    }

    [HttpGet("top")]
    public async Task<IActionResult> GetTop()
    {
        var prod = await _context.Products.OrderByDescending(p => p.Price).Take(3).ToListAsync();
        
        if(prod.Count==0) return NoContent();
        
        return Ok(prod);
    }

    [HttpGet("name/{name}/exists")]
    public async Task<IActionResult> Exists(string name)
    {
        var p=await _context.Products.Where(p=>p.Name==name).AnyAsync();
        
        return Ok(p);
    }




}