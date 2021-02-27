using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.CreateReservation;
using EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using EvidencijaTransporta.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.Web.Services
{
	public class TransportService
	{
        private readonly Repository _repository;

		public TransportService(Repository repository)
		{
            _repository = repository;
		}

        public List<TransportTypeModel> GetAllTransportTypesService()
        {
            ListAllTransportTypesRequestModel request = new ListAllTransportTypesRequestModel();

            List<ListAllTransportTypesResponseModel> responseModels = _repository.
                GetListStoredProcedure<ListAllTransportTypesResponseModel, ListAllTransportTypesRequestModel>(request);

            return responseModels.Select(m => new TransportTypeModel(m)).ToList();
        }

        public void ReservateTransportService(CreateTransportModel model)
		{
			CreateResevationRequestModel transport = new CreateResevationRequestModel
			{
				Date = model.Date,
				ShipmentAmount = model.ShipmentAmount,
				TypeOfTransport = model.SelectedTransportType,
				TypeOfVehicle = model.VehicleType
			};

			CreateReservationResponseModel response = _repository
				.CreateNewModel<CreateResevationRequestModel, CreateReservationResponseModel>(transport);
		}

		public List<TransportModel> ListTransportsService()
		{
			RequestAllTransports request = new RequestAllTransports();

			List<ResponseAllTransports> responseModels = _repository.GetListStoredProcedure<ResponseAllTransports, RequestAllTransports>(request);

			return responseModels.Select(m => new TransportModel(m)).ToList();
		}
    }
}