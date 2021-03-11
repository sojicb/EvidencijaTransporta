using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Models.CreateReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.RESERVATE_TRANSPORT)]
	public class CreateResevationRequestModel : RequestModel<CreateResevationRequestModel>
	{
		[DataBaseRequestParameterName("Datum", SqlDbType.Date)]
		public DateTime Date { get; set; }

		[DataBaseRequestParameterName("KolicinaTransportneRobe", SqlDbType.NVarChar)]
		public string ShipmentAmount { get; set; }

		[DataBaseRequestParameterName("VrstaVozila", SqlDbType.NVarChar)]
		public string TypeOfVehicle { get; set; }

		[DataBaseRequestParameterName("VrstaTransportaId", SqlDbType.Int)]
		public int TypeOfTransport { get; set; }

		public override List<ParameterModel> GetParameters<TType>(TType istance)
		{
			List<ParameterModel> parameters = new List<ParameterModel>();

			foreach(PropertyInfo property in istance.GetType().GetProperties())
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
