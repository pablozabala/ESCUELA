using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
    }
}
