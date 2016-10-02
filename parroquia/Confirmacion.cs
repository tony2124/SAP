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
    public partial class Confirmacion : Form
    {
        private String ID_LIBRO;
        private int Partida;
        private double Hoja;
        public static Object[] anios;

        //VARIABLES OCUPADAS PARA LA EDICION
        private int ID_REGISTRO;
        private Boolean edicion;
        private Boolean btn = false;


        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        /*CONSTRUCTOR PARA INSERTAR REGISTRO */
        public Confirmacion(String ID_libro)
        {
            edicion = false;
            ID_LIBRO = ID_libro;
            InitializeComponent();
            
            try
            {
                Bdatos.conexion();
                Datos = Bdatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_libro="+ID_LIBRO+";");
                if (Datos.HasRows)
                {
                    while (Datos.Read()) {
                        libro.Text = Datos.GetString(0);                        
                    }
                }
                Datos.Close();

                /**** MODIFICANDO EL FORMULARIO *****/
                toolTip1.SetToolTip(this.guardarConfirBtn, ":: GUARDAR REGISTRO ::");
                toolTip1.SetToolTip(this.guardaImprimeBtn, ":: GUARDAR E IMPRIMIR ::");
                Text = ":: INSERTAR REGISTRO DE CONFIRMACIÓN ::";
            
                //cargar los datos para el autocomplete del textbox
                lugarbau.AutoCompleteCustomSource = Autocomplete(0);
                lugarbau.AutoCompleteMode = AutoCompleteMode.Suggest;
                lugarbau.AutoCompleteSource = AutoCompleteSource.CustomSource;

                /****************************************************************/
                ministro.AutoCompleteCustomSource = Autocomplete(1);
                ministro.AutoCompleteMode = AutoCompleteMode.Suggest;
                ministro.AutoCompleteSource = AutoCompleteSource.CustomSource;

                /*Estableciendo la partida y hoja*/
                Partida = 1;
                Hoja = 1;
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_libro, num_hoja, num_partida from confirmaciones where id_libro =" + ID_LIBRO + " AND bis = 0  order by num_hoja asc, num_partida asc");

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        Partida = Datos.GetInt16(2);
                        Hoja = Datos.GetInt16(1);
                    }
                }
                num_partida.Text = "" + (Partida + 1);
                num_hoja.Text = "" + Hoja;
                Datos.Close();
                /*Reestablecer la ultima fecha de bautismo*/
                Datos = Bdatos.obtenerBasesDatosMySQL("select max(fecha_confirmacion) from confirmaciones where id_libro =" + ID_LIBRO);

                if (Datos.HasRows)
                    if (Datos.Read())
                        fecconf.Text = Datos.GetValue(0) + "";
                    
                Datos.Close();

                /*CALCULANDO LA HOJA*/
              /*  Hoja = Math.Ceiling((Partida + 1) / 10.0);
                num_hoja.Text = "" + Hoja;
                */
                Bdatos.Desconectar();
            }
            catch (Exception r) { MessageBox.Show("Error: " + r.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            
        }

        //CONSTRUCTOR PARA EDICIONES
        public Confirmacion(int id_registro,  String NOMMBRE_LIBRO)
        {  
            edicion = true;
            ID_REGISTRO = id_registro;

            InitializeComponent();
            //Establecemos los componentes sin edicion

            habilitarCampos(false);

            /******* MODIFICACION DEL FORMULARIO *******/
            guardarConfirBtn.Image = global::Parroquia.Properties.Resources.actualizar;
            toolTip1.SetToolTip(this.guardarConfirBtn, ":: MODIFICAR REGISTRO ::");
            toolTip1.SetToolTip(this.guardaImprimeBtn, ":: IMPRIMIR ::");
            Text = ":: MODIFICAR REGISTRO DE CONFIRMACIÓN ::";

            //cargar los datos para el autocomplete del textbox
            lugarbau.AutoCompleteCustomSource = Autocomplete(0);
            lugarbau.AutoCompleteMode = AutoCompleteMode.Suggest;
            lugarbau.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //cargar los datos para el autocomplete del textbox
            ministro.AutoCompleteCustomSource = Autocomplete(1);
            ministro.AutoCompleteMode = AutoCompleteMode.Suggest;
            ministro.AutoCompleteSource = AutoCompleteSource.CustomSource;

            try
            {  
                libro.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM confirmaciones where id_confirmacion = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        num_hoja.Text = Datos.GetString(2);
                        num_partida.Text = Datos.GetString(3);
                        nombre.Text = Datos.GetString(4);
                        padre.Text = Datos.GetString(5);
                        madre.Text = Datos.GetString(6);
                        fecconf.Text = Datos.GetString(7);
                        fecbau.Text = Datos.GetString(8);
                        lugarbau.Text = Datos.GetString(9);
                        padrino.Text = Datos.GetString(10);
                        madrina.Text = Datos.GetString(11);
                        ministro.Text = Datos.GetString(12);
                       
                    }
                }
                Bdatos.Desconectar();
            }
            catch (Exception j)
            {
                MessageBox.Show("Error al mostrar edicion. "+j.Message, " Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* HABILITA O DESHABILITA LOS CAMPOS */
        public void habilitarCampos(Boolean enabled)
        {
            nombre.Enabled = enabled;
            padre.Enabled = enabled;
            madre.Enabled = enabled;
            fecconf.Enabled = enabled;
            lugarbau.Enabled = enabled;
            fecbau.Enabled = enabled;
            padrino.Enabled = enabled;
            madrina.Enabled = enabled;
            ministro.Enabled = enabled;
            registronull.Enabled = enabled;
            registrobis.Enabled = enabled;
            num_hoja.Enabled = enabled;
            num_partida.Enabled = enabled;
        }

        /*Se establecen en blanco todos los campos*/
        public void limpiarCampos()
        {
            nombre.Text = "";
            nombre.Focus();
            padre.Text = "";
            madre.Text = "";
            padrino.Text = "";
            madrina.Text = "";
           // lugarbau.Text = "";
           // ministro.Text = "";
        }

        /* VERIFICA SI HAY CAMPOS OBLIGATORIOS VACIOS */
        public Boolean camposVacios()
        {
            if ((nombre.Text.ToString().CompareTo("") == 0) ||
                       (padre.Text.CompareTo("") == 0) ||
                       (madre.Text.CompareTo("") == 0) ||
                       (padrino.Text.CompareTo("") == 0) ||
                       (madrina.Text.CompareTo("") == 0) ||
                       (lugarbau.Text.CompareTo("") == 0) ||
                       (ministro.Text.CompareTo("") == 0))
            {
                MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /** GUARDAR EL REGISTRO A LA BD */
        public bool guardarRegistro()
        {
            Bdatos.conexion();
            //Se prepara para verificar si es BIS
            String bis = "0", partida = num_partida.Text;
            if (registrobis.Checked)
                bis = "1";
            Partida = Int16.Parse(num_partida.Text);
            Hoja = Int16.Parse(num_hoja.Text);
            if (Bdatos.peticion("insert into confirmaciones(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_confirmacion,fecha_bautismo,lugar_bautismo,padrino,madrina,presbitero,anio,bis)" +
                    " values('" + int.Parse(ID_LIBRO) +
                    "','" + int.Parse(num_hoja.Text) +
                    "','" + num_partida.Text +
                    "','" + nombre.Text +
                    "','" + padre.Text +
                    "','" + madre.Text +
                    "','" + fecconf.Value.ToString("yyyy-MM-dd") +
                    "','" + fecbau.Value.ToString("yyyy-MM-dd") +
                    "','" + lugarbau.Text +
                    "','" + padrino.Text +
                    "','" + madrina.Text +
                    "','" + ministro.Text +
                    "','" + fecconf.Value.Year +
                    "'," + bis + ");") > 0)
            {
                MessageBox.Show("Datos ingresados correctamente ", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bdatos.Desconectar();
                return true;
            }
           
            Bdatos.Desconectar();
            return false;
        }

        private void guardarConfirBtn_Click(object sender, EventArgs e)
        {

            if (!edicion)//si no esta puesta edicion se guarda normalmente
            {
                if (!registronull.Checked)
                    if (camposVacios())
                        return;
                if (guardarRegistro())
                    calculaPartida();
            }
            else //Si edicion esta puesta
            {
                if (btn == false)
                {
                    btn = true;
                    guardarConfirBtn.Image = global::Parroquia.Properties.Resources.guardar;
                    guardaImprimeBtn.Enabled = false;
                    toolTip1.SetToolTip(guardarConfirBtn, ":: GUARDAR REGISTRO ::");
                    habilitarCampos(true);
                    return;
                }
                else
                {
                    if (!registronull.Checked)
                        if (camposVacios())
                            return;
                    if (actualizarRegistro())
                        btn = false;
                }
            }
            lugarbau.AutoCompleteCustomSource = Autocomplete(0);
            ministro.AutoCompleteCustomSource = Autocomplete(1);
        }

        private bool actualizarRegistro()
        {
            Bdatos.conexion();

            if (Bdatos.peticion("UPDATE confirmaciones SET nombre='" + nombre.Text +
                     "',padre='" + padre.Text + "',madre='" + madre.Text +
                     "',fecha_confirmacion='" + fecconf.Value.ToString("yyyy-MM-dd") + "',fecha_bautismo='" + fecbau.Value.ToString("yyyy-MM-dd") +
                     "',lugar_bautismo='" + lugarbau.Text + "',padrino='" + padrino.Text +
                     "',madrina='" + madrina.Text + "',presbitero='" + ministro.Text +
                     "',anio='" + fecconf.Value.Year + "' , num_hoja = " + num_hoja.Text + ", num_partida = " + num_partida.Text + " where id_confirmacion= '" + ID_REGISTRO + "';") > 0)
            {
                btn = false;
                this.guardaImprimeBtn.Enabled = true;
                guardarConfirBtn.Image = global::Parroquia.Properties.Resources.actualizar;
                toolTip1.SetToolTip(guardarConfirBtn, ":: MODIFICAR REGISTRO ::");

                habilitarCampos(false);

                //actualizar tabla de busqueda
                Parroquia.btnbuscar.PerformClick();
                MessageBox.Show("Registro actualizado correctamente ", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bdatos.Desconectar();
                return true;
            }
            Bdatos.Desconectar();
            return false;
        }

        private void guardaImprimeBtn_Click(object sender, EventArgs e)
        {
            if (!edicion)
            {
                if (!registronull.Checked)
                    if (camposVacios())
                        return;

                if (guardarRegistro())
                {

                    //IMPRIME
                    formatosImpresion fi = new formatosImpresion(libro.Text, num_hoja.Text,
                             num_partida.Text, nombre.Text, padre.Text, madre.Text, lugarbau.Text,
                             fecbau.Value.ToString("yyyy-MMMM-dd"), fecconf.Value.ToString("yyyy-MMMM-dd"),
                             ministro.Text, madrina.Text, padrino.Text, "", 2);
                    fi.ShowDialog();

                    // Imprimir a = new Imprimir();

                    calculaPartida();
                }
            }
            else
            {
                //IMPRIME
                formatosImpresion fi = new formatosImpresion(libro.Text, num_hoja.Text,
                             num_partida.Text, nombre.Text, padre.Text, madre.Text, lugarbau.Text,
                             fecbau.Value.ToString("yyyy-MMMM-dd"), fecconf.Value.ToString("yyyy-MMMM-dd"),
                             ministro.Text, madrina.Text, padrino.Text,"",2);
                fi.ShowDialog();

            }
        }

        //metodo para cargar los datos de la bd
        public DataTable DatosAutocomplete(int tipo)
        {
            DataTable dt = new DataTable();
            string consulta;
            if(tipo == 0)
                consulta = "SELECT lugar_bautismo as auto FROM confirmaciones";
            else
                consulta = "SELECT presbitero as auto FROM confirmaciones";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD.conexionBD);
            MySqlDataAdapter adap = new MySqlDataAdapter(comando);
            adap.Fill(dt);
            return dt;
        }

        //metodo para cargar la coleccion de datos para el autocomplete
        public AutoCompleteStringCollection Autocomplete(int tipo)
        {
            DataTable dt = DatosAutocomplete(tipo);

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["auto"]));
            }

            return coleccion;
        }

        private void nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void botones(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guardarConfirBtn.PerformClick();
        }

        private void padre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void madre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void lugar_bautismo_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void padrino_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void madrina_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void ministro_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void registrobis_CheckedChanged(object sender, EventArgs e)
        {
            if (registrobis.Checked)
            {
                num_partida.Text = (int.Parse(num_partida.Text) - 1) + "BIS";
            }
            else
            {
                num_partida.Text = (Partida + 1) + "";
            }
        }

        private void registronull_CheckedChanged(object sender, EventArgs e)
        {
            if (registronull.Checked)
            {
                habilitarCampos(false);
                limpiarCampos();               
                guardaImprimeBtn.Enabled = false;
                registronull.Enabled = true;
            }
            else
            {
                habilitarCampos(true);
                if (!edicion)
                    guardaImprimeBtn.Enabled = true;
                else guardaImprimeBtn.Enabled = false;
            }
        }

        private void calculaPartida()
        {
            if (!registrobis.Checked)
                Partida++;
            else
                registrobis.Checked = false;

            num_partida.Text = "" + (Partida);
            /*
            Hoja = Math.Ceiling((Partida + 1) / 10.0);
            num_hoja.Text = "" + Hoja;
            */
            limpiarCampos();
        }
    }
}
