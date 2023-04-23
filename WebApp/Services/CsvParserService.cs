using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using WebApp.Abstractions.Interfaces;
using MvcApiApplication.Models;
using WebApp.Services;

namespace MvcApiApplication.Services;

public class CsvParserService : ICsvParserService
{
    public async Task<List<PropertyTransaction>> ParseCsvFile(IFormFile file)
    {
        using var streamReader = new StreamReader(file.OpenReadStream());
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        csvReader.Context.RegisterClassMap<CsvPropertyTransactionMap>();

        var records = csvReader.GetRecords<PropertyTransaction>().ToList();
        var propertyTransactions = records.Select(record => new PropertyTransaction
        {
            Year = record.Year,
            AvgPriceRegion1 = record.AvgPriceRegion1,
            TransactionCountRegion1 = record.TransactionCountRegion1,
            AvgPriceRegion2 = record.AvgPriceRegion2,
            TransactionCountRegion2 = record.TransactionCountRegion2,
            AvgPriceRegion3 = record.AvgPriceRegion3,
            TransactionCountRegion3 = record.TransactionCountRegion3
        }).ToList();

        return propertyTransactions;
    }

}