using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class ReporteService
    {
        private static List<Reporte> _reportes = new List<Reporte>();

        public async Task<List<Reporte>> Listar() => await Task.FromResult(_reportes);

        public async Task<Reporte?> ObtenerPorId(int id) => _reportes.FirstOrDefault(r => r.Rep_Id == id);

        public async Task Insertar(Reporte nuevo)
        {
            nuevo.Rep_Id = _reportes.Count > 0 ? _reportes.Max(r => r.Rep_Id) + 1 : 1;
            _reportes.Add(nuevo);
        }

        public async Task Actualizar(Reporte modificado)
        {
            var index = _reportes.FindIndex(r => r.Rep_Id == modificado.Rep_Id);
            if (index != -1) _reportes[index] = modificado;
        }

        public async Task Borrar(int id) => _reportes.RemoveAll(r => r.Rep_Id == id);
    }
}

