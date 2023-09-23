using EjercicioWebApiPlatzi.Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioWebApiPlatzi.Servicios
{
    public class AuthService : IAuthService
    {
        public string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez)
        {
            throw new NotImplementedException();
        }

        public bool ValidateLogin(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
