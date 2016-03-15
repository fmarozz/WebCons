using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCons.WebUI.Utils
{
    public class Costanti
    {
        #region "ACTION"
        public const string ACTION_Filters = "Index";
        public const string ACTION_Grid = "Index";
        public const string ACTION_UpdateGrid = "UpdateGrid";
        public const string ACTION_RiPopola = "RiPopola";
        public const string ACTION_UpdateContesto = "UpdateContesto";
        #endregion

        #region "CODICI ERRORE CUSTOM"
        public const int COD_ErroreCustomCookie = 1;
        public const int COD_ErroreCustomNearUser = 2;
        #endregion

        #region "CONTROLLER & ACTION"
        public const string CONTROLLER_Filters = "Filters";
        public const string CONTROLLER_FiltriPopup = "FiltriPopup";
        public const string CONTROLLER_Grid = "Grid";
        #endregion

        #region "LINK"
        public const string LINK_RADICE = "/WebCons";
        public const string LINK_ERROR_Error = LINK_RADICE + "/Error/Error/";
        #endregion

        #region "LOG"
        //Costante nome applicazione utilizzata per LOG
        public const string NOME_APPLICAZIONE = "Portale WebCons";
        #endregion

        #region "SESSIONE"
        public const string NOME_OGGETTO_SESSIONE_DATI = "SessionData_WebCons";
        public const string NOME_OGGETTO_SESSIONE_UTENTE = "SessionUser";
        #endregion

        #region "VIEW"
        public const string VIEW_AccessoNegato = "~/Views/Main/AccessoNegato.cshtml";
        public const string VIEW_FiltriPopup = "~/Views/Filters/FiltriPopup.cshtml";
        public const string VIEW_Grid =  "~/Views/Grid/Index.shtml";
        #endregion

    }
}