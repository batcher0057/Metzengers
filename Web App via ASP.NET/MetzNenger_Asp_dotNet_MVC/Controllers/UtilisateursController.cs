using MetzNenger.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetzNenger.Web.UI.Controllers
{
    public class UtilisateursController : Controller
    {
        //private readonly MetzengerContext _context = null;
        //public UtilisateursController(MetzengerContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index([FromServices]MetzengerContext _context)
        {
            ViewBag.MonTitre = "Utilisateurs";
            var query = from item in _context.UserAccounts 
                        select item;

            return View(query.ToList());
        }
    }
}
