using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
    public class WarehouseController : BaseController
    {
        public ActionResult ListAllWarehouses()
        {
            return View(WarehouseService.ListWarehousesService());
        }
    }
}