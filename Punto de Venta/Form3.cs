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
    public partial class frm_Login_Usuario : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public frm_Login_Usuario()
        {
            InitializeComponent();
        }

        private void txt_contra_TextChanged(object sender, EventArgs e)
        {
            txt_contra.PasswordChar = '*';
            txt_contra.MaxLength = 8;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            frm_Menu_Principal mp = new frm_Menu_Principal();
            mp.Show();
            this.Hide();
        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }

            string con = "Select Usuario, Contraseña From Meseros Where Usuario='" + txt_usuario.Text + "' and Contraseña='" + txt_contra.Text + "'";
            OleDbCommand comand = new OleDbCommand(con, conexion);
            OleDbDataReader leedb;
            leedb = comand.ExecuteReader();

            Boolean Existe;
            Existe = leedb.HasRows;
            if (Existe)
            {
                frm_Punto_Venta pv = new frm_Punto_Venta();
                pv.Show();
                this.Hide();
            }
            else { MessageBox.Show("Datos Incorrectos, Porfavor Verifique","Conexion Fallida"); }
            conexion.Close();
        }

        private void frm_Login_Usuario_Load(object sender, EventArgs e)
        {
        }
    }
}
