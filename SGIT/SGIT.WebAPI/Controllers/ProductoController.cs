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
        [Route("/ObtenerProductos")]
        public IEnumerable<ProductoModelo> ObtenerProductos()
        {
            var usuarios = ProductoRepositorio.ObtenerProductos(0);
            return usuarios.ToArray();
        }

        /// <summary>
        /// Obtiene producto por id
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        [Route("/ObtenerProductosPorID")]
        [HttpGet]
        public ProductoModelo ObtenerProductosPorID(int idProducto)
        {
            var producto = ProductoRepositorio.ObtenerProductos(idProducto);
            return producto.First();
        }

        /// <summary>
        /// Agrega un nuevo proucto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("/CrearProducto")]
        [HttpPost]
        public int CrearProducto([FromBody] ProductoRequest request)
        {
            var respuesta = ProductoRepositorio.CrearProducto(request);
            return respuesta;
        }
    }
}
