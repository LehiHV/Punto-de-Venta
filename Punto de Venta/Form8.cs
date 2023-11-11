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
using static Punto_de_Venta.frm_Seleccion_envios;

namespace Punto_de_Venta
{
    public partial class frm_Registro_Envios : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public frm_Registro_Envios()
        {
            InitializeComponent();
        }

        private void frm_Registro_Envios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mariscos_PepeDataSet.Envios' Puede moverla o quitarla según sea necesario.
            this.enviosTableAdapter.Fill(this.mariscos_PepeDataSet.Envios);
            cmb_Ciudad.SelectedIndex= 0;
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }
        }

        private void frm_Registro_Envios_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (txt_Telefono.Text == string.Empty || txt_Nombre.Text == string.Empty || txt_Calle.Text == string.Empty || txt_Colonia.Text == string.Empty || txt_NumeroExt.Text == string.Empty)
                MessageBox.Show("Debes rellenar todos los Campos para hacer el Registro");
            else
            {
                this.enviosTableAdapter.InsertQuery(txt_Telefono.Text, txt_Nombre.Text, txt_Calle.Text, txt_Colonia.Text, txt_NumeroExt.Text, cmb_Ciudad.Text);
                MessageBox.Show("Registro Creado, Datos Tomados", "Registro Envios");
                ClaseCompartida.Nombre = txt_Nombre.Text;
                ClaseCompartida.Telefono = txt_Telefono.Text;
                ClaseCompartida.Calle = txt_Calle.Text;
                ClaseCompartida.Colonia = txt_Colonia.Text;
                ClaseCompartida.Ciudad = cmb_Ciudad.Text;
                ClaseCompartida.NE = txt_NumeroExt.Text;
                ClaseCompartida.pedido = true;
                this.Hide();
            }
        }

        private void enviosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.enviosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mariscos_PepeDataSet);

        }
    }
}
