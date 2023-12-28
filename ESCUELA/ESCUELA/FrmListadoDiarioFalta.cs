using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESCUELA.Clases;
namespace ESCUELA
{
    public partial class FrmListadoDiarioFalta : FrmBase
    {
        public FrmListadoDiarioFalta()
        {
            InitializeComponent();
        }

        private void FrmListadoDiarioFalta_Load(object sender, EventArgs e)
        {
            dpFechaDesde.Value = DateTime.Now;
            dpFechaHasta.Value = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime Desde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime Hasta = Convert.ToDateTime(dpFechaHasta.Value);
            cFalta falta = new cFalta();
            DataTable trdo = falta.GetFaltasDiario(Desde, Hasta);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;0;18;18;14;7;7;7;7;7;7;8");
        }


        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un elemento ");
                return;
            }
            DateTime Fecha = DateTime.Now;
            DateTime FechaRegistro = Convert.ToDateTime(Grilla.CurrentRow.Cells[4].Value);
            Int32 CodFalta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            if ( FechaRegistro.ToShortDateString() == Fecha.ToShortDateString())
            {
                cFalta falta = new cFalta();
                falta.Borrar(CodFalta);
                Mensaje("Registro borrado");
                Buscar();
            }
            else
            {
                Mensaje("no Puede borrar ");
            }

            
        }
    }
}
