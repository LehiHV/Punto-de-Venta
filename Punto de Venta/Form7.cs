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
    public partial class frm_Registro_Usuario : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public frm_Registro_Usuario()
        {
            InitializeComponent();
        }

        private void frm_Registro_Usuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }

        private void frm_Registro_Usuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mariscos_PepeDataSet.Meseros' Puede moverla o quitarla según sea necesario.
            this.meserosTableAdapter.Fill(this.mariscos_PepeDataSet.Meseros);
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Edicion_Datos ed = new frm_Edicion_Datos();
            ed.Show();
        }

        private void txt_contraseña_TextChanged(object sender, EventArgs e)
        {
            txt_contraseña.MaxLength = 8;
        }

        private void txt_contraseña2_TextChanged(object sender, EventArgs e)
        {
            txt_contraseña.MaxLength = 8;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "" || txt_contraseña2.Text == "" || txt_usuario.Text == "")
            {
                MessageBox.Show("Favor de rellenar todos los datos", "Registro Usuario");
            }
            else
            {
                if (txt_contraseña.Text != txt_contraseña2.Text)
                {
                    MessageBox.Show("Las Contrasñeas No Coinciden, Favor de Revisar", "Registro Usuario");
                }
                else
                {
                    this.meserosTableAdapter.Insert(txt_usuario.Text, txt_contraseña.Text);
                    MessageBox.Show("Usuario Creado", "Registro Usuario");
                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";
                    txt_contraseña2.Text = "";
                }

            }
        }

        private void meserosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.meserosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mariscos_PepeDataSet);

        }
    }
}
