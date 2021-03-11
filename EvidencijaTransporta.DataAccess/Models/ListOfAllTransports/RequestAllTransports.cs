using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Models.ListOfAllTransports
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORTS)]
	public class RequestAllTransports : RequestModel<RequestAllTransports>
	{
		public override List<ParameterModel> GetParameters<TType>(TType istance)
		{
			throw new NotImplementedException();
		}
	}
}
