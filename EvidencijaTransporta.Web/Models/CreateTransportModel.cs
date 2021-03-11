using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Models
{
	public class CreateTransportModel
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Date")]
		public DateTime Date { get; set; }

		[Required]
		[Display(Name = "Transport Type")]
		public int SelectedTransportType { get; set; }
		public IEnumerable<SelectListItem> TransportTypes { get; set; }

		[Required]
		[Display(Name = "Shipment Amount")]
		public string ShipmentAmount { get; set;}

		[Required]
		[Display(Name = "Vehicle Type")]
		public string VehicleType { get; set; }
	}
}