using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Interfaces
{
    public interface IRequestRepository
    {
        Task<bool> CreateRequest(Request request);
        Task<IEnumerable<Request>> GetRequests();
        Task<Request> GetRequest(int id);
        Task<bool> DeleteRequest(int id);

    }
}
