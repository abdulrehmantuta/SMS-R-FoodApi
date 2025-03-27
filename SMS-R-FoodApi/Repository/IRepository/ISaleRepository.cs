
using SMS_R_FoodApi.Models;

namespace SMS_R_FoodApi.Repository.IRepository
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetSalesAsync();
        Task<Sale> GetSaleByIdAsync(int id);
        Task AddSaleAsync(Sale sale);
        Task UpdateSaleAsync(Sale sale);
        //Task DeleteSaleAsync(int id);
    }
}
