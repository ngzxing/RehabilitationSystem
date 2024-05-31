using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface IExtendedUser
    {
        Task<string?> GetIdByAppUserIdAsync(string appUserId);
    }
}