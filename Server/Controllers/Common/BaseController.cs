using DOOR.EF.Data;
using Microsoft.AspNetCore.Mvc;
using DOOR.Shared.Utils;
using DOOR.Server.Models;
using System.Security.Principal;

namespace DOOR.Server.Controllers.Common
{
    public class BaseController : Controller
    {

        protected DOOROracleContext _context;
        protected readonly OraTransMsgs _OraTranslateMsgs;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly iCurrentUser _CurrUser;
        protected readonly IIdentity _IIdentity;

        public BaseController(DOOROracleContext DBcontext,
            IHttpContextAccessor httpContextAccessor,                     
            OraTransMsgs _OraTransMsgs)
        {
            _context = DBcontext;
            _httpContextAccessor = httpContextAccessor;
            _OraTranslateMsgs = _OraTransMsgs;
          
            _CurrUser = new CurrentUser(httpContextAccessor);
        }
    }
}
