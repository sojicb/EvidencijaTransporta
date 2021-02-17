using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
	public class DataBaseRequestParameterNameAttribute : Attribute
	{
		public DataBaseRequestParameterNameAttribute(string attributeName, SqlDbType attributeType)
		{
			AttributeName = attributeName;
			AttributeType = attributeType;
		}

		public string AttributeName { get; set; }
		public SqlDbType AttributeType { get; set; }
	}
}
