using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.CreateReservation;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using EvidencijaTransporta.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class TransportController : BaseController
    {
        private CreateTransportModel CreateReservateTransportViewModel(CreateTransportModel model = null)
		{
            CreateTransportModel viewModel = new CreateTransportModel
            {
                TransportTypes = TransportService.GetAllTransportTypesService().Select(transport => new SelectListItem
                {
                    Text = transport.TransportType,
                    Value = transport.Id.ToString()
                })
            };

            return viewModel;
        }

		// GET: Transport
		public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReservateTransport()
        {
            return View(CreateReservateTransportViewModel());
        }

		[HttpPost]
		public ActionResult ReservateTransport(CreateTransportModel model)
		{
            if (ModelState.IsValid)
			{
                TransportService.ReservateTransportService(model);

                return RedirectToAction("ListTransports");
			}

			return View(CreateReservateTransportViewModel());
		}

        public ActionResult ListTransports()
        {
            List<TransportModel> models = TransportService.ListTransportsService();

            return View(models);
        }
    }
}