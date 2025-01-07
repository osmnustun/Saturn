using Microsoft.AspNetCore.Identity;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Abstract
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateUser(User user, string password);
        Task<IEnumerable<User>> GetUsers();
    }
}
