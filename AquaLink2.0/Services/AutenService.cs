using AquaLink2._0.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AquaLink2._0.Services
{
    public class AutenService : IAutenService
    {
        public async Task<Usuario?> LoginAsync(string correo, string password)
        {
            await Task.Delay(100);

            if (correo == "admin@agua.com" && password == "1234")
            {
                 //agregar algo como una vista o algo que compruebe que si ingreso que c io
            }

            if (correo == "user@agua.com" && password == "1234")
            {
                //agregar algo como una vista o algo que compruebe que si ingreso que c iox2 version usuario
            }
            return null;
        }

    }
}
