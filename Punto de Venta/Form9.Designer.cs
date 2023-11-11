namespace Punto_de_Venta
{
    partial class frm_Seleccion_envios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Seleccion_envios));
            this.btn_seleccion = new System.Windows.Forms.Button();
            this.lbl_Telefono = new System.Windows.Forms.Label();
            this.dgv_Tabla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_seleccion
            // 
            this.btn_seleccion.Location = new System.Drawing.Point(724, 192);
            this.btn_seleccion.Name = "btn_seleccion";
            this.btn_seleccion.Size = new System.Drawing.Size(148, 76);
            this.btn_seleccion.TabIndex = 1;
            this.btn_seleccion.Text = "Seleccionar";
            this.btn_seleccion.UseVisualStyleBackColor = true;
            this.btn_seleccion.Click += new System.EventHandler(this.btn_seleccion_Click);
            // 
            // lbl_Telefono
            // 
            this.lbl_Telefono.AutoSize = true;
            this.lbl_Telefono.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Telefono.Location = new System.Drawing.Point(767, 35);
            this.lbl_Telefono.Name = "lbl_Telefono";
            this.lbl_Telefono.Size = new System.Drawing.Size(107, 20);
            this.lbl_Telefono.TabIndex = 2;
            this.lbl_Telefono.Text = "Direccion de: ";
            // 
            // dgv_Tabla
            // 
            this.dgv_Tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Tabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tabla.Location = new System.Drawing.Point(12, 12);
            this.dgv_Tabla.Name = "dgv_Tabla";
            this.dgv_Tabla.Size = new System.Drawing.Size(706, 437);
            this.dgv_Tabla.TabIndex = 9;
            this.dgv_Tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tabla_CellContentClick);
            // 
            // frm_Seleccion_envios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.dgv_Tabla);
            this.Controls.Add(this.lbl_Telefono);
            this.Controls.Add(this.btn_seleccion);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Seleccion_envios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciona el Envio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Seleccion_envios_FormClosing);
            this.Load += new System.EventHandler(this.frm_Seleccion_envios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_seleccion;
        public System.Windows.Forms.Label lbl_Telefono;
        private System.Windows.Forms.DataGridView dgv_Tabla;
    }
}