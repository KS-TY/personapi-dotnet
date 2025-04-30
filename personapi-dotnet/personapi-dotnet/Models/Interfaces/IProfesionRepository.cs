using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IProfesionRepository
    {
        Task<List<Profesion>> GetAllProfesionesAsync();
        Task<Profesion> GetProfesionByIdAsync(int id);
        Task AddProfesionAsync(Profesion profesion);
        Task UpdateProfesionAsync(Profesion profesion);
        Task DeleteProfesionAsync(int id);
        Task<int> GetMaxProfesionIdAsync();

    }
}
