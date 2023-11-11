namespace Punto_de_Venta
{
    partial class frm_Registro_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Registro_Usuario));
            this.btn_atras = new System.Windows.Forms.Button();
            this.txt_contraseña2 = new System.Windows.Forms.TextBox();
            this.lbl_Contraseña2 = new System.Windows.Forms.Label();
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.lbl_Contraseña = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.mariscos_PepeDataSet = new Punto_de_Venta.Mariscos_PepeDataSet();
            this.meserosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.meserosTableAdapter = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.MeserosTableAdapter();
            this.tableAdapterManager = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meserosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_atras
            // 
            this.btn_atras.Location = new System.Drawing.Point(12, 380);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(113, 41);
            this.btn_atras.TabIndex = 15;
            this.btn_atras.Text = "Atras";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // txt_contraseña2
            // 
            this.txt_contraseña2.Location = new System.Drawing.Point(228, 130);
            this.txt_contraseña2.Name = "txt_contraseña2";
            this.txt_contraseña2.Size = new System.Drawing.Size(155, 26);
            this.txt_contraseña2.TabIndex = 14;
            this.txt_contraseña2.TextChanged += new System.EventHandler(this.txt_contraseña2_TextChanged);
            // 
            // lbl_Contraseña2
            // 
            this.lbl_Contraseña2.AutoSize = true;
            this.lbl_Contraseña2.Location = new System.Drawing.Point(12, 137);
            this.lbl_Contraseña2.Name = "lbl_Contraseña2";
            this.lbl_Contraseña2.Size = new System.Drawing.Size(166, 18);
            this.lbl_Contraseña2.TabIndex = 13;
            this.lbl_Contraseña2.Text = "Confirmar Contraseña:";
            // 
            // txt_contraseña
            // 
            this.txt_contraseña.Location = new System.Drawing.Point(136, 97);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.Size = new System.Drawing.Size(171, 26);
            this.txt_contraseña.TabIndex = 12;
            this.txt_contraseña.TextChanged += new System.EventHandler(this.txt_contraseña_TextChanged);
            // 
            // lbl_Contraseña
            // 
            this.lbl_Contraseña.AutoSize = true;
            this.lbl_Contraseña.Location = new System.Drawing.Point(12, 104);
            this.lbl_Contraseña.Name = "lbl_Contraseña";
            this.lbl_Contraseña.Size = new System.Drawing.Size(93, 18);
            this.lbl_Contraseña.TabIndex = 11;
            this.lbl_Contraseña.Text = "Contraseña:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(100, 62);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(171, 26);
            this.txt_usuario.TabIndex = 10;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(136, 249);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(119, 54);
            this.btn_Agregar.TabIndex = 9;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.Location = new System.Drawing.Point(12, 65);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(66, 18);
            this.lbl_Usuario.TabIndex = 8;
            this.lbl_Usuario.Text = "Usuario:";
            // 
            // mariscos_PepeDataSet
            // 
            this.mariscos_PepeDataSet.DataSetName = "Mariscos_PepeDataSet";
            this.mariscos_PepeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // meserosBindingSource
            // 
            this.meserosBindingSource.DataMember = "Meseros";
            this.meserosBindingSource.DataSource = this.mariscos_PepeDataSet;
            // 
            // meserosTableAdapter
            // 
            this.meserosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AdminTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EnviosTableAdapter = null;
            this.tableAdapterManager.FacturasTableAdapter = null;
            this.tableAdapterManager.MeserosTableAdapter = this.meserosTableAdapter;
            this.tableAdapterManager.ProductosTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frm_Registro_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 433);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.txt_contraseña2);
            this.Controls.Add(this.lbl_Contraseña2);
            this.Controls.Add(this.txt_contraseña);
            this.Controls.Add(this.lbl_Contraseña);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.lbl_Usuario);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Registro_Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro-Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Registro_Usuario_FormClosing);
            this.Load += new System.EventHandler(this.frm_Registro_Usuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meserosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.TextBox txt_contraseña2;
        private System.Windows.Forms.Label lbl_Contraseña2;
        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.Label lbl_Contraseña;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Label lbl_Usuario;
        private Mariscos_PepeDataSet mariscos_PepeDataSet;
        private System.Windows.Forms.BindingSource meserosBindingSource;
        private Mariscos_PepeDataSetTableAdapters.MeserosTableAdapter meserosTableAdapter;
        private Mariscos_PepeDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}