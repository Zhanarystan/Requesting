using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Interfaces
{
    public interface IUserRepository
    {
        Task<Client> GetCurrentUser();
    }
}
