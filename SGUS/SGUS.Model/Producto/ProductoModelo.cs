using SGUS.Model.Usuario;

namespace SGUS.Model.Producto
{
    public class ProductoModelo
    {
        /// <summary>
        /// Id del producto
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Npmbre del producto
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Fecha de vencimiento
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Estado del producto 
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Relevancia del producto
        /// </summary>
        private int importancia;

        /// <summary>
        /// Relevancia del producto
        /// </summary>
        public Importancia Importancia
        {
            get
            {
                TimeSpan diferencia = DateTime.Now - this.FechaVencimiento;

                int dias = diferencia.Days;
                if (importancia == 1)
                    return Importancia.Alta;
                else if (dias < 3)
                    return Importancia.Alta;
                else
                    return Importancia.Baja;
            }
            set => importancia = value == Importancia.Alta ?
                1 : 2;
        }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }
    }

    public enum Importancia
    {
        Alta = 1,
        Baja = 2
    }
}
