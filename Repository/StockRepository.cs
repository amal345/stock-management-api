using System;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Dtos.Stock;
using MyWebApi.Interfaces;
using MyWebApi.Mappers;
using MyWebApi.Models;

namespace MyWebApi.Repository;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Stock>> GetAllAsync()
    {
        List<Stock> stocks = await _context.Stocks.Include(c => c.Comments).ToListAsync();
        return stocks;
    }
    public async Task<Stock?> GetByIdAsync(int id)
    {
        Stock? stock = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(stock => stock.Id == id);
        return stock;
    }
    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }
    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updatedStockDto)
    {
        var existingStock = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
        if (existingStock == null)
        {
            return null;
        }
        existingStock.UpdateFromDto(updatedStockDto);
        await _context.SaveChangesAsync();
        return existingStock;
    }
    public async Task<Stock?> DeleteAsync(int id)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
        if (stock == null)
        {
            return null;
        }
        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public Task<bool> isStockExists(int id)
    {
        return _context.Stocks.AnyAsync(stock => stock.Id == id);
    }
}
