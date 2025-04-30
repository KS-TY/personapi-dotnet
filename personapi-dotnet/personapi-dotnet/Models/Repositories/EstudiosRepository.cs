using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private readonly PersonaDbContext _context;

        // Constructor que recibe el contexto de la base de datos.
        public EstudiosRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los estudios.
        public async Task<List<Estudios>> GetAllEstudiosAsync()
        {
            return await _context.Estudios.ToListAsync();
        }

        // Obtener un estudio por su ID.
        public async Task<Estudios> GetEstudiosByIdAsync(int id_prof, int cc_per)
        {
            return await _context.Estudios.FindAsync(id_prof, cc_per);
        }

        // Agregar un nuevo estudio.
        public async Task AddEstudiosAsync(Estudios estudios)
        {
            _context.Estudios.Add(estudios);
            await _context.SaveChangesAsync();
        }

        // Actualizar un estudio existente.
        public async Task UpdateEstudiosAsync(Estudios estudios)
        {
            _context.Estudios.Update(estudios);
            await _context.SaveChangesAsync();
        }

        // Eliminar un estudio por su ID.
        public async Task DeleteEstudiosAsync(int id_prof, int cc_per)
        {
            var estudios = await _context.Estudios.FindAsync(id_prof, cc_per);
            if (estudios != null)
            {
                _context.Estudios.Remove(estudios);
                await _context.SaveChangesAsync();
            }
        }
    }
}
