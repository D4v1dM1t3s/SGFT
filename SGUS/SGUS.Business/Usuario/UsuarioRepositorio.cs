using SGUS.Business.Producto;
using SGUS.Data.Data;
using SGUS.Model.Producto;
using SGUS.Model.Usuario;

namespace SGUS.Business.Usuario
{
    public static class UsuarioRepositorio
    {
        public static List<UsuarioModelo> ObtenerUsuarios()
        {
            using DataContext ctx = new();
            var query = from x in ctx.Usuarios
                        select x;
            return [.. (from x in query
                    select new UsuarioModelo()
                    {
                        IdUsuario = x.IdUsuario,
                        Nombres = x.Nombres,
                        EstadoUsuario = x.Activo?1:0,
                        ItemsAsignados = (from y in x.ProductoUsuarios
                                          orderby y.IdProductoNavigation.Importancia,y.IdProductoNavigation.FechaVencimiento
                                          select new ProductoModelo()
                                          {
                                              IdProducto = y.IdProducto,
                                              Nombre = y.IdProductoNavigation.Nombre,
                                              FechaVencimiento = y.IdProductoNavigation.FechaVencimiento!.Value,
                                              Activo = y.IdProductoNavigation.Activo,
                                              Relevancia = y.IdProductoNavigation.Importancia!.Value
                                          }).ToList()
                    })];
        }
        private static List<UsuarioModelo> ObtenerUsuariosPorNroAsignados()
        {
            var query = (from x in ObtenerUsuarios()
                         orderby x.NroItemsAsignados
                         select x);
            return [.. query];
        }

        public static UsuarioModelo? ObtenerUsuarioPorID(int idUsuario)
        {
            var query = from x in ObtenerUsuarios()
                        select x;
            if (idUsuario > 0)
            {
                query = (from x in query
                         where x.IdUsuario == idUsuario
                         select x);
            }

            return (from x in query

                    select x).FirstOrDefault();
        }

        public static List<UsuarioModelo> ObtenerUsuariosPorEstado(int estado)
        {
            var query = from x in ObtenerUsuarios()
                        select x;

            if (estado == 1)
            {
                query = (from x in query
                         where x.Estado == Saturado.SI
                         select x);
            }
            if (estado == 2)
            {
                query = from x in query
                        where x.Estado == Saturado.NO
                        select x;
            }
            return [.. query.OrderBy(x => x.Estado)];
        }

        public static UsuarioModelo? AsignarItemAUsuario(AsignarItemRequest request)
        {
            var response = new UsuarioModelo();
            if (request == null)
                return response;

            if (request.IdProducto <= 0)
                return response;

            using DataContext ctx = new();
            var producto = (from x in ctx.Productos
                            where x.IdProducto == request.IdProducto
                            select x).FirstOrDefault();

            if (producto != null)
            {
                var usuarioSeleccionado = (from x in ObtenerUsuariosPorNroAsignados()
                                           where x.Estado == Saturado.NO
                                           select x).FirstOrDefault();


                if (usuarioSeleccionado != null)
                {
                    var usuario = (from x in ctx.Usuarios
                                   where x.IdUsuario == usuarioSeleccionado.IdUsuario
                                   select x).FirstOrDefault();
                    if (usuario != null)
                        ctx.ProductoUsuarios.Add(new Model.Modelos.ProductoUsuario()
                        {
                            FechaAsignacion = request.FechaVencimiento,
                            IdProducto = producto.IdProducto,
                            IdUsuario = usuario.IdUsuario
                        });

                    ctx.SaveChanges();

                    response = ObtenerUsuarioPorID(usuarioSeleccionado.IdUsuario);
                }
            }

            return response;
        }
    }
}
