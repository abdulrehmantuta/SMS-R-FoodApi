using Microsoft.EntityFrameworkCore;
using SMS_R_FoodApi.Data;
using SMS_R_FoodApi.Models;
using SMS_R_FoodApi.Repository.IRepository;
using System;

namespace SMS_R_FoodApi.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync() => await _context.Items.ToListAsync(); 
        public async Task<Item> GetItemByIdAsync(int id) => await _context.Items.FindAsync(id);
        public async Task AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
