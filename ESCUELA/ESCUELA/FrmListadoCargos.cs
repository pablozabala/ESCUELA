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
    public partial class FrmListadoCargos : FormBase 
    {
        public FrmListadoCargos()
        {
            InitializeComponent();
        }

        private void FrmListadoCargos_Load(object sender, EventArgs e)
        {
            DateTime Hoy = DateTime.Now;
            DateTime Pasado = Hoy.AddDays(-7);
            DateTime Futuro = Hoy.AddDays(7);
            txtFechaDesde.Text = Pasado.ToShortDateString();
            txtFechaHasta.Text = Futuro.ToShortDateString();
            CargarGrilla(Pasado,Futuro);
        }

        private void CargarGrilla(DateTime FechaDesde,DateTime FechaHasta)
        {
            cCargo cargo = new Clases.cCargo();
            DataTable trdo = cargo.GetCargosaVencer(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (fun.ValidarFecha (txtFechaDesde.Text)==false)
            {
                Mensaje("La fecha desde es incorrecta");
                return;
            }
             
            if (fun.ValidarFecha(txtFechaHasta.Text) == false)
            {
                Mensaje("La fecha Hasta es incorrecta");
                return;
            }
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            CargarGrilla(FechaDesde, FechaHasta);
        }
    }
}
