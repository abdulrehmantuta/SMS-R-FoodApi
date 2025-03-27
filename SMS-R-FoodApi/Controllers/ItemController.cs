using Microsoft.AspNetCore.Mvc;
using SMS_R_FoodApi.Models;
using SMS_R_FoodApi.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return Ok(await _itemRepository.GetItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(Item item)
        {
            await _itemRepository.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, Item item)
        {
            if (id != item.Id) return BadRequest();
            await _itemRepository.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _itemRepository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
