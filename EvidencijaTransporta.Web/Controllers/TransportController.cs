using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using EvidencijaTransporta.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
    public class TransportController : Controller
    {
        public Repository Repository { get; set; } = new Repository();
		// GET: Transport
		public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTransports()
        {
            List<TransportModel> models = new List<TransportModel>();

            RequestAllTransports request = new RequestAllTransports
            {
                Id = 1
            };

            List<ResponseAllTransports> transports = Repository.GetListStoredProcedure<ResponseAllTransports, RequestAllTransports>(request);

            foreach (var transport in transports)
            {
                models.Add(new TransportModel
                {
                    Id = transport.Id,
                    Datum = transport.Date,
                    KolicinaTransportneRobe = transport.ShipmentAmount,
                    VrstaTransporta = transport.TypeOfTransport,
                    VrstaVozila = transport.TypeOfVehicle
                });
            }
            return View(models);
        }
    }
}