using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGUS.Model.Usuario
{
    public class UsuarioRequest
    {
        /// <summary>
        /// ID de usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Estado de usuario
        /// </summary>
        public int EstadoUsuario { get; set; }
    }
}
