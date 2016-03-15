using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCons.WebUI.Utils
{
    public static class SessionUtil
    {
        public static SessionData GetSessionObject_DATA(this HttpContext current)
        {
            return current != null ? current.Session[Costanti.NOME_OGGETTO_SESSIONE_DATI] as SessionData : null;
        }
    }
}