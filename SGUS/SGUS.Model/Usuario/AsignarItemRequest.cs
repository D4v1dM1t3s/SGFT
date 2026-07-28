namespace SGUS.Model.Usuario
{
    public class AsignarItemRequest
    {
        /// <summary>
        /// ID de producto a asignar
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Fecha de vencimiento
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

    }
}
