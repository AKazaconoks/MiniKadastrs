using Microsoft.AspNetCore.Mvc;
using WebApp.Abstractions.Interfaces;
using MvcApiApplication.Models;

namespace WebApp.Controllers;

[ApiController]
[Route("PropertyTransaction")]
public class PropertyTransactionController : ControllerBase
{
    private readonly IPropertyTransactionRepository _repository;
    private readonly ICsvParserService _csvParserService;

    public PropertyTransactionController(IPropertyTransactionRepository repository, ICsvParserService csvParserService)
    {
        _repository = repository;
        _csvParserService = csvParserService;
    }

    [HttpPost("uploadcsv")]
    public async Task<IActionResult> UploadCsv([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file was provided");
        }

        var transactions = await _csvParserService.ParseCsvFile(file);
        foreach (var transaction in transactions)
        {
            await _repository.AddAsync(transaction);
        }

        return Ok();
    }

    [HttpGet]
    public async Task<List<PropertyTransaction>> GetTransactions()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PropertyTransaction>> GetTransaction(int id)
    {
        var transaction = await _repository.GetByIdAsync(id);
        return transaction == null ? BadRequest() : transaction;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        return isDeleted ? Ok() : NotFound();
    }


    [HttpPut]
    public async Task<IActionResult> UpdateTransaction([FromBody] PropertyTransaction transaction)
    {
        var isUpdated = await _repository.UpdateAsync(transaction);
        return isUpdated ? Ok() : NotFound();
    }
}