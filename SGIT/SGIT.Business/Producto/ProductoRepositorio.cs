using SGIT.Model.Producto;

namespace SGIT.Business.Producto
{
    public class ProductoRepositorio
    {
        public static List<ProductoModelo> products = new List<ProductoModelo>();

        public static List<ProductoModelo> ObtenerProductos(int idProducto)
        {
            var query = from x in poblarProductos()
                        select x;
            if (idProducto > 0)
            {
                query = from x in query
                        where x.IdProducto == idProducto
                        select x;
            }
            return query.OrderBy(x => x.IdProducto).ToList();
        }

        public static ProductoModelo BuscarProductoPorDescripcion(string descripcion)
        {
            ProductoModelo producto = new ProductoModelo();
            if (!string.IsNullOrEmpty(descripcion))
            {
                producto = (from x in poblarProductos()
                            where x.Nombre == descripcion
                            select x).First();
            }
            return producto;
        }

        public static int CrearProducto(ProductoRequest request)
        {
            var response = 0;
            if (request != null)
            {
                var producto = ProductoRepositorio.BuscarProductoPorDescripcion(request.Nombre);

                if (producto == null)
                {
                    producto = new ProductoModelo();
                    producto.IdProducto = 6;//Secuencial;
                    producto.Importancia = request.Importancia == 1 ? Importancia.Alta : Importancia.Baja;
                    producto.FechaVencimiento = request.FechaVencimiento;
                    producto.Activo = true;
                    producto.Nombre = request.Nombre;
                    products.Add(producto);
                }
                return response;
            }
            return response;
        }

        private static List<ProductoModelo> poblarProductos()
        {
            var producto = new ProductoModelo();
            producto.IdProducto = 1;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 30);
            producto.Activo = true;
            producto.Nombre = "Item A";
            products.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 2;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 28);
            producto.Activo = true;
            producto.Nombre = "Item B";
            products.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 3;
            producto.Importancia = Importancia.Baja;
            producto.FechaVencimiento = new DateTime(2026, 07, 27);
            producto.Activo = true;
            producto.Nombre = "Item C";
            products.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 4;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 30);
            producto.Activo = true;
            producto.Nombre = "Item D";
            products.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 5;
            producto.Importancia = Importancia.Baja;
            producto.FechaVencimiento = new DateTime(2026, 07, 25);
            producto.Activo = true;
            producto.Nombre = "Item E";
            products.Add(producto);

            return products;
        }
    }
}
