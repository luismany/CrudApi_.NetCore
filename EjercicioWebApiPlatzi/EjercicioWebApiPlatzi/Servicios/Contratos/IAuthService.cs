using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioWebApiPlatzi.Servicios.Contratos
{
    public interface IAuthService
    {
        public bool ValidateLogin(string username, string password);
        string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez);
    }
}
