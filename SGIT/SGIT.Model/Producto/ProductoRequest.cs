namespace SGIT.Model.Producto
{
    public class ProductoRequest
    {
        /// <summary>
        /// Npmbre del producto
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Fecha de vencimiento
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Relevancia del producto
        /// </summary>
        public int Importancia;

    }
}
