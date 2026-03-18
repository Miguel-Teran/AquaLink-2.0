using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class IAutenService
    {
        public interface Usuario
        {
            Task<Usuario?> LoginAsync(string correo, string password);
        }
    }
}
