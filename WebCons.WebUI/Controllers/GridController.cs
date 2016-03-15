using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cruisenet.Audit.Mit.Web.Mapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WebCons.Data;
 

namespace WebCons.WebUI.Controllers
{
    public class GridController : Controller
    {
        private readonly IRepository<Movimenti> repository;
        
        public GridController(IRepository<Movimenti> repository )
        {
            this.repository = repository;
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            var model = repository.FindAll().Select(x => x.ToViewModel<Movimenti, MovimentiViewModel>());
            return Json(model.ToDataSourceResult(request));
        }

        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, MovimentiViewModel viewModel )
        {
            if (viewModel != null && ModelState.IsValid)
            {
                repository.Save(viewModel.ToEntity<MovimentiViewModel, Movimenti>());
            }

            return Json(new[] { viewModel }.ToDataSourceResult(request, ModelState));
        }

         [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, MovimentiViewModel viewModel)
        {
            if (viewModel != null && ModelState.IsValid)
            {
                Movimenti movimenti = repository.FindById(viewModel.Id);
                repository.Update(movimenti.UpdateFromViewModel(viewModel));
            }
            return Json(new[] { viewModel }.ToDataSourceResult(request, ModelState));
        }

         [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, Movimenti product)
        {
            if (product != null)
            {
                repository.Delete(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

    }

}
