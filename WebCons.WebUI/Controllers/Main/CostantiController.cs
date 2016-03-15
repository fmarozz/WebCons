using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebCons.WebUI.Utils;

namespace WebCons.WebUI.Controllers
{
    public class CostantiController : Controller
    {

        /// <summary>
        /// Azione per ottenere le costanti lato server (Utils.Costanti) 
        /// in formato javascript (quindi accessibili dai js)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCostanti()
        {
            //tramite reflection ottiene tutti i campi della classe Costanti e li scrive in un dictionary
            var constants = typeof(Costanti)
                .GetFields()
                .ToDictionary(x => x.Name, x => x.GetValue(null));

            //serializza il dictionary in un json
            var json = new JavaScriptSerializer().Serialize(constants);

            //ritorna un documento .js con un unica variabile che contiene le costanti
            return JavaScript("var COSTANTI_SERVER = " + json + ";");
        }

    }
}
