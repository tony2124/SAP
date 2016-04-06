namespace Parroquia
{
    partial class formatosImpresion
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
            this.formatoCopia = new System.Windows.Forms.Button();
            this.originalVertical = new System.Windows.Forms.Button();
            this.originalHorizontal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // formatoCopia
            // 
            this.formatoCopia.Location = new System.Drawing.Point(12, 48);
            this.formatoCopia.Name = "formatoCopia";
            this.formatoCopia.Size = new System.Drawing.Size(133, 147);
            this.formatoCopia.TabIndex = 0;
            this.formatoCopia.Text = "Formato copia simple";
            this.formatoCopia.UseVisualStyleBackColor = true;
            this.formatoCopia.Click += new System.EventHandler(this.button1_Click);
            // 
            // originalVertical
            // 
            this.originalVertical.Location = new System.Drawing.Point(191, 48);
            this.originalVertical.Name = "originalVertical";
            this.originalVertical.Size = new System.Drawing.Size(133, 147);
            this.originalVertical.TabIndex = 1;
            this.originalVertical.Text = "Formato original vertical";
            this.originalVertical.UseVisualStyleBackColor = true;
            this.originalVertical.Click += new System.EventHandler(this.button2_Click);
            // 
            // originalHorizontal
            // 
            this.originalHorizontal.Location = new System.Drawing.Point(370, 48);
            this.originalHorizontal.Name = "originalHorizontal";
            this.originalHorizontal.Size = new System.Drawing.Size(133, 147);
            this.originalHorizontal.TabIndex = 2;
            this.originalHorizontal.Text = "Formato original horizontal";
            this.originalHorizontal.UseVisualStyleBackColor = true;
            this.originalHorizontal.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elige el formato que deseas imprimir";
            // 
            // formatosImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(515, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.originalHorizontal);
            this.Controls.Add(this.originalVertical);
            this.Controls.Add(this.formatoCopia);
            this.MaximizeBox = false;
            this.Name = "formatosImpresion";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formatos de impresión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button formatoCopia;
        private System.Windows.Forms.Button originalVertical;
        private System.Windows.Forms.Button originalHorizontal;
        private System.Windows.Forms.Label label1;
    }
}