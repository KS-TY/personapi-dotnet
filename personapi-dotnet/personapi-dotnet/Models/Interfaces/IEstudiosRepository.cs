using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IEstudiosRepository
    {
        Task<List<Estudios>> GetAllEstudiosAsync();
        Task<Estudios> GetEstudiosByIdAsync(int id_prof, int cc_per);
        Task AddEstudiosAsync(Estudios estudios);
        Task UpdateEstudiosAsync(Estudios estudios);
        Task DeleteEstudiosAsync(int id_prof, int cc_per);
    }
}
