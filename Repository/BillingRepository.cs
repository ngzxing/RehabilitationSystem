using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels;
using RehabilitationSystem.ViewModels.Billing;

namespace RehabilitationSystem.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetBilling>?> GetAllAsync(BillingQuery query, List<string> includes)
        {
            var billings = _context.Billings.AsQueryable();

            if (query.IssueDateBefore.HasValue)
                billings = billings.Where(b => b.IssueDate <= query.IssueDateBefore.Value);
            if (query.IssueDateAfter.HasValue)
                billings = billings.Where(b => b.IssueDate >= query.IssueDateAfter.Value);
            if (query.LessThanTotalPayAmount.HasValue)
                billings = billings.Where(b => b.TotalPayAmount <= query.LessThanTotalPayAmount.Value);
            if (query.MoreThanTotalPayAmount.HasValue)
                billings = billings.Where(b => b.TotalPayAmount >= query.MoreThanTotalPayAmount.Value);
            if (query.PaymentStatus.HasValue)
                billings = billings.Where(b => b.PaymentStatus == query.PaymentStatus);
            if (query.PaymentDateBefore.HasValue)
                billings = billings.Where(b => b.PaymentDate <= query.PaymentDateBefore.Value);
            if (query.PaymentDateAfter.HasValue)
                billings = billings.Where(b => b.PaymentDate >= query.PaymentDateAfter.Value);
            if (!string.IsNullOrEmpty(query.StudentId))
                billings = billings.Where(b => b.ProgramStudent!.StudentId == query.StudentId);
            if (!string.IsNullOrEmpty(query.ParentId))
                billings = billings.Where(b => b.ProgramStudent!.Student!.ParentId == query.ParentId);
            if (!string.IsNullOrEmpty(query.ProgramName))
                billings = billings.Where(b => b.ProgramStudent!.Program!.Name!.Contains(query.ProgramName));
            if( query.PageNumber.HasValue && query.PageSize.HasValue )
                billings = billings.Skip((int)((query.PageNumber - 1) * query.PageSize)).Take((int)query.PageSize);

            return await billings.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetBilling?> GetByIdAsync(string id, List<string> includes)
        {
            var billings = _context.Billings.AsQueryable();

            var billing = await billings.ToViewModel(includes).FirstOrDefaultAsync(b => b.BillingId == id);

            return  billing;
        }

        public async Task<string?> AddAsync(AddBilling vm)
        {   

            decimal? price = await _context.ProgramStudents.Where( p => p.ProgramStudentId == vm.ProgramStudentId )
                                        .Select(p => p.Program!.Price)
                                        .FirstOrDefaultAsync();
            if(price == null){

                return "Not Such Students Register At This Program";
            }
            

            var billing = new Billing
            {
                IssueDate = DateTime.Now,
                TotalPayAmount = price,
                PaymentStatus = false,
                

            };

            await _context.Billings.AddAsync(billing);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateBilling billingViewModel)
        {
            var billing = await _context.Billings.FindAsync(id);
            if (billing == null) return "Billing Not Found";

            billing.ProgramStudentId = billingViewModel.ProgramStudentId;
            
            await _context.SaveChangesAsync();
            return null;      
            
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var billing = await _context.Billings.FindAsync(id);
            if (billing == null) return "Billing Not Found";

            _context.Billings.Remove(billing);
            await _context.SaveChangesAsync();
            return null;   
        }
    }

}