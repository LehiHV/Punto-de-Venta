using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static Punto_de_Venta.frm_Menu_Principal;

namespace Punto_de_Venta
{
    public partial class frm_Edicion_Datos : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        String fecha = Convert.ToString(DateTime.Now).Substring(0, 10);
        public frm_Edicion_Datos()
        {
            InitializeComponent();
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere Salir?", "Salir del Tabla de Datos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frm_Menu_Principal mp = new frm_Menu_Principal();
                mp.Show();
                this.Hide();
            }
        }

        private void frm_Edicion_Datos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mariscos_PepeDataSet.Envios' Puede moverla o quitarla según sea necesario.
            this.enviosTableAdapter.Fill(this.mariscos_PepeDataSet.Envios);
            cmb_Tablas.SelectedIndex = 0;
            cmb_ciudad.SelectedIndex = 0;
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }
            dgv_Tabla.AllowUserToAddRows = false;
            dgv_Tabla.AllowUserToDeleteRows = false;
            dgv_Tabla.ReadOnly = true;
        }

        private void frm_Edicion_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cmb_Tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_Tablas.SelectedIndex)
            {
                case 0:
                    btn_Agregar.Enabled = true;
                    btn_Cambiar.Enabled = true;
                    btn_Eliminar.Enabled = true;

                    btn_Agregar.Visible = true;
                    btn_Cambiar.Visible = true;
                    btn_Eliminar.Visible = true;

                    lbl_pago_empleados.Visible = false;
                    lbl_pago_provedor.Visible = false;
                    txt_pago_Empleados.Visible = false;
                    txt_pago_provedor.Visible = false;
                    btn_realizar_cambios.Visible = false;
                    btn_realizar_cambios.Enabled = false;

                    lbl_Telefono.Visible = false;
                    lbl_Nombre.Visible = false;
                    lbl_Calle.Visible = false;
                    lbl_Colonia.Visible = false;
                    lbl_Numero.Visible = false;
                    lbl_Ciudad.Visible = false;
                    lbl_telefono_ref.Visible = false;
                    txt_Telefono.Visible = false;
                    txt_Nombre.Visible = false;
                    txt_calle.Visible = false;
                    txt_Colonia.Visible = false;
                    txt_Numero.Visible = false;
                    cmb_ciudad.Visible = false;
                    txt_telefono_ref.Visible = false;
                    btn_actualizar_telefono.Visible = false;
                    btn_agregar_telefono.Visible = false;
                    btn_agregar_telefono.Enabled = false;
                    btn_actualizar_telefono.Enabled = false;

                    txt_Telefono.Text = string.Empty;
                    txt_Nombre.Text = string.Empty;
                    txt_calle.Text = string.Empty;
                    txt_Colonia.Text = string.Empty;
                    txt_Numero.Text = string.Empty;
                    btn_eliminar_telefono.Visible = false;
                    btn_eliminar_telefono.Enabled = false;
                    txt_telefono_ref.Text=string.Empty;
                    lbl_año.Visible = false;
                    lbl_dias.Visible = false;
                    lbl_mes.Visible = false;
                    btn_buscar.Visible = false;
                    txt_año.Visible = false;
                    nud_dias.Visible = false;
                    nud_mes.Visible = false;
                    nud_dias.Value = 1;
                    nud_mes.Value = 1;
                    txt_año.Text = string.Empty;

                    OleDbDataAdapter ada = new OleDbDataAdapter();
                    DataTable tabla = new DataTable();
                    ada.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    ada.Fill(tabla);
                    dgv_Tabla.DataSource = tabla;

                    break;
                case 1:

                    btn_Agregar.Enabled = true;
                    btn_Cambiar.Enabled = true;
                    btn_Eliminar.Enabled = true;

                    btn_Agregar.Visible = true;
                    btn_Cambiar.Visible = true;
                    btn_Eliminar.Visible = true;

                    lbl_pago_empleados.Visible = false;
                    lbl_pago_provedor.Visible = false;
                    txt_pago_Empleados.Visible = false;
                    txt_pago_provedor.Visible = false;
                    btn_realizar_cambios.Visible = false;
                    btn_realizar_cambios.Enabled = false;

                    lbl_Telefono.Visible = false;
                    lbl_Nombre.Visible = false;
                    lbl_Calle.Visible = false;
                    lbl_Colonia.Visible = false;
                    lbl_Numero.Visible = false;
                    lbl_Ciudad.Visible = false;
                    lbl_telefono_ref.Visible = false;
                    txt_Telefono.Visible = false;
                    txt_Nombre.Visible = false;
                    txt_calle.Visible = false;
                    txt_Colonia.Visible = false;
                    txt_Numero.Visible = false;
                    cmb_ciudad.Visible = false;
                    txt_telefono_ref.Visible = false;
                    btn_actualizar_telefono.Visible = false;
                    btn_agregar_telefono.Visible = false;
                    btn_agregar_telefono.Enabled = false;
                    btn_actualizar_telefono.Enabled = false;
                    txt_Telefono.Text = string.Empty;
                    txt_Nombre.Text = string.Empty;
                    txt_calle.Text = string.Empty;
                    txt_Colonia.Text = string.Empty;
                    txt_Numero.Text = string.Empty;
                    btn_eliminar_telefono.Visible = false;
                    btn_eliminar_telefono.Enabled = false;
                    txt_telefono_ref.Text = string.Empty;
                    lbl_año.Visible = false;
                    lbl_dias.Visible = false;
                    lbl_mes.Visible = false;
                    btn_buscar.Visible = false;
                    txt_año.Visible = false;
                    nud_dias.Visible = false;
                    nud_mes.Visible = false;
                    nud_dias.Value = 1;
                    nud_mes.Value = 1;
                    txt_año.Text = string.Empty;

                    OleDbDataAdapter ada1 = new OleDbDataAdapter();
                    DataTable tabla1 = new DataTable();
                    ada1.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    ada1.Fill(tabla1);
                    dgv_Tabla.DataSource = tabla1;

                    break;
                case 2:

                    btn_Agregar.Visible = false;
                    btn_Cambiar.Visible = true;
                    btn_Cambiar.Enabled = true;
                    btn_Eliminar.Visible = false;

                    lbl_pago_empleados.Visible = false;
                    lbl_pago_provedor.Visible = false;
                    txt_pago_Empleados.Visible = false;
                    txt_pago_provedor.Visible = false;
                    btn_realizar_cambios.Visible = false;
                    btn_realizar_cambios.Enabled = false;

                    lbl_Telefono.Visible = false;
                    lbl_Nombre.Visible = false;
                    lbl_Calle.Visible = false;
                    lbl_Colonia.Visible = false;
                    lbl_Numero.Visible = false;
                    lbl_Ciudad.Visible = false;
                    lbl_telefono_ref.Visible = false;
                    txt_Telefono.Visible = false;
                    txt_Nombre.Visible = false;
                    txt_calle.Visible = false;
                    txt_Colonia.Visible = false;
                    txt_Numero.Visible = false;
                    cmb_ciudad.Visible = false;
                    txt_telefono_ref.Visible = false;
                    btn_actualizar_telefono.Visible = false;
                    btn_agregar_telefono.Visible = false;
                    btn_agregar_telefono.Enabled = false;
                    btn_actualizar_telefono.Enabled = false;
                    txt_Telefono.Text = string.Empty;
                    txt_Nombre.Text = string.Empty;
                    txt_calle.Text = string.Empty;
                    txt_Colonia.Text = string.Empty;
                    txt_Numero.Text = string.Empty;
                    btn_eliminar_telefono.Visible = false;
                    btn_eliminar_telefono.Enabled = false;
                    txt_telefono_ref.Text = string.Empty;
                    lbl_año.Visible = false;
                    lbl_dias.Visible = false;
                    lbl_mes.Visible = false;
                    btn_buscar.Visible = false;
                    txt_año.Visible = false;
                    nud_dias.Visible = false;
                    nud_mes.Visible = false;
                    nud_dias.Value = 1;
                    nud_mes.Value = 1;
                    txt_año.Text = string.Empty;


                    OleDbDataAdapter ada2 = new OleDbDataAdapter();
                    DataTable tabla2 = new DataTable();
                    ada2.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    ada2.Fill(tabla2);
                    dgv_Tabla.DataSource = tabla2;

                    break;
                case 3:
                    btn_Cambiar.Visible = false;
                    btn_Agregar.Visible = false;
                    btn_Eliminar.Visible = false;

                    lbl_pago_empleados.Visible = false;
                    lbl_pago_provedor.Visible = false;
                    txt_pago_Empleados.Visible = false;
                    txt_pago_provedor.Visible = false;
                    btn_realizar_cambios.Visible = false;
                    btn_realizar_cambios.Enabled = false;

                    lbl_Telefono.Visible = true;
                    lbl_Nombre.Visible = true;
                    lbl_Calle.Visible=true;
                    lbl_Colonia.Visible=true;
                    lbl_Numero.Visible=true;
                    lbl_Ciudad.Visible  =true;
                    lbl_telefono_ref.Visible = true;
                    txt_Telefono.Visible=true;
                    txt_Nombre.Visible  =true;
                    txt_calle.Visible=true;
                    txt_Colonia.Visible=true;
                    txt_Numero.Visible =true;
                    cmb_ciudad.Visible=true;
                    txt_telefono_ref.Visible=true;
                    btn_actualizar_telefono.Visible=true;
                    btn_agregar_telefono.Visible = true;
                    btn_agregar_telefono.Enabled=true;
                    btn_actualizar_telefono.Enabled = true;
                    btn_eliminar_telefono.Visible = true;
                    btn_eliminar_telefono.Enabled = true;

                    lbl_año.Visible = false;
                    lbl_dias.Visible = false;
                    lbl_mes.Visible = false;
                    btn_buscar.Visible = false;
                    txt_año.Visible = false;
                    nud_dias.Visible = false;
                    nud_mes.Visible = false;
                    nud_dias.Value = 1;
                    nud_mes.Value=1;
                    txt_año.Text=string.Empty;

                    OleDbDataAdapter ada3 = new OleDbDataAdapter();
                    DataTable tabla3 = new DataTable();
                    ada3.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    ada3.Fill(tabla3);
                    dgv_Tabla.DataSource = tabla3;
                    break;
                case 4:
                    btn_Cambiar.Visible = false;
                    btn_Agregar.Visible = false;
                    btn_Eliminar.Visible = false;

                    lbl_pago_empleados.Visible = true;
                    lbl_pago_provedor.Visible = true;
                    txt_pago_Empleados.Visible = true;
                    txt_pago_provedor.Visible = true;
                    btn_realizar_cambios.Visible = true;
                    btn_realizar_cambios.Enabled    = true;

                    lbl_Telefono.Visible = false;
                    lbl_Nombre.Visible = false;
                    lbl_Calle.Visible = false;
                    lbl_Colonia.Visible = false;
                    lbl_Numero.Visible = false;
                    lbl_Ciudad.Visible = false;
                    lbl_telefono_ref.Visible = false;
                    txt_Telefono.Visible = false;
                    txt_Nombre.Visible = false;
                    txt_calle.Visible = false;
                    txt_Colonia.Visible = false;
                    txt_Numero.Visible = false;
                    cmb_ciudad.Visible = false;
                    txt_telefono_ref.Visible = false;
                    btn_actualizar_telefono.Visible = false;
                    btn_agregar_telefono.Visible = false;
                    btn_agregar_telefono.Enabled = false;
                    btn_actualizar_telefono.Enabled = false;
                    txt_Telefono.Text = string.Empty;
                    txt_Nombre.Text = string.Empty;
                    txt_calle.Text = string.Empty;
                    txt_Colonia.Text = string.Empty;
                    txt_Numero.Text = string.Empty;
                    btn_eliminar_telefono.Visible = false;
                    btn_eliminar_telefono.Enabled = false;
                    txt_telefono_ref.Text = string.Empty;

                    lbl_año.Visible = true;
                    lbl_dias.Visible = true;
                    lbl_mes.Visible = true;
                    btn_buscar.Visible = true;
                    txt_año.Visible=true;
                    nud_dias.Visible = true;
                    nud_mes.Visible =true;
                    btn_buscar.Enabled = true;

                    OleDbDataAdapter ada4 = new OleDbDataAdapter();
                    DataTable tabla4 = new DataTable();
                    ada4.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    ada4.Fill(tabla4);
                    dgv_Tabla.DataSource = tabla4;
                    this.facturasTableAdapter.UpdateTotal(Convert.ToInt32(new OleDbCommand("Select Caja From Facturas Where Fecha='" + fecha + "'", conexion).ExecuteScalar()), fecha);
                    int Total = Convert.ToInt32(new OleDbCommand("Select Total From Facturas Where Fecha='" + fecha + "'", conexion).ExecuteScalar());
                    int Empleados = Convert.ToInt32(new OleDbCommand("Select Pago_a_Empleados From Facturas Where Fecha='" + fecha + "'", conexion).ExecuteScalar());
                    int Provedores = Convert.ToInt32(new OleDbCommand("Select Pago_Provedores From Facturas Where Fecha='" + fecha + "'", conexion).ExecuteScalar());
                    this.facturasTableAdapter.UpdateTotal_Neto(Total - (Empleados + Provedores), fecha);
                    break;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Tabla.CurrentCell.ColumnIndex.ToString() == "2")
            {

                MessageBox.Show("Campo no valido, porfavor Seleccionar otro campo", "Eliminar");
            }
            else
            {
                if (MessageBox.Show("¿Esta Seguro de querer Eliminar este Administrador?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    switch (dgv_Tabla.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            OleDbDataReader exe = (new OleDbCommand("DELETE FROM " + cmb_Tablas.Text + " Where Id = " + (dgv_Tabla.CurrentCell.Value).ToString(), conexion)).ExecuteReader();
                            MessageBox.Show("Se ha Eliminado el usuario", "Eliminar");
                            
                            break;
                        case 1:
                            OleDbDataReader exec = (new OleDbCommand("DELETE FROM " + cmb_Tablas.Text + " Where Usuario = '" + (dgv_Tabla.CurrentCell.Value).ToString()+"'", conexion)).ExecuteReader();
                            MessageBox.Show("Se ha Eliminado el usuario", "Eliminar");
                            break;
                    }
                    OleDbDataAdapter adap = new OleDbDataAdapter();
                    DataTable table = new DataTable();
                    adap.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    adap.Fill(table);
                    dgv_Tabla.DataSource = table;

                }
            }
        }
        frm_Registro_Admin ra = new frm_Registro_Admin();
        frm_Registro_Usuario ru = new frm_Registro_Usuario();
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            switch (cmb_Tablas.SelectedIndex)
            {
                case 0:
                    ra.Show();
                    this.Hide();
                    break;
                case 1:
                    ru.Show();
                    this.Hide();
                    break;
            }
        }

        private void btn_Cambiar_Click(object sender, EventArgs e)
        {
            dgv_Tabla.ReadOnly = false;
            btn_confirmar.Visible = true;
            btn_confirmar.Enabled = true;
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            switch (cmb_Tablas.SelectedIndex)
            {
                case 0:
                    switch (dgv_Tabla.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            MessageBox.Show("No Puedes Cambiar el Id, Solo otros campos", "Cambios");
                            break;
                        case 1:
                            OleDbDataReader exec = (new OleDbCommand("UPDATE Admin SET Usuario='" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "',Contraseña = '" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex+1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "' WHERE Id="+ (dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 1, dgv_Tabla.CurrentCell.RowIndex]).Value, conexion)).ExecuteReader();
                            MessageBox.Show("Cambios Realizacos", "Cambios");
                            break;
                        case 2:
                            OleDbDataReader exe = (new OleDbCommand("UPDATE Admin SET Usuario='" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex-1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "',Contraseña = '" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "' WHERE Id=" + (dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 2, dgv_Tabla.CurrentCell.RowIndex]).Value, conexion)).ExecuteReader();
                            MessageBox.Show("Cambios Realizacos", "Cambios");
                            break;

                    }
                    break;
                case 1:
                    switch (dgv_Tabla.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            MessageBox.Show("No Puedes Cambiar el Id, Solo otros campos", "Cambios");
                            break;
                        case 1:
                            OleDbDataReader exec = (new OleDbCommand("UPDATE Meseros SET Usuario='" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "',Contraseña = '" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "' WHERE Id=" + (dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 1, dgv_Tabla.CurrentCell.RowIndex]).Value, conexion)).ExecuteReader();
                            MessageBox.Show("Cambios Realizacos", "Cambios");
                            break;
                        case 2:
                            OleDbDataReader exe = (new OleDbCommand("UPDATE Meseros SET Usuario='" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "',Contraseña = '" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "' WHERE Id=" + (dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 2, dgv_Tabla.CurrentCell.RowIndex]).Value, conexion)).ExecuteReader();
                            MessageBox.Show("Cambios Realizacos", "Cambios");
                            break;

                    }
                    break;
                case 2:

                    switch (dgv_Tabla.CurrentCell.ColumnIndex)
                    {
                        case 2:
                            OleDbDataReader exe = (new OleDbCommand("UPDATE Productos SET Nombre='" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() +"', Precio = "+ dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + " WHERE Id=" + (dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 2, dgv_Tabla.CurrentCell.RowIndex]).Value, conexion)).ExecuteReader();
                            MessageBox.Show("Cambios Realizacos", "Cambios");
                            break;
                        case 3:
                                OleDbDataReader exe2 = (new OleDbCommand("UPDATE Productos SET Nombre='" + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + "', Precio = " + dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString() + " WHERE Id=" + (dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 3, dgv_Tabla.CurrentCell.RowIndex]).Value, conexion)).ExecuteReader();
                                MessageBox.Show("Cambios Realizacos", "Cambios");
                            break;
                        default:
                            MessageBox.Show("Solo se peude Cambiar el Nombre y Precio de los Productos", "Cambios");
                            break;

                    }

                    break;
            }

            OleDbDataAdapter ada = new OleDbDataAdapter();
            DataTable tabla = new DataTable();
            ada.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
            ada.Fill(tabla);
            dgv_Tabla.DataSource = tabla;

            btn_confirmar.Enabled = false;
            btn_confirmar.Visible=false;
            dgv_Tabla.ReadOnly = true;
        }

        private void Dgv_Tabla_DataError1(object sender, DataGridViewDataErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Dgv_Tabla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgv_Tabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgv_Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_realizar_cambios_Click(object sender, EventArgs e)
        {
            OleDbCommand em = new OleDbCommand("Select Pago_a_Empleados From Facturas Where Fecha='"+fecha+"'",conexion);
            OleDbCommand pro = new OleDbCommand("Select Pago_Provedores From Facturas Where Fecha='"+fecha+"'",conexion);
            OleDbCommand Total_Neto = new OleDbCommand("Select Total_Neto From Facturas Where Fecha='" + fecha + "'", conexion);
            dgv_Tabla.DataSource = "";
            if (MessageBox.Show("¿Esta Seguro de realizar estos Cambios?","Realizar Cambios", MessageBoxButtons.YesNo) == DialogResult.Yes){
                if (txt_pago_Empleados.Text != string.Empty && txt_pago_provedor.Text == string.Empty)
                {
                    OleDbCommand emac = new OleDbCommand("Update Facturas SET Pago_a_Empleados=" + Convert.ToInt32(txt_pago_Empleados.Text) + " Where Fecha='" + fecha + "'", conexion);
                    OleDbCommand proac = new OleDbCommand("Update Facturas SET Pago_Provedores=" + Convert.ToInt32(txt_pago_provedor.Text) + " Where Fecha='" + fecha + "'", conexion);
                    emac.ExecuteScalar();
                    proac.ExecuteScalar();
                    MessageBox.Show("Se a cambiado el Pago a Empleados a :" + txt_pago_Empleados.Text, "Pago a Empleados");
                }
                if (txt_pago_provedor.Text != string.Empty && txt_pago_Empleados.Text == string.Empty)
                {
                    OleDbCommand emac = new OleDbCommand("Update Facturas SET Pago_a_Empleados=" + Convert.ToInt32(txt_pago_Empleados.Text) + " Where Fecha='" + fecha + "'", conexion);
                    OleDbCommand proac = new OleDbCommand("Update Facturas SET Pago_Provedores=" + Convert.ToInt32(txt_pago_provedor.Text) + " Where Fecha='" + fecha + "'", conexion);
                    emac.ExecuteScalar();
                    proac.ExecuteScalar();
                    MessageBox.Show("Se a cambiado el Pago a Provedores a :" + txt_pago_provedor.Text, "Pago a Provedor");
                }
                if(txt_pago_Empleados.Text != string.Empty && txt_pago_provedor.Text != string.Empty)
                {
                    OleDbCommand emac = new OleDbCommand("Update Facturas SET Pago_a_Empleados=" + Convert.ToInt32(txt_pago_Empleados.Text) + " Where Fecha='" + fecha + "'", conexion);
                    OleDbCommand proac = new OleDbCommand("Update Facturas SET Pago_Provedores=" + Convert.ToInt32(txt_pago_provedor.Text) + " Where Fecha='" + fecha + "'", conexion);
                    emac.ExecuteScalar();
                    proac.ExecuteScalar();
                    OleDbCommand up3 =  new OleDbCommand("Update Facturas SET Total_Neto=" + (Convert.ToInt32(Total_Neto.ExecuteScalar()) - (Convert.ToInt32(em.ExecuteScalar()) + Convert.ToInt32(pro.ExecuteScalar()))) + " Where Fecha = '" + fecha + "'", conexion);
                    up3.ExecuteScalar();
                    MessageBox.Show("Se a cambiado el Pago a Empleados y a Provedores", "Pago a Empleados y Provedores");
                }
               
            }
            OleDbDataAdapter adap = new OleDbDataAdapter();
            DataTable table = new DataTable();
            adap.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
            adap.Fill(table);
            dgv_Tabla.DataSource = table;
            txt_pago_Empleados.Text = string.Empty;
            txt_pago_provedor.Text = string.Empty;
        }

        private void dgv_Tabla_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Valor no Valido porfavor revise bien sus valores", "Revision de Cambios Fallida");
        }

        private void btn_agregar_telefono_Click(object sender, EventArgs e)
        {
            if(txt_Telefono.Text==string.Empty || txt_Nombre.Text == string.Empty || txt_calle.Text == string.Empty || txt_Colonia.Text == string.Empty || txt_Numero.Text == string.Empty)
            {
                MessageBox.Show("Debe de rellenar todos los campos para registrar un numero", "Registro de Envios");
            }
            else
            {
                this.enviosTableAdapter.InsertQuery(txt_Telefono.Text, txt_Nombre.Text, txt_calle.Text, txt_Colonia.Text, txt_Numero.Text, cmb_ciudad.Text);
                MessageBox.Show("Registro Realizado", "Registro de Envios");
            }
            OleDbDataAdapter adap = new OleDbDataAdapter();
            DataTable table = new DataTable();
            adap.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
            adap.Fill(table);
            dgv_Tabla.DataSource = table;

            txt_Telefono.Text= string.Empty;
            txt_Nombre.Text=string.Empty;
            txt_calle.Text= string.Empty;
            txt_Colonia.Text= string.Empty;
            txt_Numero.Text= string.Empty;
        }

        private void btn_actualizar_telefono_Click(object sender, EventArgs e)
        {
            if (txt_Telefono.Text == string.Empty || txt_Nombre.Text == string.Empty || txt_calle.Text == string.Empty || txt_Colonia.Text == string.Empty || txt_Numero.Text == string.Empty)
            {
                MessageBox.Show("Debe de rellenar todos los campos para registrar un numero", "Registro de Envios");
            }
            else
            {
                if(txt_telefono_ref.Text == string.Empty)
                {
                    MessageBox.Show("Debe especificar a que numero le va realizar el cambio", "Cambio de Envios");
                }
                else
                {
                    OleDbCommand comand = new OleDbCommand("Select Telefono From Envios Where Telefono='"+ txt_telefono_ref.Text +"'", conexion);
                    OleDbDataReader leedb;
                    leedb = comand.ExecuteReader();

                    Boolean Existe;
                    Existe = leedb.HasRows;
                    if (Existe)
                    {
                        this.enviosTableAdapter.UpdateTelefono(txt_Telefono.Text, txt_Nombre.Text, txt_calle.Text, txt_Colonia.Text, txt_Numero.Text, cmb_ciudad.Text, txt_telefono_ref.Text);
                        MessageBox.Show("Cambios realizados con exito", "Cambio de Envios");
                    }
                    else
                    {
                        MessageBox.Show("Ese Telefono no existe o esta mal escrito el telefono de referencia", "Cambio de Envios");
                    }
                }
            }

            OleDbDataAdapter adap = new OleDbDataAdapter();
            DataTable table = new DataTable();
            adap.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
            adap.Fill(table);
            dgv_Tabla.DataSource = table;
            txt_Telefono.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            txt_calle.Text = string.Empty;
            txt_Colonia.Text = string.Empty;
            txt_Numero.Text = string.Empty;
            txt_telefono_ref.Text = string.Empty;
        }

        private void btn_eliminar_telefono_Click(object sender, EventArgs e)
        {
            if (txt_telefono_ref.Text != string.Empty)
            {
                OleDbCommand comand = new OleDbCommand("Select Telefono From Envios Where Telefono='" + txt_telefono_ref.Text + "'", conexion);
                OleDbDataReader leedb;
                leedb = comand.ExecuteReader();

                Boolean Existe;
                Existe = leedb.HasRows;
                if (Existe)
                {
                    this.enviosTableAdapter.DeleteTelefono(txt_telefono_ref.Text);
                    MessageBox.Show("Registro Eliminado con Exito", "Eliminacion de Envios");

                    OleDbDataAdapter adap = new OleDbDataAdapter();
                    DataTable table = new DataTable();
                    adap.SelectCommand = new OleDbCommand("Select * FROM " + cmb_Tablas.Text, conexion);
                    adap.Fill(table);
                    dgv_Tabla.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Ese Telefono no esta registrado en el sistema", "Eliminacion de Envios");
                }
            }
            else
            {
                MessageBox.Show("Debe Escribir un numero para eliminar un Registro", "Eliminacion de Envios");
            }
            dgv_Tabla.Refresh();
            txt_Telefono.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            txt_calle.Text = string.Empty;
            txt_Colonia.Text = string.Empty;
            txt_Numero.Text = string.Empty;
            txt_telefono_ref.Text = string.Empty;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string fecha_f= "SELECT * from facturas where fecha like'";
            if (txt_año.Text != string.Empty)
            {
                if (nud_dias.Value != 0)
                {
                    if(nud_dias.Value<9)
                        fecha_f = fecha_f + "0" +Convert.ToString(nud_dias.Value) + "/";
                    else
                        fecha_f = fecha_f + Convert.ToString(nud_dias.Value) + "/";
                }
                if (nud_mes.Value != 0)
                {
                    if(nud_mes.Value<9)
                        fecha_f = fecha_f +"0" +Convert.ToString(nud_mes.Value) + "/";
                    else
                        fecha_f = fecha_f + Convert.ToString(nud_mes.Value) + "/";
                }
                if (txt_año.Text != string.Empty)
                {
                    fecha_f = fecha_f + txt_año.Text + "'";
                }
                OleDbDataAdapter ada6 = new OleDbDataAdapter();
                DataTable tabla6 = new DataTable();
                ada6.SelectCommand = new OleDbCommand(fecha_f, conexion);
                ada6.Fill(tabla6);
                dgv_Tabla.DataSource = tabla6;
            }
            else
            {
                MessageBox.Show("Debes Rellenar todos los datos del fecha, para buscar el registro", "Busqueda de Facturas");
            }
            txt_año.Text = string.Empty;
            nud_dias.Value = 1;
            nud_mes.Value=1;
        }
    }
}
