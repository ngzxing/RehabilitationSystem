using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.CustomerService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class CustomerServiceRepository : ICustomerServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCustomerService>?> GetAllAsync(QueryCustomerService query, List<string> includes)
        {
            var customerServices = _context.CustomerServices.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                customerServices = customerServices.Where(cs => cs.Name!.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.PhoneNumber))
                customerServices = customerServices.Include(cs => cs.AppUser).Where(cs => cs.AppUser!.PhoneNumber == query.PhoneNumber);
            if (!string.IsNullOrEmpty(query.Email))
                customerServices = customerServices.Include(cs => cs.AppUser).Where(cs => cs.AppUser!.Email == query.Email);

           

            return await customerServices.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetCustomerService?> GetByIdAsync(string id, List<string> includes)
        {
            var customerServices = _context.CustomerServices.AsQueryable();


            return await customerServices.Where(cs => cs.CustomerServiceId == id).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<string?> AddAsync(AddCustomerService vm, string appUserId)
        {
            var newCustomerService = new CustomerService
            {
                CustomerServiceId = vm.CustomerServiceId,
                Name = vm.Name,
                AppUserId = appUserId
            };

            await _context.CustomerServices.AddAsync(newCustomerService);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateCustomerService vm)
        {
            var existingCustomerService = await _context.CustomerServices.FindAsync(id);
            if (existingCustomerService == null) return "Customer Service Not Found";

            existingCustomerService.Name = vm.Name;

            await _context.SaveChangesAsync();
            return null;
        }

       
    }
}
