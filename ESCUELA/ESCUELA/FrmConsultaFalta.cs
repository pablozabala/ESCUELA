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
    public partial class FrmConsultaFalta : FormBase 
    {
        public FrmConsultaFalta()
        {
            InitializeComponent();
        }

        private void FrmConsultaFalta_Load(object sender, EventArgs e)
        {
            int anio = DateTime.Now.Year;
            string FechaDesde = "01/01/" + anio;
            string FechaHasta = "31/12/" + anio;
            dpFechaDesde.Value = Convert.ToDateTime(FechaDesde);
            dpFechaHasta.Value = Convert.ToDateTime(FechaHasta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            cFalta falta = new Clases.cFalta();
            DataTable trdo = falta.GetFaltas(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;16;12;8;8;8;8;8;8;8;8;8");
        }
    }
}
