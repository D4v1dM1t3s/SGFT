using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGIT.Model.Modelos
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [StringLength(64)]
        public string Nombres { get; set; } = null!;

        [StringLength(256)]
        public string Email { get; set; } = null!;

        [StringLength(32)]
        public string? Telefono { get; set; }

        public bool Activo { get; set; }

        public int? UsuarioCreacion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<ProductoUsuario> ProductoUsuarios { get; set; } = [];
    }

}
