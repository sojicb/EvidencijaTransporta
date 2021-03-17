using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.UPDATE_TRANSPORT_RESERVATION)]
	public class UpdateTransportReservationRequest : RequestModel<UpdateTransportReservationRequest>
	{
		[DataBaseRequestParameterName("Id", SqlDbType.Int)]
		public int Id { get; set; }

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
