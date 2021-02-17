using EvidencijaTransporta.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EvidencijaTransporta.DataAccess
{
	public class Repository
	{
		private readonly string _connectionString = ConfigurationManager.ConnectionStrings["IP_PK2020Usluge3"].ConnectionString;

		public TResponse GetModelStoredProcedure<TResponse, TRequest>(TRequest request)
			where TResponse : new()
			where TRequest : new()
		{
			return new TResponse();
		}

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

					return new TResponse();
				}
			}
		}
	}
}
