using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Authentication
{
    public interface IAuthenticationService
    {
        public string Authenticate(String accessToken);
    }
}
