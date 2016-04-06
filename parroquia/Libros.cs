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
    public partial class Libros : Form
    {
        //Declaro variable global tipo publica para recibir 
        //como parametros de que categoria se quiero abrir el libro
        private int CATEGORIA;
        private String Categorias;

        private MySqlDataReader conjuntoDatos;
        private int tamanio;
        private ConexionBD BDatos;

        private Button[] libritos;
        private Panel[] panelitos;
        private Label[] etiquetaLibro;
        private Label[] etiquetaNombre;

        //constructor me recibe los parametros de la categoria 
        //de donde se manda llamar.
        public Libros(int categoria)
        {
            //Asigno los parametos recibidos a la variable global
            CATEGORIA = categoria;

            if (CATEGORIA == 1)
                this.Categorias = "Bautismo";
            if (CATEGORIA == 2)
                this.Categorias = "Confirmación";
            if (CATEGORIA == 3)
                this.Categorias = "Primera Comunión";
            if (CATEGORIA == 4)
                this.Categorias = "Matrimonio";
        
            try
            {
                //Realizo conexion a la base de datos
                BDatos = new ConexionBD();
                BDatos.conexion();
                InitializeComponent();
                label1.Text = "No tiene libros en esta categoría de " + Categorias;
                this.Text = "Libros de " + Categorias;
                Pintar();
            }
            catch (Exception h)
            {
                Dispose();
                MessageBox.Show("Error al conectar al servidor de MySQL: " +
                    h.Message, "Error al conectar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public void crearLibro(object sender, EventArgs e)
        {
            crearLibro cl = new crearLibro(CATEGORIA);
            cl.ShowDialog();

            panelContenedorLibros.Controls.Clear();
            BDatos.conexion();
            Pintar();
            BDatos.Desconectar();
        }

        public void eliminarLibro(object sender, EventArgs e)
        {
            eliminarLibro El = new eliminarLibro(CATEGORIA,tamanio);
            El.ShowDialog();
            panelContenedorLibros.Controls.Clear();
            BDatos.conexion();
            Pintar();
            BDatos.Desconectar();
        }

        public void cancelarVentana(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Insertar(object sender, EventArgs e)
        {
            if (CATEGORIA == 1)
            {
                Button b = (Button)sender;
                Bautismo ib = new Bautismo(b.Name.ToString());
                ib.ShowDialog(); 
            }

            if (CATEGORIA == 2)
            {
                Button b = (Button)sender;
               // MessageBox.Show(b.Name.ToString());
                Confirmacion ic = new Confirmacion(b.Name.ToString());
                ic.ShowDialog();
                
            }

            if (CATEGORIA == 3)
            {
                Button b = (Button)sender;
                PrimerComunion ipc = new PrimerComunion(b.Name.ToString());
                ipc.ShowDialog();

            }

            if (CATEGORIA == 4)
            {
                Button b = (Button)sender;
                Matrimonio im = new Matrimonio(b.Name.ToString());
                im.ShowDialog();

            }
        }

        public void editarLibro(object sender, EventArgs e) 
        {
            editarLibro Editl = new editarLibro(CATEGORIA, tamanio);
            Editl.ShowDialog();
            panelContenedorLibros.Controls.Clear();
            BDatos.conexion();
            Pintar();
            BDatos.Desconectar();
        }

        public void Pintar()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Libros));

            //Realizo la consulto a la tabla libros
            conjuntoDatos = BDatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_categoria='" + CATEGORIA + "';");
            //Se contabiliza para saber cuantos registros tiene 
            //la consulta que se hizo a la tabla libros
            if (conjuntoDatos.HasRows)
            {
                eliminarLibroButton.Enabled = true;
                tamanio = 0;
                while (conjuntoDatos.Read())
                {
                    tamanio++;
                }
                conjuntoDatos.Close();


                conjuntoDatos = BDatos.obtenerBasesDatosMySQL("select id_libro, id_categoria, nombre_libro from libros where id_categoria='" + CATEGORIA + "';");

                /*Se inicializan los componentes que integraran 
            * los libros virtuales*/
                this.panelitos = new System.Windows.Forms.Panel[tamanio];
                this.libritos = new System.Windows.Forms.Button[tamanio];
                this.etiquetaLibro = new System.Windows.Forms.Label[tamanio];
                this.etiquetaNombre = new System.Windows.Forms.Label[tamanio];

                /*Inicializacion y agregacion de los componentes que integran
                 la ventana libros*/
                int i = 0;
                int u = 4, v = 4;

                while (conjuntoDatos.Read())
                {
                    this.panelitos[i] = new System.Windows.Forms.Panel();
                    this.libritos[i] = new System.Windows.Forms.Button();
                    this.etiquetaLibro[i] = new System.Windows.Forms.Label();
                    this.etiquetaNombre[i] = new System.Windows.Forms.Label();

                    this.libritos[i].Image = global::Parroquia.Properties.Resources.Book_Red;
                    this.libritos[i].Location = new System.Drawing.Point(4, 4);
                    this.libritos[i].Name = conjuntoDatos.GetString(0);
                    this.libritos[i].Size = new System.Drawing.Size(73, 73);
                    this.libritos[i].UseVisualStyleBackColor = true;
                    this.libritos[i].Click += new System.EventHandler(this.Insertar);

                    this.etiquetaLibro[i].AutoSize = true;
                    this.etiquetaLibro[i].Location = new System.Drawing.Point(4, 84);
                    this.etiquetaLibro[i].Name = "label" + (i + 1);
                    this.etiquetaLibro[i].Size = new System.Drawing.Size(36, 13);
                    this.etiquetaLibro[i].Text = "Libro: ";

                    this.etiquetaNombre[i].AutoSize = true;
                    this.etiquetaNombre[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.etiquetaNombre[i].Location = new System.Drawing.Point(40, 85);
                    this.etiquetaNombre[i].Name = "label" + (i + 1);
                    this.etiquetaNombre[i].Text = conjuntoDatos.GetString(2);

                    this.panelitos[i].Controls.Add(libritos[i]);
                    this.panelitos[i].Controls.Add(etiquetaLibro[i]);
                    this.panelitos[i].Controls.Add(etiquetaNombre[i]);
                    this.panelitos[i].Location = new System.Drawing.Point(u, v);
                    this.panelitos[i].Size = new System.Drawing.Size(123, 108);
                    this.panelitos[i].Name = "panel" + (i + 1);
                    this.panelContenedorLibros.Controls.Add(this.panelitos[i]);
                    u += 124;
                    //cada 5 libros agrega una fila de libros nueva en la ventana
                    if ((i + 1) % 4 == 0) { v = v + 131; u = 4; }
                    i++;

                }
            }
            else
            {
                this.panelContenedorLibros.Controls.Add(this.label1);
                eliminarLibroButton.Enabled = false;
            }

            //Cierro el lector de los datos consultados en Mysql
            conjuntoDatos.Close();
            BDatos.Desconectar();
        }

    }
}
