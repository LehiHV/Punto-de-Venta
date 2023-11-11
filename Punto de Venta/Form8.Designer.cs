namespace Punto_de_Venta
{
    partial class frm_Registro_Envios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Registro_Envios));
            this.lbl_Telefono = new System.Windows.Forms.Label();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.txt_Colonia = new System.Windows.Forms.TextBox();
            this.lbl_Colonia = new System.Windows.Forms.Label();
            this.txt_Calle = new System.Windows.Forms.TextBox();
            this.lbl_Calle = new System.Windows.Forms.Label();
            this.lbl_Ciudad = new System.Windows.Forms.Label();
            this.txt_NumeroExt = new System.Windows.Forms.TextBox();
            this.lbl_Numero_Exterior = new System.Windows.Forms.Label();
            this.cmb_Ciudad = new System.Windows.Forms.ComboBox();
            this.mariscos_PepeDataSet = new Punto_de_Venta.Mariscos_PepeDataSet();
            this.enviosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enviosTableAdapter = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.EnviosTableAdapter();
            this.tableAdapterManager = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enviosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Telefono
            // 
            this.lbl_Telefono.AutoSize = true;
            this.lbl_Telefono.Location = new System.Drawing.Point(31, 54);
            this.lbl_Telefono.Name = "lbl_Telefono";
            this.lbl_Telefono.Size = new System.Drawing.Size(70, 18);
            this.lbl_Telefono.TabIndex = 0;
            this.lbl_Telefono.Text = "Telefono:";
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(159, 275);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(114, 51);
            this.btn_Agregar.TabIndex = 1;
            this.btn_Agregar.Text = "Registrar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Location = new System.Drawing.Point(107, 51);
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(166, 26);
            this.txt_Telefono.TabIndex = 2;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(105, 83);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(292, 26);
            this.txt_Nombre.TabIndex = 4;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Location = new System.Drawing.Point(31, 86);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(68, 18);
            this.lbl_Nombre.TabIndex = 3;
            this.lbl_Nombre.Text = "Nombre:";
            // 
            // txt_Colonia
            // 
            this.txt_Colonia.Location = new System.Drawing.Point(103, 147);
            this.txt_Colonia.Name = "txt_Colonia";
            this.txt_Colonia.Size = new System.Drawing.Size(294, 26);
            this.txt_Colonia.TabIndex = 8;
            // 
            // lbl_Colonia
            // 
            this.lbl_Colonia.AutoSize = true;
            this.lbl_Colonia.Location = new System.Drawing.Point(31, 150);
            this.lbl_Colonia.Name = "lbl_Colonia";
            this.lbl_Colonia.Size = new System.Drawing.Size(66, 18);
            this.lbl_Colonia.TabIndex = 7;
            this.lbl_Colonia.Text = "Colonia:";
            // 
            // txt_Calle
            // 
            this.txt_Calle.Location = new System.Drawing.Point(103, 115);
            this.txt_Calle.Name = "txt_Calle";
            this.txt_Calle.Size = new System.Drawing.Size(294, 26);
            this.txt_Calle.TabIndex = 6;
            // 
            // lbl_Calle
            // 
            this.lbl_Calle.AutoSize = true;
            this.lbl_Calle.Location = new System.Drawing.Point(31, 118);
            this.lbl_Calle.Name = "lbl_Calle";
            this.lbl_Calle.Size = new System.Drawing.Size(48, 18);
            this.lbl_Calle.TabIndex = 5;
            this.lbl_Calle.Text = "Calle:";
            // 
            // lbl_Ciudad
            // 
            this.lbl_Ciudad.AutoSize = true;
            this.lbl_Ciudad.Location = new System.Drawing.Point(31, 214);
            this.lbl_Ciudad.Name = "lbl_Ciudad";
            this.lbl_Ciudad.Size = new System.Drawing.Size(59, 18);
            this.lbl_Ciudad.TabIndex = 11;
            this.lbl_Ciudad.Text = "Ciudad";
            // 
            // txt_NumeroExt
            // 
            this.txt_NumeroExt.Location = new System.Drawing.Point(162, 179);
            this.txt_NumeroExt.Name = "txt_NumeroExt";
            this.txt_NumeroExt.Size = new System.Drawing.Size(235, 26);
            this.txt_NumeroExt.TabIndex = 10;
            // 
            // lbl_Numero_Exterior
            // 
            this.lbl_Numero_Exterior.AutoSize = true;
            this.lbl_Numero_Exterior.Location = new System.Drawing.Point(31, 182);
            this.lbl_Numero_Exterior.Name = "lbl_Numero_Exterior";
            this.lbl_Numero_Exterior.Size = new System.Drawing.Size(125, 18);
            this.lbl_Numero_Exterior.TabIndex = 9;
            this.lbl_Numero_Exterior.Text = "Numero Exterior:";
            // 
            // cmb_Ciudad
            // 
            this.cmb_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Ciudad.FormattingEnabled = true;
            this.cmb_Ciudad.Items.AddRange(new object[] {
            "Armeria",
            "Colima",
            "Comala",
            "Villa de Álvarez",
            "Coquimatlan",
            "Cuauhtémoc",
            "Ixtlahuacán",
            "Manzanillo",
            "Minatitlán",
            "Tecomán"});
            this.cmb_Ciudad.Location = new System.Drawing.Point(107, 211);
            this.cmb_Ciudad.Name = "cmb_Ciudad";
            this.cmb_Ciudad.Size = new System.Drawing.Size(139, 26);
            this.cmb_Ciudad.TabIndex = 12;
            // 
            // mariscos_PepeDataSet
            // 
            this.mariscos_PepeDataSet.DataSetName = "Mariscos_PepeDataSet";
            this.mariscos_PepeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // enviosBindingSource
            // 
            this.enviosBindingSource.DataMember = "Envios";
            this.enviosBindingSource.DataSource = this.mariscos_PepeDataSet;
            // 
            // enviosTableAdapter
            // 
            this.enviosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AdminTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EnviosTableAdapter = this.enviosTableAdapter;
            this.tableAdapterManager.FacturasTableAdapter = null;
            this.tableAdapterManager.MeserosTableAdapter = null;
            this.tableAdapterManager.ProductosTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frm_Registro_Envios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 433);
            this.Controls.Add(this.cmb_Ciudad);
            this.Controls.Add(this.lbl_Ciudad);
            this.Controls.Add(this.txt_NumeroExt);
            this.Controls.Add(this.lbl_Numero_Exterior);
            this.Controls.Add(this.txt_Colonia);
            this.Controls.Add(this.lbl_Colonia);
            this.Controls.Add(this.txt_Calle);
            this.Controls.Add(this.lbl_Calle);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.txt_Telefono);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.lbl_Telefono);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Registro_Envios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Telefono";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Registro_Envios_FormClosing);
            this.Load += new System.EventHandler(this.frm_Registro_Envios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enviosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Telefono;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_Colonia;
        private System.Windows.Forms.Label lbl_Colonia;
        private System.Windows.Forms.TextBox txt_Calle;
        private System.Windows.Forms.Label lbl_Calle;
        private System.Windows.Forms.Label lbl_Ciudad;
        private System.Windows.Forms.TextBox txt_NumeroExt;
        private System.Windows.Forms.Label lbl_Numero_Exterior;
        private System.Windows.Forms.ComboBox cmb_Ciudad;
        private Mariscos_PepeDataSet mariscos_PepeDataSet;
        private System.Windows.Forms.BindingSource enviosBindingSource;
        private Mariscos_PepeDataSetTableAdapters.EnviosTableAdapter enviosTableAdapter;
        private Mariscos_PepeDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        public System.Windows.Forms.TextBox txt_Telefono;
    }
}