using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Models
{
    public class Request
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
