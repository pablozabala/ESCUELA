﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ESCUELA.Clases
{
    public static class cDb
    {
        public static  DataTable  GetDatatable(string sql)
        {
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = sql;
            comando.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comando;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0]; 
        }
        
        public static void Grabar(string sql)
        {
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = sql;
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
        }

        public static Int32 EjecutarEscalarTransaccion(SqlConnection con, SqlTransaction Transaccion, string Sql)
        {
            Sql = Sql + "select SCOPE_IDENTITY()";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = Sql;
            return Convert.ToInt32(comand.ExecuteScalar());
        }

        public static void GrabarTransaccion(SqlConnection con, SqlTransaction Transaccion, string Sql)
        {
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = Sql;
            comand.ExecuteNonQuery();
        }
    }
}
