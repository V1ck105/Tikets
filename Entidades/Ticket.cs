using System;

namespace Entidades
{
    public class Ticket
    {
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoUsuario { get; set; }
        public string Cliente { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRespuesta { get; set; }
        public decimal Precio { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public Ticket()
        {

        }

        public Ticket(string codigo, DateTime fecha, string codigoUsuario, string cliente, string tipoSoporte, string descripcionSolicitud,
        string descripcionRespuesta, decimal precio, decimal isv, decimal descuento, decimal total)
        {
            Codigo = codigo;
            Fecha = fecha;
            CodigoUsuario = codigoUsuario;
            Cliente = cliente;
            TipoSoporte = tipoSoporte;
            DescripcionSolicitud = descripcionSolicitud;
            DescripcionRespuesta = descripcionRespuesta;
            Precio = precio;
            ISV = isv;
            Descuento = descuento;
            Total = total;
        }
    }
}
