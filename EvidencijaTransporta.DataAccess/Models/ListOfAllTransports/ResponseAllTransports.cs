using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.ListOfAllTransports
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORTS)]
	public class ResponseAllTransports : IResponseModel
	{
		[DataBeseResponseParameterName("Id")]
		public int Id { get ; set; }

		[DataBeseResponseParameterName("Datum")]
		public DateTime Date { get; set; }

		[DataBeseResponseParameterName("KolicinaTransportneRobe")]
		public string ShipmentAmount { get; set; }

		[DataBeseResponseParameterName("VrstaVozila")]
		public string TypeOfVehicle { get; set; }

		[DataBeseResponseParameterName("VrstaPrevoza")]
		public string TypeOfTransport { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new ResponseAllTransports
			{
				Id = (int)reader["Id"],
				ShipmentAmount = reader["KolicinaTransportneRobe"] as string,
				Date = (DateTime)reader["Datum"],
				TypeOfTransport = reader["VrstaPrevoza"] as string,
				TypeOfVehicle = reader["VrstaVozila"] as string
			};
		}
	}
}
