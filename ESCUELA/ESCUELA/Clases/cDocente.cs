using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;    
namespace ESCUELA.Clases
{
   public class cDocente
    {
       public DataTable GetDocentexDni(string NroDoc)
        {
            string sql = "select * from Docente ";
            sql = sql + " where NroDoc=" + "'" + NroDoc + "'";
            return cDb.GetDatatable(sql);
        }

        public Int32 GrabarDocenteTransaccion(SqlConnection con,SqlTransaction tran, string NroDoc,
            string Apellido,string Nombre,string Email,string Celular)
        {
            string sql = "Insert into Docente";
            sql = sql + "(NroDoc,Apellido,Nombre,Email,Celular)";
            sql = sql + "Values(" + Texto(NroDoc);
            sql = sql + "," + Texto(Apellido);
            sql = sql + "," + Texto(Nombre);
            sql = sql + "," + Texto(Email);
            sql = sql + "," + Texto(Celular);
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, tran, sql);
        }

        private string Texto(string t)
        {
            string t1 = "'" + t + "'";
            return t1;
        }
    }
}
