using SaffiraCloud.ApplicationCore.Entities;
using SaffiraCloud.ApplicationCore.Interfaces.Repositories;

namespace SaffiraCloud.Infra.Data.Repositories
{
    public class PaisRepository : EFRepository<Pais>, IPaisRepository
    {
    }
}
