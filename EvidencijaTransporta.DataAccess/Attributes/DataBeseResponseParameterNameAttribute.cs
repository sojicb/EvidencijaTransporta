using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
	public class DataBeseResponseParameterNameAttribute : Attribute
	{
		public DataBeseResponseParameterNameAttribute(string attributeName)
		{
			AttributeName = attributeName;
		}
		public string AttributeName { get; set; }
	}
}
