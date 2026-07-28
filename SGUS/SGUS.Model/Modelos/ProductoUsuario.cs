using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGUS.Model.Modelos
{
    [Table("ProductoUsuario")]
    public partial class ProductoUsuario
    {
        [Key]
        public int IdProductoUsuario { get; set; }

        public int IdProducto { get; set; }

        public int IdUsuario { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FechaAsignacion { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("ProductoUsuarios")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;

        [ForeignKey("IdUsuario")]
        [InverseProperty("ProductoUsuarios")]
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
