using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Event;
 
using Pedidos.Infraestructure.EF.Config.WriteConfig;
using Reservas.Domain.Evento;
using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System.Data.Entity;

namespace Pedidos.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Vuelos> Vuelos { get; set; }
       // public virtual DbSet<Producto> Producto { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new VueloWriteConfig();
            modelBuilder.ApplyConfiguration<Vuelos>(pedidoConfig);
           // modelBuilder.ApplyConfiguration<DetallePedido>(pedidoConfig);

            //var productoConfig = new ProductoWriteConfig();
            //modelBuilder.ApplyConfiguration<Producto>(productoConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<VueloCreado>();
            modelBuilder.Ignore<Item_Vuelo_Agregado>();
        }
    }
}
