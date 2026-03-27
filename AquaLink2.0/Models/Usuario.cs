using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaLink2._0.Models
{
    public class Usuario
    {
        public int Usu_Id { get; set; }

        public string? Usu_Nombre { get; set; }

        public string? Usu_Correo { get; set; }

        public string? Usu_Telefono { get; set; }

        public int Usu_IdRol {  get; set; }

        public string? Usu_Password { get; set; }
    }
}
