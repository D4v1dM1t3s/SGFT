using SGIT.Model.Producto;
using SGIT.Data.Data;

namespace SGIT.Business.Producto
{
    public static class ProductoRepositorio
    {
        public static ProductoModelo? ObtenerProducto(int idProducto)
        {
            using DataContext ctx = new();
            var query = from x in ctx.Productos
                        select x;
            if (idProducto > 0)
            {
                return (from x in query
                        where x.IdProducto == idProducto
                        orderby x.Importancia
                        select new ProductoModelo()
                        {
                            IdProducto = x.IdProducto,
                            Nombre = x.Nombre,
                            Activo = x.Activo,
                            FechaVencimiento = x.FechaVencimiento!.Value,
                            Relevancia = x.Importancia!.Value
                        }).FirstOrDefault();
            }
            return new ProductoModelo();
        }

        /// <summary>
        /// Obtiene listado de productos
        /// </summary>
        /// <returns>ProductoModelo</returns>
        public static List<ProductoModelo> ObtenerProductos()
        {
            using DataContext ctx = new();
            var query = from x in ctx.Productos
                        select x;
            return [.. (from x in query
                        orderby x.Importancia
                        select new ProductoModelo()
                        {
                            IdProducto = x.IdProducto,
                            Nombre = x.Nombre,
                            Activo = x.Activo,
                            FechaVencimiento = x.FechaVencimiento!.Value,
                            Relevancia = x.Importancia!.Value
                        })];
        }

        public static ProductoModelo? BuscarProductoPorDescripcion(string descripcion)
        {
            using DataContext ctx = new();
            var query = from x in ctx.Productos
                        select x;
            if (!string.IsNullOrEmpty(descripcion))
            {
                return (from x in query
                        where x.Nombre.ToUpper().Trim().Equals(descripcion.ToUpper().Trim())
                        orderby x.Importancia
                        select new ProductoModelo()
                        {
                            IdProducto = x.IdProducto,
                            Nombre = x.Nombre,
                            Activo = x.Activo,
                            FechaVencimiento = x.FechaVencimiento!.Value,
                            Relevancia = x.Importancia!.Value
                        }).FirstOrDefault();
            }
            return new ProductoModelo();
        }

        public static ProductoModelo? CrearProducto(ProductoRequest request)
        {
            var response = new ProductoModelo();
            if (request == null)
                return response;

            if (string.IsNullOrEmpty(request.Nombre))
                return response;

            using DataContext ctx = new();
            var producto = (from x in ctx.Productos
                            where x.Nombre.ToUpper().Trim().Equals(request.Nombre.ToUpper().Trim())
                            select x).FirstOrDefault();

            if (producto == null)
            {
                var prd = new Model.Modelos.Producto()
                {
                    Importancia = request.Importancia,
                    Activo = true,
                    FechaVencimiento = request.FechaVencimiento,
                    Nombre = request.Nombre
                };

                ctx.Productos.Add(prd);
                ctx.SaveChanges();

                response = ObtenerProducto(prd.IdProducto);
            }

            return response;
        }
    }
}
