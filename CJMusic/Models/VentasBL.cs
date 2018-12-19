using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class VentasBL
    {
        VentasDAL _dal = new VentasDAL();

        public int AgregarVentas(VentasEN pEN)
        {
            return _dal.AgregarVentas(pEN);
        }

        public List<VentasEN> ConsultarVentas()
        {
            return _dal.ConsultarVentas();
        }

    }
}