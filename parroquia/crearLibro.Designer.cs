namespace Parroquia
{
    partial class crearLibro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(crearLibro));
            this.label1 = new System.Windows.Forms.Label();
            this.nombreLibro = new System.Windows.Forms.TextBox();
            this.cancelarCrearLibro = new System.Windows.Forms.Button();
            this.guardarCrearLibro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite el nombre del libro";
            // 
            // nombreLibro
            // 
            this.nombreLibro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreLibro.Location = new System.Drawing.Point(16, 32);
            this.nombreLibro.Name = "nombreLibro";
            this.nombreLibro.Size = new System.Drawing.Size(207, 20);
            this.nombreLibro.TabIndex = 1;
            // 
            // cancelarCrearLibro
            // 
            this.cancelarCrearLibro.Image = ((System.Drawing.Image)(resources.GetObject("cancelarCrearLibro.Image")));
            this.cancelarCrearLibro.Location = new System.Drawing.Point(123, 68);
            this.cancelarCrearLibro.Name = "cancelarCrearLibro";
            this.cancelarCrearLibro.Size = new System.Drawing.Size(100, 38);
            this.cancelarCrearLibro.TabIndex = 2;
            this.cancelarCrearLibro.UseVisualStyleBackColor = true;
            this.cancelarCrearLibro.Click += new System.EventHandler(this.cancelarCrearLibro_Click);
            // 
            // guardarCrearLibro
            // 
            this.guardarCrearLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarCrearLibro.Image = ((System.Drawing.Image)(resources.GetObject("guardarCrearLibro.Image")));
            this.guardarCrearLibro.Location = new System.Drawing.Point(12, 68);
            this.guardarCrearLibro.Name = "guardarCrearLibro";
            this.guardarCrearLibro.Size = new System.Drawing.Size(90, 38);
            this.guardarCrearLibro.TabIndex = 3;
            this.guardarCrearLibro.Text = "Guardar";
            this.guardarCrearLibro.UseVisualStyleBackColor = true;
            this.guardarCrearLibro.Click += new System.EventHandler(this.guardarCrearLibro_Click);
            // 
            // crearLibro
            // 
            this.AcceptButton = this.guardarCrearLibro;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(235, 118);
            this.Controls.Add(this.guardarCrearLibro);
            this.Controls.Add(this.cancelarCrearLibro);
            this.Controls.Add(this.nombreLibro);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "crearLibro";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nombre del libro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreLibro;
        private System.Windows.Forms.Button cancelarCrearLibro;
        private System.Windows.Forms.Button guardarCrearLibro;
    }
}