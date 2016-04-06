using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    public partial class DialogConfirmacion : Form
    {

        public static bool impresion = false;

        public DialogConfirmacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.parroquia.Text.CompareTo("") == 0 || this.diocesis.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Debe llenar todos los campos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Imprimir.parroquiaBautismo = this.parroquia.Text;
                Imprimir.diocesisBautismo = this.diocesis.Text;
                impresion = true;
                Dispose();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            impresion = false;
            Dispose();
        }

    }
}
