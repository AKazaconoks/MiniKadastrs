using MvcApiApplication.Models;
using Microsoft.AspNetCore.Http;

namespace WebApp.Abstractions.Interfaces;

public interface ICsvParserService
{
    Task<List<PropertyTransaction>> ParseCsvFile(IFormFile file);
}