using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexionbd;
using MySql.Data.MySqlClient;

namespace Parroquia
{
    public partial class crearLibro : Form
    {
        private int CATEGORIA;
        private ConexionBD BDatos;

        public crearLibro(int categoria)
        {
            CATEGORIA = categoria;
            BDatos = new ConexionBD();
            InitializeComponent();
        }

        private void cancelarCrearLibro_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guardarCrearLibro_Click(object sender, EventArgs e)
        {
            GuardarR();

        }

        public void GuardarR()
        {

            if (nombreLibro.Text.ToString().CompareTo("") != 0)
            {
                BDatos.conexion();

                //Evaluacion para que los nombres no sean iguales
                int iguales = 0;
                MySqlDataReader Datos = BDatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_categoria='" + CATEGORIA + "'");
                if (nombreLibro.Text.Substring(0, 1).CompareTo(" ") == 0)
                    nombreLibro.Text = nombreLibro.Text.Substring(1, (nombreLibro.Text.Length - 1));

                if (nombreLibro.Text.Substring((nombreLibro.Text.Length - 1), 1).CompareTo(" ") == 0)
                    nombreLibro.Text = nombreLibro.Text.Substring(0, (nombreLibro.Text.Length - 1));

                if (Datos.HasRows)
                    while (Datos.Read())
                    {
                        if (Datos.GetString(0).CompareTo(nombreLibro.Text) == 0)
                        {
                            iguales++;

                        }
                    }
                Datos.Close();
                if (iguales > 0 || nombreLibro.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("No puede agregar nombres de libros iguales y no puede dejar el libro sin nombre"
                     , " Error ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (BDatos.peticion("insert into libros (id_categoria, nombre_libro) values(" + CATEGORIA + ",'" + nombreLibro.Text.ToString() + "');") > 0)
                    {
                        MessageBox.Show("Se ha agregado un libro nuevo"
                            , " Acción ejecutada con exito ",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BDatos.Desconectar();
                        Dispose();

                    }
                    else
                        MessageBox.Show("Se ha detectado un problema al agregar un libro"
                           , " Error ",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                BDatos.Desconectar();
            }
            else
            {
                MessageBox.Show("No puede agregar libros sin nombre"
                        , " Error ",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
