using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.AbstractViewModel;
using RehabilitationSystem.ViewModels.Admin;
using RehabilitationSystem.ViewModels.CustomerService;
using RehabilitationSystem.ViewModels.Parent;
using RehabilitationSystem.ViewModels.Therapist;

namespace RehabilitationSystem.Repository
{
    public class ExtendUserRepository : IExtendUserRepository
    {   
        public readonly ApplicationDbContext _context;
        public IAdminRepository adminRepo { get; set; }
        public ICustomerServiceRepository customerServiceRepo { get; set; }
        public ITherapistRepository therapistRepo { get; set; }
        public IParentRepository parentRepo { get; set; }
        public ExtendUserRepository(ApplicationDbContext context){

            
            _context = context;
            adminRepo = new AdminRepository(context);
            customerServiceRepo = new CustomerServiceRepository(context);
            therapistRepo = new TherapistRepository(context);
            parentRepo = new ParentRepository(context);
        }

        public async Task<(string?, string?)> GetIdByAppUserId(string AppUserId, string role)
        {   
            role = role.ToUpper();
            string? Id = String.Empty;
            if(role == "ADMIN"){

                Id = await _context.Admins.Where( a => a.AppUserId == AppUserId).Select(e => e.AdminId).FirstOrDefaultAsync();

            }else if(role == "THERAPIST"){
                
                Id = await _context.Therapists.Where( a => a.AppUserId == AppUserId).Select(e => e.TherapistId).FirstOrDefaultAsync();

            }else if(role == "PARENT"){

                Id = await _context.Parents.Where( a => a.AppUserId == AppUserId).Select(e => e.ParentId).FirstOrDefaultAsync();

            }else if(role == "CUSTOMERSERVICE"){

                Id = await _context.CustomerServices.Where( a => a.AppUserId == AppUserId).Select(e => e.CustomerServiceId).FirstOrDefaultAsync();

            }else{

                return (null, "No Such Role Exists");
            }

            if(Id == null)
                return (null, "Extended User Not Exists");
            
            return (Id, null);
        }

        public async Task<string?> AddAsync(string AppUserId, AbstractAddUserViewModel vm)
        {   
            
            
            if( vm is AddAdmin){

            return await adminRepo.AddAsync((AddAdmin)vm, AppUserId);

            }else if( vm is AddTherapist ){
                
                return await therapistRepo.AddAsync((AddTherapist)vm, AppUserId);

            }else if( vm is AddParent ){

                return await parentRepo.AddAsync((AddParent)vm, AppUserId);

            }else if( vm is AddCustomerService ){

                return await customerServiceRepo.AddAsync((AddCustomerService)vm, AppUserId);

            }else{

                return  "No Such Role Exists";
            }

        
        }

        public async Task<string?> UpdateAsync(string ExtendUserId, AbstractUpdateUserViewModel vm)
        {   
            
            if( vm is UpdateAdmin){

            return await adminRepo.UpdateAsync(ExtendUserId, (UpdateAdmin)vm);

            }else if( vm is UpdateTherapist ){
                
                return await therapistRepo.UpdateAsync(ExtendUserId, (UpdateTherapist)vm);

            }else if( vm is UpdateParent ){

                return await parentRepo.UpdateAsync(ExtendUserId, (UpdateParent)vm);

            }else if( vm is UpdateCustomerService ){

                return await customerServiceRepo.UpdateAsync(ExtendUserId, (UpdateCustomerService)vm);

            }else{

                return  "No Such Role Exists";
            }
        }
    }
}