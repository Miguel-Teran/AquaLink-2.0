using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaLink2._0.Models
{
    public class Reporte
    {
        [Key]
        public int Rep_Id { get; set; }
        public string? Rep_Descripcion { get; set; }
        public DateOnly? Rep_Fecha { get; set; }

        [Column(TypeName = "decimal(18,10)")]
        public decimal Rep_Lat { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        public decimal Rep_Lon { get; set; }

        public int Rep_IdUsu {  get; set; }
    }
}
