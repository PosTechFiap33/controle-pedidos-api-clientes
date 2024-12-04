using CP.Clientes.Domain.Adapters.Repositories;
using CP.Clientes.Domain.Base;
using CP.Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP.Clientes.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
	{
        private readonly CPClientesContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClienteRepository(CPClientesContext context)
        {
            _context = context;
        }

        public Guid Criar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            return cliente.Id;
        }

        public Task<Cliente?> ConsultarPorEmail(string email)
        {
            return _context.Cliente.AsNoTracking().FirstOrDefaultAsync(c => c.Email.Endereco == email);
        }

        public Task<Cliente?> ConsultarPorCpf(string cpf)
        {
            return _context.Cliente.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<ICollection<Cliente>> ListarTodos()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

