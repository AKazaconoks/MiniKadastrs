using MvcApiApplication.Models;

namespace WebApp.Abstractions.Interfaces;

public interface IPropertyTransactionRepository
{
    Task<List<PropertyTransaction>> GetAllAsync();
    Task<PropertyTransaction> GetByIdAsync(int id);
    Task AddAsync(PropertyTransaction transaction);
    Task<bool> UpdateAsync(PropertyTransaction transaction);
    Task<bool> DeleteAsync(int id);
}