using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Punto_de_Venta.frm_Punto_Venta;

namespace Punto_de_Venta
{
    public partial class frm_Seleccion_envios : Form
    {

        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public frm_Seleccion_envios()
        {
            InitializeComponent();
        }

        private void frm_Seleccion_envios_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }

        private void frm_Seleccion_envios_Load(object sender, EventArgs e)
        {
            String Telefono2 = lbl_Telefono.Text.Substring(15);
            OleDbDataAdapter adap = new OleDbDataAdapter();
            DataTable table = new DataTable();
            adap.SelectCommand = new OleDbCommand("Select * FROM Envios Where Telefono='" + Telefono2+"'" , conexion);
            adap.Fill(table);
            dgv_Tabla.DataSource = table;
            dgv_Tabla.AllowUserToAddRows = false;
            dgv_Tabla.AllowUserToDeleteRows = false;
            dgv_Tabla.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_seleccion_Click(object sender, EventArgs e)
        {
            switch (dgv_Tabla.CurrentCell.ColumnIndex)
            {
                case 0:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex +2 , dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 4, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 5, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 6, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
                case 1:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 4, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 5, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
                case 2:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex-1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex , dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 4, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
                case 3:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex-1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex , dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
                case 4:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex-1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex , dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
                case 5:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 4, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex -2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex + 1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
                case 6:
                    ClaseCompartida.Telefono = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 5, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Nombre = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex - 4, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Calle = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex-3, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.Colonia = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex -2, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    ClaseCompartida.NE = Convert.ToString(dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex -1, dgv_Tabla.CurrentCell.RowIndex].Value.ToString());
                    ClaseCompartida.Ciudad = dgv_Tabla[dgv_Tabla.CurrentCell.ColumnIndex, dgv_Tabla.CurrentCell.RowIndex].Value.ToString();
                    break;
            }
            ClaseCompartida.pedido = true;
            MessageBox.Show("Se a elegido con la Direccion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad, "Direccion Seleccionada");
            this.Hide();
        }

        private void dgv_Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
