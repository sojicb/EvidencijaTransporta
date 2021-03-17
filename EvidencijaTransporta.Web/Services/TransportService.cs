using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.CreateReservation;
using EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation;
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

		/// <summary>
		/// Gets a list of all transport types from the database
		/// </summary>
		/// <returns>All transportTypes converted into TransportTypeModel</returns>
        public List<TransportTypeModel> GetAllTransportTypesService()
        {
            ListAllTransportTypesRequestModel request = new ListAllTransportTypesRequestModel();

            List<ListAllTransportTypesResponseModel> responseModels = _repository.
                GetListStoredProcedure<ListAllTransportTypesResponseModel, ListAllTransportTypesRequestModel>(request);

            return responseModels.Select(m => new TransportTypeModel(m)).ToList();
        }

		/// <summary>
		/// Updates the row in the table with the given model
		/// </summary>
		/// <param name="model">Model with parameters to be updated in database</param>
		public void UpdateTransportReservationService(CreateTransportModel model)
		{
			UpdateTransportReservationRequest request = new UpdateTransportReservationRequest
			{
				Id = model.Id,
				Date = model.Date,
				ShipmentAmount = model.ShipmentAmount,
				TypeOfTransport = model.SelectedTransportType,
				TypeOfVehicle = model.VehicleType
			};

			_repository.CreateNewModel<UpdateTransportReservationRequest, UpdateTransportReservationResponse>(request);
		}

		/// <summary>
		/// Converts the CreateTransportModel from the view into a request model to be inserted into database
		/// </summary>
		/// <param name="model"></param>
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

		/// <summary>
		/// Gets a list of all transports from the database
		/// </summary>
		/// <returns>All reservedTransports converted into TransportModel</returns>
		public List<TransportModel> ListTransportsService()
		{
			RequestAllTransports request = new RequestAllTransports();

			List<ResponseAllTransports> responseModels = _repository.GetListStoredProcedure<ResponseAllTransports, RequestAllTransports>(request);

			return responseModels.Select(m => new TransportModel(m)).ToList();
		}
	}
}