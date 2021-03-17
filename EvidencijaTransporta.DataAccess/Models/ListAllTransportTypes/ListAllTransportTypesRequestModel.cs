using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;

namespace EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORT_TYPES)]
	public class ListAllTransportTypesRequestModel : RequestModel<ListAllTransportTypesRequestModel>
	{
		public override List<ParameterModel> GetParameters<TType>(TType istance)
		{
			throw new NotImplementedException();
		}
	}
}
