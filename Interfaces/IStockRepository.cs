using System;
using MyWebApi.Dtos.Stock;
using MyWebApi.Models;

namespace MyWebApi.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updatedStockDto);
    Task<Stock?> DeleteAsync(int id);

    
}
