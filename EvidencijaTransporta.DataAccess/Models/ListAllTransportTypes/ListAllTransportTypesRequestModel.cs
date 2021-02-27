using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORT_TYPES)]
	public class ListAllTransportTypesRequestModel : IRequestModel
	{
		public string GetClassAttribute()
		{
			DataBaseProcedureNameAttribute attribute = (DataBaseProcedureNameAttribute)Attribute
				.GetCustomAttribute(typeof(ListAllTransportTypesRequestModel), typeof(DataBaseProcedureNameAttribute));

			return attribute.ProcedureName;
		}

		public List<ParameterModel> GetParameters<TType>(TType istance)
		{
			throw new NotImplementedException();
		}
	}
}
