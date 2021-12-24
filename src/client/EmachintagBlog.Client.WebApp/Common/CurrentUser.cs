using EmachintagBlog.Client.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EmachintagBlog.Client.WebApp.Common
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            Claims = _httpContextAccessor.HttpContext.User.Claims;
        }

        private readonly IEnumerable<Claim> Claims;

        public bool IsAuthenticated
        {
            get
            {
                return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public string Email
        {
            get
            {
                if (Claims != null && Claims.Any())
                {
                    return Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                }

                return null;
            }
        }

        public string UserId
        {
            get
            {
                if (Claims != null && Claims.Any())
                {
                    return Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                }

                return null;
            }
        }
    }
}
