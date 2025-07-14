using System;
using MyWebApi.Dtos.Stock;
using MyWebApi.Models;

namespace MyWebApi.Mappers;

public static class StockMappers
{
    public static StockDtos ToStockDto(this Stock stockModel)
    {
        if (stockModel == null)
        {
            throw new ArgumentNullException(nameof(stockModel), "Stock model cannot be null");
        }

        return new StockDtos
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c=>c.ToCommentDto()).ToList()
        };
    }

    public static Stock ToStockModel(this CreateStockRequestDto newStockModelDto)
    {
        if (newStockModelDto == null)
        {
            throw new ArgumentNullException(nameof(newStockModelDto), "Stock DTO cannot be null");
        }

        return new Stock
        {
            Symbol = newStockModelDto.Symbol,
            CompanyName = newStockModelDto.CompanyName,
            Purchase = newStockModelDto.Purchase,
            LastDiv = newStockModelDto.LastDiv,
            Industry = newStockModelDto.Industry,
            MarketCap = newStockModelDto.MarketCap
        };
    }
    
    public static void UpdateFromDto(this Stock stock, UpdateStockRequestDto dto)
    {
        stock.Symbol = dto.Symbol;
        stock.CompanyName = dto.CompanyName;
        stock.Purchase = dto.Purchase;
        stock.LastDiv = dto.LastDiv;
        stock.Industry = dto.Industry;
        stock.MarketCap = dto.MarketCap;
    }
}
