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
            Int32? CodDocente = null;
            if (txtCodDocente.Text != "")
                CodDocente = Convert.ToInt32(txtCodDocente.Text);

            
            DataTable trdo = tardanza.GetTardanza(FechaDesde, FechaHasta, CodDocente);

            Grilla.DataSource = trdo;

            cFunciones fun = new cFunciones();
            fun.AnchoColumnas(Grilla, "0;50;25;25");

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Consultar();
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
                    Consultar();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodDocente.Text = "";
            txtDocente.Text = "";
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar en elemento ");
                return; 
            }

            var Resul = MessageBox.Show("Confirma Elimianr", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resul == DialogResult.Yes)
            {
                Int32 Codigo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
                cTardanza tardanza = new cTardanza();
                tardanza.Eliminar(Codigo);
                MessageBox.Show("Datos eliminados correctamente");
                Consultar();
            }

        }
    }
}
