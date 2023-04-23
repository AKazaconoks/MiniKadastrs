using CsvHelper.Configuration;
using MvcApiApplication.Models;

namespace WebApp.Services;

public class CsvPropertyTransactionMap : ClassMap<PropertyTransaction>
{
    public CsvPropertyTransactionMap()
    {
        Map(m => m.Year).Name("Gads un pusgads");
        Map(m => m.AvgPriceRegion1).Name("Vidējā cena (EUR/m2) Rīga (centrs)");
        Map(m => m.TransactionCountRegion1).Name("Darījumu skaits Rīga (centrs)");
        Map(m => m.AvgPriceRegion2).Name("Vidējā cena (EUR/m2) Rīga (mikrorajoni)");
        Map(m => m.TransactionCountRegion2).Name("Darījumu skaits Rīga (mikrorajoni)");
        Map(m => m.AvgPriceRegion3).Name("Vidējā cena (EUR/m2) Jūrmala");
        Map(m => m.TransactionCountRegion3).Name("Darījumu skaits Jūrmala");
    }
}