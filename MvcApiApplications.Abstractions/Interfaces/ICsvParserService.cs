using Microsoft.AspNetCore.Http;
using MvcApiApplication.Models;

namespace Infrastructure;

public interface ICsvParserService
{
    Task<List<PropertyTransaction>> ParseCsvFile(IFormFile file);
}