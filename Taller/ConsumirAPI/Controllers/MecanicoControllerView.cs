using ConsumirAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace ConsumirAPI.Controllers
{
    public class MecanicoControllerView : Controller
    {
        private readonly HttpClient _client;

        public MecanicoControllerView()
        {
            // Configuración de la dirección base de la API
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7299/api")
            };
        }

        // ListarMecanicos - Acción para mostrar la lista de mecánicos
        public async Task<IActionResult> ListarMecanicos()
        {
            // Inicializar lista de mecánicos
            List<MecanicoViewModel> mecanicos = new List<MecanicoViewModel>();

            // Obtener la lista de mecánicos desde la API
            HttpResponseMessage response = await _client.GetAsync("/MecanicoController/Listar");

            // Procesar la respuesta y llenar la lista de mecánicos
            if (response.IsSuccessStatusCode)
            {
                mecanicos = await response.Content.ReadFromJsonAsync<List<MecanicoViewModel>>();
            }

            // Mostrar la vista con la lista de mecánicos
            return View(mecanicos);
        }

        // AgregarMecanico - Acción para mostrar el formulario de creación
        public IActionResult AgregarMecanico()
        {
            return View();
        }

        // AgregarMecanico (POST) - Acción para procesar el formulario de creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarMecanico(MecanicoViewModel mecanico)
        {
            // Validar el modelo y agregar el mecánico a través de la API
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("/MecanicoController/AgregarMecanico", mecanico);

                // Redirigir a la acción ListarMecanicos en caso de éxito
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListarMecanicos");
                }
            }

            // Mostrar la vista con el formulario en caso de error
            return View(mecanico);
        }

        // EditarMecanico - Acción para mostrar el formulario de edición
        public async Task<IActionResult> EditarMecanico(int? id)
        {
            // Validar si se proporcionó un ID válido
            if (id == null)
            {
                return NotFound();
            }

            // Obtener el mecánico desde la API
            HttpResponseMessage response = await _client.GetAsync($"/MecanicoController/ListarMecanicos/{id}");

            // Procesar la respuesta y mostrar la vista con el mecánico para editar
            if (response.IsSuccessStatusCode)
            {
                var mecanico = await response.Content.ReadFromJsonAsync<MecanicoViewModel>();
                return View(mecanico);
            }

            // Mostrar error si no se encuentra el mecánico
            return NotFound();
        }

        // EditarMecanico (POST) - Acción para procesar el formulario de edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarMecanico(int id, MecanicoViewModel mecanico)
        {
            // Validar si el ID del mecánico coincide
            if (id != mecanico.IdMecanico)
            {
                return NotFound();
            }

            // Validar el modelo y actualizar el mecánico a través de la API
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PutAsJsonAsync($"/MecanicoController/Editar/{id}", mecanico);

                // Redirigir a la acción ListarMecanicos en caso de éxito
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListarMecanicos");
                }
            }

            // Mostrar la vista con el formulario en caso de error
            return View(mecanico);
        }

        // EliminarMecanico - Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> EliminarMecanico(int? id)
        {
            // Validar si se proporcionó un ID válido
            if (id == null)
            {
                return NotFound();
            }

            // Obtener el mecánico desde la API
            HttpResponseMessage response = await _client.GetAsync($"/MecanicoController/ListarMecanicos/{id}");

            // Procesar la respuesta y mostrar la vista con el mecánico para confirmar la eliminación
            if (response.IsSuccessStatusCode)
            {
                var mecanico = await response.Content.ReadFromJsonAsync<MecanicoViewModel>();
                return View(mecanico);
            }

            // Mostrar error si no se encuentra el mecánico
            return NotFound();
        }

        // EliminarMecanico (POST) - Acción para procesar la eliminación
        [HttpPost, ActionName("EliminarMecanico")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminarMecanico(int id)
        {
            // Eliminar el mecánico a través de la API
            HttpResponseMessage response = await _client.DeleteAsync($"/MecanicoController/EliminarMecanico/{id}");

            // Redirigir a la acción ListarMecanicos en caso de éxito
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListarMecanicos");
            }

            // Mostrar error si no se pudo eliminar el mecánico
            return NotFound();
        }
    }
}
