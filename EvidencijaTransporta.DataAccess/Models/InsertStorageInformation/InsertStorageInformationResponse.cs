using EvidencijaTransporta.DataAccess.Attributes;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.InsertStorageInformation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.INSERT_STORAGE_INFORMATION)]
	public class InsertStorageInformationResponse : IResponseModel
	{
		public int Id { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new InsertStorageInformationResponse
			{
				Id = (int)reader["Id"]
			};
		}
	}
}
