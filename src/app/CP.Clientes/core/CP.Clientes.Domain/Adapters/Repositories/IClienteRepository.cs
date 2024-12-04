using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CP.Clientes.Domain.Base;
using CP.Clientes.Domain.Entities;

namespace CP.Clientes.Domain.Adapters.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
	{
		Guid Criar(Cliente cliente);
        Task<Cliente?> ConsultarPorEmail(string email);
        Task<Cliente?> ConsultarPorCpf(string cpf);
        Task<ICollection<Cliente>> ListarTodos();
    }
}

