using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Dtos.Stock;
using MyWebApi.Interfaces;
using MyWebApi.Mappers;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return Ok(stocks?.Select(stock => stock.ToStockDto()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockRequestDto stockDto)
        {
            if (stockDto == null)
            {
                return BadRequest("Stock data is required.");
            }

            var stockModel = stockDto.ToStockModel();
            await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updatedStockDto)
        {
            if (updatedStockDto == null)
            {
                return BadRequest("Stock data is required.");
            }

            var existingStock = await _stockRepository.UpdateAsync(id, updatedStockDto);
            if (existingStock == null)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return Ok(existingStock.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
