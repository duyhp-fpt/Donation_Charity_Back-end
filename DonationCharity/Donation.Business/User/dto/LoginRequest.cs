using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.User.dto
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
