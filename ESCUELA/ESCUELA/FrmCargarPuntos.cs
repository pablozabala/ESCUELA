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
    public partial class FrmCargarPuntos : FrmBase
    {
        public FrmCargarPuntos()
        {
            InitializeComponent();
        }

        private void Buscar(Int32 IdConvocatoria)
        {
            cConvocatoria con = new cConvocatoria();
            DataTable tb = con.GetConvocatoriaDocentexId(IdConvocatoria);
            Grilla.DataSource = tb;
            txtCantidad.Text = tb.Rows.Count.ToString();
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 260;

        }

        private void FrmCargarPuntos_Load(object sender, EventArgs e)
        {
            Buscar(Principal.Codigo);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Docente = Grilla.CurrentRow.Cells[1].Value.ToString();
            string dni = Grilla.CurrentRow.Cells[2].Value.ToString();
            txtDocente.Text = Docente;
            txtDni.Text = dni.ToString();
        }

        private void txtPuntaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text =="")
            {
                Mensaje("Ingresar categoria");
                return;
            }
            if (txtPuntaje.Text =="")
            {
                Mensaje("Ingresar Puntaje");
                return;
            }
            if (txtDni.Text =="")
            {
                Mensaje("Ingresar dni");
                return;
            }
            Double Puntaje = Convert.ToDouble(txtPuntaje.Text);
            Int32 Categoria = Convert.ToInt32(txtCategoria.Text);
            string dni = txtDni.Text;
            cConvocatoria con = new cConvocatoria();
            con.CargarPuntaje(Puntaje, Categoria, dni);
            Buscar(Principal.Codigo);
            Mensaje("Datos grabados correctamente");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            cConvocatoria con = new cConvocatoria();
            DataTable trdo = con.GetConvocatoriaDocentexIdOrdenadaPuntaje(Principal.Codigo);
            Grilla.DataSource = trdo;

        }
    }
}
