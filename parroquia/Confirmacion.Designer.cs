using System;
namespace Parroquia
{
    partial class Confirmacion
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.libro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.num_hoja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.num_partida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.padre = new System.Windows.Forms.TextBox();
            this.madre = new System.Windows.Forms.TextBox();
            this.lugarbau = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fecconf = new System.Windows.Forms.DateTimePicker();
            this.fecbau = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.madrina = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.padrino = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ministro = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cancelBtnConfirmacion = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.registronull = new System.Windows.Forms.CheckBox();
            this.registrobis = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.guardaImprimeBtn = new System.Windows.Forms.Button();
            this.guardarConfirBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "LIBRO:";
            // 
            // libro
            // 
            this.libro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.libro.Enabled = false;
            this.libro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libro.Location = new System.Drawing.Point(86, 12);
            this.libro.Name = "libro";
            this.libro.ReadOnly = true;
            this.libro.Size = new System.Drawing.Size(69, 23);
            this.libro.TabIndex = 1;
            this.libro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "HOJA:";
            // 
            // num_hoja
            // 
            this.num_hoja.Enabled = false;
            this.num_hoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_hoja.Location = new System.Drawing.Point(253, 12);
            this.num_hoja.Name = "num_hoja";
            this.num_hoja.ReadOnly = true;
            this.num_hoja.Size = new System.Drawing.Size(57, 23);
            this.num_hoja.TabIndex = 3;
            this.num_hoja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(361, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "PARTIDA:";
            // 
            // num_partida
            // 
            this.num_partida.Enabled = false;
            this.num_partida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_partida.Location = new System.Drawing.Point(442, 12);
            this.num_partida.Name = "num_partida";
            this.num_partida.ReadOnly = true;
            this.num_partida.Size = new System.Drawing.Size(71, 23);
            this.num_partida.TabIndex = 5;
            this.num_partida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "NOMBRE COMPLETO DEL CONFIRMADO:";
            // 
            // nombre
            // 
            this.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(192, 110);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(481, 23);
            this.nombre.TabIndex = 1;
            this.nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(189, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "PADRES DEL BAUTIZADO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(210, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "MADRE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(190, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "FECHA DE CONFIRMACIÓN:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(190, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "FECHA DE BAUTISMO:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "LUGAR DEL BAUTISMO:";
            // 
            // padre
            // 
            this.padre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.padre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.padre.Location = new System.Drawing.Point(281, 168);
            this.padre.Name = "padre";
            this.padre.Size = new System.Drawing.Size(391, 23);
            this.padre.TabIndex = 2;
            this.padre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.padre_KeyPress);
            // 
            // madre
            // 
            this.madre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madre.Location = new System.Drawing.Point(282, 197);
            this.madre.Name = "madre";
            this.madre.Size = new System.Drawing.Size(390, 23);
            this.madre.TabIndex = 3;
            this.madre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.madre_KeyPress);
            // 
            // lugarbau
            // 
            this.lugarbau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lugarbau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lugarbau.Location = new System.Drawing.Point(212, 311);
            this.lugarbau.Name = "lugarbau";
            this.lugarbau.Size = new System.Drawing.Size(362, 23);
            this.lugarbau.TabIndex = 6;
            this.lugarbau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lugar_bautismo_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(210, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "PADRE:";
            // 
            // fecconf
            // 
            this.fecconf.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecconf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecconf.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecconf.Location = new System.Drawing.Point(407, 230);
            this.fecconf.Name = "fecconf";
            this.fecconf.Size = new System.Drawing.Size(266, 23);
            this.fecconf.TabIndex = 4;
            // 
            // fecbau
            // 
            this.fecbau.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecbau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecbau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecbau.Location = new System.Drawing.Point(407, 262);
            this.fecbau.Name = "fecbau";
            this.fecbau.Size = new System.Drawing.Size(265, 23);
            this.fecbau.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(59, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "PADRINO:";
            // 
            // madrina
            // 
            this.madrina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madrina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madrina.Location = new System.Drawing.Point(151, 409);
            this.madrina.Name = "madrina";
            this.madrina.Size = new System.Drawing.Size(423, 23);
            this.madrina.TabIndex = 8;
            this.madrina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.madrina_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(59, 412);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "MADRINA:";
            // 
            // padrino
            // 
            this.padrino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.padrino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.padrino.Location = new System.Drawing.Point(150, 378);
            this.padrino.Name = "padrino";
            this.padrino.Size = new System.Drawing.Size(424, 23);
            this.padrino.TabIndex = 7;
            this.padrino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.padrino_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(27, 351);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(207, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "PADRINOS DEL CONFIRMADO:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(26, 455);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "NOMBRE DEL MINISTRO:";
            // 
            // ministro
            // 
            this.ministro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ministro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ministro.Location = new System.Drawing.Point(212, 451);
            this.ministro.Name = "ministro";
            this.ministro.Size = new System.Drawing.Size(362, 23);
            this.ministro.TabIndex = 9;
            this.ministro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ministro_KeyPress);
            // 
            // cancelBtnConfirmacion
            // 
            this.cancelBtnConfirmacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtnConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtnConfirmacion.Image = global::Parroquia.Properties.Resources.cancelar;
            this.cancelBtnConfirmacion.Location = new System.Drawing.Point(608, 451);
            this.cancelBtnConfirmacion.Name = "cancelBtnConfirmacion";
            this.cancelBtnConfirmacion.Size = new System.Drawing.Size(65, 65);
            this.cancelBtnConfirmacion.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cancelBtnConfirmacion, ":: CERRAR VENTANA ::");
            this.cancelBtnConfirmacion.UseVisualStyleBackColor = true;
            this.cancelBtnConfirmacion.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(679, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 15);
            this.label16.TabIndex = 33;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(678, 235);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 15);
            this.label17.TabIndex = 34;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(678, 265);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 15);
            this.label18.TabIndex = 35;
            this.label18.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(580, 314);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(12, 15);
            this.label20.TabIndex = 37;
            this.label20.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(580, 455);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(12, 15);
            this.label21.TabIndex = 38;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(678, 173);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(12, 15);
            this.label22.TabIndex = 39;
            this.label22.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(678, 205);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(12, 15);
            this.label23.TabIndex = 40;
            this.label23.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(580, 382);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(12, 15);
            this.label24.TabIndex = 41;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(580, 412);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 15);
            this.label25.TabIndex = 42;
            this.label25.Text = "*";
            // 
            // registronull
            // 
            this.registronull.AutoSize = true;
            this.registronull.Location = new System.Drawing.Point(583, 16);
            this.registronull.Name = "registronull";
            this.registronull.Size = new System.Drawing.Size(88, 17);
            this.registronull.TabIndex = 52;
            this.registronull.Text = "Registro nulo";
            this.registronull.UseVisualStyleBackColor = true;
            this.registronull.CheckedChanged += new System.EventHandler(this.registronull_CheckedChanged);
            // 
            // registrobis
            // 
            this.registrobis.AutoSize = true;
            this.registrobis.Location = new System.Drawing.Point(583, 39);
            this.registrobis.Name = "registrobis";
            this.registrobis.Size = new System.Drawing.Size(81, 17);
            this.registrobis.TabIndex = 50;
            this.registrobis.Text = "Registro bis";
            this.registrobis.UseVisualStyleBackColor = true;
            this.registrobis.CheckedChanged += new System.EventHandler(this.registrobis_CheckedChanged);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(27, 498);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(515, 31);
            this.label26.TabIndex = 51;
            this.label26.Text = "\"Y tú, después que hayas vuelto, tendrás que fortalecer a tus hermanos. Lc 22, 32" +
    "\"";
            // 
            // guardaImprimeBtn
            // 
            this.guardaImprimeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardaImprimeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardaImprimeBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guardaImprimeBtn.Image = global::Parroquia.Properties.Resources.imprimir;
            this.guardaImprimeBtn.Location = new System.Drawing.Point(608, 382);
            this.guardaImprimeBtn.Name = "guardaImprimeBtn";
            this.guardaImprimeBtn.Size = new System.Drawing.Size(65, 65);
            this.guardaImprimeBtn.TabIndex = 11;
            this.guardaImprimeBtn.UseVisualStyleBackColor = true;
            this.guardaImprimeBtn.Click += new System.EventHandler(this.guardaImprimeBtn_Click);
            // 
            // guardarConfirBtn
            // 
            this.guardarConfirBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardarConfirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarConfirBtn.Image = global::Parroquia.Properties.Resources.guardar1;
            this.guardarConfirBtn.Location = new System.Drawing.Point(608, 314);
            this.guardarConfirBtn.Name = "guardarConfirBtn";
            this.guardarConfirBtn.Size = new System.Drawing.Size(65, 65);
            this.guardarConfirBtn.TabIndex = 10;
            this.guardarConfirBtn.UseVisualStyleBackColor = true;
            this.guardarConfirBtn.Click += new System.EventHandler(this.guardarConfirBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Parroquia.Properties.Resources.confirmacion;
            this.pictureBox1.Location = new System.Drawing.Point(14, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 200);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Confirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(709, 537);
            this.Controls.Add(this.registronull);
            this.Controls.Add(this.registrobis);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.guardaImprimeBtn);
            this.Controls.Add(this.guardarConfirBtn);
            this.Controls.Add(this.cancelBtnConfirmacion);
            this.Controls.Add(this.ministro);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.madrina);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.padrino);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.fecbau);
            this.Controls.Add(this.madre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fecconf);
            this.Controls.Add(this.padre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lugarbau);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.num_partida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_hoja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.libro);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Confirmacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox libro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox num_hoja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox num_partida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox padre;
        private System.Windows.Forms.TextBox madre;
        private System.Windows.Forms.TextBox lugarbau;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker fecconf;
        private System.Windows.Forms.DateTimePicker fecbau;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox madrina;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox padrino;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ministro;
        private System.Windows.Forms.Button cancelBtnConfirmacion;
        private System.Windows.Forms.Button guardarConfirBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button guardaImprimeBtn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox registronull;
        private System.Windows.Forms.CheckBox registrobis;
        private System.Windows.Forms.Label label26;
    }
}