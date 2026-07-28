using SGUS.Data.Data;
using SGUS.Model.Producto;
using SGUS.Model.Usuario;

namespace SGUS.Business.Producto
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
            return (from x in query
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
                    select new ProductoModelo()
                        {
                            IdProducto = x.IdProducto,
                            Nombre = x.Nombre,
                            Activo = x.Activo,
                            FechaVencimiento = x.FechaVencimiento!.Value,
                            Relevancia = x.Importancia!.Value
                    })];
        }

    }
}
