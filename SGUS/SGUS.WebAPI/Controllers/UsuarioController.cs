using Microsoft.AspNetCore.Mvc;
using SGUS.Business.Usuario;
using SGUS.Model.Usuario;

namespace SGUS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtener listado de usuarios 1=Saturado; 0=NOSaturado
        /// </summary>
        /// <param name="estado">1=Saturado; 2=NOSaturado: <> = Todos</param>
        /// <returns>IEnumerable</returns>
        [HttpGet]
        [Route("/ObtenerUsuariosPorEstadoAsignacion")]
        public IEnumerable<UsuarioModelo> ObtenerUsuariosPorEstado(int estado)
        {
            var usuarios = UsuarioRepositorio.ObtenerUsuariosPorEstado(estado);
            return usuarios.ToArray();
        }

        /// <summary>
        /// Obtener listado de usuarios
        /// </summary>
        /// <param name="request">idCliente</param>
        /// <returns>IEnumerable</returns>
        [HttpGet]
        [Route("/ObtenerUsuariosPorID")]
        public IEnumerable<UsuarioModelo> ObtenerUsuariosPorID(int idCliente)
        {
            var usuarios = UsuarioRepositorio.ObtenerUsuarioPorID(idCliente);
            return usuarios.ToArray();
        }

        /// <summary>
        /// Asignar item a usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPost(Name = "Usuario/AsignarItemUsuario")]
        public int AsignarItemUsuario([FromBody] AsignarItemRequest request)
        {
            int resultado = UsuarioRepositorio.AsignarItemAUsuario(request);

            return resultado;
        }
    }
}
