using SMS_R_FoodApi.Models;

namespace SMS_R_FoodApi.Repository.IRepository
{
    public interface IItemCategoryRepository
    {
        Task<IEnumerable<ItemCategory>> GetItemsAsync();
        Task<ItemCategory> GetItemByIdAsync(int id);
        Task AddItemAsync(ItemCategory itemCategory);
        Task UpdateItemAsync(ItemCategory itemCategory);
        Task DeleteItemAsync(int id);
    }
}
