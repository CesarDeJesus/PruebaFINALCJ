using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class FotosBL
    {

        FotosDAL _dal = new FotosDAL();

        public int AgregarGaleria(FotosEN pEN)
        {
            return _dal.AgregarGaleria(pEN);
        }

        public List<FotosEN> ConsultarGaleria()
        {
            return _dal.ConsultarGaleria();
        }

        public int EliminarGaleria(FotosEN pEN)
        {
            return _dal.EliminarGaleria(pEN);
        }
    }
}