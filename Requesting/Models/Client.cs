using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Models
{
    public class Client : IdentityUser
    {  
        public virtual IEnumerable<Request> Requests { get; set; }
    }
}
