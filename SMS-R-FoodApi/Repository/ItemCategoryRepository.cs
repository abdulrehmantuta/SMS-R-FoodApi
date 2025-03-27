using Microsoft.EntityFrameworkCore;
using SMS_R_FoodApi.Data;
using SMS_R_FoodApi.Models;
using SMS_R_FoodApi.Repository.IRepository;
using System;

namespace SMS_R_FoodApi.Repository
{
    public class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly AppDbContext _context;

        public ItemCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemCategory>> GetItemsAsync() => await _context.Category.ToListAsync();
        public async Task<ItemCategory> GetItemByIdAsync(int id) => await _context.Category.FindAsync(id);
        public async Task AddItemAsync(ItemCategory item)
        {
            _context.Category.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(ItemCategory item)
        {
            _context.Category.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Category.FindAsync(id);
            if (item != null)
            {
                _context.Category.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
