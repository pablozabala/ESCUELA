using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ESCUELA.Clases
{
    public class cCatDocente
    {   //metodo que retorna cat docente
        public DataTable GetCatDocente()
        {
            string sql = "select * from CatDocente ";
            return cDb.GetDatatable(sql);
        }
    }
}
