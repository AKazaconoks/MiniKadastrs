

using Microsoft.EntityFrameworkCore;
using WebApp.Abstractions.Interfaces;
using MvcApiApplication.Models;

namespace Infrastructure.Repositories;

public class PropertyTransactionRepository : IPropertyTransactionRepository
{
    private readonly ApplicationDbContext _context;

    public PropertyTransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PropertyTransaction>> GetAllAsync()
    {
        var transactions = await _context.PropertyTransactions.ToListAsync();
        return transactions;
    }

    public async Task<PropertyTransaction> GetByIdAsync(int id)
    {
        var transaction = await _context.PropertyTransactions.FirstOrDefaultAsync(p => p.Id == id);
        return transaction;
    }

    public async Task AddAsync(PropertyTransaction transaction)
    {
        await _context.PropertyTransactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(PropertyTransaction transaction)
    {
        var existingTransaction = await _context.PropertyTransactions.FirstOrDefaultAsync(p => p.Id == transaction.Id);
        if(existingTransaction == null)
        {
            return false;
        }
        _context.PropertyTransactions.Update(transaction);
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var transaction = await _context.PropertyTransactions.FirstOrDefaultAsync(p => p.Id == id);
        if (transaction == null)
        {
            return false;
        }

        _context.PropertyTransactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return true;
    }
}
