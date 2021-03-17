using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using System;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaTransporta.Web.Models
{
	public class TransportModel
	{
		public TransportModel(ResponseAllTransports response)
		{
			Id = response.Id;
			Datum = response.Date;
			VrstaVozila = response.TypeOfVehicle;
			VrstaTransportaId = response.TransportTypeId;
			KolicinaTransportneRobe = response.ShipmentAmount;
			VrstaTransporta = response.TypeOfTransport;
		}

		public int Id { get; set; }

		[Display(Name = "Datum")]
		public DateTime Datum { get; set; }

		[Display(Name = "Vrsta Transporta")]
		public string VrstaTransporta { get; set; }

		[Display(Name = "Vrsta Transporta ID")]
		public int VrstaTransportaId { get; set; }

		[Display(Name = "Kolicina Transportne Robe")]
		public string KolicinaTransportneRobe { get; set; }

		[Display(Name = "Vrsta Vozila")]
		public string VrstaVozila { get; set; }
	}
}