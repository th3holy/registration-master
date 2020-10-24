using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registration.models
{
    public class ApplicationUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string fullName { get; set; }
        public string ROLE { get; set; }


    }
}
