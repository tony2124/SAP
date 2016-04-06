namespace Parroquia
{
    partial class Ingresos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exentros_mitra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donativos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limosnas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_tabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.anio = new System.Windows.Forms.ComboBox();
            this.mes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cerrar = new System.Windows.Forms.Button();
            this.pdf = new System.Windows.Forms.Button();
            this.imprimir = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.total_mitra = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.otros_gastos = new System.Windows.Forms.TextBox();
            this.contador = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dos_por_ciento = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diez_por_ciento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.total_exento = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ingresos_lbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.egresos = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.AllowUserToResizeRows = false;
            this.tabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.exentros_mitra,
            this.donativos,
            this.limosnas,
            this.notaria,
            this.otras,
            this.total_tabla});
            this.tabla.Location = new System.Drawing.Point(12, 144);
            this.tabla.MultiSelect = false;
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(811, 238);
            this.tabla.TabIndex = 1;
            this.tabla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_CellEndEdit);
            // 
            // fecha
            // 
            dataGridViewCellStyle1.Format = "M";
            dataGridViewCellStyle1.NullValue = null;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecha.Frozen = true;
            this.fecha.HeaderText = "FECHA";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // exentros_mitra
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.exentros_mitra.DefaultCellStyle = dataGridViewCellStyle2;
            this.exentros_mitra.HeaderText = "EXENTOS MITRA";
            this.exentros_mitra.Name = "exentros_mitra";
            this.exentros_mitra.ReadOnly = true;
            // 
            // donativos
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.donativos.DefaultCellStyle = dataGridViewCellStyle3;
            this.donativos.HeaderText = "DONATIVOS";
            this.donativos.Name = "donativos";
            // 
            // limosnas
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.limosnas.DefaultCellStyle = dataGridViewCellStyle4;
            this.limosnas.HeaderText = "LIMOSNAS";
            this.limosnas.Name = "limosnas";
            // 
            // notaria
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.notaria.DefaultCellStyle = dataGridViewCellStyle5;
            this.notaria.HeaderText = "NOTARÍA";
            this.notaria.Name = "notaria";
            // 
            // otras
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.otras.DefaultCellStyle = dataGridViewCellStyle6;
            this.otras.HeaderText = "OTRAS";
            this.otras.Name = "otras";
            // 
            // total_tabla
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.total_tabla.DefaultCellStyle = dataGridViewCellStyle7;
            this.total_tabla.HeaderText = "TOTAL";
            this.total_tabla.Name = "total_tabla";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.anio);
            this.groupBox1.Controls.Add(this.mes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(305, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // anio
            // 
            this.anio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(51, 67);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(136, 21);
            this.anio.TabIndex = 3;
            this.anio.SelectedIndexChanged += new System.EventHandler(this.anio_SelectedIndexChanged);
            // 
            // mes
            // 
            this.mes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mes.FormattingEnabled = true;
            this.mes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.mes.Location = new System.Drawing.Point(51, 28);
            this.mes.Name = "mes";
            this.mes.Size = new System.Drawing.Size(136, 21);
            this.mes.TabIndex = 2;
            this.mes.SelectedIndexChanged += new System.EventHandler(this.mes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mes";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cerrar);
            this.groupBox2.Controls.Add(this.pdf);
            this.groupBox2.Controls.Add(this.imprimir);
            this.groupBox2.Controls.Add(this.guardar);
            this.groupBox2.Location = new System.Drawing.Point(528, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operación";
            // 
            // cerrar
            // 
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = global::Parroquia.Properties.Resources.cancelar;
            this.cerrar.Location = new System.Drawing.Point(220, 28);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(62, 62);
            this.cerrar.TabIndex = 3;
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.button4_Click);
            // 
            // pdf
            // 
            this.pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pdf.Image = global::Parroquia.Properties.Resources.pdf;
            this.pdf.Location = new System.Drawing.Point(152, 28);
            this.pdf.Name = "pdf";
            this.pdf.Size = new System.Drawing.Size(62, 62);
            this.pdf.TabIndex = 2;
            this.pdf.UseVisualStyleBackColor = true;
            this.pdf.Click += new System.EventHandler(this.pdf_Click);
            // 
            // imprimir
            // 
            this.imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imprimir.Image = global::Parroquia.Properties.Resources.vistapre;
            this.imprimir.Location = new System.Drawing.Point(84, 28);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(62, 62);
            this.imprimir.TabIndex = 1;
            this.imprimir.UseVisualStyleBackColor = true;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // guardar
            // 
            this.guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardar.Image = global::Parroquia.Properties.Resources.guardar;
            this.guardar.Location = new System.Drawing.Point(16, 28);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(62, 62);
            this.guardar.TabIndex = 0;
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Parroquia.Properties.Resources.ingresos;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 111);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.total_mitra);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.otros_gastos);
            this.groupBox3.Controls.Add(this.contador);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dos_por_ciento);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.diez_por_ciento);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 173);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "M I T R A";
            // 
            // total_mitra
            // 
            this.total_mitra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_mitra.Location = new System.Drawing.Point(94, 145);
            this.total_mitra.Name = "total_mitra";
            this.total_mitra.Size = new System.Drawing.Size(100, 25);
            this.total_mitra.TabIndex = 11;
            this.total_mitra.Text = "----";
            this.total_mitra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 23);
            this.label9.TabIndex = 10;
            this.label9.Text = "TOTAL";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // otros_gastos
            // 
            this.otros_gastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otros_gastos.Location = new System.Drawing.Point(110, 104);
            this.otros_gastos.Name = "otros_gastos";
            this.otros_gastos.Size = new System.Drawing.Size(84, 21);
            this.otros_gastos.TabIndex = 9;
            this.otros_gastos.Text = "0";
            this.otros_gastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.otros_gastos.Leave += new System.EventHandler(this.otros_gastos_Leave);
            // 
            // contador
            // 
            this.contador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contador.Location = new System.Drawing.Point(110, 79);
            this.contador.Name = "contador";
            this.contador.Size = new System.Drawing.Size(84, 21);
            this.contador.TabIndex = 8;
            this.contador.Text = "0";
            this.contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contador.Leave += new System.EventHandler(this.contador_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 23);
            this.label10.TabIndex = 6;
            this.label10.Text = "OTROS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "CONTADOR";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dos_por_ciento
            // 
            this.dos_por_ciento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dos_por_ciento.Location = new System.Drawing.Point(70, 53);
            this.dos_por_ciento.Name = "dos_por_ciento";
            this.dos_por_ciento.Size = new System.Drawing.Size(124, 25);
            this.dos_por_ciento.TabIndex = 3;
            this.dos_por_ciento.Text = "----";
            this.dos_por_ciento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "2 %";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // diez_por_ciento
            // 
            this.diez_por_ciento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diez_por_ciento.Location = new System.Drawing.Point(70, 28);
            this.diez_por_ciento.Name = "diez_por_ciento";
            this.diez_por_ciento.Size = new System.Drawing.Size(124, 25);
            this.diez_por_ciento.TabIndex = 1;
            this.diez_por_ciento.Text = "----";
            this.diez_por_ciento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "10 %";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.total_exento);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.ingresos_lbl);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.egresos);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(237, 407);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 125);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "E X E N T O S   M I T R A";
            // 
            // total_exento
            // 
            this.total_exento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_exento.Location = new System.Drawing.Point(89, 97);
            this.total_exento.Name = "total_exento";
            this.total_exento.Size = new System.Drawing.Size(111, 25);
            this.total_exento.TabIndex = 9;
            this.total_exento.Text = "----";
            this.total_exento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 23);
            this.label16.TabIndex = 8;
            this.label16.Text = "TOTAL";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ingresos_lbl
            // 
            this.ingresos_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingresos_lbl.Location = new System.Drawing.Point(89, 53);
            this.ingresos_lbl.Name = "ingresos_lbl";
            this.ingresos_lbl.Size = new System.Drawing.Size(111, 25);
            this.ingresos_lbl.TabIndex = 7;
            this.ingresos_lbl.Text = "----";
            this.ingresos_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 23);
            this.label14.TabIndex = 6;
            this.label14.Text = "INGRESOS";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // egresos
            // 
            this.egresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.egresos.Location = new System.Drawing.Point(89, 28);
            this.egresos.Name = "egresos";
            this.egresos.Size = new System.Drawing.Size(111, 25);
            this.egresos.TabIndex = 5;
            this.egresos.Text = "----";
            this.egresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 23);
            this.label12.TabIndex = 4;
            this.label12.Text = "EGRESOS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // total
            // 
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(680, 407);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(143, 23);
            this.total.TabIndex = 6;
            this.total.Text = "$ 0.00";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(590, 410);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 17);
            this.label18.TabIndex = 7;
            this.label18.Text = "T O T A L:";
            // 
            // Ingresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 602);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.total);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ingresos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresos";
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox anio;
        private System.Windows.Forms.ComboBox mes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Button pdf;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox otros_gastos;
        private System.Windows.Forms.TextBox contador;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dos_por_ciento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label diez_por_ciento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label total_mitra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label total_exento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label ingresos_lbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label egresos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn exentros_mitra;
        private System.Windows.Forms.DataGridViewTextBoxColumn donativos;
        private System.Windows.Forms.DataGridViewTextBoxColumn limosnas;
        private System.Windows.Forms.DataGridViewTextBoxColumn notaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn otras;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_tabla;
    }
}