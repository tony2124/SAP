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


using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
namespace Parroquia
{
    public partial class Informacion : Form
    {
        ConexionBD Bdatos = new ConexionBD();
        MySqlDataReader Datos;
        public bool cambiofoto = false;
        public string ruta = "c:/DOCSParroquia/logo.jpg";
        public Informacion()
        {
            InitializeComponent();

            logo.ImageLocation = ruta;

            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

           

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {
                    nombre_parroquia.Text = Datos.GetValue(0) + "";
                    nombre_parroco.Text = Datos.GetValue(1) + "";
                    calles.Text = Datos.GetValue(2) + "";
                    colonia.Text = Datos.GetValue(3) + "";
                    ciudad.Text = Datos.GetValue(4) + "";
                    estado.Text = Datos.GetValue(5) + "";
                    cp.Text = Datos.GetValue(6) + "";
                    
                    telefono.Text = Datos.GetValue(7) + "";
                    email.Text = Datos.GetValue(8) + "";
                    //ubicacion carpeta = Datos.GetValue(9) + "";
                    //contrasena  = Datos.GetValue(10) + "";
                    nombre_obispo.Text = Datos.GetValue(11)+"";
                    nombre_diocesis.Text = Datos.GetValue(12) + "";

                    /*
                    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    var qrCode = qrEncoder.Encode(Datos.GetValue(0) + ", " + Datos.GetValue(12) );

                    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                    using (var stream = new FileStream(@"c:/DOCSParroquia/qrcode.png", FileMode.Create))
                        renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);*/

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

            if (cambiofoto)
            {
                string archivoorigen = BuscarImagen.FileName;

                if (File.Exists(@ruta))
                    File.Delete(@ruta);
                File.Copy(archivoorigen, @ruta, true);
                cambiofoto = false;
            }

            if (Bdatos.peticion("UPDATE informacion set nombre_parroquia = '" + nombre_parroquia.Text + 
                "', nombre_parroco = '" + nombre_parroco.Text + 
                "', calles = '" + calles.Text + 
                "', colonia = '" + colonia.Text +
                "', ciudad = '" + ciudad.Text +
                "', estado = '" + estado.Text +
                "', cp = '" + cp.Text +
                "', telefono = '" + telefono.Text +
                "', email = '" + email.Text + 
                "', nombre_obispo = '" + nombre_obispo.Text + 
                "', nombre_diocesis = '" + nombre_diocesis.Text + "'") > 0)
                 MessageBox.Show("Se ha actualizado correctamente la información de la parroquia", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void cambiar_Click(object sender, EventArgs e)
        {
            cambiarImagen();
        }

        void cambiarImagen()
        {
            BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Todos los archivos de Imagen (*.gif;*.bmp;*.jpg;*.png)|*.gif;*.bmp;*.jpg;*.png";
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Buscar imagen logo del sitio";
            BuscarImagen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                String Direccion = BuscarImagen.FileName;

                logo.ImageLocation = Direccion;
                //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 
              //  logo.SizeMode = PictureBoxSizeMode.Zoom;
                cambiofoto = true;
            }
        }
    }
}
