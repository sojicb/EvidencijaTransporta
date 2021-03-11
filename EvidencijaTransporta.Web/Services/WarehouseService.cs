using EvidencijaTransporta.DataAccess;
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

			return response.Select(warehouse => new WarehouseModel(warehouse)).ToList();
		}
	}
}