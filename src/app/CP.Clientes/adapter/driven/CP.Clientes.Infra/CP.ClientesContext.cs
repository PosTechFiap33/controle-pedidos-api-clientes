using System.ComponentModel.DataAnnotations;
using CP.Clientes.Domain.Base;
using CP.Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP.Clientes.Infra
{
    public class CPClientesContext : DbContext, IUnitOfWork
    {
        public CPClientesContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        
        public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Produto> Produto { get; set; }
        //public DbSet<Pedido> Pedido { get; set; }
        //public DbSet<PedidoPagamento> Pagamento { get; set; }
        //public DbSet<PedidoStatus> PedidoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CPClientesContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }
}