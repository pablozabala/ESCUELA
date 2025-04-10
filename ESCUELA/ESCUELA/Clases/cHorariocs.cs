using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ESCUELA.Clases
{
    public class cHorariocs
    {
        public void Insertar(Int32 CodCurso, string Hora , string Lunes ,
            string Martes, string Miercoles , string Jueves, string Viernes
            )
        {
            string sql = "insert into Horario (";
            sql = sql + " CodCurso,Hora,Lunes,Martes,Miercoles,Jueves,Viernes) ";
            sql = sql + " values(" + CodCurso.ToString();
            sql = sql + "," + "'" + Hora + "'";
            sql = sql + "," + "'" + Lunes  + "'";
            sql = sql + "," + "'" + Martes  + "'";
            sql = sql + "," + "'" + Miercoles + "'";
            sql = sql + "," + "'" + Jueves + "'";
            sql = sql + "," + "'" + Viernes  + "'";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetHorarioxCodCurso(int CodCurso)
        {
            string sql = "select * ";
            sql = sql + " from Horario ";
            sql = sql + " where CodCurso =" + CodCurso.ToString();
            return cDb.GetDatatable(sql);
        }

        public void ModificarHorario(Int32 CodCurso, string Hora, string Lunes,
            string Martes, string Miercoles, string Jueves, string Viernes)
        {
            string sql = "update horario ";
            sql = sql + " set ";
            sql = sql + " Lunes =" + "'" + Lunes + "'";
            sql = sql + ", Martes="+ "'" + Martes  + "'";
            sql = sql + ", Miercoles=" + "'" + Miercoles + "'";
            sql = sql + ", Jueves=" + "'" + Jueves + "'";
            sql = sql + ", Viernes=" + "'" + Viernes + "'";
            sql = sql + " where CodCurso =" + CodCurso.ToString();
            sql = sql + " and Hora =" + "'" + Hora + "'";
            cDb.Grabar(sql);
        }

       
    }
}
