using SGUS.Model.Producto;
using SGUS.Model.Usuario;
using System.Collections.Generic;

namespace SGUS.Business.Usuario
{
    public static class UsuarioRepositorio
    {
        public static List<UsuarioModelo> ObtenerUsuarioPorID(int idUsuario)
        {
            if (idUsuario > 0)
            {
                var query = from x in poblarUsuarios()
                            where x.IdUsuario == idUsuario
                            select x;

                return query.OrderBy(x => x.Estado).ToList();
            }
            return new List<UsuarioModelo>();
        }

        public static List<UsuarioModelo> ObtenerUsuariosPorEstado(int estado)
        {
            var query = from x in poblarUsuarios()
                        select x;
            if (estado == 1 )
            {
                query = from x in query
                        where x.Estado == Saturado.SI
                        select x;
            }
            if (estado == 2)
            {
                query = from x in query
                        where x.Estado == Saturado.NO
                        select x;
            }
            return query.OrderBy(x => x.Estado).ToList();
        }

        public static int AsignarItemAUsuario(AsignarItemRequest request)
        {
            var response = 0;
            if (request != null)
            {
                if (request.IdProducto > 0)
                {
                    var producto = ProductoRepositorio.ObtenerProducto(request.IdProducto).FirstOrDefault();

                    if (producto != null)
                    {
                        var usuario = (from x in poblarUsuarios()
                                       where x.Estado == Saturado.SI
                                       select x).FirstOrDefault();
                        if (usuario != null)
                        {
                            if (usuario.ItemsAsignados == null)
                                usuario.ItemsAsignados = new List<ProductoModelo>();
                            usuario.ItemsAsignados.Add(producto!);
                            response = usuario.IdUsuario;
                        }
                    }
                }
                return response;
            }
            return response;
        }

        private static List<UsuarioModelo> poblarUsuarios()
        {
            List<UsuarioModelo> users = new List<UsuarioModelo>();

            /// Usuario A 
            var nuevoUsuario = new UsuarioModelo();
            nuevoUsuario.IdUsuario = 1;
            nuevoUsuario.Nombres = "Usuario A";
            nuevoUsuario.Estado = Saturado.NO;

            var producto = new ProductoModelo();
            producto.IdProducto = 1;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 30);
            producto.Activo = true;
            producto.Nombre = "Item A";
            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();
            nuevoUsuario.ItemsAsignados.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 2;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 28);
            producto.Activo = true;
            producto.Nombre = "Item B";
            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();
            nuevoUsuario.ItemsAsignados.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 3;
            producto.Importancia = Importancia.Baja;
            producto.FechaVencimiento = new DateTime(2026, 07, 27);
            producto.Activo = true;
            producto.Nombre = "Item C";
            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();
            nuevoUsuario.ItemsAsignados.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 1;
            producto.Importancia = Importancia.Alta;
            producto.FechaVencimiento = new DateTime(2026, 07, 30);
            producto.Activo = true;
            producto.Nombre = "Item D";
            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();
            nuevoUsuario.ItemsAsignados.Add(producto);

            producto = new ProductoModelo();
            producto.IdProducto = 1;
            producto.Importancia = Importancia.Baja;
            producto.FechaVencimiento = new DateTime(2026, 07, 25);
            producto.Activo = true;
            producto.Nombre = "Item E";
            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();
            nuevoUsuario.ItemsAsignados.Add(producto);

            users.Add(nuevoUsuario);

            /// Usuario B
            nuevoUsuario = new UsuarioModelo();
            nuevoUsuario.IdUsuario = 2;
            nuevoUsuario.Nombres = "Usuario B";
            nuevoUsuario.Estado = Saturado.NO;

            producto = new ProductoModelo();
            producto.IdProducto = 3;
            producto.Importancia = Importancia.Baja;
            producto.FechaVencimiento = new DateTime(2026, 08, 01);
            producto.Activo = true;
            producto.Nombre = "Item C";
            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();
            nuevoUsuario.ItemsAsignados.Add(producto);

            users.Add(nuevoUsuario);

            /// Usuario C
            nuevoUsuario = new UsuarioModelo();
            nuevoUsuario.IdUsuario = 3;
            nuevoUsuario.Nombres = "Usuario C";
            nuevoUsuario.Estado = Saturado.NO;

            if (nuevoUsuario.ItemsAsignados == null)
                nuevoUsuario.ItemsAsignados = new List<ProductoModelo>();

            users.Add(nuevoUsuario);

            return users;
        }
    }
}
