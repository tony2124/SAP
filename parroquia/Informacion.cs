using conexionbd;
using MySql.Data.MySqlClient;
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
    public partial class Informacion : Form
    {
        ConexionBD Bdatos = new ConexionBD();
        MySqlDataReader Datos;

        public Informacion()
        {
            InitializeComponent();
            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {

                    nombre_parroquia.Text = Datos.GetValue(0) + "";
                    nombre_parroco.Text = Datos.GetValue(1) + "";
                    ubicacion_parroquia.Text = Datos.GetValue(2) + "";
                    telefono.Text = Datos.GetValue(3) + "";

                    nombre_obispo.Text = Datos.GetValue(6)+"";
                    nombre_diocesis.Text = Datos.GetValue(7) + "";
                }
            }
            Bdatos.Desconectar();

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Bdatos.conexion();
            if (Bdatos.peticion("UPDATE informacion set nombre_parroquia = '" + nombre_parroquia.Text + 
                "', nombre_parroco = '" + nombre_parroco.Text + 
                "', ubicacion_parroquia = '" + ubicacion_parroquia.Text + 
                "', telefono = '" + telefono.Text + 
                "', nombre_obispo = '" + nombre_obispo.Text + 
                "', nombre_diocesis = '" + nombre_diocesis.Text + "'") > 0)
                 MessageBox.Show("Se ha actualizado correctamente la información de la parroquia", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
