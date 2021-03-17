using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace EvidencijaTransporta.DataAccess.Models.InsertStorageInformation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.INSERT_STORAGE_INFORMATION)]
	public class InsertStorageInformationRequest : RequestModel<InsertStorageInformationRequest>
	{
		[DataBaseRequestParameterName("Amount", SqlDbType.Int)]
		public int Amount { get; set; }

		[DataBaseRequestParameterName("Type", SqlDbType.NVarChar)]
		public string Type { get; set; }

		[DataBaseRequestParameterName("DateStored", SqlDbType.Date)]
		public DateTime DateStored { get; set; }

		[DataBaseRequestParameterName("DateCleared", SqlDbType.Date)]
		public DateTime DateCleared { get; set; }

		[DataBaseRequestParameterName("WarehouseId", SqlDbType.Int)]
		public int WarehouseId { get; set; }

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
