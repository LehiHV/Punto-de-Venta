namespace Punto_de_Venta
{
    partial class frm_Edicion_Datos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Edicion_Datos));
            this.btn_atras = new System.Windows.Forms.Button();
            this.dgv_Tabla = new System.Windows.Forms.DataGridView();
            this.cmb_Tablas = new System.Windows.Forms.ComboBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Cambiar = new System.Windows.Forms.Button();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.mariscos_PepeDataSet = new Punto_de_Venta.Mariscos_PepeDataSet();
            this.mariscosPepeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasTableAdapter = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.FacturasTableAdapter();
            this.tableAdapterManager = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.TableAdapterManager();
            this.lbl_pago_empleados = new System.Windows.Forms.Label();
            this.txt_pago_Empleados = new System.Windows.Forms.TextBox();
            this.txt_pago_provedor = new System.Windows.Forms.TextBox();
            this.lbl_pago_provedor = new System.Windows.Forms.Label();
            this.btn_realizar_cambios = new System.Windows.Forms.Button();
            this.btn_agregar_telefono = new System.Windows.Forms.Button();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.lbl_Telefono = new System.Windows.Forms.Label();
            this.txt_Colonia = new System.Windows.Forms.TextBox();
            this.lbl_Colonia = new System.Windows.Forms.Label();
            this.txt_calle = new System.Windows.Forms.TextBox();
            this.lbl_Calle = new System.Windows.Forms.Label();
            this.lbl_Ciudad = new System.Windows.Forms.Label();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.lbl_Numero = new System.Windows.Forms.Label();
            this.cmb_ciudad = new System.Windows.Forms.ComboBox();
            this.btn_actualizar_telefono = new System.Windows.Forms.Button();
            this.txt_telefono_ref = new System.Windows.Forms.TextBox();
            this.lbl_telefono_ref = new System.Windows.Forms.Label();
            this.enviosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enviosTableAdapter = new Punto_de_Venta.Mariscos_PepeDataSetTableAdapters.EnviosTableAdapter();
            this.btn_eliminar_telefono = new System.Windows.Forms.Button();
            this.nud_dias = new System.Windows.Forms.NumericUpDown();
            this.lbl_dias = new System.Windows.Forms.Label();
            this.lbl_mes = new System.Windows.Forms.Label();
            this.nud_mes = new System.Windows.Forms.NumericUpDown();
            this.lbl_año = new System.Windows.Forms.Label();
            this.txt_año = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mariscosPepeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enviosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_atras
            // 
            this.btn_atras.AutoSize = true;
            this.btn_atras.Location = new System.Drawing.Point(12, 578);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(67, 33);
            this.btn_atras.TabIndex = 7;
            this.btn_atras.Text = "Atras";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // dgv_Tabla
            // 
            this.dgv_Tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Tabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tabla.Location = new System.Drawing.Point(12, 12);
            this.dgv_Tabla.Name = "dgv_Tabla";
            this.dgv_Tabla.Size = new System.Drawing.Size(748, 560);
            this.dgv_Tabla.TabIndex = 8;
            this.dgv_Tabla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tabla_CellClick);
            this.dgv_Tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgv_Tabla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Tabla_CellFormatting);
            this.dgv_Tabla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Tabla_DataError_1);
            // 
            // cmb_Tablas
            // 
            this.cmb_Tablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Tablas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Tablas.FormattingEnabled = true;
            this.cmb_Tablas.Items.AddRange(new object[] {
            "Admin",
            "Meseros",
            "Productos",
            "Envios",
            "Facturas"});
            this.cmb_Tablas.Location = new System.Drawing.Point(766, 12);
            this.cmb_Tablas.Name = "cmb_Tablas";
            this.cmb_Tablas.Size = new System.Drawing.Size(217, 26);
            this.cmb_Tablas.TabIndex = 9;
            this.cmb_Tablas.SelectedIndexChanged += new System.EventHandler(this.cmb_Tablas_SelectedIndexChanged);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Enabled = false;
            this.btn_Agregar.Location = new System.Drawing.Point(766, 524);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(175, 48);
            this.btn_Agregar.TabIndex = 11;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Visible = false;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Enabled = false;
            this.btn_Eliminar.Location = new System.Drawing.Point(766, 470);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(175, 48);
            this.btn_Eliminar.TabIndex = 13;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Visible = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Cambiar
            // 
            this.btn_Cambiar.Enabled = false;
            this.btn_Cambiar.Location = new System.Drawing.Point(1013, 470);
            this.btn_Cambiar.Name = "btn_Cambiar";
            this.btn_Cambiar.Size = new System.Drawing.Size(175, 48);
            this.btn_Cambiar.TabIndex = 14;
            this.btn_Cambiar.Text = "Cambiar";
            this.btn_Cambiar.UseVisualStyleBackColor = true;
            this.btn_Cambiar.Visible = false;
            this.btn_Cambiar.Click += new System.EventHandler(this.btn_Cambiar_Click);
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.Enabled = false;
            this.btn_confirmar.Location = new System.Drawing.Point(1013, 524);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(175, 48);
            this.btn_confirmar.TabIndex = 15;
            this.btn_confirmar.Text = "Confirmar";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Visible = false;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // mariscos_PepeDataSet
            // 
            this.mariscos_PepeDataSet.DataSetName = "Mariscos_PepeDataSet";
            this.mariscos_PepeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mariscosPepeDataSetBindingSource
            // 
            this.mariscosPepeDataSetBindingSource.DataSource = this.mariscos_PepeDataSet;
            this.mariscosPepeDataSetBindingSource.Position = 0;
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
            // lbl_pago_empleados
            // 
            this.lbl_pago_empleados.AutoSize = true;
            this.lbl_pago_empleados.Location = new System.Drawing.Point(822, 443);
            this.lbl_pago_empleados.Name = "lbl_pago_empleados";
            this.lbl_pago_empleados.Size = new System.Drawing.Size(130, 18);
            this.lbl_pago_empleados.TabIndex = 16;
            this.lbl_pago_empleados.Text = "Pago Empleados";
            this.lbl_pago_empleados.Visible = false;
            // 
            // txt_pago_Empleados
            // 
            this.txt_pago_Empleados.Location = new System.Drawing.Point(825, 464);
            this.txt_pago_Empleados.Name = "txt_pago_Empleados";
            this.txt_pago_Empleados.Size = new System.Drawing.Size(127, 26);
            this.txt_pago_Empleados.TabIndex = 17;
            this.txt_pago_Empleados.Visible = false;
            // 
            // txt_pago_provedor
            // 
            this.txt_pago_provedor.Location = new System.Drawing.Point(982, 464);
            this.txt_pago_provedor.Name = "txt_pago_provedor";
            this.txt_pago_provedor.Size = new System.Drawing.Size(111, 26);
            this.txt_pago_provedor.TabIndex = 19;
            this.txt_pago_provedor.Visible = false;
            // 
            // lbl_pago_provedor
            // 
            this.lbl_pago_provedor.AutoSize = true;
            this.lbl_pago_provedor.Location = new System.Drawing.Point(979, 443);
            this.lbl_pago_provedor.Name = "lbl_pago_provedor";
            this.lbl_pago_provedor.Size = new System.Drawing.Size(114, 18);
            this.lbl_pago_provedor.TabIndex = 18;
            this.lbl_pago_provedor.Text = "Pago Provedor";
            this.lbl_pago_provedor.Visible = false;
            // 
            // btn_realizar_cambios
            // 
            this.btn_realizar_cambios.Enabled = false;
            this.btn_realizar_cambios.Location = new System.Drawing.Point(886, 496);
            this.btn_realizar_cambios.Name = "btn_realizar_cambios";
            this.btn_realizar_cambios.Size = new System.Drawing.Size(175, 48);
            this.btn_realizar_cambios.TabIndex = 20;
            this.btn_realizar_cambios.Text = "Realizar Pagos";
            this.btn_realizar_cambios.UseVisualStyleBackColor = true;
            this.btn_realizar_cambios.Visible = false;
            this.btn_realizar_cambios.Click += new System.EventHandler(this.btn_realizar_cambios_Click);
            // 
            // btn_agregar_telefono
            // 
            this.btn_agregar_telefono.Enabled = false;
            this.btn_agregar_telefono.Location = new System.Drawing.Point(933, 163);
            this.btn_agregar_telefono.Name = "btn_agregar_telefono";
            this.btn_agregar_telefono.Size = new System.Drawing.Size(175, 48);
            this.btn_agregar_telefono.TabIndex = 25;
            this.btn_agregar_telefono.Text = "Agregar";
            this.btn_agregar_telefono.UseVisualStyleBackColor = true;
            this.btn_agregar_telefono.Visible = false;
            this.btn_agregar_telefono.Click += new System.EventHandler(this.btn_agregar_telefono_Click);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(769, 199);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(127, 26);
            this.txt_Nombre.TabIndex = 24;
            this.txt_Nombre.Visible = false;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Location = new System.Drawing.Point(766, 178);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(64, 18);
            this.lbl_Nombre.TabIndex = 23;
            this.lbl_Nombre.Text = "Nombre";
            this.lbl_Nombre.Visible = false;
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Location = new System.Drawing.Point(769, 149);
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(127, 26);
            this.txt_Telefono.TabIndex = 22;
            this.txt_Telefono.Visible = false;
            // 
            // lbl_Telefono
            // 
            this.lbl_Telefono.AutoSize = true;
            this.lbl_Telefono.Location = new System.Drawing.Point(766, 128);
            this.lbl_Telefono.Name = "lbl_Telefono";
            this.lbl_Telefono.Size = new System.Drawing.Size(66, 18);
            this.lbl_Telefono.TabIndex = 21;
            this.lbl_Telefono.Text = "Telefono";
            this.lbl_Telefono.Visible = false;
            // 
            // txt_Colonia
            // 
            this.txt_Colonia.Location = new System.Drawing.Point(769, 299);
            this.txt_Colonia.Name = "txt_Colonia";
            this.txt_Colonia.Size = new System.Drawing.Size(127, 26);
            this.txt_Colonia.TabIndex = 29;
            this.txt_Colonia.Visible = false;
            // 
            // lbl_Colonia
            // 
            this.lbl_Colonia.AutoSize = true;
            this.lbl_Colonia.Location = new System.Drawing.Point(766, 278);
            this.lbl_Colonia.Name = "lbl_Colonia";
            this.lbl_Colonia.Size = new System.Drawing.Size(62, 18);
            this.lbl_Colonia.TabIndex = 28;
            this.lbl_Colonia.Text = "Colonia";
            this.lbl_Colonia.Visible = false;
            // 
            // txt_calle
            // 
            this.txt_calle.Location = new System.Drawing.Point(769, 249);
            this.txt_calle.Name = "txt_calle";
            this.txt_calle.Size = new System.Drawing.Size(127, 26);
            this.txt_calle.TabIndex = 27;
            this.txt_calle.Visible = false;
            // 
            // lbl_Calle
            // 
            this.lbl_Calle.AutoSize = true;
            this.lbl_Calle.Location = new System.Drawing.Point(766, 228);
            this.lbl_Calle.Name = "lbl_Calle";
            this.lbl_Calle.Size = new System.Drawing.Size(44, 18);
            this.lbl_Calle.TabIndex = 26;
            this.lbl_Calle.Text = "Calle";
            this.lbl_Calle.Visible = false;
            // 
            // lbl_Ciudad
            // 
            this.lbl_Ciudad.AutoSize = true;
            this.lbl_Ciudad.Location = new System.Drawing.Point(763, 378);
            this.lbl_Ciudad.Name = "lbl_Ciudad";
            this.lbl_Ciudad.Size = new System.Drawing.Size(59, 18);
            this.lbl_Ciudad.TabIndex = 32;
            this.lbl_Ciudad.Text = "Ciudad";
            this.lbl_Ciudad.Visible = false;
            // 
            // txt_Numero
            // 
            this.txt_Numero.Location = new System.Drawing.Point(766, 349);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(127, 26);
            this.txt_Numero.TabIndex = 31;
            this.txt_Numero.Visible = false;
            // 
            // lbl_Numero
            // 
            this.lbl_Numero.AutoSize = true;
            this.lbl_Numero.Location = new System.Drawing.Point(763, 328);
            this.lbl_Numero.Name = "lbl_Numero";
            this.lbl_Numero.Size = new System.Drawing.Size(121, 18);
            this.lbl_Numero.TabIndex = 30;
            this.lbl_Numero.Text = "Numero Exterior";
            this.lbl_Numero.Visible = false;
            // 
            // cmb_ciudad
            // 
            this.cmb_ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ciudad.FormattingEnabled = true;
            this.cmb_ciudad.Items.AddRange(new object[] {
            "Villa de Álvarez",
            "Colima",
            "Armeria",
            "Comala",
            "Coquimatlán",
            "Cuauhtémoc",
            "Ixtlahuacán",
            "Manzanillo",
            "Minatitlán",
            "Tecomán"});
            this.cmb_ciudad.Location = new System.Drawing.Point(766, 399);
            this.cmb_ciudad.Name = "cmb_ciudad";
            this.cmb_ciudad.Size = new System.Drawing.Size(130, 26);
            this.cmb_ciudad.TabIndex = 33;
            // 
            // btn_actualizar_telefono
            // 
            this.btn_actualizar_telefono.Enabled = false;
            this.btn_actualizar_telefono.Location = new System.Drawing.Point(933, 327);
            this.btn_actualizar_telefono.Name = "btn_actualizar_telefono";
            this.btn_actualizar_telefono.Size = new System.Drawing.Size(175, 48);
            this.btn_actualizar_telefono.TabIndex = 34;
            this.btn_actualizar_telefono.Text = "Actualizar";
            this.btn_actualizar_telefono.UseVisualStyleBackColor = true;
            this.btn_actualizar_telefono.Visible = false;
            this.btn_actualizar_telefono.Click += new System.EventHandler(this.btn_actualizar_telefono_Click);
            // 
            // txt_telefono_ref
            // 
            this.txt_telefono_ref.Location = new System.Drawing.Point(966, 399);
            this.txt_telefono_ref.Name = "txt_telefono_ref";
            this.txt_telefono_ref.Size = new System.Drawing.Size(127, 26);
            this.txt_telefono_ref.TabIndex = 36;
            this.txt_telefono_ref.Visible = false;
            // 
            // lbl_telefono_ref
            // 
            this.lbl_telefono_ref.AutoSize = true;
            this.lbl_telefono_ref.Location = new System.Drawing.Point(963, 378);
            this.lbl_telefono_ref.Name = "lbl_telefono_ref";
            this.lbl_telefono_ref.Size = new System.Drawing.Size(70, 18);
            this.lbl_telefono_ref.TabIndex = 35;
            this.lbl_telefono_ref.Text = "Telefono:";
            this.lbl_telefono_ref.Visible = false;
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
            // btn_eliminar_telefono
            // 
            this.btn_eliminar_telefono.Enabled = false;
            this.btn_eliminar_telefono.Location = new System.Drawing.Point(933, 249);
            this.btn_eliminar_telefono.Name = "btn_eliminar_telefono";
            this.btn_eliminar_telefono.Size = new System.Drawing.Size(175, 48);
            this.btn_eliminar_telefono.TabIndex = 37;
            this.btn_eliminar_telefono.Text = "Eliminar";
            this.btn_eliminar_telefono.UseVisualStyleBackColor = true;
            this.btn_eliminar_telefono.Visible = false;
            this.btn_eliminar_telefono.Click += new System.EventHandler(this.btn_eliminar_telefono_Click);
            // 
            // nud_dias
            // 
            this.nud_dias.Location = new System.Drawing.Point(842, 90);
            this.nud_dias.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nud_dias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dias.Name = "nud_dias";
            this.nud_dias.Size = new System.Drawing.Size(63, 26);
            this.nud_dias.TabIndex = 38;
            this.nud_dias.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dias.Visible = false;
            // 
            // lbl_dias
            // 
            this.lbl_dias.AutoSize = true;
            this.lbl_dias.Location = new System.Drawing.Point(839, 69);
            this.lbl_dias.Name = "lbl_dias";
            this.lbl_dias.Size = new System.Drawing.Size(37, 18);
            this.lbl_dias.TabIndex = 39;
            this.lbl_dias.Text = "Dia:";
            this.lbl_dias.Visible = false;
            // 
            // lbl_mes
            // 
            this.lbl_mes.AutoSize = true;
            this.lbl_mes.Location = new System.Drawing.Point(917, 69);
            this.lbl_mes.Name = "lbl_mes";
            this.lbl_mes.Size = new System.Drawing.Size(42, 18);
            this.lbl_mes.TabIndex = 41;
            this.lbl_mes.Text = "Mes:";
            this.lbl_mes.Visible = false;
            // 
            // nud_mes
            // 
            this.nud_mes.Location = new System.Drawing.Point(920, 90);
            this.nud_mes.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nud_mes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_mes.Name = "nud_mes";
            this.nud_mes.Size = new System.Drawing.Size(63, 26);
            this.nud_mes.TabIndex = 40;
            this.nud_mes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_mes.Visible = false;
            // 
            // lbl_año
            // 
            this.lbl_año.AutoSize = true;
            this.lbl_año.Location = new System.Drawing.Point(991, 69);
            this.lbl_año.Name = "lbl_año";
            this.lbl_año.Size = new System.Drawing.Size(40, 18);
            this.lbl_año.TabIndex = 42;
            this.lbl_año.Text = "Año:";
            this.lbl_año.Visible = false;
            // 
            // txt_año
            // 
            this.txt_año.Location = new System.Drawing.Point(994, 90);
            this.txt_año.Name = "txt_año";
            this.txt_año.Size = new System.Drawing.Size(67, 26);
            this.txt_año.TabIndex = 43;
            this.txt_año.Visible = false;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Enabled = false;
            this.btn_buscar.Location = new System.Drawing.Point(1076, 90);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(120, 26);
            this.btn_buscar.TabIndex = 44;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Visible = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // frm_Edicion_Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1208, 631);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_año);
            this.Controls.Add(this.lbl_año);
            this.Controls.Add(this.lbl_mes);
            this.Controls.Add(this.nud_mes);
            this.Controls.Add(this.lbl_dias);
            this.Controls.Add(this.nud_dias);
            this.Controls.Add(this.btn_eliminar_telefono);
            this.Controls.Add(this.txt_telefono_ref);
            this.Controls.Add(this.lbl_telefono_ref);
            this.Controls.Add(this.btn_actualizar_telefono);
            this.Controls.Add(this.cmb_ciudad);
            this.Controls.Add(this.lbl_Ciudad);
            this.Controls.Add(this.txt_Numero);
            this.Controls.Add(this.lbl_Numero);
            this.Controls.Add(this.txt_Colonia);
            this.Controls.Add(this.lbl_Colonia);
            this.Controls.Add(this.txt_calle);
            this.Controls.Add(this.lbl_Calle);
            this.Controls.Add(this.btn_agregar_telefono);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.txt_Telefono);
            this.Controls.Add(this.lbl_Telefono);
            this.Controls.Add(this.btn_realizar_cambios);
            this.Controls.Add(this.txt_pago_provedor);
            this.Controls.Add(this.lbl_pago_provedor);
            this.Controls.Add(this.txt_pago_Empleados);
            this.Controls.Add(this.lbl_pago_empleados);
            this.Controls.Add(this.btn_confirmar);
            this.Controls.Add(this.btn_Cambiar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.cmb_Tablas);
            this.Controls.Add(this.dgv_Tabla);
            this.Controls.Add(this.btn_atras);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Edicion_Datos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablas-Mariscos Pepe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Edicion_Datos_FormClosing);
            this.Load += new System.EventHandler(this.frm_Edicion_Datos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mariscos_PepeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mariscosPepeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enviosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.DataGridView dgv_Tabla;
        private System.Windows.Forms.BindingSource mariscosPepeDataSetBindingSource;
        private Mariscos_PepeDataSet mariscos_PepeDataSet;
        private System.Windows.Forms.ComboBox cmb_Tablas;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Cambiar;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.BindingSource facturasBindingSource;
        private Mariscos_PepeDataSetTableAdapters.FacturasTableAdapter facturasTableAdapter;
        private Mariscos_PepeDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label lbl_pago_empleados;
        private System.Windows.Forms.TextBox txt_pago_Empleados;
        private System.Windows.Forms.TextBox txt_pago_provedor;
        private System.Windows.Forms.Label lbl_pago_provedor;
        private System.Windows.Forms.Button btn_realizar_cambios;
        private System.Windows.Forms.Button btn_agregar_telefono;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.Label lbl_Telefono;
        private System.Windows.Forms.TextBox txt_Colonia;
        private System.Windows.Forms.Label lbl_Colonia;
        private System.Windows.Forms.TextBox txt_calle;
        private System.Windows.Forms.Label lbl_Calle;
        private System.Windows.Forms.Label lbl_Ciudad;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.Label lbl_Numero;
        private System.Windows.Forms.ComboBox cmb_ciudad;
        private System.Windows.Forms.Button btn_actualizar_telefono;
        private System.Windows.Forms.TextBox txt_telefono_ref;
        private System.Windows.Forms.Label lbl_telefono_ref;
        private System.Windows.Forms.BindingSource enviosBindingSource;
        private Mariscos_PepeDataSetTableAdapters.EnviosTableAdapter enviosTableAdapter;
        private System.Windows.Forms.Button btn_eliminar_telefono;
        private System.Windows.Forms.NumericUpDown nud_dias;
        private System.Windows.Forms.Label lbl_dias;
        private System.Windows.Forms.Label lbl_mes;
        private System.Windows.Forms.NumericUpDown nud_mes;
        private System.Windows.Forms.Label lbl_año;
        private System.Windows.Forms.TextBox txt_año;
        private System.Windows.Forms.Button btn_buscar;
    }
}