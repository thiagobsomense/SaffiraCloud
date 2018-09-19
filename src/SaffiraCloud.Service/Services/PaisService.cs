using SaffiraCloud.ApplicationCore.Entities;
using SaffiraCloud.ApplicationCore.Interfaces.Repositories;
using SaffiraCloud.ApplicationCore.Interfaces.Services;

namespace SaffiraCloud.Service.Services
{
    public class PaisService : BaseService<Pais>, IPaisService
    {
        public PaisService(IPaisRepository repository) : base(repository)
        {
        }
    }
}
