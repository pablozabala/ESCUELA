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
    public partial class FrmListadoIncidencia : FormBase 
    {
        public FrmListadoIncidencia()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmRegistrarIncidente frm = new FrmRegistrarIncidente();
            frm.Show();
        }

        private void FrmListadoIncidencia_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            cFunciones fun = new Clases.cFunciones();
            DateTime Desde = dpFechaDessde.Value;
            DateTime Hasta = dpFechaHasta.Value;
            cIncidencia INC = new Clases.cIncidencia();
            DataTable trdo = INC.GetIncidencia(Desde, Hasta);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "75;25");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Consultar();
        }
    }
}
