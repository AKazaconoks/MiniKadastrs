namespace MvcApiApplication.Models;

public class PropertyTransaction
{
    public int Id { get; set; }
    public string Year { get; set; }
    public decimal AvgPriceRegion1 { get; set; }
    public int TransactionCountRegion1 { get; set; }
    public decimal AvgPriceRegion2 { get; set; }
    public int TransactionCountRegion2 { get; set; }
    public decimal AvgPriceRegion3 { get; set; }
    public int TransactionCountRegion3 { get; set; }
}