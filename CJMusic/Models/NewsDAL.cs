using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CJMusic.Models
{
    public class NewsDAL
    {
        IDbConnection _conn = DBCommon.Conexion();

        //metodo de agregar
        public int AgregarNews(NewsEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarNews", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Artista", pEN.Artista));
            _Comand.Parameters.Add(new SqlParameter("@TNoticia", pEN.TNoticia));
            _Comand.Parameters.Add(new SqlParameter("@foto", pEN.foto));
            _Comand.Parameters.Add(new SqlParameter("@DNoticia", pEN.DNoticia));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }

        //metodo de consultar

        public List<NewsEN> ConsultarNews()
        {
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ConsultarNews", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<NewsEN> _lista = new List<NewsEN>();
            while (_reader.Read())
            {
                NewsEN pEN = new NewsEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Artista = _reader.GetString(1);
                pEN.TNoticia = _reader.GetString(2);
                pEN.foto = _reader.GetString(3);
                pEN.DNoticia = _reader.GetString(4);
                _lista.Add(pEN);
            }
            _conn.Close();
            _conn.Dispose();

            return _lista;

        }

        //metodo de actualizar
        public int ActualizaNews(NewsEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("ActualizaNews", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            _Comand.Parameters.Add(new SqlParameter("@Artista", pEN.Artista));
            _Comand.Parameters.Add(new SqlParameter("@TNoticia", pEN.TNoticia));
            _Comand.Parameters.Add(new SqlParameter("@foto", pEN.foto));
            _Comand.Parameters.Add(new SqlParameter("@DNoticia", pEN.DNoticia));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }


        //Metodo eliminar
        public int EliminarNews(NewsEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("EliminarNews", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }
    }
}