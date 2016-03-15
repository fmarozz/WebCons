using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Cruisenet.Audit.Mit.Web.Mapper;
using WebCons.Data;
using WebCons.WebUI.Models;
using WebCons.WebUI.Utils;

namespace WebCons.WebUI.Controllers
{
    public class MainController : Controller
    {
        
        
        private readonly IRepository<Risorsa> repositoryRisorsa;
        private readonly IRepository<Fase> repositoryFase;
        private readonly IRepository<Presidio> repositoryPresidio;
        private readonly IRepository<Progetto> repositoryProgetto;
        private readonly IRepository<Unita> repositoryUnita;
        public MainController(IRepository<Risorsa> repositoryRisorsa, 
            IRepository<Fase> repositoryFase, IRepository<Presidio> repositoryPresidio, 
            IRepository<Progetto> repositoryProgetto, IRepository<Unita> repositoryUnita, ISessionManager sessionManager)
        {
            this.repositoryFase = repositoryFase;
            this.repositoryRisorsa = repositoryRisorsa;
            this.repositoryPresidio = repositoryPresidio;
            this.repositoryProgetto = repositoryProgetto;
            this.repositoryUnita = repositoryUnita;
        }
        public ActionResult Index(string username, string password)
        {
            SessionData sessionData = SessionUtil.GetSessionObject_DATA(System.Web.HttpContext.Current);
            UtilsDAO uDAO = new UtilsDAO();
            MainModel model = new MainModel();

            if (username != null || password != null)
            {
                if (!sessionData.UserParameters.UserIsLogged)
                {
                    #region Init Auth
                    model.UserIsLogged = uDAO.UserIsAutenticato(username, password);

                    if (model.UserIsLogged)
                        sessionData.UserParameters.User = username;
                    else
                        model.UserOrPasswordIncorrect = true;

                    sessionData.UserParameters.UserIsLogged = model.UserIsLogged;
                    #endregion
                }
                else
                {
                    #region Load Auth
                    model.UserIsLogged = sessionData.UserParameters.UserIsLogged;
                    #endregion
                }
                model.Username = sessionData.UserParameters.User;
                model.Nominativo = sessionData.UserParameters.Nome + " " + sessionData.UserParameters.Cognome;
            }

            ViewData["Risorsa_Data"] = repositoryRisorsa.FindAll();
            ViewData["Fase_Data"] =  repositoryFase.FindAll();
            ViewData["Progetto_Data"] = repositoryProgetto.FindAll();
            ViewData["Presidio_Data"] = repositoryPresidio.FindAll();
            ViewData["Unita_Data"] =  repositoryUnita.FindAll();
            return View(model);
        }

        public ActionResult Logout()
        {
            SessionData sessionData = SessionUtil.GetSessionObject_DATA(System.Web.HttpContext.Current);
            MainModel model = new MainModel();

            sessionData.UserParameters.UserIsLogged = false;
            model.UserIsLogged = false;

            return View("~/Views/Main/Index.cshtml", model);
        }
    }
}
