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
    public partial class FrmCargarPuntos : FormBase
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
           // Grilla.Columns[0].Visible = false;
            Grilla.Columns[4].HeaderText = "Pos"; 
           // Grilla.Columns[1].Width = 260;
            cFunciones fun = new Clases.cFunciones();
            string col = "0;40;15;15;15;15";
            fun.AnchoColumnas(Grilla, col);

        }

        private void FrmCargarPuntos_Load(object sender, EventArgs e)
        {
            Buscar(Principal.Codigo);
            CargarCategoria();
        }

        private void CargarCategoria()
        {            
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(CmbCategoriaDocente, "CatDocente","Nombre", "CodCatDocente");
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
            Int32 IdConvocatoria = Convert.ToInt32(Principal.Codigo);
            string PuntajeLetra = "";
            PuntajeLetra = Puntaje.ToString();
            if (CmbCategoriaDocente.SelectedIndex >0)
            {
                PuntajeLetra = PuntajeLetra + " " + CmbCategoriaDocente.Text;
            }
            string dni = txtDni.Text;
            cConvocatoria con = new cConvocatoria();
            con.CargarPuntaje(Puntaje, Categoria, dni, IdConvocatoria, PuntajeLetra);
            Buscar(Principal.Codigo);
            Mensaje("Datos grabados correctamente");
            txtDni.Text = "";
            txtDocente.Text = "";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }
            string Dni = Grilla.CurrentRow.Cells[2].Value.ToString();
            int IdConvocatoria = Principal.Codigo;
            cConvocatoria conv = new cConvocatoria();
            conv.BorrarDocentexConvocatoria(IdConvocatoria, Dni);
            Buscar(Principal.Codigo);
        }
    }
}
