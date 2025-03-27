using Microsoft.AspNetCore.Mvc;
using SMS_R_FoodApi.Models;
using SMS_R_FoodApi.Repository.IRepository;

namespace SMS_R_FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;

        public ItemCategoryController(IItemCategoryRepository itemCategoryRepository)
        {
            _itemCategoryRepository = itemCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCategory>>> GetItems()
        {
            return Ok(await _itemCategoryRepository.GetItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCategory>> GetItem(int id)
        {
            var item = await _itemCategoryRepository.GetItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(ItemCategory item)
        {
            await _itemCategoryRepository.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, ItemCategory item)
        {
            if (id != item.Id) return BadRequest();
            await _itemCategoryRepository.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _itemCategoryRepository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
