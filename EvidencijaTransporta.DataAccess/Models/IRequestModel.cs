using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Models
{
	public interface IRequestModel
	{
		//int Id { get; set; }
		List<ParameterModel> GetParameters<TType>(TType istance);
		string GetClassAttribute();
	}
}
