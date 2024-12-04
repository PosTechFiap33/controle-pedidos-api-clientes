using CP.Clientes.Application.DTOs;

namespace CP.Clientes.Application.UseCases.Clientes
{
    public interface IListarTodosClientesUseCase
	{
		Task<ICollection<ClienteDTO>> Executar();
	}
}

