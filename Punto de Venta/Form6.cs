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

namespace Punto_de_Venta
{
    public partial class frm_Registro_Admin : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public frm_Registro_Admin()
        {
            InitializeComponent();
        }

        private void frm_registro_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }
        }

        private void frm_registro_FormClosing(object sender, FormClosingEventArgs e)
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
            this.Hide();
            frm_Edicion_Datos ed = new frm_Edicion_Datos();
            ed.Show();
            conexion.Close();
            
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "" || txt_contraseña2.Text == "" || txt_usuario.Text == "")
            {
                MessageBox.Show("Favor de rellenar todos los datos", "Registro Admin");
            }
            else
            {
                if (txt_contraseña.Text != txt_contraseña2.Text)
                {
                    MessageBox.Show("Las Contrasñeas No Coinciden, Favor de Revisar", "Registro Admin");
                }
                else
                {
                    this.adminTableAdapter.Insert(txt_usuario.Text, txt_contraseña.Text);
                    MessageBox.Show("Usuario Creado", "Registro Admin");
                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";
                    txt_contraseña2.Text = "";
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            txt_contraseña.MaxLength = 8;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txt_contraseña2.MaxLength = 8;
        }

        private void adminBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.adminBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mariscos_PepeDataSet);

        }
    }
}
