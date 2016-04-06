using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using conexionbd;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;


namespace Parroquia
{
    public partial class Egresos : Form
    {
        public PrintDocument MyPrintDocument;
        ImprimirEgresos MyDataGridViewPrinter;
        static int num_columns = 19, num_rows = 31;
        int[,] matriz_modificacion; // 0 -> null   1 -> ya registrado   2 -> modificado ya registrado  3 -> modificado no registrado
        double[,] matriz_mapeada; //matriz que mapea los datos a la tabla

        public bool guardar1 = false;
        public Egresos()
        {
            InitializeComponent();

            /****  MES Y AÑOS  ****/
            Object[] a = new Object[DateTime.Now.Year - 2014 + 1];
            for (int i = 2014; i <= DateTime.Now.Year; i++)
                a[i - 2014] = i;
            anio.Items.AddRange(a);
            anio.Text = DateTime.Now.Year + "";
            mes.SelectedIndex = DateTime.Now.Month - 1;

            /**** IMPRIMIR ***/
            MyPrintDocument = new PrintDocument();
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
        }

        public void restaurar(string mes, string anio)
        {
            DateTime fecha;
            int concepto;
            double cantidad;

            ConexionBD db = new ConexionBD();
            db.conexion();
            MySqlDataReader Datos = db.obtenerBasesDatosMySQL("SELECT * FROM egresos WHERE fecha >= '" + anio + "-" + mes + "-01' AND fecha <= '" + anio + "-" + mes + "-" + num_rows + "'");
            if (Datos.HasRows)
            {
                while (Datos.Read())
                {
                    fecha = Datos.GetDateTime(0);
                    concepto = Datos.GetInt32(1);
                    cantidad = Datos.GetDouble(2);
                    matriz_mapeada[fecha.Day-1, concepto] = cantidad;
                    matriz_modificacion[fecha.Day-1, concepto] = 1;
                    //MessageBox.Show(fecha.Day+" - "+concepto+": "+cantidad);
                    tabla.Rows[fecha.Day-1].Cells[concepto].Value = cantidad;
                }
            }
        }

 
        public void mapear_matriz(int fil, int col, double valor)
        {
            /*** CALCULANDO TOTALES Y ESCRIBIENDO NUEVO VALOR **/
            matriz_mapeada[fil, num_columns] = matriz_mapeada[fil, num_columns] - matriz_mapeada[fil, col] + valor;
            matriz_mapeada[num_rows, col] = matriz_mapeada[num_rows, col] - matriz_mapeada[fil, col] + valor;
            matriz_mapeada[fil, col] = valor;

            tabla.Rows[fil].Cells[num_columns].Value = matriz_mapeada[fil, num_columns];
            tabla.Rows[num_rows].Cells[col].Value = matriz_mapeada[num_rows, col];
            tabla.Rows[fil].Cells[col].Value = valor;

            /**** ESTABLECER MODO DE ALMACENAMIENTO ****/
            switch (matriz_modificacion[fil, col])
            {
                case 0: matriz_modificacion[fil, col] = 3; break;
                case 1: matriz_modificacion[fil, col] = 2; break;
            }

            /**** CALCULAR TOTAL ****/
            double suma = 0.0;
            for (int i = 0; i < num_rows; i++)
                suma += matriz_mapeada[i, num_columns];
            
            tabla.Rows[num_rows].Cells[num_columns].Value = suma;

            total.Text = "$ " + String.Format("{0:0.00}", suma);
        }


        private void calculoTotales()
        {
            double suma = 0;
            /*** SUMA DE FILA O(n*m) ***/
            for (int fila = 0; fila < num_rows; fila++)
            {
                suma = 0;
                for (int i = 2; i < num_columns; i++)
                    suma += matriz_mapeada[fila, i];
                matriz_mapeada[fila, num_columns] = suma;
                tabla.Rows[fila].Cells[num_columns].Value = suma;
            }
            
            /*** SUMA DE COLUMNA ***/
            for (int col = 2; col < num_columns+1; col++)
            {
                suma = 0.0;
                for (int i = 0; i < num_rows; i++)
                    suma += matriz_mapeada[i, col];
                matriz_mapeada[num_rows, col] = suma;
                tabla.Rows[num_rows].Cells[col].Value = suma;
            }
            tabla.Rows[num_rows].Cells[num_columns].Value = suma; 
            total.Text = "$ " + String.Format("{0:0.00}", suma);
        }

        private void tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double valor = double.Parse(tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
                mapear_matriz(e.RowIndex, e.ColumnIndex, valor);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "El valor ingresado no es válido", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                mapear_matriz(e.RowIndex, e.ColumnIndex, 0);
            }
        }
  

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool SetupThePrinting()
        {
            String ubicacionParroquia = "", nombreParroquia = "";
            ConexionBD db = new ConexionBD();
            MySqlDataReader datos;
            db.conexion();

            datos = db.obtenerBasesDatosMySQL("select nombre_parroquia, ubicacion_parroquia from informacion;");     

            if (datos.HasRows)
                while (datos.Read())
                {
                    nombreParroquia = datos.GetString(0);
                    ubicacionParroquia = datos.GetString(1);
                }

            db.Desconectar();
            if (!guardar1)
            {
                PrintDialog MyPrintDialog = new PrintDialog();
                MyPrintDialog.AllowCurrentPage = false;
                MyPrintDialog.AllowPrintToFile = false;
                MyPrintDialog.AllowSelection = false;
                MyPrintDialog.AllowSomePages = false;
                MyPrintDialog.PrintToFile = false;
                MyPrintDialog.ShowHelp = false;
                MyPrintDialog.ShowNetwork = false;

                if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                    return false;


                MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
                MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
                
            }
            else
            {
                guardar1 = false;
                MyPrintDocument.DefaultPageSettings.PrinterSettings.PrinterName = "PDFCreator";
            }

            String nombreDoc="";
            nombreDoc = "Egresos_" + mes.Text + "_" + anio.Text;

            MyPrintDocument.DocumentName = nombreDoc;
            MyPrintDocument.DefaultPageSettings.Landscape = true;
        
            MyPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("Legal", 850, 1340);
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(5, 5, 40, 40);


            MyDataGridViewPrinter = new ImprimirEgresos(tabla, MyPrintDocument, true, true, "E   R   O   G   A   C   I   O   N   E   S", new System.Drawing.Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true, nombreParroquia, ubicacionParroquia, mes.Text, anio.Text);
           
            return true;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            ConexionBD datos = new ConexionBD();
            datos.conexion();
            for(int dia = 0; dia < num_rows; dia++)
                for (int concep = 2; concep < num_columns; concep++)
                {
                    if (matriz_modificacion[dia, concep] == 2)
                    {
                        //MessageBox.Show("Actualizar: " + (dia + 1) + "," + concep);
                        String fecha = anio.Text + "-" + (mes.SelectedIndex + 1) + "-" + (dia + 1);
                        if (datos.peticion("UPDATE egresos SET cantidad = " + matriz_mapeada[dia, concep] + " WHERE fecha = '" + fecha + "' AND concepto = " + concep) > 0)
                        {
                            matriz_modificacion[dia, concep] = 1;
                        }
                    }
                    else if (matriz_modificacion[dia, concep] == 3)
                    {
                        //MessageBox.Show("Insertar: " + (dia + 1) + "," + concep + ": " + matriz_mapeada[dia, concep]);
                        String fecha = anio.Text + "-" + (mes.SelectedIndex + 1) + "-" + (dia + 1);
                        if (datos.peticion("INSERT INTO egresos (fecha, concepto, cantidad) values('" + fecha + "'," + concep + "," + matriz_mapeada[dia, concep] + ")") > 0)
                        {
                            matriz_modificacion[dia, concep] = 1;
                        }

                    }
                }
            MessageBox.Show(this,"Datos guardados correctamente.","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void actualizarDatos()
        {
            /*** OBTENER EL NUMERO DE DIAS DEL MES ****/
            int calc_mes = (mes.SelectedIndex + 1) % 12 + 1;
            num_rows = Convert.ToDateTime(anio.Text + "-" + calc_mes + "-01").AddDays(-1).Day;

            /*** CREAR NUEVAS MATRICES ***/
            matriz_modificacion = new int[num_rows, num_columns];
            matriz_mapeada = new double[num_rows + 1, num_columns + 1];

            tabla.Rows.Clear();

            /** CARACTERISTICAS DE LA TABLA ****/
            tabla.Rows.Add(num_rows);
            tabla.Rows.Insert(tabla.RowCount - 1, "");
            tabla.Rows[num_rows].Cells[1].Value = "TOTAL";

            tabla.Rows[num_rows].ReadOnly = true;
            tabla.Columns[num_columns].ReadOnly = true;

            //Poner los numeros de los dias
            for (int i = 0; i < num_rows; i++)
                tabla.Rows[i].SetValues((i + 1) + "");

            //Hacer consulta
            restaurar((mes.SelectedIndex + 1) + "", anio.Text);

            //** calculo de totales **/
            calculoTotales();

        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void enviar_correo_Click(object sender, EventArgs e)
        {
            guardar1 = true;
            if (SetupThePrinting())
            {
                MyPrintDocument.Print();
            }

        }


        private void cancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDatos();
        }
    }

}
