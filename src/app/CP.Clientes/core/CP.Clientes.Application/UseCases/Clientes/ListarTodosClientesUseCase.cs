using CP.Clientes.Application.DTOs;
using CP.Clientes.Domain.Adapters.Repositories;

namespace CP.Clientes.Application.UseCases.Clientes
{
    public class ListarTodosClientesUseCase : IListarTodosClientesUseCase
	{
		private readonly IClienteRepository _repository;

        public ListarTodosClientesUseCase(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ClienteDTO>> Executar()
        {
            var clientes = await _repository.ListarTodos();
            return clientes.Select(c => new ClienteDTO(c.Nome, c.Cpf.Numero, c.Email.Endereco))
                           .ToList();
        }              
    }
}

