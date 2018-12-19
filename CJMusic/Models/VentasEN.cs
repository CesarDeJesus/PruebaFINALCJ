using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class VentasEN
    {
        public Int64 Id { get; set; }

        public string NombreCliente { get; set; }

        public string ApellidosCliente { get; set; }

        public string NoTarjeta { get; set; }

        public string CodigoCVV { get; set; }

        public string Comentario { get; set; }
    }
}