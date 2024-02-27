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
    public partial class FrmConsultarCertificados : FormBase 
    {
        public FrmConsultarCertificados()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            Int32? CodDocente = null;
            if (txtCodDocente.Text != "")
                CodDocente = Convert.ToInt32(txtCodDocente.Text);

            cCertificado cer = new Clases.cCertificado();
            DataTable trdo = cer.GetCertificadosxFecha(FechaDesde, FechaHasta, CodDocente);
            Grilla.DataSource = trdo;
            cFunciones fun = new cFunciones();
            fun.AnchoColumnas(Grilla, "0;25;30;30;15");
        }

        private void FrmConsultarCertificados_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            dpFechaHasta.Value = Fecha;
            Fecha = Fecha.AddMonths(-1);
            dpFechaDesde.Value = Fecha;
        }

        private void btnBuscarDocente_Click(object sender, EventArgs e)
        {
            FrmBuscarDocente frm = new ESCUELA.FrmBuscarDocente();
            frm.FormClosing += new FormClosingEventHandler(Continuar);
            frm.ShowDialog();
        }


        private void Continuar(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodDocente != null)
            {
                cDocente doc = new Clases.cDocente();
                Int32 CodDOcente = Convert.ToInt32(Principal.CodDocente);
                DataTable trdo = doc.GetDoocentexCodigo(CodDOcente);
                if (trdo.Rows.Count > 0)
                {  
                    string Nombre = trdo.Rows[0]["Nombre"].ToString();
                    string Apellido = trdo.Rows[0]["Apellido"].ToString();
                    string NomApe = Nombre + " " + Apellido;
                    txtDocente.Text = NomApe;
                    txtCodDocente.Text = trdo.Rows[0]["CodDocente"].ToString();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodDocente.Text = "";
            txtDocente.Text = "";
        }
    }
}
