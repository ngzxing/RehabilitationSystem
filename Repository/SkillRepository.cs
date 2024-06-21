using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Skill;

namespace RehabilitationSystem.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository( ApplicationDbContext context ){

            _context = context;
        }
        
        public async Task<ICollection<GetSkillSet>?> GetAllSetAsync(List<string> includes){

            return await _context.SkillSets.ToViewModel(includes).ToListAsync();
        }

        public async Task<ICollection<GetSkillCategory>?> GetAllCategoryAsync(List<string> includes){

            return await _context.SkillCategories.ToViewModel(includes).ToListAsync();
        }

        public async Task<ICollection<GetSkillLineItem>?> GetAllLineItemAsync(List<string> includes){

            return await _context.SkillLineItems.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetSkillSet> GetSetByIdAsync(string Id, List<string> includes){

            return await _context.SkillSets.Where( s => s.SkillSetId == Id ).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<GetSkillCategory> GetCategoryByIdAsync(string Id, List<string> includes){

            return await _context.SkillCategories.Where( s => s.SkillCategoryId == Id ).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<GetSkillLineItem> GetLineItemByIdAsync(string Id, List<string> includes){

            return await _context.SkillLineItems.Where( s => s.SkillLineItemId == Id ).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<(string?, string?)> AddSetAsync( AddSet vm ){
            
            var exists = await _context.SkillSets.AnyAsync( s => s.SkillSetId == vm.SkillSetId );
            if(exists) return ("Duplicated Skill Set Id", null);

            var newSet = new SkillSet{

                SkillSetId = vm.SkillSetId,
                Name = vm.Name,
                Description = vm.Description
            };

           try{

                await _context.AddAsync(newSet);
                await _context.SaveChangesAsync();

           }catch(Exception e){

                return ("Add Failed: " + e.ToString(), null);
           }

           return (null, newSet.SkillSetId);

        } 

        public async Task<(string?, string?)> AddCategoryAsync( AddCategory vm ){
            
            var exists = await _context.SkillCategories.AnyAsync( s => s.SkillCategoryId == vm.SkillCategoryId );
            if(exists) return ("Duplicated Skill Category Id", null);

            exists = await _context.SkillSets.AnyAsync( s => s.SkillSetId == vm.SkillSetId );
            if(!exists) return ("No Such Skill Set Exist", null);

            var newCategory = new SkillCategory{

                SkillCategoryId = vm.SkillCategoryId,
                SkillSetId = vm.SkillSetId,
                Name = vm.Name,
            };

           try{

                await _context.AddAsync(newCategory);
                await _context.SaveChangesAsync();

           }catch(Exception e){

                return ("Add Failed: " + e.ToString(), null);
           }

           return (null, newCategory.SkillCategoryId);

        }

        public async Task<(string?, string?)> AddLineItemAsync( AddLineItem vm ){
            
            var exists = await _context.SkillLineItems.AnyAsync( s => s.SkillCategoryId == vm.SkillCategoryId );
            if(exists) return ("Duplicated Skill Line Item Id", null);

            exists = await _context.SkillCategories.AnyAsync( s => s.SkillCategoryId == vm.SkillCategoryId );
            if(!exists) return ("No Such Skill Category Exist", null);

            var newLineItem = new SkillLineItem{

                SkillLineItemId = vm.SkillLineItemId,
                SkillCategoryId = vm.SkillCategoryId,
                Name = vm.Name,
            };

           try{

                await _context.AddAsync(newLineItem);
                await _context.SaveChangesAsync();

           }catch(Exception e){

                return ("Add Failed: " + e.ToString(), null);
           }

           return (null, newLineItem.SkillLineItemId);

        }

        public async Task<(string?, string?)> EditSetAsync( AddSet vm ){
            
            bool exists = await _context.SkillSets.AnyAsync( s => s.SkillSetId == vm.SkillSetId );
            if(!exists) return ("No Such Skill Set Exist", null);

            var newSet = new SkillSet{

                SkillSetId = vm.SkillSetId,
                Name = vm.Name,
                Description = vm.Description
            };

           try{

                await _context.SaveChangesAsync();

           }catch(Exception e){

                return ("Edit Failed: " + e.ToString(), null);
           }

           return (null, newSet.SkillSetId);

        } 

        public async Task<(string?, string?)> EditCategoryAsync( EditCategory vm ){

            bool exists = await _context.SkillCategories.AnyAsync( s => s.SkillCategoryId == vm.SkillCategoryId );
            if(!exists) return ("No Such Skill Category Exist", null);
            
            var newCategory = new SkillCategory{

                SkillCategoryId = vm.SkillCategoryId,
                SkillSetId = vm.SkillSetId,
                Name = vm.Name,
            };

           try{

                await _context.SaveChangesAsync();

           }catch(Exception e){

                return ("Edit Failed: " + e.ToString(), null);
           }

           return (null, newCategory.SkillCategoryId);

        }

        public async Task<(string?, string?)> EditLineItemAsync( EditLineItem vm ){

            var exists = await _context.SkillLineItems.AnyAsync( s => s.SkillCategoryId == vm.SkillCategoryId );
            if(exists) return ("No Such Skill Line Item Exist", null);
            
            var newLineItem = new SkillLineItem{

                SkillLineItemId = vm.SkillLineItemId,
                SkillCategoryId = vm.SkillCategoryId,
                Name = vm.Name,
            };

           try{

                await _context.SaveChangesAsync();

           }catch(Exception e){

                return ("Edit Failed: " + e.ToString(), null);
           }

           return (null, newLineItem.SkillLineItemId);

        }

        public async Task<string?> DeleteAsync(string SkillLevel, string id){

            try{

                if(SkillLevel == "Set"){

                    var removed = await _context.SkillSets.FindAsync(id);
                    if (removed == null) return "Skill Set Not Found";

                    _context.SkillSets.Remove(removed);
                    await _context.SaveChangesAsync();
                }

                else if(SkillLevel == "Category"){

                    var removed = await _context.SkillCategories.FindAsync(id);
                    if (removed == null) return "Skill Category Not Found";

                    _context.SkillCategories.Remove(removed);
                    await _context.SaveChangesAsync();
                }

                else if(SkillLevel == "LineItem"){

                    var removed = await _context.SkillLineItems.FindAsync(id);
                    if (removed == null) return "Skill LineItem Not Found";

                    _context.SkillLineItems.Remove(removed);
                    await _context.SaveChangesAsync();
                }
                else{

                    return "Invalid Skill Level";
                }

            }catch(Exception e){

                return "Remove Failed: " + e.ToString();
            }

            return null;
        }
    }
}