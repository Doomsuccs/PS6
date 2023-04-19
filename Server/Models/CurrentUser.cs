using DOOR.EF.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DOOR.Server.Models
{
    public class CurrentUser : iCurrentUser
    {


        protected readonly IHttpContextAccessor _httpContextAccessor;
        public string UserID { get; set; }
        public string UserName { get; set; }

        public CurrentUser(IHttpContextAccessor httpContextAccessor            )
        {
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor.HttpContext.User.Claims.Count() > 0)
            {
                this.UserID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
