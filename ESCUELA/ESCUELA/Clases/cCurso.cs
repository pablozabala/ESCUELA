using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ESCUELA.Clases
{
    public class cCurso
    {
        public DataTable GetCursoxTurno(int CodTurno)
        {
            string sql = "select CodCurso, Nombre ";
            sql = sql + " from Curso ";
            sql = sql + " where CodTurno =" + CodTurno.ToString();
            return cDb.GetDatatable(sql);
        }
    }
}
