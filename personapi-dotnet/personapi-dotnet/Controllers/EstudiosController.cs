using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [Route("estudios")]
    public class EstudiosController : Controller
    {
        private readonly IEstudiosRepository _estudiosRepo;
        private readonly IPersonaRepository _personaRepo;
        private readonly IProfesionRepository _profesionRepo;

        public EstudiosController(IEstudiosRepository estudiosRepo, IPersonaRepository personaRepo, IProfesionRepository profesionRepo)
        {
            _estudiosRepo = estudiosRepo;
            _personaRepo = personaRepo;
            _profesionRepo = profesionRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var estudios = await _estudiosRepo.GetAllEstudiosAsync();

            foreach (var e in estudios)
            {
                e.CcPerNavigation = await _personaRepo.GetPersonaByCcAsync(e.CcPer);
                e.IdProfNavigation = await _profesionRepo.GetProfesionByIdAsync(e.IdProf);
            }

            return View(estudios);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Estudios estudios)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View(estudios);
            }

            estudios.CcPerNavigation = await _personaRepo.GetPersonaByCcAsync(estudios.CcPer);
            estudios.IdProfNavigation = await _profesionRepo.GetProfesionByIdAsync(estudios.IdProf);

            await _estudiosRepo.AddEstudiosAsync(estudios);
            return RedirectToAction(nameof(Index));
        }

        // GET: /estudios/edit/{id_prof}/{cc_per}
        [HttpGet("edit/{id_prof}/{cc_per}")]
        public async Task<IActionResult> Edit(int id_prof, int cc_per)
        {
            // Obtener el estudio por las claves primarias
            var estudios = await _estudiosRepo.GetEstudiosByIdAsync(id_prof, cc_per);
            if (estudios == null)
            {
                return NotFound();
            }

            return View(estudios); // Pasar el estudio a la vista para que se muestre en el formulario
        }

        // POST: /estudios/edit/{id_prof}/{cc_per}
        [HttpPost("edit/{id_prof}/{cc_per}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id_prof, int cc_per, Estudios estudios)
        {
            // Verificar que las claves primarias coinciden entre la URL y el modelo
            if ((id_prof != estudios.IdProf) || (cc_per != estudios.CcPer))
            {
                return BadRequest("Las claves primarias no coinciden. ");
            }

            // Validar si el modelo es válido
            if (!ModelState.IsValid)
            {
                return View(estudios); // Si no es válido, se regresa a la vista para que se corrijan los errores
            }

            try
            {
                // Actualizar solo los campos editables: Fecha y Univer
                var estudioActualizado = await _estudiosRepo.GetEstudiosByIdAsync(id_prof, cc_per);
                if (estudioActualizado != null)
                {
                    // Solo actualizar los campos permitidos
                    estudioActualizado.Fecha = estudios.Fecha; // Actualizar la fecha
                    estudioActualizado.Univer = estudios.Univer; // Actualizar la universidad (univer)

                    // Actualizar el estudio en la base de datos
                    await _estudiosRepo.UpdateEstudiosAsync(estudioActualizado);

                    // Redirigir al índice después de la actualización
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound(); // Si no se encuentra el estudio, devolver NotFound
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al actualizar el estudio: {ex.Message}");
                return View(estudios); // Si ocurre un error, regresar a la vista con el mensaje de error
            }
        }
        // GET: /estudios/delete/{id_prof}/{cc_per}
        [HttpGet("delete/{id_prof}/{cc_per}")]
        public async Task<IActionResult> Delete(int id_prof, int cc_per)
        {
            var estudios = await _estudiosRepo.GetEstudiosByIdAsync(id_prof, cc_per);
            if (estudios == null) return NotFound();

            estudios.CcPerNavigation = await _personaRepo.GetPersonaByCcAsync(estudios.CcPer);
            estudios.IdProfNavigation = await _profesionRepo.GetProfesionByIdAsync(estudios.IdProf);

            return View(estudios);
        }

        // POST: /estudios/delete/{id_prof}/{cc_per}
        [HttpPost("delete/{id_prof}/{cc_per}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id_prof, int cc_per)
        {
            await _estudiosRepo.DeleteEstudiosAsync(id_prof, cc_per);
            return RedirectToAction(nameof(Index));
        }


        

    

        private async Task LoadDropdownsAsync()
        {
            var personas = await _personaRepo.GetAllPersonasAsync();
            var profesiones = await _profesionRepo.GetAllProfesionesAsync();

            ViewBag.Personas = new SelectList(personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = p.Nombre + " " + p.Apellido
            }), "Cc", "NombreCompleto");

            ViewBag.Profesiones = new SelectList(profesiones, "Id", "Nom");
        }
    }
}
