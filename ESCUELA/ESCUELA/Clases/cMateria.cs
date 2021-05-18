using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ESCUELA.Clases
{
    public class cMateria
    {
        public DataTable GetMateria()
        {
            string sql = "select * from Materia ";
            sql = sql + " order by Nombre ";
            return cDb.GetDatatable(sql);            
        }
    }
}
