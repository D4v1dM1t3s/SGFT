using Microsoft.AspNetCore.Mvc;
using SGUS.Business.Usuario;
using SGUS.Model.Usuario;

namespace SGUS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private ILogger<UsuarioController> Logger { get; set; }

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Obtener listado de usuarios 1=Saturado; 0=NOSaturado
        /// </summary>
        /// <param name="estado">1=Saturado; 2=NOSaturado: <> = Todos</param>
        /// <returns>IEnumerable</returns>
        [HttpGet]
        [Route("ObtenerUsuariosPorEstado")]
        public IEnumerable<UsuarioModelo> ObtenerUsuariosPorEstado(int estado)
        {
            Logger.LogInformation("Obtener Usuarios por estado");
            var usuarios = UsuarioRepositorio.ObtenerUsuariosPorEstado(estado);
            return [.. usuarios];
        }

        /// <summary>
        /// Obtener listado de usuarios
        /// </summary>
        /// <param name="request">idCliente</param>
        /// <returns>IEnumerable</returns>
        [HttpGet]
        [Route("ObtenerUsuarios")]
        public IEnumerable<UsuarioModelo> ObtenerUsuarios()
        {
            Logger.LogInformation("Obtener listado de Usuarios");
            var usuarios = UsuarioRepositorio.ObtenerUsuarios();
            return usuarios;
        }

        /// <summary>
        /// Obtener listado de usuarios
        /// </summary>
        /// <param name="request">idCliente</param>
        /// <returns>IEnumerable</returns>
        [HttpGet]
        [Route("ObtenerUsuarioPorID")]
        public UsuarioModelo? ObtenerUsuarioPorID(int idCliente)
        {
            Logger.LogInformation("Obtener Usuarios por ID");
            var usuarios = UsuarioRepositorio.ObtenerUsuarioPorID(idCliente);
            return usuarios;
        }

        /// <summary>
        /// Asignar item a usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPost]
        [Route("AsignarItemUsuario")]
        public UsuarioModelo? AsignarItemUsuario([FromBody] AsignarItemRequest request)
        {
            Logger.LogInformation("Asignar Item de trabajo a usuario");
            var resultado = UsuarioRepositorio.AsignarItemAUsuario(request);

            return resultado;
        }
    }
}
