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
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Arial", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Arial", 12, FontStyle.Bold),
                       Brushes.Black, mitad + 85 , 150);

            //LUGAR BAUTISMO
            tamaño_total = 880 - ev.Graphics.MeasureString("RECIBIÓ EL SACRAMENTE DEL BAUTISMO EN LA PARROQUIA", new Font("Arial", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString("RECIBIÓ EL SACRAMENTE DEL BAUTISMO EN LA PARROQUIA", 
               new Font("Arial", 9, FontStyle.Regular),
                       Brushes.Black, mitad + 85, 190);

            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia + ". " + lugar, new Font("Arial", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia + " " + lugar, 
               new Font("Arial", 9, FontStyle.Regular),
                       Brushes.Black, mitad + 85, 205);
            

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            String[] fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia

              tamaño_total = 880 - ev.Graphics.MeasureString(fecha[2] + " DE "+fecha[1]+" DEL "+fecha[0], new Font("Arial", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(fecha[2] + " DE "+fecha[1]+" DEL "+fecha[0],
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, mitad + 85, 265);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString(lugarNacimiento,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 200, 298 + y);

            //IMPRIME FECHA DE NACIMIENTO
            //separo la fecha de nacimiento
            fecha = fechaNacimiento.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2] + " DE "+fecha[1]+" DE "+fecha[0],
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 605, 298 + y );

            //IMPRIME PADRES
           

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            ev.Graphics.DrawString(padre,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 175, 330 + y);

            ev.Graphics.DrawString(madre,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 175, 365 + y);

            //IMPRIME PADRINOS
           

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";

     
            ev.Graphics.DrawString(padrino,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 185, 405 + y);

            ev.Graphics.DrawString(madrina,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 185, 435 + y);

            //IMPRIME LIBRO, FOJA Y PARTIDA
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
                new Font("Arial", 12, FontStyle.Regular),
                        Brushes.Black, 170, 510 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 265, 510 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 410, 510 + y);

            //IMPRIME PRESBITERO
            tamaño_total = 440 - ev.Graphics.MeasureString("PBRO. " + presbitero, new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString("PBRO. " + presbitero,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, mitad + 420, 510 + y);

        }
      
        //IMPRESION DE BOLETA ORIGINAL DE CONFIRMACION        PENDIENTE   *******************
        private void imprimirConfirmacionOriginal(object sender, PrintPageEventArgs ev)
        {
            
            String[] fecha;
            ev.Graphics.DrawImage(newImage, 0, 0);

            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            float tamaño_total, mitad;
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            /********************************************************/

            //IMPRIME NOMBRE
            ev.Graphics.DrawString(nombre,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, mitad - 140 + x, 229 + y);

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
                padres = padre + " \n \n" + madre;
            ev.Graphics.DrawString(padres,
               new Font("Arial", 10, FontStyle.Bold),
               Brushes.Black, 160 + x, 314 + y);


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

            tamaño_total = 880 - ev.Graphics.MeasureString(padrinos, new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(padrinos,
                new Font("Arial", 9, FontStyle.Bold),
                Brushes.Black, mitad - 120 + x, 378 + y);

            //IMPRIME LUGAR DE BAUTISMO
            tamaño_total = 880 - ev.Graphics.MeasureString(lugarBautismo, new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(lugarBautismo,
                new Font("Arial", 10, FontStyle.Bold),
                Brushes.Black, mitad - 120 + x, 410 + y);

            //IMPRIME PARROQUIA DEL BAUTIZADO
           tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia.ToUpper(), new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia.ToUpper(),
                new Font("Arial", 10, FontStyle.Bold),
                Brushes.Black, mitad - 120 + x, 440 + y);
            
            //IMPRIME LIBRO
            tamaño_total = 880 - ev.Graphics.MeasureString(libro,
                new Font("Arial", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(libro,
                new Font("Arial", 11, FontStyle.Bold),
                Brushes.Black, mitad - 385 + x, 470 + y);

            //IMPRIME HOJA
            tamaño_total = 880 - ev.Graphics.MeasureString(foja,
                new Font("Arial", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(foja,
                new Font("Arial", 11, FontStyle.Bold),
                Brushes.Black, mitad - 334 + x, 470 + y);

            //IMPRIME PARTIDA
            tamaño_total = 880 - ev.Graphics.MeasureString(partida,
                new Font("Arial", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(partida,
                new Font("Arial", 11, FontStyle.Bold),
                Brushes.Black, mitad - 284 + x, 470 + y);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();

            //imprimo el dia
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[2],
                new Font("Arial", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[2],
                new Font("Arial", 11, FontStyle.Bold),
                        Brushes.Black, mitad - 150 + x, 470 + y);

            //imprimo el mes
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[1],
                new Font("Arial", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[1],
                new Font("Arial", 11, FontStyle.Bold),
                        Brushes.Black, mitad - 40 + x, 470 + y);

            //imprimo el año
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[0],
              new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[0],
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, mitad + 80 + x, 470 + y);

            //IMPRIME DIOCESIS DEL BAUTIZADO
            tamaño_total = 880 - ev.Graphics.MeasureString(diocesisBautismo,
              new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(diocesisBautismo,
                new Font("Arial", 10, FontStyle.Bold),
                Brushes.Black, mitad - 100 + x, 505 + y);

            //IMPRIME PARROQUIA DE CONFIRMACION
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia + " " + lugar,
           new Font("Arial", 7, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia + " " + lugar,
                new Font("Arial", 7, FontStyle.Bold),
                Brushes.Black, mitad - 70 + x, 535 + y);

            //IMPRIME FECHA DE CONFIRMACION
            //separo la fecha de CONFIRMACION
            fecha = fechaConfirmacion.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[2],
         new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[2],
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, mitad - 185 + x, 625 + y);

            //imprimo el mes
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[1],
         new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[1],
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, mitad - 75 + x, 625 + y);

            //imprimo el año
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[0],
       new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[0],
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, mitad + 50 + x, 625 + y);

        }

        //IMPRIME ORIGINAL DE COMUNION    
        private void imprimirComunionOriginal(object sender, PrintPageEventArgs ev)
        {
          
            string []fecha;
            float tamaño_total, mitad;
            ev.Graphics.DrawImage(newImage, 0, 0);

            //NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Arial", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Arial", 12, FontStyle.Bold),
               Brushes.Black, mitad - 20, 135);

            //NOMBRE Y LUGAR DE PARROQUIA
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia+", "+lugar , new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia + ", " + lugar,
               new Font("Arial", 10, FontStyle.Regular),
               Brushes.Black, mitad - 20, 215);

            //FECHA DE COMUNION
            fecha = fechaComunion.Split('-');
            fecha[1] = fecha[1].ToUpper();

            ev.Graphics.DrawString(fecha[2],
               new Font("Arial", 10, FontStyle.Regular),
               Brushes.Black, 290, 277);

            ev.Graphics.DrawString(fecha[1],
               new Font("Arial", 10, FontStyle.Regular),
               Brushes.Black, 370, 277);

            ev.Graphics.DrawString(fecha[0],
               new Font("Arial", 10, FontStyle.Regular),
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
               new Font("Arial", 10, FontStyle.Regular),
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
              new Font("Arial", 10, FontStyle.Regular),
              Brushes.Black, 210, 340);
            
            //IMPRIME LIBRO
            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
              new Font("Arial", 12, FontStyle.Regular),
              Brushes.Black, 290, 380);
            
            //IMPRIME HOJA
           ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
              new Font("Arial", 12, FontStyle.Regular),
              Brushes.Black, 390, 380);
              
            //IMPRIME PARTIDA
            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
              new Font("Arial", 12, FontStyle.Regular),
              Brushes.Black, 550, 380);

            //IMPRIME LUGAR Y FECHA DE BAUTIMSO
            fecha = fechaBautismo.Split('-');
            tamaño_total = 880 - ev.Graphics.MeasureString(lugarBautismo+
                " EL " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0],
            new Font("Arial", 9, FontStyle.Regular)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(lugarBautismo +
                ". EL " + fecha[2] + " DE " + fecha[1].ToUpper() + 
                " DE " + fecha[0],
              new Font("Arial", 9, FontStyle.Regular),
              Brushes.Black, mitad, 440);

            //PARROCO
            tamaño_total = 880 - ev.Graphics.MeasureString(presbitero, new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(presbitero,
               new Font("Arial", 9, FontStyle.Regular),
               Brushes.Black, mitad-10, 480);
        }

        //IMPRESION ORIGINAL DE MATRIMONIO    PENDIENTE *******************
        private void imprimirMatrimonioOriginal(object sender, PrintPageEventArgs ev)
        {
            string[] fecha;


            // int x, y;
            DbDatos.conexion();
            datos = DbDatos.obtenerBasesDatosMySQL("select x,y from coordenadas where id=4;");
            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    x1 = datos.GetFloat(0);
                    y1 = datos.GetFloat(1);
                }
            }
            DbDatos.Desconectar();

            x = int.Parse(Math.Round(float.Parse(x1 + "") * 35) + "");
            y = int.Parse(Math.Round(float.Parse(y1 + "") * 35) + "");

            float tamaño_total, mitad;
            ev.Graphics.DrawImage(newImage, 0, 0);

            //IMPRIME NOVIO
            tamaño_total = 880 - ev.Graphics.MeasureString(novio, new Font("Arial", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(novio,
               new Font("Arial", 12, FontStyle.Bold),
               Brushes.Black, mitad - 165 + x, 408 + y);

            //IMPRIME NOVIA
            tamaño_total = 880 - ev.Graphics.MeasureString(novia, new Font("Arial", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(novia,
               new Font("Arial", 12, FontStyle.Bold),
               Brushes.Black, mitad - 165 + x, 443 + y);

            //FECHA DEL MATRIMONIO
            fecha = fechaMatrimonio.Split('-');//


            ev.Graphics.DrawString(fecha[2],
               new Font("Arial", 12, FontStyle.Bold),
               Brushes.Black, 365 + x, 480 + y);

            tamaño_total = 880 - ev.Graphics.MeasureString(fecha[1].ToUpper(),
                new Font("Arial", 12, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha[1].ToUpper(),
              new Font("Arial", 12, FontStyle.Bold),
              Brushes.Black, mitad - 295 + x, 513 + y);

            ev.Graphics.DrawString(fecha[0].ToUpper(),
             new Font("Arial", 12, FontStyle.Bold),
             Brushes.Black, 325 + x, 513 + y);

            //LUGAR CELEBRACION
            ev.Graphics.DrawString(lugarCelebracion,
             new Font("Arial", 12, FontStyle.Bold),
             Brushes.Black, 90 + x, 547 + y);

            //TESTIGOS

            if (testigo1.Contains('=') == true)
                testigo1 = "";
            if (testigo2.Contains('=') == true)
                testigo2 = "";

            tamaño_total = 880 - ev.Graphics.MeasureString(testigo1,
               new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(testigo1,
            new Font("Arial", 10, FontStyle.Bold),
            Brushes.Black, mitad - 165 + x, 621 + y);

            tamaño_total = 880 - ev.Graphics.MeasureString(testigo2,
              new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(testigo2,
            new Font("Arial", 10, FontStyle.Bold),
            Brushes.Black, mitad - 165 + x, 657 + y);

            //LIBRO
            tamaño_total = 880 - ev.Graphics.MeasureString(libro,
            new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(libro,
            new Font("Arial", 10, FontStyle.Bold),
            Brushes.Black, mitad - 290 + x, 716 + y);

            //HOJA
            tamaño_total = 880 - ev.Graphics.MeasureString(foja,
            new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(foja,
            new Font("Arial", 10, FontStyle.Bold),
            Brushes.Black, mitad - 295 + x, 750 + y);

            //PARTIDA
            tamaño_total = 880 - ev.Graphics.MeasureString(partida,
            new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(partida,
            new Font("Arial", 10, FontStyle.Bold),
            Brushes.Black, mitad - 285 + x, 787 + y);

            //PARROCO
            tamaño_total = 880 - ev.Graphics.MeasureString("PBRO. " + presbitero, new Font("Arial", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString("PBRO. " + presbitero,
               new Font("Arial", 9, FontStyle.Bold),
               Brushes.Black, mitad - 33 + x, 786 + y);

        }


        //METODO PARA IMPRIMIR COPIA DE BAUTISMO
        public void imprimirBautismoCopia(object sender, PrintPageEventArgs ev)
        {
            imprimeImagen(ev);

            /**/
            float tamaño_total, mitad;
            int y = 0;
            /********************************************************/




            //LIBRO,FOJA,PARTIDA

            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 270, 455 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 448, 455 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 680, 455 + y);


            //IMPRIME Nombre
            ev.Graphics.DrawString(nombre,
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, 290, 530);

            //IMPRIME PAPA  Y MAMA

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            ev.Graphics.DrawString(padre + ", " + madre,
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, 190, 560);



            //IMPRIME LUGAR DE NACIMIENTO

            ev.Graphics.DrawString(lugarNacimiento + ". EL " + fechaNacimiento.ToUpper(),
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, 350, 592);


            //IMPRIME FECHA DE BAUTISMO


            ev.Graphics.DrawString(fechaBautismo.ToUpper(),
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, 320, 622);

            //IMPRIME PRESBITERO

            ev.Graphics.DrawString(presbitero,
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, 440, 683);

            //IMPRIME PADRINO Y MADRINA

            if (padrino.Contains('=') == true)
                padrino = "";
            if (madrina.Contains('=') == true)
                madrina = "";
            ev.Graphics.DrawString(padrino + ", " + madrina,
                new Font("Arial", 9, FontStyle.Bold),
                        Brushes.Black, 200, 653);

            //IMPRIME ANOTACIONES 
            notasRenglones(anotacion, ev, 260, 716, 60, "b");

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Arial", 12, FontStyle.Regular),
                        Brushes.Black, 113, 835 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, mitad + 400, 930 + y);


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

                    ev.Graphics.DrawImage(img, 113, 860 + y, 130, 130);

                }
            }
            Bdatos.Desconectar();


            


        }

        //METODO PARA IMPRIMIR COPIA DE CONFIRMACION
        public void imprimirConfirmacionCopia(object sender, PrintPageEventArgs ev)
        {
            imprimeImagen(ev);

            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            /**/float tamaño_total, mitad;
           
            /********************************************************/
            //IMPRIME PARROCO
           /* ev.Graphics.DrawString(nombre_parroco,
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 390, 315);
            */
            //IMPRIME NOMBRE
            /**/
            
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre,new Font("Arial", 18, FontStyle.Bold)).Width;
            mitad  = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Arial", 15, FontStyle.Bold),
                       Brushes.Black, 35+mitad, 520);

            //IMPRIME FECHA DE CONFIRMACION
            String [] fecha = fechaConfirmacion.Split('-');
            ev.Graphics.DrawString(fecha[2]+" DE "+fecha[1].ToUpper()+" DE "+fecha[0]+".",
                new Font("Arial", 12, FontStyle.Bold),
                        Brushes.Black, 350, 610);

            //LIBRO,FOJA,PARTIDA

            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 415, 405 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 545, 405 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 680, 405 + y);



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
                new Font("Arial", 11, FontStyle.Bold),
                        Brushes.Black, 215, 580);

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
                new Font("Arial", 11, FontStyle.Bold),
                        Brushes.Black, 315,695);

            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            ev.Graphics.DrawString(lugarBautismo + "." + " EL " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0] + ".",
                new Font("Arial", 11, FontStyle.Bold),
                        Brushes.Black, 115, 665);

            //IMPRIME OBISPO
            ev.Graphics.DrawString(nombre_obispo,
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 115, 450);

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Arial", 12, FontStyle.Regular),
                        Brushes.Black, 113, 825 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                 new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, mitad + 380, 940 + y);

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

                    ev.Graphics.DrawImage(img, 113, 860 + y, 130, 130);

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
            int y = 24;

            /********************************************************/

           

            //LIBRO,FOJA,PARTIDA

            ev.Graphics.DrawString(Int32.Parse(libro).ToString("D2"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 570, 349 + y);

            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 688, 349 + y);

            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Arial", 12, FontStyle.Regular),
                       Brushes.Black, 190, 371 + y);


            //IMPRIME NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre,
                new Font("Arial", 12, FontStyle.Bold)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(nombre,
               new Font("Arial", 12, FontStyle.Bold),
                       Brushes.Black, mitad, 455 + y);


            //IMPRIME PADRE

            if (padre.Contains('=') == true)
                padre = "";
            if (madre.Contains('=') == true)
                madre = "";

            tamaño_total = 880 - ev.Graphics.MeasureString(padre,
                new Font("Arial", 12, FontStyle.Bold)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(padre,
                new Font("Arial", 12, FontStyle.Bold),
                        Brushes.Black, mitad, 506 + y);

            /*** IMPRIME MADRE **/
            tamaño_total = 880 - ev.Graphics.MeasureString(madre,
                new Font("Arial", 12, FontStyle.Bold)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(madre,
                new Font("Arial", 12, FontStyle.Bold),
                        Brushes.Black, mitad, 559 + y);

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
               new Font("Arial", 12, FontStyle.Bold)).Width;

            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(padrinos,
                new Font("Arial", 12, FontStyle.Bold),
                        Brushes.Black, mitad, 610 + y);




            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaComunion.Split('-');

            String lugaryfecha = lugarBautismo + ". El " + fecha[2] +
                " DE " + fecha[1].ToUpper() +
                " DE " + fecha[0];

            tamaño_total = 880 - ev.Graphics.MeasureString(lugaryfecha,
               new Font("Arial", 12, FontStyle.Bold)).Width;

            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(lugaryfecha,
               new Font("Arial", 12, FontStyle.Bold),
                       Brushes.Black, mitad, 663 + y);

            //IMPRIME FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            String fecha_bau = fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0];
            tamaño_total = 880 - ev.Graphics.MeasureString(fecha_bau,
              new Font("Arial", 12, FontStyle.Bold)).Width;

            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(fecha_bau,
                new Font("Arial", 12, FontStyle.Bold),
                        Brushes.Black, mitad, 713 + y);



            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Arial", 12, FontStyle.Regular),
                        Brushes.Black, 113, 845 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, mitad + 420, 935 + y);


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

                    ev.Graphics.DrawImage(img, 113, 880 + y, 130, 130);

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
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, 460, 365);

            //IMPRIME hoja
            ev.Graphics.DrawString(Int32.Parse(foja).ToString("D4"),
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, 590, 365);

            //IMPRIME partida
            ev.Graphics.DrawString(Int32.Parse(partida).ToString("D5"),
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, 280, 458);


            //IMPRIME NOVIO
            ev.Graphics.DrawString(novio +" Y " +novia,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, 115, 423);

            //IMPRIME NOVIO
            ev.Graphics.DrawString(novio + " Y " + novia,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, 115, 575);

            //IMPRIME FECHA DE MATRIMONIO
            //separo la fecha de matrimonio
            fecha = fechaMatrimonio.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 180, 515);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 385, 515);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Arial", 10, FontStyle.Bold),
                        Brushes.Black, 590, 515);

            //IMPRIME LUGAR CELEBRACION
            ev.Graphics.DrawString(nombre_parroquia +", "+lugarCelebracion,
               new Font("Arial", 10, FontStyle.Bold),
               Brushes.Black, 270, 493);

         
            //IMPRIME TESTIGO 1
            if (testigo1.Contains('=') == true)
                testigo1 = "";
            ev.Graphics.DrawString(testigo1 + " Y "+testigo2,
               new Font("Arial", 10, FontStyle.Bold),
               Brushes.Black, 115, 645);

          
            //IMPRIME ASISTENTE
            ev.Graphics.DrawString(presbitero,
               new Font("Arial", 10, FontStyle.Bold),
               Brushes.Black, 115, 715);

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " de " + m.ToLower() + " del " + a;

            ev.Graphics.DrawString(lugar + " " + fechaActual,
                new Font("Arial", 12, FontStyle.Regular),
                        Brushes.Black, 113, 825 + y);


            tamaño_total = 440 - ev.Graphics.MeasureString(nombre_parroco,
                new Font("Arial", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
               new Font("Arial", 10, FontStyle.Bold),
                       Brushes.Black, mitad + 380, 935 + y);


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
              new Font("Arial", 9, FontStyle.Bold),
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
                new Font("Arial", 9, FontStyle.Bold),
                Brushes.Black, i, j);
            }
            

        }

        public void imprimeImagen(PrintPageEventArgs ev)
        {
            //IMPRIMIMOS DOCUMENTO
            ev.Graphics.DrawImage(newImage, 0, 0);

            /********************* iMG LOGO *************************/

            System.Drawing.Image logo = System.Drawing.Image.FromFile(@"c:/DOCSParroquia/logo.jpg");

            ev.Graphics.DrawImage(logo, 610, 60,155,215);

            //UBICACION PARROQUIA

            ev.Graphics.DrawString(nombre_parroquia + "\n" + nombre_diocesis + "\n" + ubicacion_parroquia + "\nTel: " + telefono + "\nE-mail: " + email,
              new Font("Arial", 12, FontStyle.Bold),
                      Brushes.Black, ev.MarginBounds);
            
        }

    }
}







