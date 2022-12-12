using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestor_de_gastos.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            builder.HasIndex(p => p.Nome)
                .IsUnique();
        }
    }
}