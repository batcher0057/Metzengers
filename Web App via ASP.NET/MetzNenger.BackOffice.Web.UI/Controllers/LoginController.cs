using MetzNenger.Core.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetzNenger.BackOffice.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        #region Proprieté
        private MetzengerContext _Context { get; set; }
        #endregion
        public LoginController(MetzengerContext _context)
        {
            _Context = _context;
        }

        
        
    }
}
