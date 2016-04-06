using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parroquia;
using System.IO;

namespace conexionbd
{
    class ConexionBD
    {
        public static string usuario, contrasena, basedatos, host, puerto;
        public static bool carga_datos_desde_archivo = false, form = true, exit = false;
        public static string conex;
        public static MySqlConnection conexionBD;

        public void verificarDirectorio(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
                
        }

        public ConexionBD(string h, string u, string pass, string port, string bd)
        {
            host = h;
            usuario = u;
            contrasena = pass;
            puerto = port;
            basedatos = bd;
            
        }

        public ConexionBD()
        {
            if (!carga_datos_desde_archivo && form)
            {
                /*host = "localhost";
                usuario = "root";
                contrasena = "UwBJAE0AUABVAFMAMgAxADIANAA=";
                puerto = "3306";
                basedatos = "parroquiaantunez";*/

                host = "";
                usuario = "";
                contrasena = "=";
                puerto = "";
                basedatos = "";
            }
            verificarDirectorio("C:/DOCSParroquia");

            form = false;
        }

        public void conexion()
        {
            try
            {
                //form = false;
                conex = "server="+host+"; port="+puerto+"; user id=" + usuario + "; password=" + DesEncriptar(contrasena) + "; database="+basedatos+";";
                conexionBD = new MySqlConnection(conex);
                conexionBD.Open();
                //form = true;
            }
            catch (MySqlException ex)
            {
                if(form)
                    MessageBox.Show("Error al conectar a la base de datos de MySQL: \nDETALLES DEL ERROR: " + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carga_desde_archivo();
            }
        }

        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            
            string result = string.Empty;
            try
            {
                byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
                result = System.Text.Encoding.Unicode.GetString(decryted);
            }
            catch (Exception e) { }
            return result;
        }

        public void carga_desde_archivo()
        {
            form = true;
            if (!carga_datos_desde_archivo)
            {
                carga_datos_desde_archivo = true;

                if (File.Exists(@"C:\DOCSParroquia\informacion.txt"))
                {
                    /** OBTENER LA INFORMACIÓN DEL ARCHIVO **/
                    string line, archivo = "";
                    StreamReader file = new StreamReader(@"C:\DOCSParroquia\informacion.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        archivo += line;
                    }

                    string[] caracteres = archivo.Split(' ');
                    host = caracteres[0];
                    usuario = caracteres[1];
                    contrasena = caracteres[2];
                    puerto = caracteres[3];
                    basedatos = caracteres[4];
                    file.Close();
                }
                conexion();
            }
            else
            {
                carga_datos_desde_archivo = false;
                if (!exit)
                {
                    new DatosConexionDB().ShowDialog();
                    conexion();
                }
            }
        }

        public MySqlDataReader obtenerBasesDatosMySQL(String consulta)
        {
            MySqlDataReader registrosObtenidosMySQL = null;

            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
            try
            {
                registrosObtenidosMySQL = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener bases de datos de MySQL: \nDETALLES DEL ERROR: " + ex.Message, "Error al obtener catálogos",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return registrosObtenidosMySQL;
        }

        public int peticion(String consulta)
        {
            int resultado=0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
                resultado = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ingresar datos en MySQL: \nDETALLES DEL ERROR: " + ex.Message, " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public void Desconectar()
        {
            conexionBD.Close();
        }
    }
}