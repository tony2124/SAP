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
    public partial class formatosImpresion : Form
    {
        /*VARIABLES GLOBALES DE TODAS LAS CATEGORIAS********************/
        /**/private string LIBRO;
        /**/private string HOJA;
        /**/private string PARTIDA;
        /***************************************************************/

        /*VARIABLES GLOBALES DE CATEGORIA BAUTISMO, ********************/
        /*CONFIRMACION Y COMUNIONES*************************************/
        /**/private string NOMBRE;
        /**/private string PADRE;
        /**/private string MADRE;
        /**/private string MADRINA;
        /**/private string PADRINO;
        /***************************************************************/

        /*VARIABLES GLOBALES DE BAUTISMO Y CONFIRMACIONES***************/
        /**/private string FECHA_BAUTISMO;
        /**/private string PRESBITERO;
        /***************************************************************/

        /*VARIABLES GLOBALES SOLO DE BAUTISMO***************************/
        /**/private string NACIMIENTO_LUGAR, FECHA_NACIMIENTO, ANOTACION;
        /***************************************************************/

        /*VARIABLES GLOBALES SOLO DE CONFIRMACION*/
        /**/private string FECHA_CONFIRMACION, LUGAR_BAUTISMO;

        /*VARIABLES GLOBALES DE COMUNIONES*/
        private string FECHA_COMUNION;

        /*VARIABLES GLOBALES DE MATRIMONIO*/
        private string NOVIO, NOVIA, TESTIGO1, TESTIGO2, FECHA_MATRIMONIO,
            LUGAR_CELEBRACION;

        private int CATEGORIA;

        public formatosImpresion()
        {
            InitializeComponent();
        }

        public formatosImpresion(string libro, string hoja, string partida, 
            string A, string B, string C, string D, string E, string F, 
            string G, string H, string I, string J, int categoria)
        {
            /*INICIALIZACION DE LOS COMPONENTES GRAFICOS*/
            /**/InitializeComponent();
            /**************************************************/

            CATEGORIA = categoria;
            this.LIBRO = libro;
            this.HOJA = hoja;
            this.PARTIDA = partida;

            // TODO: Complete member initialization
            if (categoria == 1)
            { 
                this.NOMBRE = A;
                this.PADRE = B;
                this.MADRE = C;
                this.NACIMIENTO_LUGAR = D;
                this.FECHA_NACIMIENTO = E;
                this.FECHA_BAUTISMO = F;
                this.PRESBITERO = G;
                this.MADRINA = H;
                this.PADRINO = I;
                this.ANOTACION = J;
            }
            else if (categoria == 2)
            {
                this.NOMBRE = A;
                this.PADRE = B;
                this.MADRE = C;
                this.LUGAR_BAUTISMO = D;
                this.FECHA_BAUTISMO = E;
                this.FECHA_CONFIRMACION = F;
                this.PRESBITERO = G;
                this.MADRINA = H;
                this.PADRINO = I;
                this.originalHorizontal.Enabled = false;

            }
            else if (categoria == 3)
            {
                this.NOMBRE = A;
                this.PADRE = B;
                this.MADRE = C;
                this.FECHA_COMUNION = D;
                this.FECHA_BAUTISMO = E;
                this.LUGAR_BAUTISMO = F;
                this.MADRINA = G;
                this.PADRINO = H;
                this.PRESBITERO = I;
                this.originalVertical.Enabled = false;
            }
            else if (categoria == 4)
            {
                this.NOVIO = A;
                this.NOVIA = B;
                this.FECHA_MATRIMONIO = C;
                this.LUGAR_CELEBRACION = D;
                this.TESTIGO1 = E;
                this.TESTIGO2 = F;
                this.PRESBITERO = G;
                this.ANOTACION = H;
                this.originalHorizontal.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CATEGORIA == 1)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
                PADRE, MADRE, NACIMIENTO_LUGAR, FECHA_NACIMIENTO,
                FECHA_BAUTISMO, PRESBITERO, MADRINA, PADRINO, ANOTACION, 
                CATEGORIA,0);
               // Dispose();
            }
            else if (CATEGORIA == 2)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
                PADRE, MADRE, LUGAR_BAUTISMO, FECHA_BAUTISMO, 
                FECHA_CONFIRMACION, PRESBITERO, MADRINA, PADRINO,"",
                CATEGORIA,0);
               // Dispose();
            }
            else if (CATEGORIA == 3)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
                PADRE, MADRE, FECHA_COMUNION, FECHA_BAUTISMO,
                LUGAR_BAUTISMO, PADRINO, MADRINA, PRESBITERO,"",
                CATEGORIA, 0);
              //  Dispose();
            }
            else if (CATEGORIA == 4)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOVIO,
                NOVIA, FECHA_MATRIMONIO, LUGAR_CELEBRACION, TESTIGO1,
                TESTIGO2, PRESBITERO, ANOTACION, "", "",
                CATEGORIA, 0);
               // Dispose();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CATEGORIA == 1)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
                PADRE, MADRE, NACIMIENTO_LUGAR, FECHA_NACIMIENTO,
                FECHA_BAUTISMO, PRESBITERO, MADRINA, PADRINO, ANOTACION,
                CATEGORIA, 1);
           //     Dispose();
            }
            else if (CATEGORIA == 2)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
                PADRE, MADRE, LUGAR_BAUTISMO, FECHA_BAUTISMO,
                FECHA_CONFIRMACION, PRESBITERO, MADRINA, PADRINO, "",
                CATEGORIA, 1);
            //    Dispose();
            }
            else if (CATEGORIA == 3)
            {
                
            }
            else if (CATEGORIA == 4)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOVIO,
                 NOVIA, FECHA_MATRIMONIO, LUGAR_CELEBRACION, TESTIGO1,
                 TESTIGO2, PRESBITERO, ANOTACION, "", "",
                 CATEGORIA, 1);
             //   Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CATEGORIA == 1)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
                PADRE, MADRE, NACIMIENTO_LUGAR, FECHA_NACIMIENTO,
                FECHA_BAUTISMO, PRESBITERO, MADRINA, PADRINO, ANOTACION,
                CATEGORIA, 2);
            //    Dispose();
            }
            else if (CATEGORIA == 2)
            {
               
              
            }
            else if (CATEGORIA == 3)
            {
                Imprimir a = new Imprimir(LIBRO, HOJA, PARTIDA, NOMBRE,
               PADRE, MADRE, FECHA_COMUNION, FECHA_BAUTISMO,
               LUGAR_BAUTISMO, PADRINO, MADRINA, PRESBITERO, "",
               CATEGORIA, 2);
                Dispose();

              //  Dispose();
            }
            else if (CATEGORIA == 4)
            {

               // Dispose();
            }
        }
    }
}
