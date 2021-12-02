using Microsoft.EntityFrameworkCore;
using Requesting.Interfaces;
using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Data
{
    public class AdminRequestRepository : IAdminRequestRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;

        public AdminRequestRepository(IUserRepository userRepository, DataContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<bool> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
           
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Request> GetRequest(int id)
        {
            return await _context.Requests.Where(r => r.Id == id).Include(r => r.Client).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Request>> GetRequests()
        {
            return await _context.Requests.Include(r => r.Client).ToListAsync();
        }

        public async Task<bool> UpdateRequest(Request request)
        {
            _context.Update(request);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
