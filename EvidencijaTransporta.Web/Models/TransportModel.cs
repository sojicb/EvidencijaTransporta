using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaTransporta.Web.Models
{
	public class TransportModel
	{
		public TransportModel(ResponseAllTransports response)
		{
			Id = response.Id;
			Datum = response.Date;
			VrstaVozila = response.TypeOfVehicle;
			KolicinaTransportneRobe = response.ShipmentAmount;
			VrstaTransporta = response.TypeOfTransport;
		}

		public int Id { get; set; }

		[Display(Name = "Datum")]
		public DateTime Datum { get; set; }

		[Display(Name = "Vrsta Transporta")]
		public string VrstaTransporta { get; set; }

		[Display(Name = "Kolicina Transportne Robe")]
		public string KolicinaTransportneRobe { get; set; }

		[Display(Name = "Vrsta Vozila")]
		public string VrstaVozila { get; set; }
	}
}