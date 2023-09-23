using EjercicioWebApiPlatzi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioWebApiPlatzi.ModelosEstructura
{
    public class TareaEstructura : IEntityTypeConfiguration<Tareas>
    {
        public void Configure(EntityTypeBuilder<Tareas> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Tareas)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Titulo).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.FechaCreacion).IsRequired();
                
                    
        }
    }
}
