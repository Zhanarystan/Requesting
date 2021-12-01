using Microsoft.EntityFrameworkCore;
using Requesting.Interfaces;
using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateClient(Client client)
        {

            var newClient = new Client
            {
                FullName = client.FullName,
                PhoneNumber = client.PhoneNumber
            };

            _context.Add(newClient);

            await _context.SaveChangesAsync();

            return newClient.Id;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
