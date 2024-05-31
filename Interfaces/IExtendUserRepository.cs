using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AbstractViewModel;

namespace RehabilitationSystem.Interfaces
{
    public interface IExtendUserRepository
    {
        public IAdminRepository adminRepo {get; set;}
        public ICustomerServiceRepository customerServiceRepo {get; set;}
        public ITherapistRepository therapistRepo {get; set;}
        public IParentRepository parentRepo {get; set;}
        public Task<(string?, string?)> GetIdByAppUserId(string AppUserId, string role);
        public Task<string?> AddAsync(string AppUserId, AbstractAddUserViewModel vm);
        public Task<string?> UpdateAsync(string ExtendUserId, AbstractUpdateUserViewModel vm);
        
    }
}