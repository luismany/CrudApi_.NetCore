using EjercicioWebApiPlatzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioWebApiPlatzi.Servicios
{
    public class CategoriaServicio: ICategoriaService
    {
        readonly TareasDbContext Context;
        public CategoriaServicio(TareasDbContext dbContext)
        {
            Context = dbContext;
        }

        public async Task Delete(int id)
        {
            var categoriaActual = Context.Categorias.Find(id);
            if(categoriaActual != null)
            {
                Context.Remove(categoriaActual);
                await Context.SaveChangesAsync();
            }
        }

        public IEnumerable<Categoria> Get()
        {
            return Context.Categorias;
        }

        public async Task Post(Categoria categoria)
        {
            Context.Add(categoria);
            await Context.SaveChangesAsync();
        }

        public  async Task Put(int id, Categoria categoria)
        {
            var categoriaActual = Context.Categorias.Find(id);
            if(categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;
            }

            await Context.SaveChangesAsync();
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Post(Categoria categoria);
        Task Put(int id, Categoria categoria);
        Task Delete(int id);
    }
}
