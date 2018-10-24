using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CJMusic.Models
{
    public class EventosDAL
    {
        IDbConnection _conn = DBCommon.Conexion();

        //metodo de agregar
        public int AgregarEventos(EventosEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarEventos", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Fecha", pEN.Fecha));
            _Comand.Parameters.Add(new SqlParameter("@Artista", pEN.Artista));
            _Comand.Parameters.Add(new SqlParameter("@Lugar", pEN.Lugar));
            _Comand.Parameters.Add(new SqlParameter("@Direccion", pEN.Direccion));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }

        //metodo de consultar

        public List<EventosEN> ConsultarEventos()
        {
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ConsultarEventos", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<EventosEN> _lista = new List<EventosEN>();
            while (_reader.Read())
            {
                EventosEN pEN = new EventosEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Fecha = _reader.GetString(1);
                pEN.Artista = _reader.GetString(2);
                pEN.Lugar = _reader.GetString(3);
                pEN.Direccion = _reader.GetString(4);

                _lista.Add(pEN);
            }
            _conn.Close();
            _conn.Dispose();

            return _lista;

        }

        //metodo de actualizar
        public int ActualizarEventos(EventosEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("actualiza_Evento", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            _Comand.Parameters.Add(new SqlParameter("@Fecha", pEN.Fecha));
            _Comand.Parameters.Add(new SqlParameter("@Artista", pEN.Artista));
            _Comand.Parameters.Add(new SqlParameter("@Lugar", pEN.Lugar));
            _Comand.Parameters.Add(new SqlParameter("@Direccion", pEN.Direccion));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }


        //Metodo eliminar
        public int EliminarEventos(EventosEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("eliminar_Evento", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }



    }
}