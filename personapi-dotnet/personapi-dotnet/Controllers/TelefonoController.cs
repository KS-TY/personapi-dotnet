using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [Route("telefonos")]
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepo;
        private readonly IPersonaRepository _personaRepo;

        public TelefonoController(ITelefonoRepository telefonoRepo, IPersonaRepository personaRepo)
        {
            _telefonoRepo = telefonoRepo;
            _personaRepo = personaRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var telefonos = await _telefonoRepo.GetAllTelefonosAsync();

            // Asegurarse de que DuenioNavigation esté cargado
            foreach (var telefono in telefonos)
            {
                telefono.DuenioNavigation = await _personaRepo.GetPersonaByCcAsync(telefono.Duenio);
            }

            return View(telefonos);
        }

        // GET: /telefonos/create
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var personas = await _personaRepo.GetAllPersonasAsync();
            ViewBag.Personas = new SelectList(personas.Select(p => new {
                Cc = p.Cc,
                NombreCompleto = p.Nombre + " " + p.Apellido
            }), "Cc", "NombreCompleto");


            return View();
        }


        // POST: /telefonos/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Telefono telefono)
        {
            // Validar si el modelo es válido
            if (!ModelState.IsValid)
            {
                var personas = await _personaRepo.GetAllPersonasAsync();
                ViewBag.Personas = new SelectList(personas.Select(p => new {
                    Cc = p.Cc,
                    NombreCompleto = p.Nombre + " " + p.Apellido
                }), "Cc", "NombreCompleto");

                return View(telefono);
            }

            // Buscar a la persona correspondiente usando el Duenio (Cc)
            var persona = await _personaRepo.GetPersonaByCcAsync(telefono.Duenio);

            if (persona != null)
            {
                telefono.DuenioNavigation = persona;  // Asignar la persona al teléfono
            }

            await _telefonoRepo.AddTelefonoAsync(telefono);
            return RedirectToAction(nameof(Index));
        }


        // GET: /telefonos/edit/{num}
        [HttpGet("edit/{num}")]
        public async Task<IActionResult> Edit(string num)
        {
            var telefono = await _telefonoRepo.GetTelefonoByIdAsync(num);
            if (telefono == null)
            {
                return NotFound();
            }

            // Obtener las personas para llenar el dropdown
            var personas = await _personaRepo.GetAllPersonasAsync();
            ViewBag.Personas = new SelectList(personas.Select(p => new {
                Cc = p.Cc,
                NombreCompleto = p.Nombre + " " + p.Apellido
            }), "Cc", "NombreCompleto");

            return View(telefono);
        }

        // POST: /telefonos/edit/{num}
        [HttpPost("edit/{num}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string num, Telefono telefono)
        {
            // Verificar que el número del teléfono en la URL coincide con el del modelo
            if (num != telefono.Num)
            {
                return BadRequest("El número del teléfono no coincide.");
            }

            // Validar si el modelo es válido
            if (!ModelState.IsValid)
            {
                var personas = await _personaRepo.GetAllPersonasAsync();
                ViewBag.Personas = new SelectList(personas.Select(p => new
                {
                    Cc = p.Cc,
                    NombreCompleto = p.Nombre + " " + p.Apellido
                }), "Cc", "NombreCompleto");

                return View(telefono);
            }

            try
            {
                // Buscar a la persona correspondiente usando el Duenio (Cc)
                var persona = await _personaRepo.GetPersonaByCcAsync(telefono.Duenio);

                if (persona != null)
                {
                    telefono.DuenioNavigation = persona; // Asignar la persona al teléfono
                }

                await _telefonoRepo.UpdateTelefonoAsync(telefono);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Agregar el error al ModelState para depuración
                ModelState.AddModelError("", $"Error al actualizar el teléfono: {ex.Message}");
                var personas = await _personaRepo.GetAllPersonasAsync();
                ViewBag.Personas = new SelectList(personas.Select(p => new
                {
                    Cc = p.Cc,
                    NombreCompleto = p.Nombre + " " + p.Apellido
                }), "Cc", "NombreCompleto");

                return View(telefono);
            }
        }
        // GET: /telefonos/delete/{num}
        [HttpGet("delete/{num}")]
        public async Task<IActionResult> Delete(string num)
        {
            var telefono = await _telefonoRepo.GetTelefonoByIdAsync(num);
            if (telefono == null) return NotFound();

            // Obtener el dueño para mostrar en la vista
            telefono.DuenioNavigation = await _personaRepo.GetPersonaByCcAsync(telefono.Duenio);

            return View(telefono);
        }

        // POST: /telefonos/delete/{num}
        [HttpPost("delete/{num}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string num)
        {
            await _telefonoRepo.DeleteTelefonoAsync(num);
            return RedirectToAction(nameof(Index));
        }

    }
}
