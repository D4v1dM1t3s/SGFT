using Microsoft.AspNetCore.Mvc;
using SGIT.Business.Producto;
using SGIT.Model.Producto;

namespace SGIT.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private ILogger<ProductoController> Logger { get; set; }

        public ProductoController(ILogger<ProductoController> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Obtiene el listado de productos
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerProductos")]
        public IEnumerable<ProductoModelo> ObtenerProductos()
        {
            Logger.LogInformation("Obtener listado de productos");
            var usuarios = ProductoRepositorio.ObtenerProductos();
            return usuarios;
        }

        /// <summary>
        /// Obtiene producto por id
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerProductosPorID")]
        public ProductoModelo? ObtenerProductosPorID(int idProducto)
        {
            Logger.LogInformation("Obtener producto por ID");
            var producto = ProductoRepositorio.ObtenerProducto(idProducto);
            return producto;
        }

        /// <summary>
        /// Agrega un nuevo proucto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearProducto")]
        public ProductoModelo? CrearProducto([FromBody] ProductoRequest request)
        {
            Logger.LogInformation("Crear producto nuevo");
            var respuesta = ProductoRepositorio.CrearProducto(request);
            return respuesta;
        }
    }
}
