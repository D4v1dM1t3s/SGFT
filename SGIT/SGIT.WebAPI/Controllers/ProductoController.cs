using Microsoft.AspNetCore.Mvc;
using SGIT.Business.Producto;
using SGIT.Model.Producto;

namespace SGIT.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        /// <summary>
        /// Obtiene el listado de productos
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerProductos")]
        public IEnumerable<ProductoModelo> ObtenerProductos()
        {
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
            var respuesta = ProductoRepositorio.CrearProducto(request);
            return respuesta;
        }
    }
}
