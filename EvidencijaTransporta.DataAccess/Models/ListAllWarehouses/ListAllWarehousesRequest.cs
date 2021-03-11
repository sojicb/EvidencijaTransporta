using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;

namespace EvidencijaTransporta.DataAccess.Models.ListAllWarehouses
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_WAREHOUSES)]
	public class ListAllWarehousesRequest : RequestModel<ListAllWarehousesRequest>
	{
		public override List<ParameterModel> GetParameters<TType>(TType istance)
		{
			throw new NotImplementedException();
		}
	}
}
