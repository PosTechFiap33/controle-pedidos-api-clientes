using System.Threading.Tasks;

namespace CP.Clientes.Domain.Base
{
    public interface IUnitOfWork
	{
        Task<bool> Commit();
    }
}

