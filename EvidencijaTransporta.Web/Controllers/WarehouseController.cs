using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class WarehouseController : BaseController
    {
        public ActionResult Index()
        {
            return View(new WarehouseViewModel(WarehouseService.ListWarehousesService()));
        }

        [HttpGet]
        public ActionResult OpenStoreItems(int Id)
		{
            return PartialView("OpenStoreItems", WarehouseService.GetStorageInformationForWarehouseService(Id));
		}
    }
}