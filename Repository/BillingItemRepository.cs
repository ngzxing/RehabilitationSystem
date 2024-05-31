using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.BillingItem;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class BillingItemRepository : IBillingItemRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetBillingItem>?> GetAllAsync()
        {
            var billingItems = _context.BillingItems.AsQueryable();

            return await billingItems.ToViewModel().ToListAsync();
        }

        public async Task<GetBillingItem?> GetByIdAsync(string id)
        {
            return await _context.BillingItems
                .Where(b => b.BillingItemId == id)
                .ToViewModel()
                .FirstOrDefaultAsync();
        }

        public async Task<string?> AddAsync(AddBillingItem vm)
        {
            var billing = await _context.Billings.FindAsync(vm.BillingId);
            if (billing == null) return "Billing not found";

            var billingItem = new BillingItem
            {
                Description = vm.Description,
                Price = vm.Price,
                Amount = vm.Amount,
                BillingId = vm.BillingId
            };
            
            billing.TotalPayAmount += billingItem.Price * billingItem.Amount;
            await _context.BillingItems.AddAsync(billingItem);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateBillingItem vm)
        {
            var billingItem = await _context.BillingItems.Include(b => b.Billing).FirstOrDefaultAsync(b => b.BillingId == id);
            if (billingItem == null) return "Billing item not found";
            
            billingItem.Billing!.TotalPayAmount -= billingItem.Price* billingItem.Amount;
            
            billingItem.Description = vm.Description;
            billingItem.Price = vm.Price;
            billingItem.Amount = vm.Amount;

            billingItem.Billing!.TotalPayAmount += vm.Price * vm.Amount;

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var billingItem = await _context.BillingItems.FindAsync(id);
            if (billingItem == null) return "Billing item not found";

            _context.BillingItems.Remove(billingItem);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
