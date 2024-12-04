using CP.Clientes.Domain.Adapters.Repositories;
using CP.Clientes.Domain.Base;
using CP.Clientes.Domain.Entities;

namespace CP.Clientes.Application.UseCases.Clientes
{
    public class CriarClienteUseCase : ICriarClienteUseCase
    {
        private readonly IClienteRepository _repository;

        public CriarClienteUseCase(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Executar(string nome, string cpf, string email)
        {
            var cliente = new Cliente(nome, cpf, email);

            var cpfExiste = await _repository.ConsultarPorCpf(cpf) is not null;

            if (cpfExiste)
                throw new DomainException("Cpf já cadastrado no sistema!");

            var emailExiste = await _repository.ConsultarPorEmail(email) is not null;

            if (emailExiste)
                throw new DomainException("E-mail já cadastrado no sistema!");

            _repository.Criar(cliente);

            await _repository.UnitOfWork.Commit();

            return cliente.Id;
        }
    }
}

