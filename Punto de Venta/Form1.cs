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
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|\\Mariscos_Pepe.accdb");
    public frm_Menu_Principal(){
            InitializeComponent();
        }

        private void frm_Menu_Principal_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Conectado","Conexion");
            }catch(Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
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
    }
}
