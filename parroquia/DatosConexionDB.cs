using conexionbd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    public partial class DatosConexionDB : Form
    {
        public DatosConexionDB()
        {
            InitializeComponent();
        }

        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        private void DatosConexionDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            /** OBTENER LA INFORMACIÓN DEL ARCHIVO **/
            try
            {
                String linea = host.Text + " " + usuario.Text + " " + Encriptar(contrasena.Text) + " " + port.Text + " " + basedatos.Text;
                StreamWriter tw = new StreamWriter("C:/DOCSParroquia/informacion.txt", false, Encoding.Default);
                tw.WriteLine(linea);
                tw.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            ConexionBD.host = host.Text;
            ConexionBD.usuario = usuario.Text;
            ConexionBD.contrasena = Encriptar(contrasena.Text);
            ConexionBD.puerto = port.Text;
            ConexionBD.basedatos = basedatos.Text;
            ConexionBD.form = false;
            this.Dispose();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            ConexionBD.exit = true;
        }
    }
}
