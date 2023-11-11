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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Principal));
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_admin = new System.Windows.Forms.Button();
            this.btn_usuario = new System.Windows.Forms.Button();
            this.mariscos_PepeDataSet = new Punto_de_Venta.Mariscos_PepeDataSet();
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasTableAdapter = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.FacturasTableAdapter();
            this.tableAdapterManager = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager();
            this.lbl_Caja = new System.Windows.Forms.Label();
            this.lbl_dinero_caja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(148, 181);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(84, 32);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_admin
            // 
            this.btn_admin.Location = new System.Drawing.Point(128, 26);
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(123, 43);
            this.btn_admin.TabIndex = 1;
            this.btn_admin.Text = "Administrador";
            this.btn_admin.UseVisualStyleBackColor = true;
            this.btn_admin.Click += new System.EventHandler(this.btn_admin_Click);
            // 
            // btn_usuario
            // 
            this.btn_usuario.Location = new System.Drawing.Point(128, 84);
            this.btn_usuario.Name = "btn_usuario";
            this.btn_usuario.Size = new System.Drawing.Size(123, 37);
            this.btn_usuario.TabIndex = 2;
            this.btn_usuario.Text = "Usuario";
            this.btn_usuario.UseVisualStyleBackColor = true;
            this.btn_usuario.Click += new System.EventHandler(this.btn_usuario_Click);
            // 
            // mariscos_PepeDataSet
            // 
            this.mariscos_PepeDataSet.DataSetName = "Mariscos_PepeDataSet";
            this.mariscos_PepeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "Facturas";
            this.facturasBindingSource.DataSource = this.mariscos_PepeDataSet;
            // 
            // facturasTableAdapter
            // 
            this.facturasTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AdminTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EnviosTableAdapter = null;
            this.tableAdapterManager.FacturasTableAdapter = this.facturasTableAdapter;
            this.tableAdapterManager.MeserosTableAdapter = null;
            this.tableAdapterManager.ProductosTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lbl_Caja
            // 
            this.lbl_Caja.AutoSize = true;
            this.lbl_Caja.Location = new System.Drawing.Point(242, 241);
            this.lbl_Caja.Name = "lbl_Caja";
            this.lbl_Caja.Size = new System.Drawing.Size(132, 18);
            this.lbl_Caja.TabIndex = 3;
            this.lbl_Caja.Text = "Caja Abierta Con:";
            // 
            // lbl_dinero_caja
            // 
            this.lbl_dinero_caja.AutoSize = true;
            this.lbl_dinero_caja.Font = new System.Drawing.Font("Arial", 16F);
            this.lbl_dinero_caja.Location = new System.Drawing.Point(274, 259);
            this.lbl_dinero_caja.Name = "lbl_dinero_caja";
            this.lbl_dinero_caja.Size = new System.Drawing.Size(0, 25);
            this.lbl_dinero_caja.TabIndex = 4;
            // 
            // frm_Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(386, 293);
            this.Controls.Add(this.lbl_dinero_caja);
            this.Controls.Add(this.lbl_Caja);
            this.Controls.Add(this.btn_usuario);
            this.Controls.Add(this.btn_admin);
            this.Controls.Add(this.btn_salir);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Menu_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Menu_Principal_FormClosing);
            this.Load += new System.EventHandler(this.frm_Menu_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_admin;
        private System.Windows.Forms.Button btn_usuario;
        private Mariscos_PepeDataSet mariscos_PepeDataSet;
        private System.Windows.Forms.BindingSource facturasBindingSource;
        private Mariscos_PepeDataSetTableAdapters.FacturasTableAdapter facturasTableAdapter;
        private Mariscos_PepeDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label lbl_Caja;
        private System.Windows.Forms.Label lbl_dinero_caja;
    }
}

