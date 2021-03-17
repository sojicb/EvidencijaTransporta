using EvidencijaTransporta.DataAccess.Models.GetStorageInformation;
using System;

namespace EvidencijaTransporta.Web.Models.WarehouseModels
{
	public class StorageModel
	{
		public StorageModel(GetStorageInformationResponse response)
		{
			Id = response.Id;
			Amount = response.Amount;
			Type = response.Type;
			DateStored = response.DateStored;
			DateCleared = response.DateCleared;
		}

		public int Id { get; set; }
		public int Amount { get; set; }
		public string Type { get; set; }
		public DateTime DateStored { get; set; }
		public DateTime DateCleared { get; set; }
		public int WarehouseId { get; set; }
	}
}