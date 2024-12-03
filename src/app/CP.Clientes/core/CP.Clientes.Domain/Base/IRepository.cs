using System;

namespace CP.Clientes.Domain.Base
{
    public interface IRepository<T> : IDisposable where T: IAggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
	}
}