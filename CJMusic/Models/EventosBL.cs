using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class EventosBL
    {
        EventosDAL _dal = new EventosDAL();

        public int AgregarEventos(EventosEN pEN)
        {
            return _dal.AgregarEventos(pEN);
        }

        public List<EventosEN> ConsultarEventos()
        {
            return _dal.ConsultarEventos();
        }

        public int ActualizarEventos(EventosEN pEN)
        {
            return _dal.ActualizarEventos(pEN);
        }

        public int EliminarEventos(EventosEN pEN)
        {
            return _dal.EliminarEventos(pEN);
        }
    }
}