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
    public partial class FrmInscripcionConvocatoria : FormBase
    {
        public FrmInscripcionConvocatoria()
        {
            InitializeComponent();
        }

        private void FrmInscripcionConvocatoria_Load(object sender, EventArgs e)
        {
            cConvocatoria conv = new Clases.cConvocatoria();
            DataTable trdo = conv.GetConvocatoriasVigentes(); 
          //  cFunciones.LlenarCombo(CmbConvocatoria, trdo, "Descripcion", "IdConvocatoria");
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(CmbConvocatoria, trdo, "Descripcion", "IdConvocatoria");


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (CmbConvocatoria.SelectedIndex <1)
            {
                Mensaje("Debe seleccionar una convocatoria");
                return;
            }
            if (txtDocente.Text=="")
            {
                Mensaje("Ingresar docente");
                return;
            }
            if (txtDni.Text =="")
            {
                Mensaje("Ingresar dni");
                return;
            }
            Int32 idConvocatoria = Convert.ToInt32(CmbConvocatoria.SelectedValue);
            
            string  Docente = txtDocente.Text;
            string Dni = txtDni.Text;
            cConvocatoria conv = new cConvocatoria();
            conv.grabarConvocatoriaxDocente(idConvocatoria, Docente, Dni);
            txtDocente.Text = "";
            txtDni.Text = "";
            Mensaje("Datos grabados correctamenes");
            
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPuntaje_Click(object sender, EventArgs e)
        {
            if (CmbConvocatoria.SelectedIndex <1)
            {
                Mensaje("Debe seleccionar una convocatoria");
                return;
            }
            Int32 Codigo = Convert.ToInt32(CmbConvocatoria.SelectedValue);
            Principal.Codigo = Codigo;
            FrmCargarPuntos frm = new FrmCargarPuntos();
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CmbConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdConvocatoria.Text = CmbConvocatoria.SelectedValue.ToString();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (CmbConvocatoria.SelectedIndex <1)
            {
                Mensaje("Debe seleccionar una convocatoria");
                return;
            }
            Int32 CodConvocatoria = Convert.ToInt32(CmbConvocatoria.SelectedValue);
            cConvocatoria conv = new cConvocatoria();
            conv.FinaliarConvocatoria(CodConvocatoria);
            Mensaje("Datos grabados correctamente");
        }
    }
}
