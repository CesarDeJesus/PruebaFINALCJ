using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class NewsBL
    {
        NewsDAL _dal = new NewsDAL();

        public int AgregarNews(NewsEN pEN)
        {
            return _dal.AgregarNews(pEN);
        }

        public List<NewsEN> ConsultarNews()
        {
            return _dal.ConsultarNews();
        }

        public int ActualizaNews(NewsEN pEN)
        {
            return _dal.ActualizaNews(pEN);
        }

        public int EliminarNews(NewsEN pEN)
        {
            return _dal.EliminarNews(pEN);
        }
    }
}