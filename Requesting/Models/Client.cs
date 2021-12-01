using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Request Request{ get; set; }
    }
}
