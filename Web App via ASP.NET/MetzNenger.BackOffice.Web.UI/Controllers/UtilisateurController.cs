using MetzNenger.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Otherscript;

namespace MetzNenger.BackOffice.Web.UI.Controllers
{
    public class UtilisateurController : Controller
    {
        #region Champs privés
        private MetzengerContext _context ;
        #endregion
        #region Contruscteur
        public UtilisateurController(MetzengerContext _context)
        {
            this._context = _context;
        }
        #endregion
        #region Méthode publique
        /// <summary>
        /// methode qui permet de crée une page web ....
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public ActionResult Create(UserAccount utilisateur)
        {
            this._context.UserAccounts.Add(utilisateur);
            this._context.SaveChanges();
            return this.View();
        }
        /// <summary>
        /// on crée un utilisateur null puis on lui met un useracount qui est egal à l'id  qu'on passe en paramettre
        /// de la methode.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            UserAccount utilisateur = null;
            utilisateur = this._context.UserAccounts.First(item => item.AccountId == id);
            return this.View(utilisateur);
        }
        [HttpPost]
        public ActionResult Edit(UserAccount utilisateur)
        {
            // 1er facon de modifier: modifie tout
            //this._context.UserAccounts.Update(utilisateur);
            //2eme methode : attach permet de "suivre un objet" puis apres on utilise entry afin de recupere les donné de la classe suivie et on 
            //check si il y a eu des modification en sommes la 2eme methode permet de bien gerer les champ qu'on peut modifier ou non ....
            this._context.Attach<UserAccount>(utilisateur);
            this._context.Entry(utilisateur).Property(item => item.Nickname).IsModified = true;
            this._context.SaveChanges();
            return this.View(utilisateur);
        }
        public ActionResult Login()
        {

            return this.View();
        }
        [HttpPost]
        public ActionResult Check(IFormCollection form)
        {
            string email = ToolBox.HashString(form["emailInput"]);
            string password = ToolBox.HashString(form["passwordInput"]);
            
            if (this._context.UserAccounts.Where(u=>u.Email==email && u.Password==password && u.IsValidated).Any())
            {
                UserAccount user = this._context.UserAccounts.Where(u => u.Email == email && u.Password == password && u.IsValidated).First();
                this.ViewBag.UserListToValidate=this._context.UserAccounts.Where(u =>u.IsValidated==false).ToList();
                this.ViewBag.Channels = this._context.Channels.ToList();
                return this.View(user);
            }
            else
            {
                //pour renvoyer vers une methode "actionResult"
                return RedirectToAction(nameof(Login)) ;
            }
            

            
        }
        #endregion
    }
}
