using EvidencijaTransporta.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class TransportController : BaseController
    {

        //Change to index
        public ActionResult ReservateTransport()
        {
            return View(CreateReservateTransportViewModel());
        }

        /// <summary>
        /// Method that creates a new model of ReservateTransport
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		[HttpPost]
		public ActionResult ReservateTransport(CreateTransportModel model)
		{
            if (ModelState.IsValid)
			{
                TransportService.ReservateTransportService(model);

                return RedirectToAction("ListTransportReservations");
			}

			return View(CreateReservateTransportViewModel());
		}

        /// <summary>
        /// Lists all Transport reservations
        /// </summary>
        /// <returns>View with all Transport Reservations</returns>
        public ActionResult ListTransportReservations()
        {
            return View(TransportService.ListTransportsService());
        }

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
    }
}