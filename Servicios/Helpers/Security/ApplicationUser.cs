using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Helpers.Security
{
    public class ApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor; 
        }

        public int Id => this.GetUserId();

        private int GetUserId()
        {
            var identity = _httpContextAccessor.HttpContext.User.Claims;
            var sid = int.Parse(identity.Where(c => c.Type == ClaimTypes.PrimarySid)
                        .Select(c => c.Value).SingleOrDefault());
            return sid;
        }


    }
}
