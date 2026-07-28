using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGIT.Model.Modelos
{
    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [StringLength(64)]
        public string Nombre { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? FechaVencimiento { get; set; }

        public bool Activo { get; set; }

        public int? Importancia { get; set; }

        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<ProductoUsuario> ProductoUsuarios { get; set; } = [];
    }
}
