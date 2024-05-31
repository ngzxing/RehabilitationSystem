using Microsoft.AspNetCore.Identity;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.Repository;
using RehabilitationSystem.ViewModels.AbstractViewModel;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.Parent;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RehabilitationSystem.Extensions
{   
    public class UserId{

        public required string AppUserId {get; set;}

        public required string ExtendUserId {get; set;}
            
    }
    public static class UserManagerExtensions
    {   
       
        public static async Task<(string?, string?)> CreateAsync(this UserManager<AppUser> userManager, IExtendUserRepository extendUserRepo ,AbstractAddUserViewModel vm)
        {
            var user = new AppUser
            {
                UserName = vm.AppUser!.Email,
                Email = vm.AppUser!.Email,
                PhoneNumber = vm.AppUser!.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, vm.AppUser!.Password!);
            if(!result.Succeeded) 
                return  (null, string.Join(", ", result.Errors.Select(e => e.Description)));

            var err_msg = await extendUserRepo.AddAsync(user.Id, vm);
            if(err_msg == null)
                return (user.Id, null);
            
            return (null, err_msg);
        }
        public static async Task<string?> CreateAsync(this UserManager<AppUser> userManager,  ParentRepository repo, AddParent addParent)
        {
            var user = new AppUser
            {
                UserName = addParent.AppUser!.Email,
                Email = addParent.AppUser!.Email,
                PhoneNumber = addParent.AppUser!.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, addParent.AppUser!.Password!);
            if(!result.Succeeded) 
                return  string.Join(", ", result.Errors.Select(e => e.Description));

            var err_msg = await repo.AddAsync(addParent, user.Id);
            if(err_msg != null)
                return err_msg;
            
            addParent.AppUserId = user.Id;
            return null;
        }

        public static async Task<(UserId?, string?)> GetCurrentUserId(this ClaimsPrincipal user, IExtendUserRepository extendUser){

            var appUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = user.FindFirstValue(ClaimTypes.Role);
            var ( extendUserId, err_msg ) = await extendUser.GetIdByAppUserId(appUserId!, role!);

            if(err_msg != null)
                return (null, err_msg); 

            return (new UserId{AppUserId = appUserId!, ExtendUserId = extendUserId! }, null);
        }

        public static async Task<string?> UpdateAsync(this UserManager<AppUser> userManager, IExtendUserRepository repo, AbstractUpdateUserViewModel vm, UserId userId)
        {   
            var user = await userManager.FindByIdAsync(userId.AppUserId);
            if(user == null)
                return "User Not Found!";

            user.PhoneNumber = vm.AppUser!.PhoneNumber;
            user.Email = vm.AppUser!.Email;
            user.UserName = vm.AppUser!.Email;
            var result = await userManager.UpdateAsync(user);

            if(!result.Succeeded)
                return string.Join(", ", result.Errors.Select(e => e.Description));
            
            return await repo.UpdateAsync(userId.ExtendUserId, vm);
        }
    }
}
