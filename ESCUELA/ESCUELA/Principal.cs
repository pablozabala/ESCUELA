using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESCUELA
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;
        public static Int32 Codigo;
        
        //nombre del campo id
        public static string CampoIdSecundario;
        //nombre del campo descripcion
        public static string CampoNombreSecundario;
        //nombre de la tabla donde se realiza el grabado
        public static string NombreTablaSecundario;
        public static string NombreLabelSecundario;
        //valor del id que genera al insertar
        public static string CampoIdSecundarioGenerado;
        public static Int32 CodUsuarioLogueado;
        public static string NombreUsuarioLogueado;
        public static string CodigoPrincipalAbm;
        public static string CodigoSenia;

        public static string OpcionesdeBusqueda;
        public static string TablaPrincipal;
        public static string OpcionesColumnasGrilla;
        public static string ColumnasVisibles;
        public static string ColumnasAncho;
        public static string Comodin;
        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            FrmAbmConvocatoria frm = new ESCUELA.FrmAbmConvocatoria();
            frm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            FrmInscripcionConvocatoria frm = new ESCUELA.FrmInscripcionConvocatoria();
            frm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void docenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbmDocente fr = new ESCUELA.FrmAbmDocente();
            fr.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroCargo frm = new FrmRegistroCargo();
            frm.Show();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoCargos frm = new ESCUELA.FrmListadoCargos();
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmCopia frm = new ESCUELA.FrmCopia();
            frm.Show();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            FrmCopia frm = new ESCUELA.FrmCopia();
            frm.Show();
        }

        private void BTNdOCENTES_Click(object sender, EventArgs e)
        {
            FrmAbmDocente frm = new FrmAbmDocente();
            frm.Show();
        }
    }
}
