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
    public partial class configurarCoordenada : Form
    {
        public MySqlDataReader datos;
        private float bhx, bhy, bvx, bvy, cx, cy, px, py, mx, my;
        private ConexionBD Bda;
        public configurarCoordenada()
        {
            InitializeComponent();
            int i = 0;
            Bda = new ConexionBD();

            Bda.conexion();

            datos = Bda.obtenerBasesDatosMySQL("select x,y from coordenadas");

            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    if (i == 0)
                    {
                        BHX.Text = datos.GetString(0);
                        BHY.Text = datos.GetString(1);
                    }
                    else if (i == 1)
                    {
                        CX.Text = datos.GetString(0);
                        CY.Text = datos.GetString(1);
                    }
                    else if (i == 2)
                    {
                        PX.Text = datos.GetString(0);
                        PY.Text = datos.GetString(1);
                    }
                    else if (i == 3)
                    {
                        MX.Text = datos.GetString(0);
                        MY.Text = datos.GetString(1);
                    }
                    else if (i == 4)
                    {
                        BVX.Text = datos.GetString(0);
                        BVY.Text = datos.GetString(1);
                    }


                    i++;
                    
                }
            }
            datos.Close();
            Bda.Desconectar();

        }

        private void configurarCoordenada_Load(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                bhx = float.Parse(BHX.Text);
                bhy = float.Parse(BHY.Text);

                bvx = float.Parse(BVX.Text);
                bvy = float.Parse(BVY.Text);

                cx = float.Parse(CX.Text);
                cy = float.Parse(CY.Text);

                px = float.Parse(PX.Text);
                py = float.Parse(PY.Text);

                mx = float.Parse(MX.Text);
                my = float.Parse(MY.Text);

                Bda.conexion();

                if (Bda.peticion("update coordenadas set x=" + BHX.Text + ", y=" + BHY.Text + " where id=1") > 0 &&
                    Bda.peticion("update coordenadas set x=" + BVX.Text + ", y=" + BVY.Text + " where id=5") > 0 &&
                    Bda.peticion("update coordenadas set x=" + CX.Text + ", y=" + CY.Text + " where id=2") > 0 &&
                    Bda.peticion("update coordenadas set x=" + PX.Text + ", y=" + PY.Text + " where id=3") > 0 &&
                    Bda.peticion("update coordenadas set x=" + MX.Text + ", y=" + MY.Text + " where id=4") > 0)
                    MessageBox.Show("Coordenadas actualizadas", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bda.Desconectar();
            }
            catch (FormatException ev) { MessageBox.Show("Debe introducir solo numeros: "+ev.Message); }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
