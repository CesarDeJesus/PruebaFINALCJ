using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CJMusic.Models
{
    public class ArtistasDAL
    {
        IDbConnection _conn = DBCommon.Conexion();


        //metodo de agregar
        public int AgregarArtistas(ArtistasEn pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarArtistas", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Nombre", pEN.Nombre));
            _Comand.Parameters.Add(new SqlParameter("@Descripcion", pEN.Descripcion));
            _Comand.Parameters.Add(new SqlParameter("@img", pEN.img));
            _Comand.Parameters.Add(new SqlParameter("@facebook", pEN.facebook));
            _Comand.Parameters.Add(new SqlParameter("@twitter", pEN.twitter));
            _Comand.Parameters.Add(new SqlParameter("@youtube", pEN.youtube));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }

        //metodo de consultar

        public List<ArtistasEn> ConsultarArtistas()
        {
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ConsultarArtistas", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<ArtistasEn> _lista = new List<ArtistasEn>();
            while (_reader.Read())
            {
                ArtistasEn pEN = new ArtistasEn();
                pEN.Id = _reader.GetInt64(0);
                pEN.Nombre = _reader.GetString(1);
                pEN.Descripcion = _reader.GetString(2);
                pEN.img = _reader.GetString(3);
                pEN.facebook = _reader.GetString(4);
                pEN.twitter = _reader.GetString(5);
                pEN.youtube = _reader.GetString(6);
                _lista.Add(pEN);
            }
            _conn.Close();
            _conn.Dispose();

            return _lista;

        }

        //metodo de actualizar
        public int ActualizarArtista(ArtistasEn pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("actualiza_Artista", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            _Comand.Parameters.Add(new SqlParameter("@Nombre", pEN.Nombre));
            _Comand.Parameters.Add(new SqlParameter("@Descripcion", pEN.Descripcion));
            _Comand.Parameters.Add(new SqlParameter("@img", pEN.img));
            _Comand.Parameters.Add(new SqlParameter("@facebook", pEN.facebook));
            _Comand.Parameters.Add(new SqlParameter("@twitter", pEN.twitter));
            _Comand.Parameters.Add(new SqlParameter("@youtube", pEN.youtube));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }


        //Metodo eliminar
        public int EliminarArtista(ArtistasEn pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("eliminar_Artista", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }
    }
}