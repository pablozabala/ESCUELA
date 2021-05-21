using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ESCUELA.Clases
{
    public class cCargo
    {
        public void InsertarCargo(SqlConnection con, SqlTransaction tran,
            Int32 CodDocente,Int32 CodMateria,string Curso,string Division,Int32 CodCaracter,DateTime FechaDesde,DateTime FechaHasta, Int32 CodDocenteSuplente)
        {
            cFunciones fun = new cFunciones();
            string sql = "";
            sql = "Insert into Cargo(";
            sql = sql + "CodDocente,CodMateria,Curso,Division";
            sql = sql + ",CodCaracter";
            sql = sql + ",FechaDesde";
            sql = sql + ",FechaHasta";
            sql = sql + ",CodDocenteSuplente";
            sql = sql + ")";
            sql = sql + "Values(";
            sql = sql + CodDocente.ToString();
            sql = sql + ","  + CodMateria.ToString();
            sql = sql + "," + Texto(Curso);
            sql = sql + "," + Texto(Division);
            sql = sql + "," + CodCaracter.ToString();
            sql = sql + "," + fun.SetFecha(FechaDesde);
            sql = sql + "," + fun.SetFecha(FechaHasta);
            sql = sql + "," + CodDocenteSuplente.ToString();
            sql = sql + ")";
            cDb.GrabarTransaccion(con, tran, sql);
        }

        private string Texto(string t)
        {
            string t1 = "'" + t + "'";
            return t1;
        }
        
        public DataTable GetCargosaVencer(DateTime FechaDesde,DateTime FechaHasta)
        {
            cFunciones fun = new Clases.cFunciones();
            string sql = "";
            sql = "select c.CodCargo,c.CodDocente,d.Apellido as Titular,d.Nombre"; ;
            sql = sql + ",(select sup.Apellido from Docente Sup where Sup.IdDocente=c.CodDocenteSuplente) as Suplente";
            sql = sql + ",(select sup.Nombre from Docente Sup where Sup.IdDocente=c.CodDocenteSuplente) as NombreSuplente";
            sql = sql + ",ca.Nombre as Caracter";
            sql = sql + ",m.Nombre as Materia ";
            sql = sql + ",c.FechaDesde,c.FechaHasta";
            sql = sql + " From Cargo c,Docente d,Materia m,Caracter ca";
            sql = sql + " where c.CodDocente=d.IdDocente";
            sql = sql + " and c.CodMateria = m.CodMateria";
            sql = sql + " and ca.CodCaracter=c.CodCaracter";
            sql = sql + " and c.FechaHasta>=" + fun.SetFecha(FechaDesde);
            sql = sql + " and c.FechaHasta<=" + fun.SetFecha(FechaHasta);
            return cDb.GetDatatable(sql);
        }
        
    }
}
