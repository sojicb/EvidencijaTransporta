using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.DataAccess.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class DataBaseProcedureNameAttribute : Attribute
	{
		public DataBaseProcedureNameAttribute(string procedureName)
		{
			ProcedureName = procedureName;
		}

		public string ProcedureName { get; set; }
	}
}
