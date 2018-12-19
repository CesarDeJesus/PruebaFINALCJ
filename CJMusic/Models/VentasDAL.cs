using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CJMusic.Models
{
    public class VentasDAL

    {
        IDbConnection _conn = DBCommon.Conexion();

        //metodo de agregar
        public int AgregarVentas(VentasEN pEN)
        {
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AgregarVentas", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@NombreCliente", pEN.NombreCliente));
            _Comand.Parameters.Add(new SqlParameter("@ApellidosCliente", pEN.ApellidosCliente));
            _Comand.Parameters.Add(new SqlParameter("@NoTarjeta", pEN.NoTarjeta));
            _Comand.Parameters.Add(new SqlParameter("@CodigoCVV", pEN.CodigoCVV));
            _Comand.Parameters.Add(new SqlParameter("@Comentario", pEN.Comentario));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            _conn.Dispose();
            return Resultado;

        }

        //metodo de consultar

        public List<VentasEN> ConsultarVentas()
        {
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ConsultarVentas", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<VentasEN> _lista = new List<VentasEN>();
            while (_reader.Read())
            {
                VentasEN pEN = new VentasEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.NombreCliente = _reader.GetString(1);
                pEN.ApellidosCliente = _reader.GetString(2);
                pEN.NoTarjeta = _reader.GetString(3);
                pEN.CodigoCVV = _reader.GetString(4);
                pEN.Comentario = _reader.GetString(5);

                _lista.Add(pEN);
            }
            _conn.Close();
            _conn.Dispose();

            return _lista;

        }
    }
}