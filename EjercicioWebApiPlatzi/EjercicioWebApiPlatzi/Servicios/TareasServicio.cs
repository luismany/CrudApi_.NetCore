using EjercicioWebApiPlatzi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EjercicioWebApiPlatzi.Servicios
{
    
    public class TareasServicio : ITareasServicio
    {
        readonly TareasDbContext Context;
        public TareasServicio(TareasDbContext dbContext)
        {
            Context = dbContext;
        }

        public async Task Delete(int id)
        {
            var tareaActual = Context.Tareas.Find(id);
            if (tareaActual != null)
            {

                Context.Remove(tareaActual);
                await Context.SaveChangesAsync();
            }
        }

        public IEnumerable<Tareas> Get()
        {
            return Context.Tareas;
        }

        public async Task Post(Tareas tareas)
        {
            Context.Add(tareas);
            await Context.SaveChangesAsync();
        }

        public async Task Put(int id, Tareas tareas)
        {
            var tareaActual = Context.Tareas.Find(id);
            if(tareaActual != null)
            {
                tareaActual.Titulo = tareas.Titulo;
                tareaActual.Descripcion = tareas.Descripcion;
                tareaActual.FechaCreacion = tareas.FechaCreacion;

               await Context.SaveChangesAsync();
            }
        }
    }

    public interface ITareasServicio
    {
        IEnumerable<Tareas> Get();
        Task Post(Tareas tareas);
        Task Put(int id, Tareas tareas);
        Task Delete(int id);
    }

}
