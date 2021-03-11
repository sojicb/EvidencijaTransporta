using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.ListAllWarehouses
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_WAREHOUSES)]
	public class ListAllWarehousesResponse : IResponseModel
	{
		[DataBeseResponseParameterName("Id")]
		public int Id { get; set; }

		[DataBeseResponseParameterName("Name")]
		public string Name { get; set; }

		[DataBeseResponseParameterName("Capacity")]
		public int Capacity { get; set; }

		[DataBeseResponseParameterName("City")]
		public string City { get; set; }

		[DataBeseResponseParameterName("Country")]
		public string Country { get; set; }

		[DataBeseResponseParameterName("StreetAndNumber")]
		public string StreetAndNumber { get; set; }


		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new ListAllWarehousesResponse
			{
				Id = (int)reader["Id"],
				Name = reader["Name"] as string,
				Capacity = (int)reader["Id"],
				City = reader["City"] as string,
				Country = reader["Country"] as string,
				StreetAndNumber = reader["StreetAndNumber"] as string,
			};
		}
	}
}
