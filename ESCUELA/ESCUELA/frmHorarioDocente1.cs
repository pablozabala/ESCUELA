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
    public partial class frmHorarioDocente1 : FormBase
    {
        DataTable tbHorario;
        public frmHorarioDocente1()
        {
            InitializeComponent();
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

        private void frmHorarioDocente1_Load(object sender, EventArgs e)
        {

        }

        private void ArmarHorario(Int32 CodTurno)
        {
            cFunciones fun = new Clases.cFunciones();
            string col = "Hora;Nombre;Lunes;Martes;Miercoles;Jueves;Viernes";
            tbHorario = fun.CrearTabla(col);
            cRangoHorario rango = new cRangoHorario();
            DataTable tb = rango.GetRangoHorario(CodTurno);
            string Hora = "";
            string Nombre = "";
            string Val = "";
            for (int i = 0; i < tb.Rows.Count; i++)
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
    }
}
