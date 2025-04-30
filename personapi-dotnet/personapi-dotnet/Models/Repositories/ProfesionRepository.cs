using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        // Constructor que recibe el contexto de la base de datos.
        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // Obtener todas las profesiones.
        public async Task<List<Profesion>> GetAllProfesionesAsync()
        {
            return await _context.Profesions.ToListAsync();
        }

        // Obtener una profesión por su ID.
        public async Task<Profesion> GetProfesionByIdAsync(int id)
        {
            return await _context.Profesions.FindAsync(id);
        }

        // Agregar una nueva profesión.
        public async Task AddProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            await _context.SaveChangesAsync();
        }

        // Actualizar una profesión existente.
        public async Task UpdateProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
            await _context.SaveChangesAsync();
        }

        // Eliminar una profesión por su ID.
        public async Task DeleteProfesionAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetMaxProfesionIdAsync()
        {
            var ids = await _context.Profesions.Select(p => p.Id).ToListAsync();
            return ids.DefaultIfEmpty(0).Max();
        }


    }
}
