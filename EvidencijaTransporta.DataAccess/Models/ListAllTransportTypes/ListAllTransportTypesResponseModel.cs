﻿using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORT_TYPES)]
	public class ListAllTransportTypesResponseModel : IResponseModel
	{
		[DataBeseResponseParameterName("Id")]
		public int Id { get; set; }

		[DataBeseResponseParameterName("VrstaPrevoza")]
		public string TransportType { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new ListAllTransportTypesResponseModel
			{
				Id = (int)reader["Id"],
				TransportType = reader["VrstaPrevoza"] as string
			};
		}
	}
}
