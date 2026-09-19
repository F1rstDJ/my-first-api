namespace MyFirstApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{

   [HttpGet("even/{number}")]
   public bool GetNum(int number) => number % 2 == 0;


   [HttpPost]
   public int PostNum([FromBody] int[] number) => number.Sum();

   [HttpPost("number")]
   public IEnumerable<string> PostWords([FromBody] string[] words) => words.Where(x => x.Length > 3);

   [HttpGet("max/{a}/{b}")]
   public int Max(int a, int b)
   {
       int result = a > b ? a : b;

       return result;
   }

   [HttpPost("sr_znach")]
   public double PostSrZnach([FromBody] int[] numbers) => numbers.Average();

   [HttpPost("txt")]
   public int PostTxt([FromBody] string text) => text.Length;

   [HttpPost("max/min")]
   public IEnumerable<int> PostMaxMin([FromBody] int[] numbers)=>new[]{numbers.Max(), numbers.Min()};
}
