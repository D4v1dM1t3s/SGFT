using SGUS.Model.Producto;
using SGUS.Model.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGUS.Business.Usuario
{
    public class ProductoRepositorio
    {
        public static List<ProductoModelo> ObtenerProducto(int idProducto)
        {
            if (idProducto > 0)
            {
                // si es usuario interno, tiene acceso a todas las areas.
                var query = from x in poblarProductos()
                            select x;
                if (idProducto > 0)
                    query = from x in query
                            where x.IdProducto == idProducto
                            select x;

                return query.OrderBy(x => x.IdProducto).ToList();
            }
            return new List<ProductoModelo>();
        }

        private static List<ProductoModelo> poblarProductos()
        {
            List<ProductoModelo> products = new List<ProductoModelo>();

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
            producto.IdProducto = 1;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 30);
            producto.Activo = true;
            producto.Nombre = "Item D";
            products.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 1;
            producto.Importancia = Importancia.Baja;
            producto.FechaVencimiento = new DateTime(2026, 07, 25);
            producto.Activo = true;
            producto.Nombre = "Item E";
            products.Add(producto);

            return products;
        }
    }
}
