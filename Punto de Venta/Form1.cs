using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Punto_de_Venta
{
    public partial class frm_Menu_Principal : Form
    {
        String fecha = Convert.ToString(DateTime.Now).Substring(0, 10);
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public static OleDbConnection c = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");

        
        public frm_Menu_Principal(){
            InitializeComponent();
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }
            try
            {
                c.Open();
            }
            catch (Exception a) 
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }

        }

        private void frm_Menu_Principal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mariscos_PepeDataSet.Facturas' Puede moverla o quitarla según sea necesario.
            int Total_Neto = Convert.ToInt32(new OleDbCommand("Select Total_Neto FRom Facturas WHERE Fecha='" + fecha + "'", conexion).ExecuteScalar());
            OleDbCommand comand = new OleDbCommand("Select * From Facturas Where Fecha='" + fecha+"'", conexion);
            OleDbDataReader leedb;
            leedb = comand.ExecuteReader();
            Boolean Existe;
            Existe = leedb.HasRows;

            
            if (Existe == false)
                this.facturasTableAdapter.InsertQuery(fecha);
            else
            {
                lbl_dinero_caja.Text = (Convert.ToString(Total_Neto));
            }
        }

        private void frm_Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            frm_Login_Admin La = new frm_Login_Admin();
            La.Show();
            this.Hide();
            c.Close();
        }

        private void btn_usuario_Click(object sender, EventArgs e)
        {
            frm_Login_Usuario Lu = new frm_Login_Usuario();
            Lu.Show(); 
            this.Hide();
            c.Close();
        }

        private void facturasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.facturasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mariscos_PepeDataSet);

        }
    }
}
