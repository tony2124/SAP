using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexionbd;
using MySql.Data.MySqlClient;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

namespace Parroquia
{
    class Imprimir
    {
        PrintDialog pDialog;
        PrintPreviewDialog ppD ;
        PrintDocument pd;
        Image newImage;

        //Controladores para imprimir las anotaciones en diferentes renglones*/
        /**/ public int cont = 0;
        /***********************************************************************/

        public int x = 0, y = 0;
        public float x1 = 0, y1 = 0;
        public static String libro, foja, partida, nombre, padre, madre, 
            lugarNacimiento, fechaNacimiento, fechaBautismo, presbitero, 
            madrina, padrino, anotacion, lugarBautismo, fechaConfirmacion,
            fechaComunion, parroquiaBautismo, diocesisBautismo, novio,
            novia, testigo1, testigo2, fechaMatrimonio, lugarCelebracion,
            padreNovio, madreNovio, padreNovia, madreNovia,
            nombre_parroquia, nombre_parroco, ubicacion_parroquia, nombre_obispo, telefono, nombre_diocesis,
            email, lugar, rutaQr = "c:/DOCSParroquia/qrcode.png";

        public static bool impresion = true;

        public int CATEGORIA, FORMATO;
        public ConexionBD DbDatos;
        public MySqlDataReader datos;

        ConexionBD Bdatos = new ConexionBD();
        MySqlDataReader Datos;

        public void leerArchivoBautismo()
        {
            if(CATEGORIA == 1){
                if (FORMATO == 0) //copia
                    newImage = global::Parroquia.Properties.Resources.Bautismo1;
                else if(FORMATO == 2) //original
                    newImage = global::Parroquia.Properties.Resources.BautismoFormatoOriginal2;
            }
            else if (CATEGORIA == 2)
            {
                if (FORMATO == 0) //copia
                    newImage = global::Parroquia.Properties.Resources.Confirmacion11;
               else if (FORMATO == 2) //original
                    newImage = global::Parroquia.Properties.Resources.ConfirmacionOriginala;
                
                
            }
            else if (CATEGORIA == 3)
            {
                if (FORMATO == 0) //copia
                    newImage = global::Parroquia.Properties.Resources.PrimeraComunion1;
                else if(FORMATO==2) //original
                    newImage = global::Parroquia.Properties.Resources.ComunionOriginalFormato2b;
                    
            }
            else if (CATEGORIA == 4)
            {
                if (FORMATO == 0) //copia
                    newImage = global::Parroquia.Properties.Resources.Matrimonio;
                else if (FORMATO == 2) //original
                    newImage = global::Parroquia.Properties.Resources.MatrimonioOriginalFormato1;
            }
                
        }

        public Boolean ImpresoraProperties()
        {
            pDialog = new PrintDialog();
            ppD = new PrintPreviewDialog();
            pd = new PrintDocument();


            ppD.PrintPreviewControl.Zoom = 1;
            ppD.WindowState = FormWindowState.Maximized;
            ppD.MinimizeBox = true;
            ppD.ShowInTaskbar = true;

            pDialog.AllowSomePages = false;
            pDialog.AllowPrintToFile = false;
            DialogResult t = pDialog.ShowDialog();
            if (t == DialogResult.OK)
                return true;
            else
                return false;
            
        }

        public Imprimir(String a, String b, String c, String d, 
            String e, String f, String g, String h,
            String i, String j, String k, String l, String m, int categoria,
            int formato)
        {
            //OBTENGO NOMBRE DE LA PARROQUIA, NOMBRE DEL PARROCO Y
            //LA UBICACION DE LA PARROQUIA DE LA BASE DE DATOS
            DbDatos = new ConexionBD();
            DbDatos.conexion();

            datos = DbDatos.obtenerBasesDatosMySQL("select * from informacion");

            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    nombre_parroquia = datos.GetValue(0).ToString();
                    nombre_parroco = datos.GetValue(1).ToString();

                    ubicacion_parroquia = datos.GetValue(2) + ""; //calles
                    ubicacion_parroquia += "," + datos.GetValue(3).ToString()+ "\n"; //colonia
                    ubicacion_parroquia += datos.GetValue(4).ToString()+", "; //ciudad
                    ubicacion_parroquia += datos.GetValue(5).ToString() + ", ";//estado
                    ubicacion_parroquia += "C.P. "+datos.GetValue(6).ToString();//cp

                    lugar = datos.GetValue(4).ToString() + ", " + datos.GetValue(5).ToString()+".";//estado; //ciudad

                    telefono = datos.GetValue(7).ToString();
                    email = datos.GetValue(8).ToString();
                    nombre_obispo = datos.GetValue(11).ToString();
                    nombre_diocesis = datos.GetValue(12).ToString();
                }
            }
            DbDatos.Desconectar();


            //Asignacion de variables
            libro = a;
            foja = b;
            partida = c;

         

            CATEGORIA = categoria;
            FORMATO = formato;

            if (categoria == 1 || categoria == 2)
            {
                nombre = d;
                padre = e;
                madre = f;

                presbitero = j;
                madrina = k;
                padrino = l;
            }

            if (categoria == 1)
            { 
                lugarNacimiento = g;
                fechaNacimiento = h;
                fechaBautismo = i;
                anotacion = m;
            }
            else if (categoria == 2)
            {
                lugarBautismo = g;
                fechaBautismo = h;
                fechaConfirmacion = i;

            }
            else if (categoria == 3)
            {
                nombre = d;
                padre = e;
                madre = f;
                fechaComunion = g;
                fechaBautismo = h;
                lugarBautismo = i;
                padrino = j;
                madrina = k;
                presbitero = l;

            }
            else if (categoria == 4)
            {
                novio = d;
                novia = e;
                fechaMatrimonio = f;
                lugarCelebracion = g;
                testigo1 = h;
                testigo2 = i;
                presbitero = j;
                anotacion = k;

            }

                //SE ESTABLECEN LAS PROPIEDADES DE IMPRESORA
                if (ImpresoraProperties())
                {
                    //SE LEE EL ARCHIVO QUE SE IMPRIMIRA
                    leerArchivoBautismo();

                    //SE manda a imprimir el archivo leido y lleno de informacion
                    mandaImpresion();

                }

        }

        public void mandaImpresion(){
            pd.PrinterSettings = pDialog.PrinterSettings;
            pd.PrinterSettings.Copies = pDialog.PrinterSettings.Copies;
            pd.DefaultPageSettings.Margins = new Margins(113, 100, 100, 600);
            if(CATEGORIA == 1){
               if(FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                        (this.imprimirBautismoCopia);
                else if(FORMATO == 2)
                   pd.PrintPage += new PrintPageEventHandler
                        (this.imprimirBautismoFormato2);
            }
            else if (CATEGORIA == 2)
            {
                if (FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirConfirmacionCopia);
                else if (FORMATO == 2)
                {
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirConfirmacionOriginal);
                }
            }
            else if (CATEGORIA == 3)
            {
                if (FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirComunionCopia);
                else if (FORMATO == 2)
                {
                    pd.PrintPage += new PrintPageEventHandler
                      (this.imprimirComunionOriginal);
                }
            }
            else if (CATEGORIA == 4)
            {
                if (FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirMatrimonioCopia);
                else if (FORMATO == 2)
                {
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirMatrimonioOriginal);
                }
            }

            //ppD.Document = pd;
            //ppD.ShowDialog();
           // ppD.BringToFront();

            pd.Print();
        }


        //METODO PARA IMPRIMIR FORMATO ORIGINAL DE BAUTISMOS    
        private void imprimirBautismoFormato2(object sender, PrintPageEventArgs ev)
        {

            float tamaño_total, mitad;
            int y = 5;

            ev.Graphics.DrawImage(newImage, 0, 0);

            //IMPRIME NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 12, FontStyle.Bold),
                       Brushes.Black, mitad + 85 , 150);

            //LUGAR BAUTISMO
            tamaño_total = 880 - ev.Graphics.MeasureString("RECIBIÓ EL SACRAMENTE DEL BAUTISMO EN LA PARROQUIA", new Font("Times New Roman", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString("RECIBIÓ EL SACRAMENTE DEL BAUTISMO EN LA PARROQUIA", 
               new Font("Times New Roman", 9, FontStyle.Regular),
                       Brushes.Black, mitad + 85, 190);

            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia + ". " + lugar, new Font("Times New Roman", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia + " " + lugar, 
               new Font("Times New Roman", 9, FontStyle.Regular),
                       Brushes.Black, mitad + 85, 205);
            

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            String[] fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia

              tamaño_total = 880 - ev.Graphics.MeasureString(fecha[2] + " DE "+fecha[1]+" DEL "+fecha[0], new Font("Times New Roman", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(fecha[2] + " DE "+fecha[1]+" DEL "+fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, mitad + 85, 265);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString(lugarNacimiento,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 298 + y);

            //IMPRIME FECHA DE NACIMIENTO
            //separo la fecha de nacimiento
            fecha = fechaNacimiento.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2] + " DE "+fecha[1]+" DE "+fecha[0],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 605, 298 + y );

            //IMPRIME PADRES
           

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            ev.Graphics.DrawString(padre,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 175, 330 + y);

            ev.Graphics.DrawString(madre,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 175, 365 + y);

            //IMPRIME PADRINOS
           

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";

     
            ev.Graphics.DrawString(padrino,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 185, 405 + y);

            ev.Graphics.DrawString(madrina,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 185, 435 + y);

            //IMPRIME LIBRO, FOJA Y PARTIDA
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 170, 510 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 265, 510 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 410, 510 + y);

            //IMPRIME PRESBITERO
            tamaño_total = 440 - ev.Graphics.MeasureString("PBRO. " + presbitero, new Font("Times New Roman", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString("PBRO. " + presbitero,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, mitad + 420, 510 + y);

        }
      
        //IMPRESION DE BOLETA ORIGINAL DE CONFIRMACION        
        private void imprimirConfirmacionOriginal(object sender, PrintPageEventArgs ev)
        {
            
            String[] fecha;
            ev.Graphics.DrawImage(newImage, 0, 0);
            System.Drawing.Image logo = System.Drawing.Image.FromFile(@"c:/DOCSParroquia/logo.jpg");
            ev.Graphics.DrawImage(logo, 660, 80, 100, 137);

            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            float tamaño_total, mitad;
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            /********************************************************/

            //IMPRIME NOMBRE
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 10, FontStyle.Bold),
                       Brushes.Black, mitad, 229 + y);

            //IMPRIME PADRES
            String padres = "";

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            if (padre.Trim().Length > 4 && madre.Trim().Length < 4)
                padres = padre;
            else if (padre.Trim().Length < 4 && madre.Trim().Length > 4)
                padres = madre;
            else if (padre.Trim().Length > 4 && madre.Trim().Length > 4)
                padres = padre + " Y " + madre;
           
            ev.Graphics.DrawString(padres,
               new Font("Times New Roman", 10, FontStyle.Bold),
               Brushes.Black, 180 , 270 + y);


            //IMPRIME PADRINOS
            String padrinos = "";

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";

            if (padrino.Trim().Length > 4 && madrina.Trim().Length < 4)
                padrinos = padrino;
            else if (padrino.Trim().Length < 4 && madrina.Trim().Length > 4)
                padrinos = madrina;
            else if (padrino.Trim().Length > 4 && madrina.Trim().Length > 4)
                padrinos = padrino + " Y " + madrina;

            ev.Graphics.DrawString(padrinos,
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 210, 292 + y);

            //IMPRIME LUGAR DE BAUTISMO
           /* */
            ev.Graphics.DrawString(lugarBautismo,
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 290, 310 + y);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();

            ev.Graphics.DrawString(fecha[2] + " DE " + fecha[1] +" DEL "+ fecha[0],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 290, 330 + y);

    
           //IMPRIME PRESBITERO
            tamaño_total = 880 - ev.Graphics.MeasureString(presbitero, new Font("Times New Roman", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
           ev.Graphics.DrawString(presbitero,
                new Font("Times New Roman", 9, FontStyle.Bold),
                Brushes.Black, mitad-5, 495 + y);
            
            //IMPRIME LIBRO
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
                new Font("Times New Roman", 11, FontStyle.Bold),
                Brushes.Black, 290, 450 + y);

            //IMPRIME HOJA
            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
                new Font("Times New Roman", 11, FontStyle.Bold),
                Brushes.Black, 393, 450 + y);

            //IMPRIME PARTIDA
            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
                new Font("Times New Roman", 11, FontStyle.Bold),
                Brushes.Black, 550, 450 + y);

            
            //IMPRIME DIOCESIS DEL BAUTIZADO
            /*
            ev.Graphics.DrawString(diocesisBautismo,
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, mitad - 100 + x, 505 + y);
            */
            //IMPRIME PARROQUIA DE CONFIRMACION
            ev.Graphics.DrawString(nombre_parroquia.ToUpper(),
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 350, 370 + y);

            ev.Graphics.DrawString(lugar.ToUpper(),
               new Font("Times New Roman", 10, FontStyle.Bold),
               Brushes.Black, 115, 390 + y);

            //IMPRIME FECHA DE CONFIRMACION
            //separo la fecha de CONFIRMACION
            fecha = fechaConfirmacion.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia

            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 295, 410 + y);

            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 360, 410 + y);

            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 560, 410 + y);

     

        }

        //IMPRIME ORIGINAL DE COMUNION    
        private void imprimirComunionOriginal(object sender, PrintPageEventArgs ev)
        {
          
            string []fecha;
            float tamaño_total, mitad;
            ev.Graphics.DrawImage(newImage, 0, 0);

            //NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 12, FontStyle.Bold),
               Brushes.Black, mitad - 20, 135);

            //NOMBRE Y LUGAR DE PARROQUIA
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia.ToUpper()+", "+lugar.ToUpper() , new Font("Times New Roman", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia.ToUpper() + ", " + lugar.ToUpper(),
               new Font("Times New Roman", 10, FontStyle.Regular),
               Brushes.Black, mitad +5 , 215);

            //FECHA DE COMUNION
            fecha = fechaComunion.Split('-');
            fecha[1] = fecha[1].ToUpper();

            ev.Graphics.DrawString(fecha[2],
               new Font("Times New Roman", 10, FontStyle.Regular),
               Brushes.Black, 290, 277);

            ev.Graphics.DrawString(fecha[1],
               new Font("Times New Roman", 10, FontStyle.Regular),
               Brushes.Black, 370, 277);

            ev.Graphics.DrawString(fecha[0],
               new Font("Times New Roman", 10, FontStyle.Regular),
               Brushes.Black, 540, 277);

            //IMPRIME PADRES
            String padres = "";
            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            if (padre.Trim().Length > 4 && madre.Trim().Length < 4)
                padres = padre;
            else if (padre.Trim().Length < 4 && madre.Trim().Length > 4)
                padres = madre;
            else if (padre.Trim().Length > 4 && madre.Trim().Length > 4)
                padres = padre + "  Y " + madre;
            ev.Graphics.DrawString(padres,
               new Font("Times New Roman", 10, FontStyle.Regular),
               Brushes.Black, 180, 317);

            //IMPRIME PADRINOS
            String padrinos = "";
            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";

            if (padrino.Trim().Length > 4 && madrina.Trim().Length < 4)
                padrinos = padrino;
            else if (padrino.Trim().Length < 4 && madrina.Trim().Length > 4)
                padrinos = madrina;
            else if (padre.Trim().Length > 4 && madrina.Trim().Length > 4)
                padrinos = padrino + "  Y " + madrina;

            ev.Graphics.DrawString(padrinos,
              new Font("Times New Roman", 10, FontStyle.Regular),
              Brushes.Black, 210, 340);
            
            //IMPRIME LIBRO
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
              new Font("Times New Roman", 12, FontStyle.Regular),
              Brushes.Black, 290, 380);
            
            //IMPRIME HOJA
           ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
              new Font("Times New Roman", 12, FontStyle.Regular),
              Brushes.Black, 390, 380);
              
            //IMPRIME PARTIDA
            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
              new Font("Times New Roman", 12, FontStyle.Regular),
              Brushes.Black, 550, 380);

            //IMPRIME LUGAR Y FECHA DE BAUTIMSO
            fecha = fechaBautismo.Split('-');
            tamaño_total = 880 - ev.Graphics.MeasureString(lugarBautismo+
                " EL " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0],
            new Font("Times New Roman", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(lugarBautismo.ToUpper() +
                ". EL " + fecha[2] + " DE " + fecha[1].ToUpper() + 
                " DE " + fecha[0],
              new Font("Times New Roman", 9, FontStyle.Regular),
              Brushes.Black, mitad, 440);

            //PARROCO
            tamaño_total = 880 - ev.Graphics.MeasureString(presbitero, new Font("Times New Roman", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(presbitero,
               new Font("Times New Roman", 9, FontStyle.Regular),
               Brushes.Black, mitad-10, 480);
        }

        //IMPRESION ORIGINAL DE MATRIMONIO    
        private void imprimirMatrimonioOriginal(object sender, PrintPageEventArgs ev)
        {
            string[] fecha;

            ev.Graphics.DrawImage(newImage, 0, 0);

            //IMPRIME NOVIO
            ev.Graphics.DrawString(novio,
               new Font("Times New Roman", 12, FontStyle.Bold),
               Brushes.Black, 360, 362 + y);

            //IMPRIME NOVIA
            ev.Graphics.DrawString(novia,
               new Font("Times New Roman", 12, FontStyle.Bold),
               Brushes.Black, 340 + x, 399 + y);

            //FECHA DEL MATRIMONIO
            fecha = fechaMatrimonio.Split('-');//
            String fechaActa = fecha[2] + " DE " + fecha[1].ToUpper() + " DEL "+ fecha[0];
            ev.Graphics.DrawString(fechaActa,
               new Font("Times New Roman", 12, FontStyle.Bold),
               Brushes.Black, 340, 608 + y);
          
            //LUGAR CELEBRACION
            ev.Graphics.DrawString(lugarCelebracion,
             new Font("Times New Roman", 12, FontStyle.Bold),
             Brushes.Black, 460, 669 + y);

            //TESTIGOS

            if (testigo1.Contains('=') == true)
                testigo1 = "";
            if (testigo2.Contains('=') == true)
                testigo2 = "";

            ev.Graphics.DrawString(testigo1,
            new Font("Times New Roman", 12, FontStyle.Bold),
            Brushes.Black, 410, 792 + y);

            ev.Graphics.DrawString(testigo2,
            new Font("Times New Roman", 12, FontStyle.Bold),
            Brushes.Black, 410, 824 + y);

            //LIBRO
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
            new Font("Times New Roman", 12, FontStyle.Bold),
            Brushes.Black, 390, 884 + y);

            //HOJA         
            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
            new Font("Times New Roman", 12, FontStyle.Bold),
            Brushes.Black, 530, 884 + y);

            //PARTIDA
            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
            new Font("Times New Roman", 12, FontStyle.Bold),
            Brushes.Black, 710, 884 + y);

            //PARROCO
        
            ev.Graphics.DrawString(presbitero,
               new Font("Times New Roman", 12, FontStyle.Bold),
               Brushes.Black, 480, 730 + y);

            /********************** QR **********************/
            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {

                    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    var qrCode = qrEncoder.Encode("Boleta de Matrimonio - " + Datos.GetValue(0) + ", " + Datos.GetValue(12) + " - Pbro. " + nombre_parroco + " - Expedido a " + novio + " y " + novia + " el " + fechaActa + ". LIBRO: " + libro + " FOJA: " + foja + " PARTIDA: " + partida);

                    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

                    var stream = new FileStream(@rutaQr, FileMode.Create);
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream); //.FromFile(@rutaQr);
                    stream.Close();
                    ev.Graphics.DrawImage(img, 310, 930 + y, 130, 130);

                }
            }
            Bdatos.Desconectar();
        }


        //METODO PARA IMPRIMIR COPIA DE BAUTISMO
        public void imprimirBautismoCopia(object sender, PrintPageEventArgs ev)
        {
            imprimeImagen(ev);

            /**/
            float tamaño_total, mitad;
            int y = -35, x = -10; 
            /********************************************************/

            //LIBRO,FOJA,PARTIDA

            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 188, 455 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 335, 455 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 544, 455 + y);


            //IMPRIME Nombre
            ev.Graphics.DrawString(nombre,
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 286 + x, 500 + y);

            //IMPRIME PAPA  Y MAMA

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            ev.Graphics.DrawString(padre + ", " + madre,
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 180 + x, 530 + y);



            //IMPRIME LUGAR DE NACIMIENTO
            String[] fec = fechaNacimiento.ToUpper().Split('-');
            ev.Graphics.DrawString(lugarNacimiento + "." + fec[2] + " DE " + fec[1] + " DE " + fec[0],
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 335 + x, 562 + y);


            //IMPRIME FECHA DE BAUTISMO
            fec = fechaBautismo.ToUpper().Split('-');
            ev.Graphics.DrawString(fec[2] + " DE " + fec[1] + " DE " + fec[0],
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 265 + x, 593 + y);

            //IMPRIME PRESBITERO

            ev.Graphics.DrawString(presbitero,
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 393 + x, 654 + y);

            //IMPRIME PADRINO Y MADRINA

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";
            ev.Graphics.DrawString(padrino + ", " + madrina,
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 195 + x, 623 + y);

            //IMPRIME ANOTACIONES 
            notasRenglones(anotacion, ev, 255 + x, 650, 60, "b");

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Times New Roman", 11, FontStyle.Regular),
                        Brushes.Black, 113, 865 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                new Font("Times New Roman", 11, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Times New Roman", 11, FontStyle.Regular),
                       Brushes.Black, mitad + 400, 938 + y);


            /********************** QR **********************/
            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {

                    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    var qrCode = qrEncoder.Encode("Certificado de Bautismo - " + Datos.GetValue(0) + ", " + Datos.GetValue(12) + " - Pbro. " + nombre_parroco + " - Expedido a " + nombre + " el " + fechaActual + ". LIBRO: " + libro + " FOJA: " + foja + " PARTIDA: " + partida);
                    
                    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

                    var stream = new FileStream(@rutaQr, FileMode.Create);
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream); //.FromFile(@rutaQr);
                    stream.Close();
                    ev.Graphics.DrawImage(img, 113, 890 + y, 130, 130);

                }
            }
            Bdatos.Desconectar();


            


        }

        //METODO PARA IMPRIMIR COPIA DE CONFIRMACION
        public void imprimirConfirmacionCopia(object sender, PrintPageEventArgs ev)
        {
            imprimeImagen(ev);

            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            /**/float tamaño_total, mitad, y = 0;
           
            /********************************************************/
         

            //LIBRO,FOJA,PARTIDA

            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 308, 412 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 422, 412 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 535, 412 + y);

            //IMPRIME OBISPO
            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_obispo,
                new Font("Times New Roman", 10, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_obispo,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, mitad + 160, 440 + y);

            //IMPRIME NOMBRE
            /**/

            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 18, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 15, FontStyle.Regular),
                       Brushes.Black, 35 + mitad, 520);

           
            //IMPRIME PADRES
            String padres = "";

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            if (padre.Trim().Length > 4 && madre.Trim().Length < 4)
            {
                padres = padre;
            }
            else if (padre.Trim().Length < 4 && madre.Trim().Length > 4)
            {
                padres = madre;
            }
            else if (padre.Trim().Length > 4 && madre.Trim().Length > 4)
            {
                padres = padre + " Y " + madre;
            }
            ev.Graphics.DrawString(padres,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 202, 585 + y);

            //IMPRIME FECHA DE CONFIRMACION
            String[] fecha = fechaConfirmacion.Split('-');
            ev.Graphics.DrawString(fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0] + ".",
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 337, 614 + y);

            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            ev.Graphics.DrawString(lugarBautismo + "." + " EL " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0] + ".",
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 122, 673 + y);


            //IMPRIME PADRINOS
            String padrinos = "";

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";

            if (padrino.Trim().Length > 4 && madrina.Trim().Length < 4)
            {
                padrinos = padrino;
            }
            else if (padrino.Trim().Length < 4 && madrina.Trim().Length > 4)
            {
                padrinos = madrina;
            }

            else if (padrino.Trim().Length > 4 && madrina.Trim().Length > 4)
            {
                padrinos =  padrino + " Y " + madrina;
            }
            ev.Graphics.DrawString(padrinos,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 315,702 + y);

          
            

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 113, 825 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                 new Font("Times New Roman", 12, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, mitad + 380, 925 + y);

            /********************** QR **********************/
            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {

                    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    var qrCode = qrEncoder.Encode("Certificado de Confirmación - " + Datos.GetValue(0) + ", " + Datos.GetValue(12) + " - Pbro. " + nombre_parroco + " - Expedido a " + nombre + " el " + fechaActual + ". LIBRO: " + libro + " FOJA: " + foja + " PARTIDA: " + partida);

                    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

                    var stream = new FileStream(@rutaQr, FileMode.Create);
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream); //.FromFile(@rutaQr);
                    stream.Close();
                    ev.Graphics.DrawImage(img, 113, 860 + y, 140, 140);

                }
            }
            Bdatos.Desconectar();

        }

        //METODO PARA IMPRIMIR FORMATO COPIA EN COMUNIONES
        private void imprimirComunionCopia(object sender, PrintPageEventArgs ev)
        {
            String[] fecha;
            imprimeImagen(ev);

            ev.PageSettings.Margins.Right = 10;
            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            float tamaño_total, mitad;
            int y = 20, x = -10;

            /********************************************************/

           

            //LIBRO,FOJA,PARTIDA

            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 530, 355 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 670, 355 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 198, 380 + y);


            //IMPRIME NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre,
                new Font("Times New Roman", 12, FontStyle.Regular)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, mitad + x, 449 + y);


            //IMPRIME PADRE

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            tamaño_total = 880 - ev.Graphics.MeasureString(padre,
                new Font("Times New Roman", 12, FontStyle.Regular)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(padre,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, mitad + x, 499 + y);

            /*** IMPRIME MADRE **/
            tamaño_total = 880 - ev.Graphics.MeasureString(madre,
                new Font("Times New Roman", 12, FontStyle.Regular)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(madre,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, mitad + x, 551 + y);

            //IMPRIME PADRINOS
            String padrinos = "";

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";

            if (padrino.Trim().Length > 4 && madrina.Trim().Length < 4)
            {
                padrinos = padrino;
            }
            else if (padrino.Trim().Length < 4 && madrina.Trim().Length > 4)
            {
                padrinos = madrina;
            }
            else if (padrino.Trim().Length > 4 && madrina.Trim().Length > 4)
            {
                padrinos = padrino + " Y " + madrina;
            }

            tamaño_total = 880 - ev.Graphics.MeasureString(padrinos,
               new Font("Times New Roman", 12, FontStyle.Regular)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(padrinos,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, mitad + x, 605 + y);




            // FECHA DE COM,UNION
            fecha = fechaComunion.Split('-');

            String lugaryfecha =  fecha[2] +
                " DE " + fecha[1].ToUpper() +
                " DE " + fecha[0];

            tamaño_total = 880 - ev.Graphics.MeasureString(lugaryfecha,
               new Font("Times New Roman", 12, FontStyle.Regular)).Width;

            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(lugaryfecha,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, mitad + x, 659 + y);

            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            String fecha_bau = lugarBautismo + ". EL " +fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0];
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha_bau,
              new Font("Times New Roman", 12, FontStyle.Regular)).Width;

            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha_bau,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, mitad + 7, 709 + y);



            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 167, 830 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                new Font("Times New Roman", 11, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Times New Roman", 11, FontStyle.Regular),
                       Brushes.Black, mitad + 420, 905 + y);


            /********************** QR **********************/
            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {

                    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    var qrCode = qrEncoder.Encode("Certificado de Primera comunión - " + Datos.GetValue(0) + ", " + Datos.GetValue(12) + " - Pbro. " + nombre_parroco + " - Expedido a " + nombre + " el " + fechaActual + ". LIBRO: " + libro + " FOJA: " + foja + " PARTIDA: " + partida);

                    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

                    var stream = new FileStream(@rutaQr, FileMode.Create);
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream); //.FromFile(@rutaQr);
                    stream.Close();
                    ev.Graphics.DrawImage(img, 113, 852 + y, 130, 130);

                }
            }
            Bdatos.Desconectar();

        }

        //IMPRIME COPIA DE MATRIMONIO
        private void imprimirMatrimonioCopia(object sender, PrintPageEventArgs ev)
        {
            String[] fecha;
            imprimeImagen(ev);
            float tamaño_total, mitad;

            //IMPRIME LIBRO
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 473, 363);

            //IMPRIME hoja
            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 592, 363);

            //IMPRIME partida
            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 265, 456);

            //IMPRIME NOVIO
            tamaño_total = ev.Graphics.MeasureString(novio + " Y " + novia,
                new Font("Times New Roman", 12, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(novio + " Y " + novia,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, mitad - 110, 419);

            //IMPRIME LUGAR CELEBRACION parroquia
            ev.Graphics.DrawString(nombre_parroquia.ToUpper(),
               new Font("Times New Roman", 12, FontStyle.Regular),
               Brushes.Black, 260, 492);

            //IMPRIME FECHA DE MATRIMONIO
            //separo la fecha de matrimonio
            fecha = fechaMatrimonio.Split('-');
            fecha[1] = fecha[1].ToUpper();

            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 167, 514);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 335, 514);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 480, 514);

            
            //IMPRIME NOVIO
            ev.Graphics.DrawString(novio + " Y " + novia,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, mitad - 110, 550);

            //IMPRIME LUGAR
            ev.Graphics.DrawString(lugarCelebracion,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, 220, 585);

            //IMPRIME TESTIGOS
            if (testigo1.Contains('=') == true)
                testigo1 = "";
            ev.Graphics.DrawString(testigo1 + " Y "+testigo2,
               new Font("Times New Roman", 12, FontStyle.Regular),
               Brushes.Black, 115, 658);

            //IMPRIME ASISTENTE
            ev.Graphics.DrawString(presbitero,
               new Font("Times New Roman", 12, FontStyle.Regular),
               Brushes.Black, 115, 730 + y);

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a + ".";

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Times New Roman", 12, FontStyle.Regular),
                        Brushes.Black, 113, 825 + y);

            /*** ATENTAMENTE PARROCO ***/
            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                new Font("Times New Roman", 12, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Times New Roman", 12, FontStyle.Regular),
                       Brushes.Black, mitad + 380, 955 + y);


            /********************** QR **********************/
            Bdatos.conexion();
            Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM informacion");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {

                    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    var qrCode = qrEncoder.Encode("Certificado de Matrimonio - " + Datos.GetValue(0) + ", " + Datos.GetValue(12) + " - Pbro. " + nombre_parroco + " - Expedido a " + novio + " y "+novia+" el " + fechaActual + ". LIBRO: " + libro + " FOJA: " + foja + " PARTIDA: " + partida);

                    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

                    var stream = new FileStream(@rutaQr, FileMode.Create);
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream); //.FromFile(@rutaQr);
                    stream.Close();
                    ev.Graphics.DrawImage(img, 113, 860 + y, 130, 130);

                }
            }
            Bdatos.Desconectar();
        }

        public void notasRenglones(String nota, PrintPageEventArgs ev, int i, int j, int u, string l )
        {
            if (cont == 1)
                u = 78;
            cont++;
            if (nota.Length > u)
            {
                ev.Graphics.DrawString(nota.Substring(0, u)+" - ",
              new Font("Times New Roman", 10, FontStyle.Regular),
                      Brushes.Black, i, j);
                if (l.CompareTo("a") == 0)
                {
                    i = 114;
                    j = j + 20;
                }
                else if(l.CompareTo("b")==0)
                {
                    i = 120;
                    j = j + 35;
                }

                notasRenglones(nota.Substring(u), ev, i, j, u,l);
            }
            else
            {
                ev.Graphics.DrawString(nota,
                new Font("Times New Roman", 10, FontStyle.Regular),
                Brushes.Black, i, j);
            }
            

        }

        public void imprimeImagen(PrintPageEventArgs ev)
        {
            //IMPRIMIMOS DOCUMENTO
            ev.Graphics.DrawImage(newImage, 0, 0);

            /********************* iMG LOGO *************************/

            System.Drawing.Image logo = System.Drawing.Image.FromFile(@"c:/DOCSParroquia/logo.jpg");

            ev.Graphics.DrawImage(logo, 613, 60,155,215);

            //UBICACION PARROQUIA
           
            ev.PageBounds.Offset(200,100);
            ev.Graphics.DrawString(nombre_parroquia.ToUpper() + "\n" + nombre_diocesis.ToUpper() + "\n" + ubicacion_parroquia.ToUpper() + "\nTEL: " + telefono + "\nE-MAIL: " + email.ToUpper(),
              new Font("Times New Roman", 12, FontStyle.Bold),
                      Brushes.Black, ev.MarginBounds);
            
        }

    }
}







