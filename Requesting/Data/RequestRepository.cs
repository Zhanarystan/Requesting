using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Requesting.Interfaces;
using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Requesting.Data
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public RequestRepository(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateRequest(Request request)
        {
            request.Code = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Status = "New";
            
            var currentUser = await _userRepository.GetCurrentUser();
            request.ClientId = currentUser.Id;

            _context.Requests.Add(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Request> GetRequest(int id)
        {
            var currentUser = await _userRepository.GetCurrentUser();

            return await _context.Requests.Where(r => r.Id == id)
                    .Where(r => r.ClientId == currentUser.Id)
                    .Include(r => r.Client)
                    .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Request>> GetRequests()
        {
            var currentUser = await _userRepository.GetCurrentUser();

            if (currentUser == null) return null;

            var requests = await _context.Requests.Where(r => r.ClientId == currentUser.Id).ToListAsync();

            return requests;
        }
    }
}
