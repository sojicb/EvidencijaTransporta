using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.GetStorageInformation;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;
using EvidencijaTransporta.Web.Models.WarehouseModels;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.Web.Services
{
	public class WarehouseService
	{
		//TODO ADD base service
		private readonly Repository _repository;

		public WarehouseService(Repository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Gets a list of all warehouses from the database
		/// </summary>
		/// <returns>All warehouse responses converted into WarehouseModel</returns>
		public List<WarehouseModel> ListWarehousesService()
		{
			List<ListAllWarehousesResponse> response = _repository.
				GetListStoredProcedure<ListAllWarehousesResponse, ListAllWarehousesRequest>(new ListAllWarehousesRequest());

			//Learn this shit
			return response?.Select(warehouse => new WarehouseModel(warehouse)).ToList() 
				?? Enumerable.Empty<WarehouseModel>().ToList();
		}

		/// <summary>
		/// Gets all storage information for a given warehouse
		/// </summary>
		/// <param name="id">warehouse id</param>
		/// <returns>List of all information or epmty list if there is no rows in the database</returns>
		public List<StorageModel> GetStorageInformationForWarehouseService(int id)
		{
			GetStorageInformationRequest request = new GetStorageInformationRequest
			{
				Id = id
			};

			List<GetStorageInformationResponse> response = _repository.
				GetListStoredProcedureWithParameters<GetStorageInformationResponse, GetStorageInformationRequest>(request);

			return response?.Select(information => new StorageModel(information)).ToList()
				?? Enumerable.Empty<StorageModel>().ToList();
		}
	}
}