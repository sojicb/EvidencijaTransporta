using System.ComponentModel.DataAnnotations;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;

namespace EvidencijaTransporta.Web.Models.WarehouseModels
{
	public class WarehouseModel
	{
		public WarehouseModel(ListAllWarehousesResponse response)
		{
			Id = response.Id;
			Name = response.Name;
			Capacity = response.Capacity;
			City = response.City;
			Country = response.Country;
			StreetAndNumber = response.StreetAndNumber;
		}

		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Capacity")]
		public int Capacity { get; set; }

		[Display(Name = "City")]
		public string City { get; set; }

		[Display(Name = "Country")]
		public string Country { get; set; }

		[Display(Name = "StreetAndNumber")]
		public string StreetAndNumber { get; set; }
	}
}