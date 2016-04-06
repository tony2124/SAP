using System;
namespace Parroquia
{
    public partial class Libros
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
        /// 

        

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Libros));
            this.panelContenedorLibros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.crearLibroButton = new System.Windows.Forms.Button();
            this.eliminarLibroButton = new System.Windows.Forms.Button();
            this.editarLibroButton = new System.Windows.Forms.Button();
            this.cancelarVentanaLibrosBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelContenedorLibros
            // 
            this.panelContenedorLibros.AutoScroll = true;
            this.panelContenedorLibros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedorLibros.Location = new System.Drawing.Point(13, 13);
            this.panelContenedorLibros.Name = "panelContenedorLibros";
            this.panelContenedorLibros.Size = new System.Drawing.Size(535, 274);
            this.panelContenedorLibros.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 0;
            // 
            // crearLibroButton
            // 
            this.crearLibroButton.Location = new System.Drawing.Point(12, 300);
            this.crearLibroButton.Name = "crearLibroButton";
            this.crearLibroButton.Size = new System.Drawing.Size(83, 25);
            this.crearLibroButton.TabIndex = 1;
            this.crearLibroButton.Tag = "Crear libro";
            this.crearLibroButton.Text = "Crear libro";
            this.crearLibroButton.UseVisualStyleBackColor = true;
            this.crearLibroButton.Click += new System.EventHandler(this.crearLibro);
            // 
            // eliminarLibroButton
            // 
            this.eliminarLibroButton.Enabled = false;
            this.eliminarLibroButton.Location = new System.Drawing.Point(102, 300);
            this.eliminarLibroButton.Name = "eliminarLibroButton";
            this.eliminarLibroButton.Size = new System.Drawing.Size(83, 25);
            this.eliminarLibroButton.TabIndex = 2;
            this.eliminarLibroButton.Text = "Eliminar libro";
            this.eliminarLibroButton.UseVisualStyleBackColor = true;
            this.eliminarLibroButton.Click += new System.EventHandler(this.eliminarLibro);
            // 
            // editarLibroButton
            // 
            this.editarLibroButton.Location = new System.Drawing.Point(192, 300);
            this.editarLibroButton.Name = "editarLibroButton";
            this.editarLibroButton.Size = new System.Drawing.Size(83, 25);
            this.editarLibroButton.TabIndex = 1;
            this.editarLibroButton.Tag = "Editar libro";
            this.editarLibroButton.Text = "Editar libro";
            this.editarLibroButton.UseVisualStyleBackColor = true;
            this.editarLibroButton.Click += new System.EventHandler(this.editarLibro);
            // 
            // cancelarVentanaLibrosBtn
            // 
            this.cancelarVentanaLibrosBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelarVentanaLibrosBtn.Image")));
            this.cancelarVentanaLibrosBtn.Location = new System.Drawing.Point(443, 293);
            this.cancelarVentanaLibrosBtn.Name = "cancelarVentanaLibrosBtn";
            this.cancelarVentanaLibrosBtn.Size = new System.Drawing.Size(105, 38);
            this.cancelarVentanaLibrosBtn.TabIndex = 3;
            this.cancelarVentanaLibrosBtn.UseVisualStyleBackColor = true;
            this.cancelarVentanaLibrosBtn.Click += new System.EventHandler(this.cancelarVentana);
            // 
            // Libros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 335);
            this.Controls.Add(this.cancelarVentanaLibrosBtn);
            this.Controls.Add(this.eliminarLibroButton);
            this.Controls.Add(this.editarLibroButton);
            this.Controls.Add(this.crearLibroButton);
            this.Controls.Add(this.panelContenedorLibros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Libros";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedorLibros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crearLibroButton;
        private System.Windows.Forms.Button eliminarLibroButton;
        private System.Windows.Forms.Button editarLibroButton;
        private System.Windows.Forms.Button cancelarVentanaLibrosBtn;

    }
}