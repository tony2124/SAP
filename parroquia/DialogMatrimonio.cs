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
    public partial class DialogMatrimonio : Form
    {
        public static bool impresion = false;

        public DialogMatrimonio()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (padreNovio.Text.CompareTo("") == 0 ||
                madreNovio.Text.CompareTo("") == 0 ||
                padreNovia.Text.CompareTo("") == 0 ||
                madreNovia.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Imprimir.padreNovio = padreNovio.Text;
                Imprimir.madreNovio = madreNovio.Text;
                Imprimir.padreNovia = padreNovia.Text;
                Imprimir.madreNovia = madreNovia.Text;

                impresion = true;
                Dispose();
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            impresion = false;
            Dispose();
        }
    }
}
