using Microsoft.AspNetCore.Mvc;
using SMS_R_FoodApi.Models;
using SMS_R_FoodApi.Repository;
using SMS_R_FoodApi.Repository.IRepository;

namespace SMS_R_FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var item = await _saleRepository.GetSaleByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> AddSale(Sale sale)
        {
            await _saleRepository.AddSaleAsync(sale);
            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetItems()
        {
            return Ok(await _saleRepository.GetSalesAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, Sale sale)
        {
            if (id != sale.Id) return BadRequest();
            await _saleRepository.UpdateSaleAsync(sale);
            return NoContent();
        }
    }
}
