using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using conexionbd;

namespace Parroquia
{
    public partial class eliminarLibro : Form
    {
        private int CATEGORIA;
        private int tamanio;
        private String Categorias;
        private string[] datosID;
        private string[] datosNombre;
        private MySqlDataReader conjuntoDatos;
        private ConexionBD BDatos;

        public eliminarLibro(int categoria, int TAMANIO)
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
            InitializeComponent();


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

            comboBox1.Items.AddRange(datosNombre);
            comboBox1.Text = datosNombre[0];

            this.Text = "Eliminar un libro de " + Categorias;

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult b = MessageBox.Show("¿Estás seguro que deseas eliminar el libro " + datosNombre[comboBox1.SelectedIndex] + "?", "¿Seguro?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (b == DialogResult.OK)
            {
                BDatos.conexion();
                try
                {
                    if (BDatos.peticion("delete from libros where id_libro = '" + datosID[comboBox1.SelectedIndex] + "'; ") > 0)
                    {

                        MessageBox.Show("Se ha Eliminado un libro"
                            , " Acción ejecutada con exito ",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();
                    }
                    else
                        MessageBox.Show("Se ha detectado un problema al eliminar un libro"
                           , " Error ",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }catch(Exception y){
                    MessageBox.Show("Se ha detectado un problema al eliminar un libro: "+y.Message

                           , " Error ",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                BDatos.Desconectar();
            }
           
        }
    }
}
