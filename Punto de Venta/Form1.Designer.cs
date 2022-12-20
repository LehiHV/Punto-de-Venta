namespace Punto_de_Venta
{
    partial class frm_Menu_Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_admin = new System.Windows.Forms.Button();
            this.btn_usuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(103, 183);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(84, 32);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_admin
            // 
            this.btn_admin.Location = new System.Drawing.Point(83, 28);
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(123, 43);
            this.btn_admin.TabIndex = 1;
            this.btn_admin.Text = "Administrador";
            this.btn_admin.UseVisualStyleBackColor = true;
            // 
            // btn_usuario
            // 
            this.btn_usuario.Location = new System.Drawing.Point(83, 86);
            this.btn_usuario.Name = "btn_usuario";
            this.btn_usuario.Size = new System.Drawing.Size(123, 37);
            this.btn_usuario.TabIndex = 2;
            this.btn_usuario.Text = "Usuario";
            this.btn_usuario.UseVisualStyleBackColor = true;
            // 
            // frm_Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 227);
            this.Controls.Add(this.btn_usuario);
            this.Controls.Add(this.btn_admin);
            this.Controls.Add(this.btn_salir);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Menu_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Menu_Principal_FormClosing);
            this.Load += new System.EventHandler(this.frm_Menu_Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_admin;
        private System.Windows.Forms.Button btn_usuario;
    }
}

