using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        // Constructor que recibe el contexto de la base de datos.
        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los teléfonos.
        public async Task<List<Telefono>> GetAllTelefonosAsync()
        {
            return await _context.Telefonos.ToListAsync();
        }

        // Obtener un teléfono por su número.
        public async Task<Telefono> GetTelefonoByIdAsync(string num)
        {
            return await _context.Telefonos.FindAsync(num);
        }

        // Agregar un nuevo teléfono.
        public async Task AddTelefonoAsync(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
        }

        // Actualizar un teléfono existente.
        public async Task UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            await _context.SaveChangesAsync();
        }

        // Eliminar un teléfono por su número.
        public async Task DeleteTelefonoAsync(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }
    }
}
