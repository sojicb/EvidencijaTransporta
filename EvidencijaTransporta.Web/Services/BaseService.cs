using EvidencijaTransporta.DataAccess;

namespace EvidencijaTransporta.Web.Services
{
	public class BaseService
	{
		protected Repository _repository { get; set; }

		public BaseService(Repository repository)
		{
			_repository = repository;
		}
	}
}