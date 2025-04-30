using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [Route("profesiones")]
    public class ProfesionesController : Controller
    {
        private readonly IProfesionRepository _profesionRepo;

        public ProfesionesController(IProfesionRepository profesionRepo)
        {
            _profesionRepo = profesionRepo;
        }

        // GET: /profesiones
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var profesiones = await _profesionRepo.GetAllProfesionesAsync();
            return View(profesiones);
        }

        // GET: /profesiones/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /profesiones/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return View(profesion);
            }

            // Asignar ID manualmente
            var maxId = await _profesionRepo.GetMaxProfesionIdAsync();
            profesion.Id = maxId + 1;

            await _profesionRepo.AddProfesionAsync(profesion);
            return RedirectToAction(nameof(Index));
        }


        // GET: /profesiones/edit/{id}
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var profesion = await _profesionRepo.GetProfesionByIdAsync(id);
            if (profesion == null) return NotFound();

            return View(profesion);
        }

        // POST: /profesiones/edit/{id}
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Profesion profesion)
        {
            if (id != profesion.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(profesion);
            }

            await _profesionRepo.UpdateProfesionAsync(profesion);
            return RedirectToAction(nameof(Index));
        }

        // GET: /profesiones/delete/{id}
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesion = await _profesionRepo.GetProfesionByIdAsync(id);
            if (profesion == null) return NotFound();

            return View(profesion);
        }

        // POST: /profesiones/delete/{id}
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesionRepo.DeleteProfesionAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
