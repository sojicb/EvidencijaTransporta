using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace EvidencijaTransporta.DataAccess.Models.GetStorageInformation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.GET_STORAGE_INFORMATION)]
	public class GetStorageInformationRequest : RequestModel<GetStorageInformationRequest>
	{
		[DataBaseRequestParameterName("Id", SqlDbType.Int)]
		public int Id { get; set; }

		public override List<ParameterModel> GetParameters<TType>(TType istance)
		{
			List<ParameterModel> parameters = new List<ParameterModel>();

			foreach (PropertyInfo property in istance.GetType().GetProperties())
			{
				DataBaseRequestParameterNameAttribute attribute = (DataBaseRequestParameterNameAttribute)property.GetCustomAttribute(typeof(DataBaseRequestParameterNameAttribute), false);

				parameters.Add(new ParameterModel
				{
					ParameterName = attribute.AttributeName,
					DbType = attribute.AttributeType,
					Value = property.GetValue(istance)
				});
			}
			return parameters;
		}
	}
}
