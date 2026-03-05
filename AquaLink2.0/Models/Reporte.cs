namespace AquaLink2._0.Models
{
    public class Reporte
    {
        public int Rep_Id { get; set; }
        public string? Rep_Descripcion { get; set; }
        public DateOnly Rep_Fecha { get; set; }
        public decimal Rep_Lat { get; set; }
        public decimal Rep_Lon { get; set; }
        public int Rep_IdUsu {  get; set; }
    }
}
