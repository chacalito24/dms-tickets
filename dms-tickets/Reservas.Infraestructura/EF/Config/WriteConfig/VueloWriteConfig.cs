﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Model.Pedidos.ValueObjects;
using Pedidos.Domain.Model.ValueObjects;
using Pedidos.Domain.ValueObjects;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;

namespace Pedidos.Infraestructure.EF.Config.WriteConfig
{
    public class VueloWriteConfig : IEntityTypeConfiguration<Pedido>,
        IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<Vuelos> builder)
        {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.Id);

            var nroPedidoConverter = new ValueConverter<Nro_Vuelo, string>(
                nroPedidoValue => nroPedidoValue.Value, 
                nroPedido => new NumeroPedido(nroPedido)
            );

            builder.Property(x => x.NroPedido)
                .HasConversion(nroPedidoConverter)
                .HasColumnName("nroPedido")
                .HasMaxLength(6);

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.Total)
                .HasConversion(precioConverter)
                .HasColumnName("total")
                .HasPrecision(12, 2);

            builder.HasMany(typeof(DetallePedido), "_detalle");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Detalle);
            builder.Ignore(x => x.ClienteId);
        }

        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("DetallePedido");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Instrucciones)
               .HasColumnName("instrucciones")
               .HasMaxLength(500);

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.Precio)
                .HasConversion(precioConverter)
                .HasColumnName("precio")
                .HasPrecision(12, 2);

            builder.Property(x => x.SubTotal)
                .HasConversion(precioConverter)
                .HasColumnName("subTotal")
                .HasPrecision(12, 2);

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
                cantidadValue => cantidadValue.Value,
                cantidad => new CantidadValue(cantidad)
            );

            builder.Property(x => x.Cantidad)
                .HasConversion(cantidadConverter)
                .HasColumnName("cantidad");


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
