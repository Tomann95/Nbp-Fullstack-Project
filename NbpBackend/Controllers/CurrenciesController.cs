using Microsoft.AspNetCore.Mvc;
using NbpBackend.Data;
using NbpBackend.Models;
using NbpBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace NbpBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly NbpService _nbpService;
        private readonly AppDbContext _context;

        public CurrenciesController(NbpService nbpService, AppDbContext context)
        {
            _nbpService = nbpService;
            _context = context;
        }

        
        [HttpPost("fetch")]
        public async Task<IActionResult> FetchCurrencies(string date)
        {
            try
            {
                
                var parsedDate = DateTime.Parse(date).ToUniversalTime();

                
                var ratesDto = await _nbpService.GetRatesAsync(date);

                if (ratesDto == null || !ratesDto.Any())
                    return NotFound("NBP nie zwrócił danych dla tej daty.");

                
                int addedCount = 0;
                foreach (var rate in ratesDto)
                {
                    
                    bool exists = await _context.CurrencyRates
                        .AnyAsync(r => r.Code == rate.Code && r.Date == parsedDate);

                    if (!exists)
                    {
                        _context.CurrencyRates.Add(new CurrencyRate
                        {
                            Code = rate.Code,
                            Currency = rate.Currency,
                            Mid = rate.Mid,
                            Date = parsedDate 
                        });
                        addedCount++;
                    }
                }

                await _context.SaveChangesAsync();
                return Ok(new { Message = $"Sukces! Pobrano i zapisano {addedCount} nowych kursów.", Date = date });
            }
            catch (Exception ex)
            {
                return BadRequest($"Błąd: {ex.Message}");
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.CurrencyRates.ToListAsync();
            return Ok(data);
        }
    }
}
