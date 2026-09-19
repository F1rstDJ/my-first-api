namespace MyFirstApi.Models;

public class BulkDiscountRequest
{
    public int[]  ids {get; set;}
    public decimal disqountPercent {get; set;}
}