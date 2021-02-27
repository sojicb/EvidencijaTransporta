using EvidencijaTransporta.DataAccess.Models;
using EvidencijaTransporta.Common.HelperModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess
{
	public class Repository
	{
		private readonly string _connectionString = ConfigurationManager.ConnectionStrings["IP_PK2020Usluge3"].ConnectionString;

		public List<TResponse> GetListStoredProcedure<TResponse, TRequest>(TRequest request)
			where TResponse : IResponseModel, new()
			where TRequest : IRequestModel, new()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = request.GetClassAttribute();
					command.CommandType = CommandType.StoredProcedure;

					List<TResponse> response = new List<TResponse>();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							response.Add((TResponse)new TResponse().MapToObject(reader));
						}
					}
					return response;
				}
			}
		}

		public TResponse CreateNewModel<TRequest, TResponse>(TRequest request)
			where TResponse : IResponseModel, new()
			where TRequest : IRequestModel, new()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = request.GetClassAttribute();
					command.CommandType = CommandType.StoredProcedure;

					foreach(ParameterModel parameter in request.GetParameters(request))
					{
						command.Parameters.Add(parameter.ParameterName, parameter.DbType);
						command.Parameters[parameter.ParameterName].Value = parameter.Value;
					}

					TResponse response = new TResponse();

					using(SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							response.MapToObject(reader);
						}
					}

					return response;
				}
			}
		}
	}
}
