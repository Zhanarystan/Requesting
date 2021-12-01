using Microsoft.EntityFrameworkCore;
using Requesting.Interfaces;
using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Data
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;

        public RequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRequest(Request request)
        {
            request.Code = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Status = "New";

            _context.Requests.Add(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Request>> GetAllRequests()
        {
            return await _context.Requests.Include(r => r.Client).ToListAsync();
        }

        public async Task<Request> GetRequest(int id)
        {
            return await _context.Requests.Where(r => r.Id == id).Include(r => r.Client).SingleOrDefaultAsync();
        }

        public void UpdateRequest(Request request)
        {
            _context.Update(request);
            _context.SaveChanges();
        }
    }
}
