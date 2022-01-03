using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Investment_App.Authorization
{
    public static class ClaimsIdentity
    {
        public static string GetEmailClaimValue(this ClaimsPrincipal user)
        {
            var emailClaim = user.Claims.SingleOrDefault(claim => claim.Type == "email" || claim.Type == ClaimTypes.Email);
            return emailClaim?.Value ?? string.Empty;
        }
    }
}
