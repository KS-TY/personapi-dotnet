using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [Route("personas")]
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepo;

        public PersonaController(IPersonaRepository personaRepo)
        {
            _personaRepo = personaRepo;
        }

        // GET: /personas
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var personas = await _personaRepo.GetAllPersonasAsync();
            return View(personas);
        }

        // GET: /personas/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /personas/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            await _personaRepo.AddPersonaAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        // GET: /personas/edit/{id}
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var persona = await _personaRepo.GetPersonaByIdAsync(id);
            if (persona == null) return NotFound();

            return View(persona);
        }

        // POST: /personas/edit/{id}
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persona persona)
        {
            if (id != persona.Cc) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            await _personaRepo.UpdatePersonaAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        // GET: /personas/delete/{id}
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _personaRepo.GetPersonaByIdAsync(id);
            if (persona == null) return NotFound();

            return View(persona);
        }

        // POST: /personas/delete/{id}
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Eliminamos sin validaciones adicionales
            await _personaRepo.DeletePersonaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
