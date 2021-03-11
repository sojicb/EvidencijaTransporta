using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;

namespace EvidencijaTransporta.DataAccess.Models
{
	public abstract class RequestModel<TModel> 
	{
		public string GetClassAttribute()
		{
			DataBaseProcedureNameAttribute attribute = (DataBaseProcedureNameAttribute)Attribute
				.GetCustomAttribute(typeof(TModel), typeof(DataBaseProcedureNameAttribute));

			return attribute.ProcedureName;
		}

		public abstract List<ParameterModel> GetParameters<TType>(TType istance);
	}
}
