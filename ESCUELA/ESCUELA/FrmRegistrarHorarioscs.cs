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
    public partial class FrmRegistrarHorarioscs : FormBase
    {
        DataTable tbHorario;
        public FrmRegistrarHorarioscs()
        {
            InitializeComponent();
        }

        private void ArmarHorario()
        {            
            cFunciones fun = new Clases.cFunciones();
            string col = "Hora;Nombre;Lunes;Martes;Miercoles;Jueves;Viernes";
            tbHorario = fun.CrearTabla(col);
            cRangoHorario rango = new cRangoHorario();
            DataTable tb = rango.GetRangoHorario(1);
            string Hora = "";
            string Nombre = "";
            string Val = "";
            for (int i = 0; i < tb.Rows.Count ; i++)
            {
                Hora = tb.Rows[i]["Hora"].ToString();
                Nombre = tb.Rows[i]["Nombre"].ToString();
                Val = Hora + ";" + Nombre;
                Val = Val + ";;;;;";
                tbHorario = fun.AgregarFilas(tbHorario, Val);
            }
            Grilla.DataSource = tbHorario;
            fun.AnchoColumnas(Grilla, "10;15;15;15;15;15;15");
            
        }

        private void FrmRegistrarHorarioscs_Load(object sender, EventArgs e)
        {
            ArmarHorario();
            CargarTurno();
            CargarMateria();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            cMateria mat = new cMateria();
            int CodMateria = Convert.ToInt32(cmbMateria.SelectedValue);
            string Materia = mat.GetMaeriaxCodigo(CodMateria);
            string DocMateria = Materia + "\n " + txtApellido.Text;
            int fila = Grilla.CurrentRow.Index;
            int col = Grilla.CurrentCell.ColumnIndex;
            Grilla.Rows[fila].Cells[col].Value = DocMateria;   

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarDocente frm = new ESCUELA.FrmBuscarDocente();
            frm.FormClosing += new FormClosingEventHandler(Continuar);
            frm.ShowDialog();
        }

        private void Continuar(object sender, FormClosingEventArgs e)
        {
            string Nombre = "";
            string Apellido = "";
            string NomApe = "";
            if (Principal.CodDocente != null)
            {
                cDocente doc = new Clases.cDocente();
                Int32 CodDOcente = Convert.ToInt32(Principal.CodDocente);
                DataTable trdo = doc.GetDoocentexCodigo(CodDOcente);
                if (trdo.Rows.Count > 0)
                {

                    txtCodDocente.Text = CodDOcente.ToString();
                    Apellido = trdo.Rows[0]["Apellido"].ToString();
                    Nombre = trdo.Rows[0]["Nombre"].ToString();
                    NomApe = Apellido;
                    txtApellido.Text = NomApe; 
                }
            }
        }

        private void CargarMateria()
        {
            cMateria mat = new Clases.cMateria();
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(cmbMateria, "Materia", "Nombre", "CodMateria");
        }

        private void CargarTurno()
        {
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(CMBtURNO, "Turno", "Nombre", "CodTurno");
        }

        private void CMBtURNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            cCurso curso = new cCurso();
            cFunciones fun = new cFunciones();
            if (CMBtURNO.SelectedIndex >0)
            {
                int CodTurno = Convert.ToInt32(CMBtURNO.SelectedValue);
                DataTable trdo = curso.GetCursoxTurno(CodTurno);
                fun.LlenarComboDatatable(cmbCurso, trdo, "Nombre", "CodCurso");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int graba = 1;
            int CodCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            cHorariocs horario = new cHorariocs();
            int i = 0;
            string Hora = "";
            string Lunes = "", Martes = "";
            string Miercoles = "", Jueves = "", Viernes = "";
            int b = 0;
            for(i =0;i< Grilla.Rows.Count -1;i++)
            {
                Hora = Grilla.Rows[i].Cells[0].Value.ToString(); 
                Lunes = Grilla.Rows[i].Cells[2].Value.ToString();
                Martes = Grilla.Rows[i].Cells[3].Value.ToString();
                Miercoles = Grilla.Rows[i].Cells[4].Value.ToString();
                Jueves = Grilla.Rows[i].Cells[5].Value.ToString();
                Viernes = Grilla.Rows[i].Cells[6].Value.ToString();
                if (graba ==1)
                {
                    horario.Insertar(CodCurso, Hora, Lunes, Martes, Miercoles, Jueves, Viernes);
                    b = 1;
                }
            }
            if (b==1)
            {
                MessageBox.Show("Datos grabados correctamente");
            }
        }


    }
}
