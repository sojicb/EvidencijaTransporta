using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Models.ListOfAllTransports
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORTS)]
	public class RequestAllTransports : IRequestModel
	{
		public int Id { get; set; }

		public string GetClassAttribute()
		{
			DataBaseProcedureNameAttribute attribute = (DataBaseProcedureNameAttribute)Attribute
				.GetCustomAttribute(typeof(RequestAllTransports), typeof(DataBaseProcedureNameAttribute));
			
			return attribute.ProcedureName;
		}

		public List<ParameterModel> GetParameters<TType>(TType istance)
		{
			throw new NotImplementedException();
		}
	}
}
