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
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        public void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }

    

        private void FrmBase_Load(object sender, EventArgs e)
        {

        }
    }
}
