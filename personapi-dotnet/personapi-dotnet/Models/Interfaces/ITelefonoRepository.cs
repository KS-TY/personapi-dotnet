using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<List<Telefono>> GetAllTelefonosAsync();
        Task<Telefono> GetTelefonoByIdAsync(string num);
        Task AddTelefonoAsync(Telefono telefono);
        Task UpdateTelefonoAsync(Telefono telefono);
        Task DeleteTelefonoAsync(string num);
    }
}
