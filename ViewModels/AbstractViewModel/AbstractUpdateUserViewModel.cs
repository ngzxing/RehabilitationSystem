using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AppUser;

namespace RehabilitationSystem.ViewModels.AbstractViewModel
{
    public abstract class AbstractUpdateUserViewModel
    {
        public UpdateAppUser? AppUser {get; set;}
    }
}