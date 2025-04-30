using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        // Constructor que recibe el contexto de la base de datos.
        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // Obtener todas las personas.
        public async Task<List<Persona>> GetAllPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        // Obtener una persona por su ID.
        public async Task<Persona> GetPersonaByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        // Agregar una nueva persona.
        public async Task AddPersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        // Actualizar una persona existente.
        public async Task UpdatePersonaAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        // Eliminar una persona por su ID.
        public async Task DeletePersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        // Repositorio de Persona
        public async Task<Persona> GetPersonaByCcAsync(int cc)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Cc == cc);
        }

    }
}
