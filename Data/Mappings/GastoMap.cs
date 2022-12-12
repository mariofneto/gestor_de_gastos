using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestor_de_gastos.Data.Mappings
{
    public class GastoMap : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("Gasto");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            
            builder.Property(g => g.Preco)
                .IsRequired()
                .HasColumnName("Preco")
                .HasColumnType("SMALLMONEY");

            builder.HasOne( g => g.Pessoa)
                .WithMany( p => p.Gastos)
                .HasConstraintName("FK_Gastos_Pessoa")
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}