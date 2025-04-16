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
            if (Validar ()==false)
            {
                return;
            }
            cHorarioDocentecs horarioDocente = new Clases.cHorarioDocentecs();
            cHorariocs Horario = new cHorariocs();
            cMateria mat = new cMateria();
            int CodCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            int CodMateria = Convert.ToInt32(cmbMateria.SelectedValue);
            int CodTurno = Convert.ToInt32(CMBtURNO.SelectedValue);
            int CodDocente = Convert.ToInt32(txtCodDocente.Text);

            string Materia = mat.GetMaeriaxCodigo(CodMateria);
            string DocMateria = Materia + " " + txtApellido.Text;
            int fila = Grilla.CurrentRow.Index;
            int col = Grilla.CurrentCell.ColumnIndex;
            Grilla.Rows[fila].Cells[col].Value = DocMateria;
            GrabarSoloHorario(CodCurso);
            string Hora = Grilla.CurrentRow.Cells[0].Value.ToString(); 
            string Lunes = Grilla.CurrentRow.Cells[2].Value.ToString();
            string Martes = Grilla.CurrentRow.Cells[3].Value.ToString();
            string Miercoles = Grilla.CurrentRow.Cells[4].Value.ToString();
            string Jueves = Grilla.CurrentRow.Cells[5].Value.ToString();
            string Viernes = Grilla.CurrentRow.Cells[6].Value.ToString();
            string Curso = "";
            Curso = GetCursoxCodigo(CodCurso);
            Horario.ModificarHorario(CodCurso, Hora, Lunes, Martes, Miercoles, Jueves, Viernes);
            GrabarHorarioxCurso(CodDocente, CodCurso, Hora, Curso, CodTurno);
            MessageBox.Show("Datos grabados correctamente ");
            //falta grabar el horario del curso x docente
        }

        public String GetCursoxCodigo(int CodCurso)
        {
            cCurso Curso = new Clases.cCurso();
            string Nombre = Curso.GetNombre(CodCurso);
            return Nombre;
        }

        private void GrabarHorarioxCurso(int CodDocente,int CodCurso,string Hora, string Curso, int CodTurno)
        {
            //primero busco que no exista
            int b = 0;
            cHorarioDocentecs horario = new cHorarioDocentecs();
            DataTable trdo = horario.GetHorarioxCodDocente(CodDocente, Hora, CodCurso);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodDocente"].ToString ()!="")
                {
                    b = 1;
                    horario.Modificar(CodDocente, CodCurso, Curso, Hora);
                    //modifica
                }
            }
            if (b==0)
            {
                //inserta
                horario.Insertar(CodDocente, CodCurso, Curso, Hora, CodTurno);
            }

        }

        public Boolean Validar()
        {
            Boolean op = true;
            if (cmbCurso.SelectedIndex<1)
            {
                MessageBox.Show("Debe seleccionar un curso ");
                op = false;
            }
            if (txtCodDocente.Text =="")
            {
                MessageBox.Show("Debe seleccionar un docente ");
                op = false;
            }
            return op;
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
            int graba = 0;
            int CodCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            cHorariocs horario = new cHorariocs();
            Boolean Tiene = GetHorarioxCodCurso(CodCurso);
            
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
                if (Tiene ==false)
                {
                    horario.Insertar(CodCurso, Hora, Lunes, Martes, Miercoles, Jueves, Viernes);
                    b = 1;
                }
                else
                {
                    horario.ModificarHorario(CodCurso, Hora, Lunes, Martes, Miercoles, Jueves, Viernes);
                }
            }
            if (b==1)
            {
                MessageBox.Show("Datos grabados correctamente");
            }
        }

        private Boolean GetHorarioxCodCurso(int CodCurso)
        {
            Boolean Tiene = false;
            cHorariocs horario = new cHorariocs();
            DataTable trdo = horario.GetHorarioxCodCurso(CodCurso);
            if (trdo.Rows.Count >0 )
            {
                if (trdo.Rows[0]["CodCurso"].ToString ()!="")
                    {
                    Tiene = true;
                }
            }
            return Tiene;

        }

        public void BuscarHorario(int CodCurso)
        {
            string Hora = "";
            string Lunes = "";
            string Martes = "";
            string Miercoles = "";
            string Jueves = "";
            string Viernes = "";
            cHorariocs horario = new Clases.cHorariocs();
            DataTable trdo = horario.GetHorarioxCodCurso(CodCurso);
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                Hora = trdo.Rows[i]["Hora"].ToString();
                Lunes = trdo.Rows[i]["Lunes"].ToString();
                Martes = trdo.Rows[i]["Martes"].ToString();                
                Miercoles = trdo.Rows[i]["Miercoles"].ToString();
                Jueves = trdo.Rows[i]["Jueves"].ToString();
                Viernes = trdo.Rows[i]["Viernes"].ToString();

                UbicarHorario(Hora, Lunes,Martes ,Miercoles, Jueves, Viernes);
            }
        }

        public void UbicarHorario (string Hora, string Lunes,string Martes, string Miercoles, string Jueves, string Viernes)
        {
            for (int i = 0; i < Grilla.Rows.Count -1 ; i++)
            {
                if (Grilla.Rows[i].Cells[0].Value.ToString ()== Hora)
                {
                    Grilla.Rows[i].Cells["Lunes"].Value = Lunes;
                    Grilla.Rows[i].Cells["Martes"].Value = Martes;
                    Grilla.Rows[i].Cells["Miercoles"].Value = Miercoles;
                    Grilla.Rows[i].Cells["Jueves"].Value = Jueves;
                    Grilla.Rows[i].Cells["Viernes"].Value = Viernes;
                }
            }
        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurso.SelectedIndex>0)
            {
                int CodCurso = Convert.ToInt32(cmbCurso.SelectedValue);
                BuscarHorario(CodCurso);
            }
        }

        private void GrabarSoloHorario(int CodCurso)
        {
            cHorariocs horario = new cHorariocs();
            string Hora = "";
            Boolean Tiene = GetHorarioxCodCurso(CodCurso);
            if (Tiene==true)
            {
                return;
            }
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Hora = Grilla.Rows[i].Cells[0].Value.ToString();
                horario.InsertarSoloHora(CodCurso, Hora);
            }
        }
    }
}
