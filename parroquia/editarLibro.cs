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
    public partial class editarLibro : Form
    {
        private int CATEGORIA;
        private int tamanio;
        private String Categorias;
        private string[] datosID;
        private string[] datosNombre;
        private MySqlDataReader conjuntoDatos;
        private ConexionBD BDatos;

        public editarLibro(int categoria, int TAMANIO)
        {
            CATEGORIA = categoria;
            if (CATEGORIA == 1)
                this.Categorias = "Bautismo";
            if (CATEGORIA == 2)
                this.Categorias = "Confirmación";
            if (CATEGORIA == 3)
                this.Categorias = "Primera Comunión";
            if (CATEGORIA == 4)
                this.Categorias = "Matrimonio";
            tamanio = TAMANIO;
            BDatos = new ConexionBD();

            BDatos.conexion();
            conjuntoDatos = BDatos.obtenerBasesDatosMySQL("select id_libro, nombre_libro from libros where id_categoria='" + CATEGORIA + "';");

            datosNombre = new string[tamanio];
            datosID = new string[tamanio];
            int i = 0;
            while (conjuntoDatos.Read())
            {
                datosNombre[i] = conjuntoDatos.GetString(1);
                datosID[i] = conjuntoDatos.GetString(0);
                i++;
            }
            BDatos.Desconectar();
            InitializeComponent();

            this.comboBoxNLibros.Items.AddRange(datosNombre);
            this.comboBoxNLibros.Text = datosNombre[0];
            this.Text = "Editar libro de la categoria de " + Categorias;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void editarLibros(object sender, EventArgs e)
        {
            BDatos.conexion();
             try {
                //Evaluacion para que los nombres no sean iguales
                 if (textBox1.Text.Substring(0, 1).CompareTo(" ") == 0)
                     textBox1.Text = textBox1.Text.Substring(1, (textBox1.Text.Length - 1));

                 if (textBox1.Text.Substring((textBox1.Text.Length - 1), 1).CompareTo(" ") == 0)
                     textBox1.Text = textBox1.Text.Substring(0, (textBox1.Text.Length - 1));

                int iguales = 0;
                MySqlDataReader Datos = BDatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_categoria='" + CATEGORIA + "'");
                if (Datos.HasRows)
                    while (Datos.Read())
                    {
                        if (Datos.GetString(0).CompareTo(textBox1.Text) == 0)
                        {
                            iguales++;

                        }
                    }
                Datos.Close();
                if (iguales > 0 || textBox1.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("No puede agregar nombres de libros iguales y no puede dejar el libro sin nombre"
                     , " Error ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                        if (BDatos.peticion("update libros set nombre_libro = '" + textBox1.Text + "' where id_libro = '" + datosID[comboBoxNLibros.SelectedIndex] + "'") > 0)
                        {
                            MessageBox.Show("Se ha Editado el libro exitosamente"
                                        , " Acción ejecutada con exito ",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Se ha detectado un problema al editar el libro"
                                      , " Error ",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                
            }
             catch (Exception j)
             {
                 MessageBox.Show("Se ha detectado un problema al editar el libro: " + j.Message
                                   , " Error ",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

            BDatos.Desconectar();
        }
    }
}
