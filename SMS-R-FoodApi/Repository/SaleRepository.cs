using Microsoft.EntityFrameworkCore;
using SMS_R_FoodApi.Data;
using SMS_R_FoodApi.Models;
using SMS_R_FoodApi.Repository.IRepository;

namespace SMS_R_FoodApi.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Sale>> GetSalesAsync() => await _context.Sales.ToListAsync();
        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            return await _context.Sales
                .Include(s => s.Items) // Ensure to include the related Items
                .ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id) =>
            await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task AddSaleAsync(Sale sale)
        {
            DateTime today = DateTime.UtcNow.Date;

            var lastSale = _context.Sales
                .AsEnumerable()
                .Where(s => DateTime.Parse(s.SaleDate).Date == today)
                .OrderByDescending(s => s.InvoiceNumber)
                .FirstOrDefault();

            int nextNumber = 1;
            if (lastSale != null && int.TryParse(lastSale.InvoiceNumber, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }

            sale.InvoiceNumber = nextNumber.ToString("D6");

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSaleAsync(Sale sale)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(); // ✅ Transaction start karein

            try
            {
                // ✅ Pehle existing sale entity ko database se fetch karein
                var existingSale = await _context.Sales
                    .Include(s => s.Items) // ✅ Ensure items are included
                    .FirstOrDefaultAsync(s => s.Id == sale.Id);

                if (existingSale != null)
                {
                    // ✅ Purani items delete karein
                    _context.SaleParameters.RemoveRange(existingSale.Items);
                    await _context.SaveChangesAsync(); // ✅ Ensure delete operation is committed

                    // ✅ Context se purani entity ko detach karein
                    _context.Entry(existingSale).State = EntityState.Detached;
                }

                // ✅ Ab naye items insert karein
                if (sale.Items != null && sale.Items.Any())
                {
                    foreach (var item in sale.Items)
                    {
                        item.SaleId = sale.Id; // ✅ SaleId set karna zaroori hai
                        _context.SaleParameters.Add(item);
                    }
                }

                await _context.SaveChangesAsync(); // ✅ Save new items

                // ✅ Sale entity ko explicitly update karein
                _context.Sales.Attach(sale);
                _context.Entry(sale).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync(); // ✅ Sab kuch sahi chala to commit karein
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(); // ❌ Koi error aya to rollback karein
                throw;
            }
        }


        //public async Task DeleteItemAsync(int id)
        //{
        //    var item = await _context.Sales.FindAsync(id);
        //    if (item != null)
        //    {
        //        _context.Sales.Remove(item);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
