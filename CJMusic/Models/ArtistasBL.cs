using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class ArtistasBL
    {

        ArtistasDAL _dal = new ArtistasDAL();

        public int AgregarArtistas(ArtistasEn pEN)
        {
            return _dal.AgregarArtistas(pEN);
        }

        public List<ArtistasEn> ConsultarArtistas()
        {
            return _dal.ConsultarArtistas();
        }

        public int ActualizarArtista(ArtistasEn pEN)
        {
            return _dal.ActualizarArtista(pEN);
        }

        public int EliminarArtista(ArtistasEn pEN)
        {
            return _dal.EliminarArtista(pEN);
        }
    }
}