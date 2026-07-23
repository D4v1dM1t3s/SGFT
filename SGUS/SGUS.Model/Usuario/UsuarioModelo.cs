
using SGUS.Model.Producto;

namespace SGUS.Model.Usuario
{
    /// <summary>
    /// Clase usada para usuario
    /// </summary>
    public class UsuarioModelo
    {
        /// <summary>
        /// ID de usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string? Nombres { get; set; }

        /// <summary>
        /// Estado de usuario
        /// </summary>
        public int EstadoUsuario;

        /// <summary>
        /// Estado de usuario
        /// </summary>
        public Saturado Estado
        {
            get
            {
                var saturado = (from x in ItemsAsignados
                                where x.Importancia == Importancia.Alta
                                select x).Count();
                if (saturado > 3)
                    return Saturado.SI;
                else
                    return Saturado.NO;
            }
            set => EstadoUsuario = value == Saturado.SI ?
                1 : 2;
        }

        /// <summary>
        /// Listado de productos asignados
        /// </summary>
        public List<ProductoModelo>? ItemsAsignados { get; set; }

        public override string ToString()
        {
            return $"{this.Nombres}";
        }
    }

    public enum Saturado
    {
        SI = 1,
        NO = 2
    }
}
