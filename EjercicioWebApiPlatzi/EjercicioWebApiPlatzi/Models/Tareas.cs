using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioWebApiPlatzi.Models
{
    public class Tareas
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        //public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }
        public string Resumen { get; set; }
    }

   /* public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
   */

}
