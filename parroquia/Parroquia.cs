using conexionbd;
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
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Parroquia
{
    public partial class Parroquia : Form
    {
        static ConexionBD BDatos;

        public static MySqlDataAdapter Adaptador;
        public static DataTable ds;
        int foto = 0, n_total_registros = 0;
        bool play = false;

        public Parroquia()
        {
            BDatos = new ConexionBD();
            BDatos.conexion();
            InitializeComponent();
            combo_categoria.SelectedIndex = 0;
            Text = "Sistema para la Administración de la Parroquia";
            /*************************** CONTAR REGISTROS DE TODOS LOS LIBROS *********************************/
            MySqlDataReader Datos = BDatos.obtenerBasesDatosMySQL("select count(id_bautismo) from bautismos");
            if (Datos != null)
            {
                if (Datos.HasRows)
                    while (Datos.Read())
                        n_total_registros += Datos.GetInt32(0);
                Datos.Close();
                Datos = BDatos.obtenerBasesDatosMySQL("select count(id_confirmacion) from confirmaciones");
                if (Datos.HasRows)
                    while (Datos.Read())
                        n_total_registros += Datos.GetInt32(0);
                Datos.Close();
                Datos = BDatos.obtenerBasesDatosMySQL("select count(id_comunion) from comuniones");
                if (Datos.HasRows)
                    while (Datos.Read())
                        n_total_registros += Datos.GetInt32(0);
                Datos.Close();
                Datos = BDatos.obtenerBasesDatosMySQL("select count(id_matrimonio) from matrimonios");
                if (Datos.HasRows)
                    while (Datos.Read())
                        n_total_registros += Datos.GetInt32(0);
                Datos.Close();
            }

            ip.Text = LocalIPAddress();
            total_registros.Text = "" + n_total_registros;
        }

        public void Pintar_tabla(String filtro, String libros)
        {
            //************************ APLICAR FILTROS DE CONSULTA DE DATOS *********************************/
            string otros_filtros = "";
            if ( combo_categoria.SelectedIndex > 0 )
                otros_filtros = " AND id_categoria = " + combo_categoria.SelectedIndex;
            if (text_anio.Text.CompareTo("") != 0)
                otros_filtros += " AND anio = '" + text_anio.Text + "'";
            if (text_hoja.Text.CompareTo("") != 0)
                otros_filtros += " AND num_hoja = '" + text_hoja.Text+"'";
            if (text_libro.Text.CompareTo("") != 0)
                otros_filtros += " AND nombre_libro = '" + text_libro.Text+"'";
  
            string consulta = "select id_confirmacion as id, id_libro, id_categoria, nombre, lugar_bautismo as lugar, anio, nombre_categoria, nombre_libro, num_hoja, num_partida" +
           " from confirmaciones natural join libros natural join categorias where ((nombre like '%" + filtro + "%' or anio = '" + filtro + "') " + otros_filtros + " AND lugar_bautismo like '%" + text_lugar.Text + "%' AND length(nombre) >= 0) union " +
           " select id_matrimonio as id,id_libro,id_categoria, novio as nombre, lugar_celebracion as lugar, anio, nombre_categoria, nombre_libro, num_hoja, num_partida" +
           " from matrimonios natural join libros natural join categorias where ((novio like '%" + filtro + "%' or anio = '" + filtro + "') " + otros_filtros + " AND lugar_celebracion like '%" + text_lugar.Text + "%' AND length(novio) >= 0) union " +
           " select id_matrimonio as id,id_libro,id_categoria, novia as nombre, lugar_celebracion as lugar, anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
           " from matrimonios natural join libros natural join categorias where ((novia like '%" + filtro + "%' or anio = '" + filtro + "') " + otros_filtros + " AND lugar_celebracion like '%" + text_lugar.Text + "%' AND length(novia) >= 0) union " +
           " select id_comunion as id,id_libro,id_categoria, nombre, lugar_bautismo as lugar, anio, nombre_categoria, nombre_libro, num_hoja,num_partida" +
           " from comuniones natural join libros natural join categorias where ((nombre like '%" + filtro + "%' or anio = '" + filtro + "') " + otros_filtros + " AND lugar_bautismo like '%" + text_lugar.Text + "%' AND length(nombre) >= 0) union " +
           " select id_bautismo as id,id_libro,id_categoria, nombre, lugar_nac as lugar, anio, nombre_categoria,nombre_libro,  num_hoja,num_partida" +
           " from bautismos natural join libros natural join categorias where ((nombre like '%" + filtro + "%' or anio = '" + filtro + "') " + otros_filtros + " AND lugar_nac like '%" + text_lugar.Text + "%' AND length(nombre) >= 0  ) order by nombre asc ";
          
            //MessageBox.Show(otros_filtros);

            Adaptador = new MySqlDataAdapter(consulta, ConexionBD.conex);

            ds = new DataTable();
            Adaptador.Fill(ds);
            tablaBusqueda.DataSource = ds;
            
           /* MessageBox.Show(consulta);*/

            reg_encontrados.Text = tablaBusqueda.RowCount + "";
            
            //Ancho de columnas al tamaño del contenido
            tablaBusqueda.AutoResizeColumns();

            //Agregamos nombre de headers de las columnas
            tablaBusqueda.Columns[0].Visible = true;
            tablaBusqueda.Columns[0].HeaderText = "ID";
            tablaBusqueda.Columns[0].Width = 45;

            tablaBusqueda.Columns[1].HeaderText = "IDLIB.";
            tablaBusqueda.Columns[1].Width = 45;
            
            //tablaBusqueda.Columns[2].Visible = true;
            tablaBusqueda.Columns[2].HeaderText = "CAT.";
            tablaBusqueda.Columns[2].Width = 40;

            tablaBusqueda.Columns[3].HeaderText = "NOMBRE";
            tablaBusqueda.Columns[3].Width = 420;

            tablaBusqueda.Columns[4].HeaderText = "LUGAR NAC. / BAUTISMO / CELEBRACIÓN";

            tablaBusqueda.Columns[5].HeaderText = "AÑO";
            tablaBusqueda.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[6].HeaderText = "CATEGORIA";
            tablaBusqueda.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[7].HeaderText = "LIBRO";
            tablaBusqueda.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[8].HeaderText = "FOJA";
            tablaBusqueda.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[9].HeaderText = "PARTIDA";
            tablaBusqueda.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            //Oculto columna inicial
            tablaBusqueda.RowHeadersVisible = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 1)
                {
                    Bautismo ib = new Bautismo(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    ib.ShowDialog();
                }else
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 2)
                {
                    Confirmacion ic = new Confirmacion(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    ic.ShowDialog();
                }
                else
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 3)
                {
                    PrimerComunion ipc = new PrimerComunion(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    ipc.ShowDialog();
                }
                else
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 4)
                {
                    Matrimonio im = new Matrimonio(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    im.ShowDialog();
                }
               
            }
        }

        private void informacionDeLaParroquiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Informacion().ShowDialog();
        }

        private void bautismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Libros l = new Libros(1);
                l.ShowDialog();
            }
            catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void confirmaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {
                Libros l = new Libros(2);
                l.ShowDialog();
            }
             catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void primeraComuniónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Libros l = new Libros(3);
                l.ShowDialog();
            }
            catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void matrimonioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Libros l = new Libros(4);
                l.ShowDialog();
            }
            catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnbuscar.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string libro = "and id_categoria = " + (combo_categoria.SelectedIndex + 1);

            Pintar_tabla(busqueda.Text, libro);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongDateString() + "   " + DateTime.Now.ToLongTimeString();
        }

        public void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new acercade().ShowDialog() ;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foto++;
            if (foto == 20)
                foto = 0;
            cambiarFoto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foto--;
            if (foto == -1)
                foto = 19;
            cambiarFoto();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Ingresos().ShowDialog();
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Egresos().ShowDialog();
        }

        public void cambiarFoto()
        {
            switch (foto)
            {
                case 0: fondoImg.Image = global::Parroquia.Properties.Resources.p1;
                    break;
                case 1: fondoImg.Image = global::Parroquia.Properties.Resources.p2;
                    break;
                case 2: fondoImg.Image = global::Parroquia.Properties.Resources.p3;
                    break;
                case 3: fondoImg.Image = global::Parroquia.Properties.Resources.p4;
                    break;
                case 4: fondoImg.Image = global::Parroquia.Properties.Resources.p5;
                    break;
                case 5: fondoImg.Image = global::Parroquia.Properties.Resources.p6;
                    break;
                case 6: fondoImg.Image = global::Parroquia.Properties.Resources.p7;
                    break;
                case 7: fondoImg.Image = global::Parroquia.Properties.Resources.p8;
                    break;
                case 8: fondoImg.Image = global::Parroquia.Properties.Resources.p9;
                    break;
                case 9: fondoImg.Image = global::Parroquia.Properties.Resources.p10;
                    break;
                case 10: fondoImg.Image = global::Parroquia.Properties.Resources.p11;
                    break;
                case 11: fondoImg.Image = global::Parroquia.Properties.Resources.p12;
                    break;
                case 12: fondoImg.Image = global::Parroquia.Properties.Resources.p13;
                    break;
                case 13: fondoImg.Image = global::Parroquia.Properties.Resources.p14;
                    break;
                case 14: fondoImg.Image = global::Parroquia.Properties.Resources.p15;
                    break;
                case 15: fondoImg.Image = global::Parroquia.Properties.Resources.p16;
                    break;
                case 16: fondoImg.Image = global::Parroquia.Properties.Resources.p17;
                    break;
                case 17: fondoImg.Image = global::Parroquia.Properties.Resources.p18;
                    break;
                case 18: fondoImg.Image = global::Parroquia.Properties.Resources.p19;
                    break;
                case 19: fondoImg.Image = global::Parroquia.Properties.Resources.p20;
                    break;
                
            }
            
        }

        private void respaldoDeBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metodoRespaldo();
        }

        public void metodoRespaldo()
        {
            Cursor.Current = Cursors.WaitCursor;
            saveFileDialog1.FileName = "RESPALDO_BD_" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMMM") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".sql";
            saveFileDialog1.AddExtension = true;
            // saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.Title = "RESPALDO DE LA BASE DE DATOS";
            saveFileDialog1.Filter = "Archivos SQL(*.sql)|*.sql|Archivos de Texto (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != String.Empty)
                {
                    ConexionBD bd = new ConexionBD();
                    bd.conexion();
                    String linea;
                    String fichero = saveFileDialog1.FileName;
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.FileName = "mysqldump";
                    proc.StartInfo.Arguments = ConexionBD.basedatos + " --single-transaction --host=" + ConexionBD.host + " --user=" + ConexionBD.usuario + " --password=" + ConexionBD.DesEncriptar(ConexionBD.contrasena);
                    Process miProceso;
                    miProceso = Process.Start(proc.StartInfo);
                    try
                    {
                        StreamReader sr = miProceso.StandardOutput;
                        TextWriter tw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                        while ((linea = sr.ReadLine()) != null)
                        {
                            tw.WriteLine(linea);
                        }
                        tw.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        return;
                    }
                    MessageBox.Show("Copia de seguridad realizada con éxito");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void descargarManualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.simpus.com.mx/actualizaciones/parroquia/MANUAL_USUARIO.pdf");
        }

        private void acercaDeToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            new acercade().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                pause.Text = "|>";
                timer2.Enabled = false;
                play = true;
            }
            else
            {
                pause.Text = "| |";
                timer2.Enabled = true;
                play = false;
            }
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            cambiarFoto();
            if (foto == 20)
                foto = 0;
            foto++;
        }

      /*  private void configurarCoordenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configurarCoordenada cc = new configurarCoordenada();
            cc.ShowDialog();
        }
        */
        private void Parroquia_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea realizar un respaldo de los registros?", 
                "Respaldo",MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                metodoRespaldo();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            combo_categoria.SelectedIndex = 0;
            text_anio.Text = "";
            text_hoja.Text = "";
            text_libro.Text = "";
            text_lugar.Text = "";
        }


        private void restaurarBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metodoRestaurar();
        }

        private void metodoRestaurar()
        {

            openFileDialog1.Filter = "Archivos SQL(*.sql)|*.sql|Archivos de Texto (*.txt)|*.txt";
            openFileDialog1.Title = "Selecciona un archivo.";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != String.Empty)
                {
                    ConexionBD bd = new ConexionBD();
                    bd.conexion();
                    String fichero = openFileDialog1.FileName;
                    MessageBox.Show(fichero);
                   /* System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.FileName = "mysqldump";
                    proc.StartInfo.Arguments = ConexionBD.basedatos + " --single-transaction --host=" + ConexionBD.host + " --user=" + ConexionBD.usuario + " --password=" + ConexionBD.DesEncriptar(ConexionBD.contrasena);
                    Process miProceso;
                    miProceso = Process.Start(proc.StartInfo);*/
                    try
                    {
                        Process miProceso = new Process();
                        miProceso.EnableRaisingEvents = false;
                        miProceso.StartInfo.UseShellExecute = false;
                        miProceso.StartInfo.RedirectStandardInput = true;
                        //Es necesario que el fichero mysql.exe esté en el PATH del sistema
                        miProceso.StartInfo.FileName = "mysql";
                        miProceso.StartInfo.Arguments = "--database="+ConexionBD.basedatos + " --host=" + ConexionBD.host + " --user=" + ConexionBD.usuario + " --password=" + ConexionBD.DesEncriptar(ConexionBD.contrasena);
                        
                        
                        miProceso.Start();
                        
                        StreamWriter myStreamWriter = miProceso.StandardInput;
                        myStreamWriter.Write(File.ReadAllText(fichero, Encoding.Default));
                        myStreamWriter.Close();

                        miProceso.WaitForExit();
                        miProceso.Close();
                        MessageBox.Show("Base de datos restaurada con éxito");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        return;
                    }
                    
                }
            }


            /*
            Cursor.Current = Cursors.WaitCursor;
            openFileDialog1.FileName = "RESPALDO_BD_" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMMM") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".sql";
            openFileDialog1.AddExtension = true;
            // saveFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = "RESPALDO DE LA BASE DE DATOS";
            openFileDialog1.Filter = "Archivos SQL(*.sql)|*.sql|Archivos de Texto (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != String.Empty)
                {
                    ConexionBD bd = new ConexionBD();
                    bd.conexion();
                    String linea;
                    String fichero = openFileDialog1.FileName;
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.FileName = "mysqldump";
                    proc.StartInfo.Arguments = ConexionBD.basedatos + " --single-transaction --host=" + ConexionBD.host + " --user=" + ConexionBD.usuario + " --password=" + ConexionBD.DesEncriptar(ConexionBD.contrasena);
                    Process miProceso;
                    miProceso = Process.Start(proc.StartInfo);
                    try
                    {
                        StreamReader sr = miProceso.StandardOutput;
                        TextWriter tw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                        while ((linea = sr.ReadLine()) != null)
                        {
                            tw.WriteLine(linea);
                        }
                        tw.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        return;
                    }
                    MessageBox.Show("Copia de seguridad realizada con éxito");
                }
            }
            Cursor.Current = Cursors.Default;*/
        }
    }
}
