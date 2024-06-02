using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Program;

namespace RehabilitationSystem.Repository
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetProgram>> GetAllAsync(ProgramQuery query, List<string> includes)
        {
            var programs = _context.Programs.AsQueryable();

            // Filtering based on query parameters
            if (!string.IsNullOrEmpty(query.Name))
                programs = programs.Where(p => p.Name!.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.Objective))
                programs = programs.Where(p => p.Objective!.Contains(query.Objective));
            if (query.MaxPrice.HasValue)
                programs = programs.Where(p => p.Price <= query.MaxPrice.Value);
            if (query.MinPrice.HasValue)
                programs = programs.Where(p => p.Price >= query.MinPrice.Value);

            // Selecting the view model
            return await programs.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetProgram?> GetByIdAsync(string id, List<string> includes)
        {
            var programs = _context.Programs.AsQueryable();

            // Selecting the view model
            return await programs.ToViewModel(includes).FirstOrDefaultAsync(p => p.ProgramId == id);
        }

        public async Task<string?> AddAsync(AddProgram vm)
        {
            var program = new Models.Program
            {
                Name = vm.Name,
                Objective = vm.Objective,
                Description = vm.Description,
                Price = vm.Price
            };

            await _context.Programs.AddAsync(program);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateProgram vm)
        {
            var program = await _context.Programs.FindAsync(id);
            if (program == null) return "Program Not Found";

            program.Name = vm.Name;
            program.Objective = vm.Objective;
            program.Description = vm.Description;
            program.Price = vm.Price;

            await _context.SaveChangesAsync();
            return null;
        }
    
        public async Task<string?> DeleteAsync(string id)
        {
            var program = await _context.Programs.FindAsync(id);
            if (program == null) return "Program Not Found";

            _context.Programs.Remove(program);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
