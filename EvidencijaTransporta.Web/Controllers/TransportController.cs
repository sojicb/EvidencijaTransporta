using EvidencijaTransporta.Web.Models;
using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using System.Linq;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class TransportController : BaseController
    {
        /// <summary>
        /// Lists all Transport reservations
        /// </summary>
        /// <returns>View with all Transport Reservations</returns>
        public ActionResult Index()
        {
            return View(new TransportViewModel(TransportService.ListTransportsService()));
        }

        [ChildActionOnly]
        public ActionResult ReservateTransport(CreateTransportModel model = null)
        {
            return PartialView(CreateReservateTransportViewModel());
        }

        /// <summary>
        /// Method that creates a new model of ReservateTransport
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		[HttpPost]
		public ActionResult CreateReservateTransport(CreateTransportModel model)
		{
            if (ModelState.IsValid)
			{
                TransportService.ReservateTransportService(model);

                return RedirectToAction("Index");
			}

			return View(CreateReservateTransportViewModel());
		}

		public ActionResult FillEditTransport(int id)
		{
			TransportModel transportModel = TransportService.ListTransportsService().Where(x => x.Id == id).FirstOrDefault();

            CreateTransportModel model =  new CreateTransportModel
            {
                Id = transportModel.Id,
                ShipmentAmount = transportModel.KolicinaTransportneRobe,
                Date = transportModel.Datum,
                SelectedTransportType = transportModel.VrstaTransportaId,
                VehicleType = transportModel.VrstaVozila
            };

            return PartialView("ReservateTransport", CreateReservateTransportViewModel(model));
		}

        public ActionResult EditTransport(CreateTransportModel model)
		{
            if (ModelState.IsValid)
            {
                TransportService.UpdateTransportReservationService(model);

                return RedirectToAction("Index");
            }

            return View(CreateReservateTransportViewModel(model));

		}

		[HttpGet]
        public ActionResult Details(int id)
        {
            TransportModel model = TransportService.ListTransportsService().Where(x => x.Id == id).FirstOrDefault();

            return PartialView(model);
        }

        private CreateTransportModel CreateReservateTransportViewModel(CreateTransportModel model = null)
        {
            CreateTransportModel createTransportModel = new CreateTransportModel();

			if (ModelState.IsValid)
			{
                createTransportModel.Id = model.Id;
                createTransportModel.SelectedTransportType = model.SelectedTransportType;
                createTransportModel.Date = model.Date;
                createTransportModel.ShipmentAmount = model.ShipmentAmount;
                createTransportModel.VehicleType = model.VehicleType;
            }

            createTransportModel.TransportTypes = TransportService.GetAllTransportTypesService().Select(transport => new SelectListItem
            {
                Text = transport.TransportType,
                Value = transport.Id.ToString()
            });

            return createTransportModel;
        }
    }
}