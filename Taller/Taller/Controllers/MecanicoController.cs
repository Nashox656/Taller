using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Csql;
using Taller.Models;

namespace Taller.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly MyDbContext _appDbContext;

        public MecanicoController(MyDbContext appDbContext)
        {
            // Constructor del controlador que recibe el contexto de la base de datos
            _appDbContext = appDbContext;
        }

        // METODO GET para listar todos los mecanicos
        [HttpGet]
        [Route("Listar")]
        public IActionResult GetAllMecanicos()
        {
            try
            {
                // Obtiene todos los mecanicos de la base de datos
                var mecanicos = _appDbContext.Mecanicos.ToList();

                if (mecanicos.Count == 0)
                {
                    // Si no hay mecanicos, devuelve un mensaje de NotFound
                    return NotFound("No se encuentran los Mecanicos manito");
                }

                // Retorna la lista exitosamente
                return Ok(mecanicos);
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un mensaje de BadRequest con la información de la excepción
                return BadRequest(ex.Message);
            }
        }

        // METODO GET para listar por id
        [HttpGet("{id}")]
        public IActionResult ListarMecanicos(int id)
        {
            try
            {
                // Busca un mecánico por su ID
                var mecanico = _appDbContext.Mecanicos.SingleOrDefault(m => m.IdMecanico == id);

                if (mecanico == null)
                {
                    // Si no se encuentra un mecánico con el ID proporcionado, devuelve un mensaje de NotFound
                    return NotFound($"No se encontró un Mecanico con el ID {id}.");
                }

                // Retorna el mecánico exitosamente
                return Ok(mecanico);
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un mensaje de BadRequest con la información de la excepción
                return BadRequest($"Error al intentar listar el Mecanico por ID: {ex.Message}");
            }
        }

        // METODO POST Para agregar
        [HttpPost]
        [Route("AgregarMecanico")]
        public IActionResult AgregarMecanico(Mecanicos mecanicos)
        {
            try
            {
                // Agrega un nuevo mecánico a la base de datos
                mecanicos.SueldoTotal = mecanicos.SueldoBase + mecanicos.GratTitulo;
                _appDbContext.Add(mecanicos);
                _appDbContext.SaveChanges();

                // Retorna un mensaje de éxito
                return Ok("Mecanico Agregado MANITO");
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un mensaje de BadRequest con la información de la excepción
                return BadRequest(ex.Message);
            }
        }

        // METODO PUT Para editar
        [HttpPut]
        [Route("Editar/{id}")]
        public IActionResult EditarMecanico(int id, Mecanicos mecanicos)
        {
            if (id == 0)
            {
                // Si el ID no fue proporcionado, devuelve un mensaje de BadRequest
                return BadRequest("El ID del Mecanico no fue proporcionado Manito.");
            }

            var mecanicoAEditar = _appDbContext.Mecanicos.Find(id);
            if (mecanicoAEditar == null)
            {
                // Si no se encuentra el mecánico con el ID proporcionado, devuelve un mensaje de NotFound
                return NotFound($"El Mecanico con ID {id} no existe Manito.");
            }

            try
            {
                // Excluye la propiedad IdMecanico de la actualización
                _appDbContext.Entry(mecanicoAEditar).State = EntityState.Detached;
                mecanicos.IdMecanico = id;

                // Actualiza las demás propiedades del mecánico
                mecanicos.SueldoTotal = mecanicos.SueldoBase + mecanicos.GratTitulo;
                _appDbContext.Entry(mecanicos).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                // Retorna un mensaje de éxito
                return Ok($"Datos del Mecanico con ID {id} actualizados correctamente Manito.");
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un mensaje de BadRequest con la información de la excepción
                return BadRequest($"Error al actualizar los datos del Mecanico Manito. Arreglelo: {ex.Message}");
            }
        }

        // METODO DELETE para eliminar
        [HttpDelete]
        [Route("EliminarMecanico")]
        public IActionResult EliminarMecanico(int id)
        {
            try
            {
                // Busca el mecánico por su ID
                var mecanicos = _appDbContext.Mecanicos.Find(id);
                if (mecanicos == null)
                {
                    // Si no se encuentra el mecánico con el ID proporcionado, devuelve un mensaje de NotFound
                    return NotFound($"No se encuentra el Mecanico con el id: {id} manito");
                }

                // Elimina el mecánico de la base de datos
                _appDbContext.Mecanicos.Remove(mecanicos);
                _appDbContext.SaveChanges();

                // Retorna un mensaje de éxito
                return Ok("Eliminado master.");
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devuelve un mensaje de BadRequest con la información de la excepción
                return BadRequest(ex.Message);
            }
        }
    }
}
