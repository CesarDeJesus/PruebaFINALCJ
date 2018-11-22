using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CJMusic.Models
{

    public class FotosDAL
    {
        IDbConnection _conn = DBCommon.Conexion();

        //metodo de agregar

        public int AgregarGaleria(FotosEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarGaleria", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@imagen", pEN.Imagen));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;
        }


        //metodo de consultar

        public List<FotosEN> ConsultarGaleria()
        {
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ConsultarGaleria", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<FotosEN> _lista = new List<FotosEN>();
            while (_reader.Read())
            {
                FotosEN pEN = new FotosEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Imagen = _reader.GetString(1);
                _lista.Add(pEN);
            }
            _conn.Close();
            _conn.Dispose();

            return _lista;

        }

        //Metodo eliminar
        public int EliminarGaleria(FotosEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("eliminar_Galeria", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@Id", pEN.Id));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }
    }
}