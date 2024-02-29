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
    public partial class FrmConsultarTardanza : FormBase 
    {
        public FrmConsultarTardanza()
        {
            InitializeComponent();
        }

        private void FrmConsultarTardanza_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            dpFechaDesde.Value = Fecha;
            dpFechaHasta.Value = Fecha;
            Consultar();

        }

        private void Consultar()
        {    
            cTardanza tardanza = new Clases.cTardanza();
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);

            DataTable trdo = tardanza.GetTardanza(FechaDesde, FechaHasta);

            Grilla.DataSource = trdo;

        }
    }
}
