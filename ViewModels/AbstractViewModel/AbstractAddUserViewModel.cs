using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AppUser;

namespace RehabilitationSystem.ViewModels.AbstractViewModel
{
    public abstract class AbstractAddUserViewModel
    {   
        public AddAppUser? AppUser { get; set; }
    }
}