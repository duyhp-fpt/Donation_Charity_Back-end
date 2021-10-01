using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Admins.dto
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
