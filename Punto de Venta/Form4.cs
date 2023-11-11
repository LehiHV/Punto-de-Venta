using Punto_de_Venta.Mariscos_PepeDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ListasComandasMesas;

namespace Punto_de_Venta
{
    public partial class frm_Punto_Venta : Form
    {
        List<string> comanda = new List<string>();
        List<string> comida = new List<string>();


        public static class ClaseCompartida
        {
            public static string Telefono;
            public static string Nombre;
            public static string Calle;
            public static string Colonia;
            public static string NE;
            public static string Ciudad;
            public static bool pedido;

            public static DataGridView m = new DataGridView();

            // otras variables estáticas
        }

        decimal[] Tt = new decimal[20];
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|Mariscos_Pepe.accdb");
        public frm_Punto_Venta()
        {
            InitializeComponent();
        }

        private void frm_Punto_Venta_FormClosing(object sender, FormClosingEventArgs e)
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

            if (TodasLasMesasEstanVacias())
            {
                MessageBox.Show("Antes de poder Salir no deben quedar Cuentas Pendientes en el Sistema", "Salir del Punto de Venta");
            }
            else
            {
                if (MessageBox.Show("¿Seguro que quiere Salir?", "Salir del Punto de Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frm_Menu_Principal mp = new frm_Menu_Principal();
                    mp.Show();
                    this.Hide();
                }
            }
        }
        private void MostrarCuenta(List<string> mesa, int index)
        {
            for (int i = 0; i < mesa.Count; i++)
            {
                if (mesa[i] != "")
                {
                    lsb_Cuenta.Items.Add(mesa[i]);
                    lbl_Total.Text = Convert.ToString(Tt[index] + "$");
                }
            }
        }

        //Mostrar contenido de las mesas
        private void cmb_Mesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsb_Cuenta.Items.Clear();
            lbl_Total.Text = "";

            int selectedIndex = cmb_Mesas.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < ListasComandasMesas.Mesas.Count)
            {
                MostrarCuenta(ListasComandasMesas.Mesas[selectedIndex], selectedIndex);
            }
        }

        //Codigo para la configuracion del Scrollbar Vertical de los TabPages
        private void ScrollBarConfig(TabPage page)
        {
            page.HorizontalScroll.Maximum = 0;
            page.AutoScroll = false;
            page.VerticalScroll.Visible = false;
            page.AutoScroll = true;
        }

        //Configuracion auxiliar para la vizualizacion de los componentes
        private void TextANDNumericConfig(System.Windows.Forms.TextBox textbox, NumericUpDown nud)
        {
            textbox.Visible = true;
            textbox.Visible = false;
            nud.Visible = true;
            nud.Visible = false;
        }
        private void SortComponents(char chosenLetter, int position, int limit)
        {
            do
            {
                System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)this.Controls.Find($"txt_{chosenLetter}_{position}", true).FirstOrDefault();
                NumericUpDown numericUpDown = (NumericUpDown)this.Controls.Find($"nud_{chosenLetter}_{position}", true).FirstOrDefault();

                if (textBox != null && numericUpDown != null)
                {
                    TextANDNumericConfig(textBox, numericUpDown);
                }


                position++;

            } while (position <= limit);
        }
        private void SpecialComponents()
        {
            //Casos Especiales de Entradas
            rdb_E_V_12.Visible = true;
            rdb_E_R_12.Visible = true;
            rdb_E_N_12.Visible = true;
            rdb_E_V_13.Visible = true;
            rdb_E_R_13.Visible = true;
            rdb_E_N_13.Visible = true;
            rdb_E_V_12.Visible = false;
            rdb_E_R_12.Visible = false;
            rdb_E_N_12.Visible = false;
            rdb_E_V_13.Visible = false;
            rdb_E_R_13.Visible = false;
            rdb_E_N_13.Visible = false;
            grb_E_S_12.Visible = true;
            grb_E_S_13.Visible = true;
            grb_E_S_12.Visible = false;
            grb_E_S_13.Visible = false;

            //Casos Especiales de Fuertes
            grb_F_34_F.Visible = true;
            grb_F_34_F.Visible = false;
            grb_F_41_1.Visible = true;
            grb_F_41_1.Visible = false;
            rdb_F_41_1.Visible = true;
            rdb_F_41_2.Visible = true;
            rdb_F_41_1.Visible = false;
            rdb_F_41_2.Visible = false;
            grb_I_44_H.Visible = true;
            grb_I_44_H.Visible = false;
            rdb_I_44_1.Visible = true;
            rdb_I_44_2.Visible = true;
            rdb_I_44_3.Visible = true;
            rdb_I_44_1.Visible = false;
            rdb_I_44_2.Visible = false;
            rdb_I_44_3.Visible = false;
            nud_F_35_gr.Visible = true;
            nud_F_35_gr.Visible = false;
            lbl_F_35.Visible = true;
            lbl_F_35.Visible = false;
            for (int i = 1; i <= 37; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    // Corregir la sintaxis para encontrar el CheckBox y hacerlo visible
                    CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_F_{i}_{j}", true).FirstOrDefault();

                    if (checkBox != null)
                    {
                        checkBox.Visible = true;
                        checkBox.Visible = false;
                    }
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                RadioButton rdb = (RadioButton)this.Controls.Find($"rdb_F_34_P_{i}", true).FirstOrDefault();
                if (rdb != null)
                {
                    rdb.Visible = true;
                    rdb.Visible = false;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                CheckBox chk = (CheckBox)this.Controls.Find($"chk_F_41_{i}", true).FirstOrDefault();
                if (chk != null)
                {
                    chk.Visible = true;
                    chk.Visible = false;
                }
            }

            //Casos Especiales de Menú Infantil
            grb_I_44_H.Visible = true;
            grb_I_44_H.Visible = false;
            rdb_I_44_1.Visible = true;
            rdb_I_44_2.Visible = true;
            rdb_I_44_3.Visible = true;
            rdb_I_44_1.Visible = false;
            rdb_I_44_2.Visible = false;
            rdb_I_44_3.Visible = false;

            //Casos Especiales de Paquetes
            txt_C_7.Visible = true;
            txt_C_4.Visible = true;
            nud_C_4.Visible = true;
            nud_C_7.Visible = true;
            txt_C_7.Visible = false;
            txt_C_4.Visible = false;
            nud_C_4.Visible = false;
            nud_C_7.Visible = false;

        }

        //Identificar Id's con Checkboxs
        private void UpdateCheckBoxText(Char category, int start, int end)
        {
            switch (category)
            {
                case 'E':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Entradas WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Entradas WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'F':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Fuertes WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Fuertes WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'L':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Licores WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Licores WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'B':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Bebidas WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Bebidas WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'I':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Infantil WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Infantil WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'O':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Promocion WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Promocion WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'P':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Postres WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Postres WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                case 'C':
                    for (int id = start; id <= end; id++)
                    {
                        CheckBox checkBox = (CheckBox)this.Controls.Find($"chk_{category}_{id}", true).FirstOrDefault();

                        if (checkBox != null)
                        {
                            string nombre = Convert.ToString((new OleDbCommand($"Select Nombre FROM Paquete WHERE Id={id}", conexion)).ExecuteScalar());
                            string cantidad = Convert.ToString((new OleDbCommand($"Select Cantidad FROM Paquete WHERE Id={id}", conexion)).ExecuteScalar());

                            checkBox.Text = string.IsNullOrEmpty(cantidad) ? nombre : $"{nombre} ({cantidad})";
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Error", "Error porfavor selecciona una opcion posible", MessageBoxButtons.OK);
                    break;
            }
        }

        private void frm_Punto_Venta_Load(object sender, EventArgs e)
        {

            //Permitir el VerticalScrollBar en las paginas
            ScrollBarConfig(tbp_Entradas);
            ScrollBarConfig(tbp_Fuertes);
            ScrollBarConfig(tbp_Bebidas);
            ScrollBarConfig(tbp_Paquetes);
            ScrollBarConfig(tbp_Licores);

            //Hacer que los textbox se mantengan en su posicion
            SpecialComponents();
            SortComponents('E', 1, 29);

            //Abrir la conexion para la base de datos
            try
            {
                conexion.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error por: " + a.ToString(), "Conexion");
            }
            //Cargar los precios y Id de los productos:
            UpdateCheckBoxText('E', 1, 29);
            UpdateCheckBoxText('F', 1, 33);
            UpdateCheckBoxText('B', 1, 24);
            UpdateCheckBoxText('L', 1, 22);
            UpdateCheckBoxText('P', 1, 5);
            UpdateCheckBoxText('I', 1, 3);
            UpdateCheckBoxText('C', 1, 7);
            UpdateCheckBoxText('O', 1, 9);
            btn_eliminar.Enabled = false;
            OleDbCommand comand = new OleDbCommand("Select Caja FROM Facturas WHERE Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion);

            //Activar las ofertas por dia automaticamente
            switch (Convert.ToString(DateTime.Today.DayOfWeek))
            {
                case "Tuesday":
                    lbl_Martes.Visible = true;
                    chk_O_1.Visible = true;
                    chk_O_2.Visible = true;
                    chk_O_3.Visible = true;
                    break;
                case "Wednesday":
                    lbl_Miercoles.Visible = true;
                    chk_O_1.Visible = true;
                    chk_O_2.Visible = true;
                    chk_O_3.Visible = true;
                    chk_O_4.Visible = true;
                    chk_O_5.Visible = true;
                    chk_O_6.Visible = true;
                    chk_O_7.Visible = true;
                    chk_O_8.Visible = true;
                    chk_O_9.Visible = true;
                    break;
                case "Thursday":
                    lbl_Jueves.Visible = true;
                    chk_O_4.Visible = true;
                    chk_O_5.Visible = true;
                    chk_O_6.Visible = true;
                    chk_O_7.Visible = true;
                    break;
                case "Friday":
                    lbl_Viernes.Visible = true;
                    chk_O_8.Visible = true;
                    chk_O_9.Visible = true;
                    break;
                default:

                    break;
            }



            cmb_Mesas.SelectedIndex = 0;
        }

        //Checkbox de Entradas
        private void chk_E_1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_1.Checked)
            {
                txt_E_1.Visible = true;
                nud_E_1.Visible = true;
            }
            else
            {
                txt_E_1.Text = string.Empty;
                nud_E_1.Value = 1;
                txt_E_1.Visible = false;
                nud_E_1.Visible = false;
            }
        }
        private void chk_E_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_2.Checked)
            {
                txt_E_2.Visible = true;
                nud_E_2.Visible = true;
            }
            else
            {
                txt_E_2.Text = string.Empty;
                nud_E_2.Value = 1;
                txt_E_2.Visible = false;
                nud_E_2.Visible = false;
            }
        }
        private void chk_E_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_3.Checked)
            {
                txt_E_3.Visible = true;
                nud_E_3.Visible = true;
            }
            else
            {
                txt_E_3.Text = string.Empty;
                nud_E_3.Value = 1;
                txt_E_3.Visible = false;
                nud_E_3.Visible = false;
            }
        }
        private void chk_E_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_4.Checked)
            {
                txt_E_4.Visible = true;
                nud_E_4.Visible = true;
            }
            else
            {
                txt_E_4.Text = string.Empty;
                nud_E_4.Value = 1;
                txt_E_4.Visible = false;
                nud_E_4.Visible = false;
            }
        }
        private void chk_E_5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_5.Checked)
            {
                txt_E_5.Visible = true;
                nud_E_5.Visible = true;
            }
            else
            {
                txt_E_5.Text = string.Empty;
                nud_E_5.Value = 1;
                txt_E_5.Visible = false;
                nud_E_5.Visible = false;
            }
        }
        private void chk_E_6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_6.Checked)
            {
                txt_E_6.Visible = true;
                nud_E_6.Visible = true;
            }
            else
            {
                txt_E_6.Text = string.Empty;
                nud_E_6.Value = 1;
                txt_E_6.Visible = false;
                nud_E_6.Visible = false;
            }
        }
        private void chk_E_7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_7.Checked)
            {
                txt_E_7.Visible = true;
                nud_E_7.Visible = true;
            }
            else
            {
                txt_E_7.Text = string.Empty;
                nud_E_7.Value = 1;
                txt_E_7.Visible = false;
                nud_E_7.Visible = false;
            }
        }
        private void chk_E_8_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_8.Checked)
            {
                txt_E_8.Visible = true;
                nud_E_8.Visible = true;
            }
            else
            {
                txt_E_8.Text = string.Empty;
                nud_E_8.Value = 1;
                txt_E_8.Visible = false;
                nud_E_8.Visible = false;
            }
        }
        private void chk_E_9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_9.Checked)
            {
                txt_E_9.Visible = true;
                nud_E_9.Visible = true;
            }
            else
            {
                txt_E_9.Text = string.Empty;
                nud_E_9.Value = 1;
                txt_E_9.Visible = false;
                nud_E_9.Visible = false;
            }
        }
        private void chk_E_10_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_10.Checked)
            {
                txt_E_10.Visible = true;
                nud_E_10.Visible = true;
            }
            else
            {
                txt_E_10.Text = string.Empty;
                nud_E_10.Value = 1;
                txt_E_10.Visible = false;
                nud_E_10.Visible = false;
            }
        }
        private void chk_E_11_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_11.Checked)
            {
                txt_E_11.Visible = true;
                nud_E_11.Visible = true;
            }
            else
            {
                txt_E_11.Text = string.Empty;
                nud_E_11.Value = 1;
                txt_E_11.Visible = false;
                nud_E_11.Visible = false;
            }
        }
        private void chk_E_12_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_12.Checked)
            {
                txt_E_12.Visible = true;
                nud_E_12.Visible = true;
                grb_E_S_12.Visible = true;
                rdb_E_N_12.Visible = true;
                rdb_E_R_12.Visible = true;
                rdb_E_V_12.Visible = true;
            }
            else
            {
                txt_E_12.Text = string.Empty;
                nud_E_12.Value = 1;
                txt_E_12.Visible = false;
                nud_E_12.Visible = false;
                grb_E_S_12.Visible = false;
                rdb_E_N_12.Visible = false;
                rdb_E_R_12.Visible = false;
                rdb_E_V_12.Visible = false;
            }
        }
        private void chk_E_13_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_13.Checked)
            {
                txt_E_13.Visible = true;
                nud_E_13.Visible = true;
                grb_E_S_13.Visible = true;
                rdb_E_V_13.Visible = true;
                rdb_E_R_13.Visible = true;
                rdb_E_N_13.Visible = true;
            }
            else
            {
                txt_E_13.Text = string.Empty;
                nud_E_13.Value = 1;
                txt_E_13.Visible = false;
                nud_E_13.Visible = false;
                grb_E_S_13.Visible = false;
                rdb_E_V_13.Visible = false;
                rdb_E_R_13.Visible = false;
                rdb_E_N_13.Visible = false;
            }
        }
        private void chk_E_14_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_14.Checked)
            {
                txt_E_14.Visible = true;
                nud_E_14.Visible = true;
            }
            else
            {
                txt_E_14.Text = string.Empty;
                nud_E_14.Value = 1;
                txt_E_14.Visible = false;
                nud_E_14.Visible = false;
            }
        }
        private void chk_E_15_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_15.Checked)
            {
                txt_E_15.Visible = true;
                nud_E_15.Visible = true;
            }
            else
            {
                txt_E_15.Text = string.Empty;
                nud_E_15.Value = 1;
                txt_E_15.Visible = false;
                nud_E_15.Visible = false;
            }
        }
        private void chk_E_16_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_16.Checked)
            {
                txt_E_16.Visible = true;
                nud_E_16.Visible = true;
            }
            else
            {
                txt_E_16.Text = string.Empty;
                nud_E_16.Value = 1;
                txt_E_16.Visible = false;
                nud_E_16.Visible = false;
            }
        }
        private void chk_E_17_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_17.Checked)
            {
                txt_E_17.Visible = true;
                nud_E_17.Visible = true;
            }
            else
            {
                txt_E_17.Text = string.Empty;
                nud_E_17.Value = 1;
                txt_E_17.Visible = false;
                nud_E_17.Visible = false;
            }
        }
        private void chk_E_18_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_18.Checked)
            {
                txt_E_18.Visible = true;
                nud_E_18.Visible = true;
            }
            else
            {
                txt_E_18.Text = string.Empty;
                nud_E_18.Value = 1;
                txt_E_18.Visible = false;
                nud_E_18.Visible = false;
            }
        }
        private void chk_E_19_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_E_19.Checked)
            {
                txt_E_19.Visible = true;
                nud_E_19.Visible = true;
            }
            else
            {
                txt_E_19.Text = string.Empty;
                nud_E_19.Value = 1;
                txt_E_19.Visible = false;
                nud_E_19.Visible = false;
            }
        }
        private void chk_E_20_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_20.Checked)
            {
                txt_E_20.Visible = true;
                nud_E_20.Visible = true;
            }
            else
            {
                txt_E_20.Text = string.Empty;
                nud_E_20.Value = 1;
                txt_E_20.Visible = false;
                nud_E_20.Visible = false;
            }
        }
        private void chk_E_21_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_21.Checked)
            {
                txt_E_21.Visible = true;
                nud_E_21.Visible = true;
            }
            else
            {
                txt_E_21.Text = string.Empty;
                nud_E_21.Value = 1;
                txt_E_21.Visible = false;
                nud_E_21.Visible = false;
            }
        }
        private void chk_E_22_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_22.Checked)
            {
                txt_E_22.Visible = true;
                nud_E_22.Visible = true;
            }
            else
            {
                txt_E_22.Text = string.Empty;
                nud_E_22.Value = 1;
                txt_E_22.Visible = false;
                nud_E_22.Visible = false;
            }
        }
        private void chk_E_23_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_23.Checked)
            {
                txt_E_23.Visible = true;
                nud_E_23.Visible = true;
            }
            else
            {
                txt_E_23.Text = string.Empty;
                nud_E_23.Value = 1;
                txt_E_23.Visible = false;
                nud_E_23.Visible = false;
            }
        }
        private void chk_E_24_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_24.Checked)
            {
                txt_E_24.Visible = true;
                nud_E_24.Visible = true;
            }
            else
            {
                txt_E_24.Text = string.Empty;
                nud_E_24.Value = 1;
                txt_E_24.Visible = false;
                nud_E_24.Visible = false;
            }
        }
        private void chk_E_25_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_25.Checked)
            {
                txt_E_25.Visible = true;
                nud_E_25.Visible = true;
            }
            else
            {
                txt_E_25.Text = string.Empty;
                nud_E_25.Value = 1;
                txt_E_25.Visible = false;
                nud_E_25.Visible = false;
            }
        }
        private void chk_E_26_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_26.Checked)
            {
                txt_E_26.Visible = true;
                nud_E_26.Visible = true;
            }
            else
            {
                txt_E_26.Text = string.Empty;
                nud_E_26.Value = 1;
                txt_E_26.Visible = false;
                nud_E_26.Visible = false;
            }
        }
        private void chk_E_27_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_27.Checked)
            {
                txt_E_27.Visible = true;
                nud_E_27.Visible = true;
            }
            else
            {
                txt_E_27.Text = string.Empty;
                nud_E_27.Value = 1;
                txt_E_27.Visible = false;
                nud_E_27.Visible = false;
            }
        }
        private void chk_E_28_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_28.Checked)
            {
                txt_E_28.Visible = true;
                nud_E_28.Visible = true;
            }
            else
            {
                txt_E_28.Text = string.Empty;
                nud_E_28.Value = 1;
                txt_E_28.Visible = false;
                nud_E_28.Visible = false;
            }
        }
        private void chk_E_29_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_E_29.Checked)
            {
                txt_E_29.Visible = true;
                nud_E_29.Visible = true;
            }
            else
            {
                txt_E_29.Text = string.Empty;
                nud_E_29.Value = 1;
                txt_E_29.Visible = false;
                nud_E_29.Visible = false;
            }
        }

        //Checkboxs de Fuertes
        private void chk_F_20_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_F_1.Checked)
            {
                txt_F_1.Visible = true;
                nud_F_1.Visible = true;
                chk_F_20_1.Visible = true;
                chk_F_20_2.Visible = true;
                chk_F_20_3.Visible = true;
                chk_F_20_4.Visible = true;
                chk_F_20_5.Visible = true;
                chk_F_20_6.Visible = true;
            }
            else
            {
                txt_F_1.Text = string.Empty;
                nud_F_1.Value = 1;
                txt_F_1.Visible = false;
                nud_F_1.Visible = false;
                chk_F_20_1.Checked = false;
                chk_F_20_2.Checked = false;
                chk_F_20_3.Checked = false;
                chk_F_20_4.Checked = false;
                chk_F_20_5.Checked = false;
                chk_F_20_6.Checked = false;
                chk_F_20_1.Visible = false;
                chk_F_20_2.Visible = false;
                chk_F_20_3.Visible = false;
                chk_F_20_4.Visible = false;
                chk_F_20_5.Visible = false;
                chk_F_20_6.Visible = false;
            }
        }
        private void chk_F_21_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_2.Checked)
            {
                txt_F_2.Visible = true;
                nud_F_2.Visible = true;
                chk_F_21_1.Visible = true;
                chk_F_21_2.Visible = true;
                chk_F_21_3.Visible = true;
                chk_F_21_4.Visible = true;
                chk_F_21_5.Visible = true;
                chk_F_21_6.Visible = true;
            }
            else
            {
                txt_F_2.Text = string.Empty;
                nud_F_2.Value = 1;
                txt_F_2.Visible = false;
                nud_F_2.Visible = false;
                chk_F_21_1.Checked = false;
                chk_F_21_2.Checked = false;
                chk_F_21_3.Checked = false;
                chk_F_21_4.Checked = false;
                chk_F_21_5.Checked = false;
                chk_F_21_6.Checked = false;
                chk_F_21_1.Visible = false;
                chk_F_21_2.Visible = false;
                chk_F_21_3.Visible = false;
                chk_F_21_4.Visible = false;
                chk_F_21_5.Visible = false;
                chk_F_21_6.Visible = false;
            }
        }
        private void chk_F_22_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_3.Checked)
            {
                txt_F_3.Visible = true;
                nud_F_3.Visible = true;
                chk_F_22_1.Visible = true;
                chk_F_22_2.Visible = true;
                chk_F_22_3.Visible = true;
                chk_F_22_4.Visible = true;
                chk_F_22_5.Visible = true;
                chk_F_22_6.Visible = true;
            }
            else
            {
                txt_F_3.Text = string.Empty;
                nud_F_3.Value = 1;
                txt_F_3.Visible = false;
                nud_F_3.Visible = false;
                chk_F_22_1.Checked = false;
                chk_F_22_2.Checked = false;
                chk_F_22_3.Checked = false;
                chk_F_22_4.Checked = false;
                chk_F_22_5.Checked = false;
                chk_F_22_6.Checked = false;
                chk_F_22_1.Visible = false;
                chk_F_22_2.Visible = false;
                chk_F_22_3.Visible = false;
                chk_F_22_4.Visible = false;
                chk_F_22_5.Visible = false;
                chk_F_22_6.Visible = false;
            }
        }
        private void chk_F_23_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_4.Checked)
            {
                txt_F_4.Visible = true;
                nud_F_4.Visible = true;
                chk_F_23_1.Visible = true;
                chk_F_23_2.Visible = true;
                chk_F_23_3.Visible = true;
                chk_F_23_4.Visible = true;
                chk_F_23_5.Visible = true;
                chk_F_23_6.Visible = true;
            }
            else
            {
                txt_F_4.Text = string.Empty;
                nud_F_4.Value = 1;
                txt_F_4.Visible = false;
                nud_F_4.Visible = false;
                chk_F_23_1.Checked = false;
                chk_F_23_2.Checked = false;
                chk_F_23_3.Checked = false;
                chk_F_23_4.Checked = false;
                chk_F_23_5.Checked = false;
                chk_F_23_6.Checked = false;
                chk_F_23_1.Visible = false;
                chk_F_23_2.Visible = false;
                chk_F_23_3.Visible = false;
                chk_F_23_4.Visible = false;
                chk_F_23_5.Visible = false;
                chk_F_23_6.Visible = false;
            }
        }
        private void chk_F_24_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_5.Checked)
            {
                txt_F_5.Visible = true;
                nud_F_5.Visible = true;
                chk_F_24_1.Visible = true;
                chk_F_24_2.Visible = true;
                chk_F_24_3.Visible = true;
                chk_F_24_4.Visible = true;
                chk_F_24_5.Visible = true;
                chk_F_24_6.Visible = true;
            }
            else
            {
                txt_F_5.Text = string.Empty;
                nud_F_5.Value = 1;
                txt_F_5.Visible = false;
                nud_F_5.Visible = false;
                chk_F_24_1.Checked = false;
                chk_F_24_2.Checked = false;
                chk_F_24_3.Checked = false;
                chk_F_24_4.Checked = false;
                chk_F_24_5.Checked = false;
                chk_F_24_6.Checked = false;
                chk_F_24_1.Visible = false;
                chk_F_24_2.Visible = false;
                chk_F_24_3.Visible = false;
                chk_F_24_4.Visible = false;
                chk_F_24_5.Visible = false;
                chk_F_24_6.Visible = false;
            }
        }
        private void chk_F_25_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_6.Checked)
            {
                txt_F_6.Visible = true;
                nud_F_6.Visible = true;
                chk_F_25_1.Visible = true;
                chk_F_25_2.Visible = true;
                chk_F_25_3.Visible = true;
                chk_F_25_4.Visible = true;
                chk_F_25_5.Visible = true;
                chk_F_25_6.Visible = true;
            }
            else
            {
                txt_F_6.Text = string.Empty;
                nud_F_6.Value = 1;
                txt_F_6.Visible = false;
                nud_F_6.Visible = false;
                chk_F_25_1.Checked = false;
                chk_F_25_2.Checked = false;
                chk_F_25_3.Checked = false;
                chk_F_25_4.Checked = false;
                chk_F_25_5.Checked = false;
                chk_F_25_6.Checked = false;
                chk_F_25_1.Visible = false;
                chk_F_25_2.Visible = false;
                chk_F_25_3.Visible = false;
                chk_F_25_4.Visible = false;
                chk_F_25_5.Visible = false;
                chk_F_25_6.Visible = false;
            }
        }
        private void chk_F_26_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_7.Checked)
            {
                txt_F_7.Visible = true;
                nud_F_7.Visible = true;
                chk_F_26_1.Visible = true;
                chk_F_26_2.Visible = true;
                chk_F_26_3.Visible = true;
                chk_F_26_4.Visible = true;
                chk_F_26_5.Visible = true;
                chk_F_26_6.Visible = true;
            }
            else
            {
                txt_F_7.Text = string.Empty;
                nud_F_7.Value = 1;
                txt_F_7.Visible = false;
                nud_F_7.Visible = false;
                chk_F_26_1.Checked = false;
                chk_F_26_2.Checked = false;
                chk_F_26_3.Checked = false;
                chk_F_26_4.Checked = false;
                chk_F_26_5.Checked = false;
                chk_F_26_6.Checked = false;
                chk_F_26_1.Visible = false;
                chk_F_26_2.Visible = false;
                chk_F_26_3.Visible = false;
                chk_F_26_4.Visible = false;
                chk_F_26_5.Visible = false;
                chk_F_26_6.Visible = false;
            }
        }
        private void chk_F_27_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_8.Checked)
            {
                txt_F_8.Visible = true;
                nud_F_8.Visible = true;
                chk_F_27_1.Visible = true;
                chk_F_27_2.Visible = true;
                chk_F_27_3.Visible = true;
                chk_F_27_4.Visible = true;
                chk_F_27_5.Visible = true;
                chk_F_27_6.Visible = true;
            }
            else
            {
                txt_F_8.Text = string.Empty;
                nud_F_8.Value = 1;
                txt_F_8.Visible = false;
                nud_F_8.Visible = false;
                chk_F_27_1.Checked = false;
                chk_F_27_2.Checked = false;
                chk_F_27_3.Checked = false;
                chk_F_27_4.Checked = false;
                chk_F_27_5.Checked = false;
                chk_F_27_6.Checked = false;
                chk_F_27_1.Visible = false;
                chk_F_27_2.Visible = false;
                chk_F_27_3.Visible = false;
                chk_F_27_4.Visible = false;
                chk_F_27_5.Visible = false;
                chk_F_27_6.Visible = false;
            }
        }
        private void chk_F_28_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_9.Checked)
            {
                txt_F_9.Visible = true;
                nud_F_9.Visible = true;
                chk_F_28_1.Visible = true;
                chk_F_28_2.Visible = true;
                chk_F_28_3.Visible = true;
                chk_F_28_4.Visible = true;
                chk_F_28_5.Visible = true;
                chk_F_28_6.Visible = true;
            }
            else
            {
                txt_F_9.Text = string.Empty;
                nud_F_9.Value = 1;
                txt_F_9.Visible = false;
                nud_F_9.Visible = false;
                chk_F_28_1.Checked = false;
                chk_F_28_2.Checked = false;
                chk_F_28_3.Checked = false;
                chk_F_28_4.Checked = false;
                chk_F_28_5.Checked = false;
                chk_F_28_6.Checked = false;
                chk_F_28_1.Visible = false;
                chk_F_28_2.Visible = false;
                chk_F_28_3.Visible = false;
                chk_F_28_4.Visible = false;
                chk_F_28_5.Visible = false;
                chk_F_28_6.Visible = false;
            }
        }
        private void chk_F_29_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_10.Checked)
            {
                txt_F_10.Visible = true;
                nud_F_10.Visible = true;
            }
            else
            {
                txt_F_10.Text = string.Empty;
                nud_F_10.Value = 1;
                txt_F_10.Visible = false;
                nud_F_10.Visible = false;
            }
        }
        private void chk_F_30_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_11.Checked)
            {
                txt_F_11.Visible = true;
                nud_F_11.Visible = true;
            }
            else
            {
                txt_F_11.Text = string.Empty;
                nud_F_11.Value = 1;
                txt_F_11.Visible = false;
                nud_F_11.Visible = false;
            }
        }
        private void chk_F_31_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_12.Checked)
            {
                txt_F_12.Visible = true;
                nud_F_12.Visible = true;
            }
            else
            {
                txt_F_12.Text = string.Empty;
                nud_F_12.Value = 1;
                txt_F_12.Visible = false;
                nud_F_12.Visible = false;
            }
        }
        private void chk_F_32_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_13.Checked)
            {
                txt_F_13.Visible = true;
                nud_F_13.Visible = true;
            }
            else
            {
                txt_F_13.Text = string.Empty;
                nud_F_13.Value = 1;
                txt_F_13.Visible = false;
                nud_F_13.Visible = false;
            }
        }
        private void chk_F_33_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_14.Checked)
            {
                txt_F_14.Visible = true;
                nud_F_14.Visible = true;
            }
            else
            {
                txt_F_14.Text = string.Empty;
                nud_F_14.Value = 1;
                txt_F_14.Visible = false;
                nud_F_14.Visible = false;
            }
        }
        private void chk_F_34_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_15.Checked)
            {
                txt_F_15.Visible = true;
                nud_F_15.Visible = true;
                grb_F_34_F.Visible = true;
                rdb_F_34_P_1.Visible = true;
                rdb_F_34_P_2.Visible = true;
                rdb_F_34_P_3.Visible = true;
                rdb_F_34_P_4.Visible = true;
                rdb_F_34_P_5.Visible = true;
                rdb_F_34_P_6.Visible = true;
            }
            else
            {
                txt_F_15.Text = string.Empty;
                nud_F_15.Value = 1;
                txt_F_15.Visible = false;
                nud_F_15.Visible = false;
                grb_F_34_F.Visible = true;
                rdb_F_34_P_1.Visible = false;
                rdb_F_34_P_2.Visible = false;
                rdb_F_34_P_3.Visible = false;
                rdb_F_34_P_4.Visible = false;
                rdb_F_34_P_5.Visible = false;
                rdb_F_34_P_6.Visible = false;
            }
        }
        private void chk_F_35_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_16.Checked)
            {
                lbl_F_35.Visible = true;
                nud_F_35_gr.Visible = true;
                txt_F_16.Visible = true;
                nud_F_16.Visible = true;
            }
            else
            {

                nud_F_35_gr.Value = 100;
                txt_F_16.Text = string.Empty;
                nud_F_16.Value = 1;
                txt_F_16.Visible = false;
                nud_F_16.Visible = false;
                lbl_F_35.Visible = false;
                nud_F_35_gr.Visible = false;
            }
        }
        private void chk_F_36_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_17.Checked)
            {
                txt_F_17.Visible = true;
                nud_F_17.Visible = true;
            }
            else
            {
                txt_F_17.Text = string.Empty;
                nud_F_17.Value = 1;
                txt_F_17.Visible = false;
                nud_F_17.Visible = false;
            }
        }
        private void chk_F_38_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_19.Checked)
            {
                txt_F_19.Visible = true;
                nud_F_19.Visible = true;
            }
            else
            {
                txt_F_19.Text = string.Empty;
                nud_F_19.Value = 1;
                txt_F_19.Visible = false;
                nud_F_19.Visible = false;
            }
        }
        private void chk_F_37_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_18.Checked)
            {
                txt_F_18.Visible = true;
                nud_F_18.Visible = true;
                chk_F_37_1.Visible = true;
                chk_F_37_2.Visible = true;
                chk_F_37_3.Visible = true;
                chk_F_37_4.Visible = true;
                chk_F_37_5.Visible = true;
                chk_F_37_6.Visible = true;
            }
            else
            {
                txt_F_18.Text = string.Empty;
                nud_F_18.Value = 1;
                txt_F_18.Visible = false;
                nud_F_18.Visible = false;
                chk_F_37_1.Checked = false;
                chk_F_37_2.Checked = false;
                chk_F_37_3.Checked = false;
                chk_F_37_4.Checked = false;
                chk_F_37_5.Checked = false;
                chk_F_37_6.Checked = false;
                chk_F_37_1.Visible = false;
                chk_F_37_2.Visible = false;
                chk_F_37_3.Visible = false;
                chk_F_37_4.Visible = false;
                chk_F_37_5.Visible = false;
                chk_F_37_6.Visible = false;
            }

        }
        private void chk_F_39_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_20.Checked)
            {
                txt_F_20.Visible = true;
                nud_F_20.Visible = true;
            }
            else
            {
                txt_F_20.Text = string.Empty;
                nud_F_20.Value = 1;
                txt_F_20.Visible = false;
                nud_F_20.Visible = false;
            }
        }
        private void chk_F_40_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_21.Checked)
            {
                txt_F_21.Visible = true;
                nud_F_21.Visible = true;
            }
            else
            {
                txt_F_21.Text = string.Empty;
                nud_F_21.Value = 1;
                txt_F_21.Visible = false;
                nud_F_21.Visible = false;
            }
        }
        private void chk_F_41_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_22.Checked)
            {
                txt_F_22.Visible = true;
                nud_F_22.Visible = true;
                chk_F_41_1.Visible = true;
                chk_F_41_2.Visible = true;
                chk_F_41_3.Visible = true;
                chk_F_41_4.Visible = true;
                chk_F_41_5.Visible = true;
                chk_F_41_6.Visible = true;
                grb_F_41_1.Visible = true;
                rdb_F_41_1.Visible = true;
                rdb_F_41_2.Visible = true;
            }
            else
            {
                txt_F_22.Text = string.Empty;
                nud_F_22.Value = 1;
                txt_F_22.Visible = false;
                nud_F_22.Visible = false;
                chk_F_41_1.Checked = false;
                chk_F_41_2.Checked = false;
                chk_F_41_3.Checked = false;
                chk_F_41_4.Checked = false;
                chk_F_41_5.Checked = false;
                chk_F_41_6.Checked = false;
                grb_F_41_1.Visible = false;
                rdb_F_41_1.Visible = false;
                rdb_F_41_2.Visible = false;
                rdb_F_41_1.Checked = false;
                rdb_F_41_2.Checked = false;
                chk_F_41_1.Visible = false;
                chk_F_41_2.Visible = false;
                chk_F_41_3.Visible = false;
                chk_F_41_4.Visible = false;
                chk_F_41_5.Visible = false;
                chk_F_41_6.Visible = false;


            }

        }
        private void chk_F_42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_24.Checked)
            {
                txt_F_24.Visible = true;
                nud_F_24.Visible = true;
            }
            else
            {
                txt_F_24.Text = string.Empty;
                nud_F_24.Value = 1;
                txt_F_24.Visible = false;
                nud_F_24.Visible = false;
            }
        }
        private void chk_F_43_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_25.Checked)
            {
                txt_F_25.Visible = true;
                nud_F_25.Visible = true;
            }
            else
            {
                txt_F_25.Text = string.Empty;
                nud_F_25.Value = 1;
                txt_F_25.Visible = false;
                nud_F_25.Visible = false;
            }
        }
        private void chk_F_44_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_26.Checked)
            {
                txt_F_26.Visible = true;
                nud_F_26.Visible = true;
            }
            else
            {
                txt_F_26.Text = string.Empty;
                nud_F_26.Value = 1;
                txt_F_26.Visible = false;
                nud_F_26.Visible = false;
            }
        }
        private void chk_F_45_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_27.Checked)
            {
                txt_F_27.Visible = true;
                nud_F_27.Visible = true;
            }
            else
            {
                txt_F_27.Text = string.Empty;
                nud_F_27.Value = 1;
                txt_F_27.Visible = false;
                nud_F_27.Visible = false;
            }
        }
        private void chk_F_46_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_28.Checked)
            {
                txt_F_28.Visible = true;
                nud_F_28.Visible = true;
            }
            else
            {
                txt_F_28.Text = string.Empty;
                nud_F_28.Value = 1;
                txt_F_28.Visible = false;
                nud_F_28.Visible = false;
            }
        }
        private void chk_F_47_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_29.Checked)
            {
                txt_F_29.Visible = true;
                nud_F_29.Visible = true;
            }
            else
            {
                txt_F_29.Text = string.Empty;
                nud_F_29.Value = 1;
                txt_F_29.Visible = false;
                nud_F_29.Visible = false;
            }
        }
        private void chk_F_48_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_30.Checked)
            {
                txt_F_30.Visible = true;
                nud_F_30.Visible = true;
            }
            else
            {
                txt_F_30.Text = string.Empty;
                nud_F_30.Value = 1;
                txt_F_30.Visible = false;
                nud_F_30.Visible = false;
            }
        }
        private void chk_F_49_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_31.Checked)
            {
                txt_F_31.Visible = true;
                nud_F_31.Visible = true;
            }
            else
            {
                txt_F_31.Text = string.Empty;
                nud_F_31.Value = 1;
                txt_F_31.Visible = false;
                nud_F_31.Visible = false;
            }
        }
        private void chk_F_50_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_32.Checked)
            {
                txt_F_32.Visible = true;
                nud_F_32.Visible = true;
            }
            else
            {
                txt_F_32.Text = string.Empty;
                nud_F_32.Value = 1;
                txt_F_32.Visible = false;
                nud_F_32.Visible = false;
            }
        }
        private void chk_F_51_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_33.Checked)
            {
                txt_F_33.Visible = true;
                nud_F_33.Visible = true;
            }
            else
            {
                txt_F_33.Text = string.Empty;
                nud_F_33.Value = 1;
                txt_F_33.Visible = false;
                nud_F_33.Visible = false;
            }
        }
        private void chk_F_82_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_F_23.Checked)
            {
                txt_F_23.Visible = true;
                nud_F_23.Visible = true;
            }
            else
            {
                txt_F_23.Text = string.Empty;
                nud_F_23.Value = 1;
                txt_F_23.Visible = false;
                nud_F_23.Visible = false;
            }
        }


        //CheckBox de Menú infantil
        private void chk_I_42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_I_1.Checked)
            {
                nud_I_1.Visible = true;
                txt_I_1.Visible = true;
            }
            else
            {
                txt_I_1.Text = string.Empty;
                txt_I_1.Visible = false;
                nud_I_1.Visible = false;
                nud_I_1.Value = 1;
            }
        }
        private void chk_I_43_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_I_2.Checked)
            {
                nud_I_2.Visible = true;
                txt_I_2.Visible = true;
            }
            else
            {
                txt_I_2.Text = string.Empty;
                txt_I_2.Visible = false;
                nud_I_2.Visible = false;
                nud_I_2.Value = 1;
            }
        }
        private void chk_I_44_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_I_3.Checked)
            {
                nud_I_3.Visible = true;
                txt_I_3.Visible = true;
                grb_I_44_H.Visible = true;
                rdb_I_44_1.Visible = true;
                rdb_I_44_2.Visible = true;
                rdb_I_44_3.Visible = true;
            }
            else
            {
                txt_I_3.Text = string.Empty;
                txt_I_3.Visible = false;
                nud_I_3.Visible = false;
                nud_I_3.Value = 1;
                grb_I_44_H.Visible = false;
                rdb_I_44_1.Visible = false;
                rdb_I_44_2.Visible = false;
                rdb_I_44_3.Visible = false;
            }
        }


        //CheckBox de Postres
        private void chk_P_45_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_P_1.Checked)
            {
                txt_P_1.Visible = true;
                nud_P_1.Visible = true;
            }
            else
            {
                txt_P_1.Text = string.Empty;
                nud_P_1.Value = 1;
                txt_P_1.Visible = false;
                nud_P_1.Visible = false;
            }
        }
        private void chk_P_46_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_P_2.Checked)
            {
                txt_P_2.Visible = true;
                nud_P_2.Visible = true;
            }
            else
            {
                txt_P_2.Text = string.Empty;
                nud_P_2.Value = 1;
                txt_P_2.Visible = false;
                nud_P_2.Visible = false;
            }
        }
        private void chk_P_47_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_P_3.Checked)
            {
                txt_P_3.Visible = true;
                nud_P_3.Visible = true;
            }
            else
            {
                txt_P_3.Text = string.Empty;
                nud_P_3.Value = 1;
                txt_P_3.Visible = false;
                nud_P_3.Visible = false;
            }
        }
        private void chk_P_48_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_P_4.Checked)
            {
                txt_P_4.Visible = true;
                nud_P_4.Visible = true;
            }
            else
            {
                txt_P_4.Text = string.Empty;
                nud_P_4.Value = 1;
                txt_P_4.Visible = false;
                nud_P_4.Visible = false;
            }
        }
        private void chk_P_49_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_P_5.Checked)
            {
                txt_P_5.Visible = true;
                nud_P_5.Visible = true;
            }
            else
            {
                txt_P_5.Text = string.Empty;
                nud_P_5.Value = 1;
                txt_P_5.Visible = false;
                nud_P_5.Visible = false;
            }
        }

        //CheckBoxs de Paquetes
        private void chk_P_64_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_1.Checked)
            {
                txt_C_1.Visible = true;
                nud_C_1.Visible = true;
            }
            else
            {
                txt_C_1.Text = string.Empty;
                nud_C_1.Value = 1;
                txt_C_1.Visible = false;
                nud_C_1.Visible = false;
            }
        }
        private void chk_P_65_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_2.Checked)
            {
                txt_C_2.Visible = true;
                nud_C_2.Visible = true;
            }
            else
            {
                txt_C_2.Text = string.Empty;
                nud_C_2.Value = 1;
                txt_C_2.Visible = false;
                nud_C_2.Visible = false;
            }
        }
        private void chk_P_66_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_3.Checked)
            {
                txt_C_3.Visible = true;
                nud_C_3.Visible = true;
            }
            else
            {
                txt_C_3.Text = string.Empty;
                nud_C_3.Value = 1;
                txt_C_3.Visible = false;
                nud_C_3.Visible = false;
            }
        }
        private void chk_P_67_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_5.Checked)
            {
                txt_C_5.Visible = true;
                nud_C_5.Visible = true;
            }
            else
            {
                txt_C_5.Text = string.Empty;
                nud_C_5.Value = 1;
                txt_C_5.Visible = false;
                nud_C_5.Visible = false;
            }
        }
        private void chk_P_68_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_6.Checked)
            {
                txt_C_6.Visible = true;
                nud_C_6.Visible = true;
            }
            else
            {
                txt_C_6.Text = string.Empty;
                nud_C_6.Value = 1;
                txt_C_6.Visible = false;
                nud_C_6.Visible = false;
            }
        }
        private void chk_P_66_1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_4.Checked)
            {
                txt_C_4.Visible = true;
                nud_C_4.Visible = true;
            }
            else
            {
                txt_C_4.Text = string.Empty;
                nud_C_4.Value = 1;
                txt_C_4.Visible = false;
                nud_C_4.Visible = false;
            }
        }
        private void chk_P_68_1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_7.Checked)
            {
                txt_C_7.Visible = true;
                nud_C_7.Visible = true;
            }
            else
            {
                txt_C_7.Text = string.Empty;
                nud_C_7.Value = 1;
                txt_C_7.Visible = false;
                nud_C_7.Visible = false;
            }
        }
        private void chk_P_69_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_8.Checked)
            {
                txt_C_8.Visible = true;
                nud_C_8.Visible = true;
            }
            else
            {
                txt_C_8.Text = string.Empty;
                nud_C_8.Value = 1;
                txt_C_8.Visible = false;
                nud_C_8.Visible = false;
            }
        }
        private void chk_P_70_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_C_9.Checked)
            {
                txt_C_9.Visible = true;
                nud_C_9.Visible = true;
            }
            else
            {
                txt_C_9.Text = string.Empty;
                nud_C_9.Value = 1;
                txt_C_9.Visible = false;
                nud_C_9.Visible = false;
            }
        }

        //CheckBox de Bebidas
        private void chk_B_50_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_1.Checked)
            {
                txt_B_1.Visible = true;
                nud_B_1.Visible = true;
            }
            else
            {
                txt_B_1.Text = string.Empty;
                nud_B_1.Value = 1;
                txt_B_1.Visible = false;
                nud_B_1.Visible = false;
            }
        }
        private void chk_B_51_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_2.Checked)
            {
                txt_B_2.Visible = true;
                nud_B_2.Visible = true;
            }
            else
            {
                txt_B_2.Text = string.Empty;
                nud_B_2.Value = 1;
                txt_B_2.Visible = false;
                nud_B_2.Visible = false;
            }
        }
        private void chk_B_52_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_3.Checked)
            {
                txt_B_3.Visible = true;
                nud_B_3.Visible = true;
            }
            else
            {
                txt_B_3.Text = string.Empty;
                nud_B_3.Value = 1;
                txt_B_3.Visible = false;
                nud_B_3.Visible = false;
            }

        }
        private void chk_B_53_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_4.Checked)
            {
                txt_B_4.Visible = true;
                nud_B_4.Visible = true;
            }
            else
            {
                txt_B_4.Text = string.Empty;
                nud_B_4.Value = 1;
                txt_B_4.Visible = false;
                nud_B_4.Visible = false;
            }
        }
        private void chk_B_54_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_5.Checked)
            {
                txt_B_5.Visible = true;
                nud_B_5.Visible = true;
            }
            else
            {
                txt_B_5.Text = string.Empty;
                nud_B_5.Value = 1;
                txt_B_5.Visible = false;
                nud_B_5.Visible = false;
            }
        }
        private void chk_B_55_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_6.Checked)
            {
                txt_B_6.Visible = true;
                nud_B_6.Visible = true;
            }
            else
            {
                txt_B_6.Text = string.Empty;
                nud_B_6.Value = 1;
                txt_B_6.Visible = false;
                nud_B_6.Visible = false;
            }
        }
        private void chk_B_56_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_7.Checked)
            {
                txt_B_7.Visible = true;
                nud_B_7.Visible = true;
            }
            else
            {
                txt_B_7.Text = string.Empty;
                nud_B_7.Value = 1;
                txt_B_7.Visible = false;
                nud_B_7.Visible = false;
            }
        }
        private void chk_B_57_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_8.Checked)
            {
                txt_B_8.Visible = true;
                nud_B_8.Visible = true;
            }
            else
            {
                txt_B_8.Text = string.Empty;
                nud_B_8.Value = 1;
                txt_B_8.Visible = false;
                nud_B_8.Visible = false;
            }
        }
        private void chk_B_58_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_9.Checked)
            {
                txt_B_9.Visible = true;
                nud_B_9.Visible = true;
            }
            else
            {
                txt_B_9.Text = string.Empty;
                nud_B_9.Value = 1;
                txt_B_9.Visible = false;
                nud_B_9.Visible = false;
            }
        }
        private void chk_B_59_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_10.Checked)
            {
                txt_B_10.Visible = true;
                nud_B_10.Visible = true;
            }
            else
            {
                txt_B_10.Text = string.Empty;
                nud_B_10.Value = 1;
                txt_B_10.Visible = false;
                nud_B_10.Visible = false;
            }
        }
        private void chk_B_60_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_11.Checked)
            {
                txt_B_11.Visible = true;
                nud_B_11.Visible = true;
            }
            else
            {
                txt_B_11.Text = string.Empty;
                nud_B_11.Value = 1;
                txt_B_11.Visible = false;
                nud_B_11.Visible = false;
            }
        }
        private void chk_B_61_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_12.Checked)
            {
                txt_B_12.Visible = true;
                nud_B_12.Visible = true;
            }
            else
            {
                txt_B_12.Text = string.Empty;
                nud_B_12.Value = 1;
                txt_B_12.Visible = false;
                nud_B_12.Visible = false;
            }
        }
        private void chk_B_62_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_13.Checked)
            {
                txt_B_13.Visible = true;
                nud_B_13.Visible = true;
            }
            else
            {
                txt_B_13.Text = string.Empty;
                nud_B_13.Value = 1;
                txt_B_13.Visible = false;
                nud_B_13.Visible = false;
            }
        }
        private void chk_B_63_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_14.Checked)
            {
                txt_B_14.Visible = true;
                nud_B_14.Visible = true;
            }
            else
            {
                txt_B_14.Text = string.Empty;
                nud_B_14.Value = 1;
                txt_B_14.Visible = false;
                nud_B_14.Visible = false;
            }
        }
        private void chk_B_64_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_15.Checked)
            {
                txt_B_15.Visible = true;
                nud_B_15.Visible = true;
            }
            else
            {
                txt_B_15.Text = string.Empty;
                nud_B_15.Value = 1;
                txt_B_15.Visible = false;
                nud_B_15.Visible = false;
            }
        }
        private void chk_B_65_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_16.Checked)
            {
                txt_B_16.Visible = true;
                nud_B_16.Visible = true;
            }
            else
            {
                txt_B_16.Text = string.Empty;
                nud_B_16.Value = 1;
                txt_B_16.Visible = false;
                nud_B_16.Visible = false;
            }
        }
        private void chk_B_66_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_17.Checked)
            {
                txt_B_17.Visible = true;
                nud_B_17.Visible = true;
            }
            else
            {
                txt_B_17.Text = string.Empty;
                nud_B_17.Value = 1;
                txt_B_17.Visible = false;
                nud_B_17.Visible = false;
            }
        }
        private void chk_B_67_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_18.Checked)
            {
                txt_B_18.Visible = true;
                nud_B_18.Visible = true;
            }
            else
            {
                txt_B_18.Text = string.Empty;
                nud_B_18.Value = 1;
                txt_B_18.Visible = false;
                nud_B_18.Visible = false;
            }
        }
        private void chk_B_68_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_19.Checked)
            {
                txt_B_19.Visible = true;
                nud_B_19.Visible = true;
            }
            else
            {
                txt_B_19.Text = string.Empty;
                nud_B_19.Value = 1;
                txt_B_19.Visible = false;
                nud_B_19.Visible = false;
            }
        }
        private void chk_B_69_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_20.Checked)
            {
                txt_B_20.Visible = true;
                nud_B_20.Visible = true;
            }
            else
            {
                txt_B_20.Text = string.Empty;
                nud_B_20.Value = 1;
                txt_B_20.Visible = false;
                nud_B_20.Visible = false;
            }
        }
        private void chk_B_70_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_21.Checked)
            {
                txt_B_21.Visible = true;
                nud_B_21.Visible = true;
            }
            else
            {
                txt_B_21.Text = string.Empty;
                nud_B_21.Value = 1;
                txt_B_21.Visible = false;
                nud_B_21.Visible = false;
            }
        }
        private void chk_B_71_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_22.Checked)
            {
                txt_B_22.Visible = true;
                nud_B_22.Visible = true;
            }
            else
            {
                txt_B_22.Text = string.Empty;
                nud_B_22.Value = 1;
                txt_B_22.Visible = false;
                nud_B_22.Visible = false;
            }
        }
        private void chk_B_72_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_23.Checked)
            {
                txt_B_23.Visible = true;
                nud_B_23.Visible = true;
            }
            else
            {
                txt_B_23.Text = string.Empty;
                nud_B_23.Value = 1;
                txt_B_23.Visible = false;
                nud_B_23.Visible = false;
            }
        }
        private void chk_B_73_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_B_24.Checked)
            {
                txt_B_24.Visible = true;
                nud_B_24.Visible = true;
            }
            else
            {
                txt_B_24.Text = string.Empty;
                nud_B_24.Value = 1;
                txt_B_24.Visible = false;
                nud_B_24.Visible = false;
            }
        }

        //CheckBox de Licores
        private void chk_L_69_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_1.Checked)
            {
                txt_L_1.Visible = true;
                nud_L_1.Visible = true;
            }
            else
            {
                txt_L_1.Text = string.Empty;
                nud_L_1.Value = 1;
                txt_L_1.Visible = false;
                nud_L_1.Visible = false;
            }
        }
        private void chk_L_70_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_2.Checked)
            {
                txt_L_2.Visible = true;
                nud_L_2.Visible = true;
            }
            else
            {
                txt_L_2.Text = string.Empty;
                nud_L_2.Value = 1;
                txt_L_2.Visible = false;
                nud_L_2.Visible = false;
            }
        }
        private void chk_L_71_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_3.Checked)
            {
                txt_L_3.Visible = true;
                nud_L_3.Visible = true;
            }
            else
            {
                txt_L_3.Text = string.Empty;
                nud_L_3.Value = 1;
                txt_L_3.Visible = false;
                nud_L_3.Visible = false;
            }
        }
        private void chk_L_72_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_4.Checked)
            {
                txt_L_4.Visible = true;
                nud_L_4.Visible = true;
            }
            else
            {
                txt_L_4.Text = string.Empty;
                nud_L_4.Value = 1;
                txt_L_4.Visible = false;
                nud_L_4.Visible = false;
            }
        }
        private void chk_L_73_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_5.Checked)
            {
                txt_L_5.Visible = true;
                nud_L_5.Visible = true;
            }
            else
            {
                txt_L_5.Text = string.Empty;
                nud_L_5.Value = 1;
                txt_L_5.Visible = false;
                nud_L_5.Visible = false;
            }
        }
        private void chk_L_74_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_6.Checked)
            {
                txt_L_6.Visible = true;
                nud_L_6.Visible = true;
            }
            else
            {
                txt_L_6.Text = string.Empty;
                nud_L_6.Value = 1;
                txt_L_6.Visible = false;
                nud_L_6.Visible = false;
            }
        }
        private void chk_L_75_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_7.Checked)
            {
                txt_L_7.Visible = true;
                nud_L_7.Visible = true;
            }
            else
            {
                txt_L_7.Text = string.Empty;
                nud_L_7.Value = 1;
                txt_L_7.Visible = false;
                nud_L_7.Visible = false;
            }
        }
        private void chk_L_76_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_8.Checked)
            {
                txt_L_8.Visible = true;
                nud_L_8.Visible = true;
            }
            else
            {
                txt_L_8.Text = string.Empty;
                nud_L_8.Value = 1;
                txt_L_8.Visible = false;
                nud_L_8.Visible = false;
            }
        }
        private void chk_L_77_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_9.Checked)
            {
                txt_L_9.Visible = true;
                nud_L_9.Visible = true;
            }
            else
            {
                txt_L_9.Text = string.Empty;
                nud_L_9.Value = 1;
                txt_L_9.Visible = false;
                nud_L_9.Visible = false;
            }
        }
        private void chk_L_78_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_10.Checked)
            {
                txt_L_10.Visible = true;
                nud_L_10.Visible = true;
            }
            else
            {
                txt_L_10.Text = string.Empty;
                nud_L_10.Value = 1;
                txt_L_10.Visible = false;
                nud_L_10.Visible = false;
            }
        }
        private void chk_L_80_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_11.Checked)
            {
                txt_L_11.Visible = true;
                nud_L_11.Visible = true;
            }
            else
            {
                txt_L_11.Text = string.Empty;
                nud_L_11.Value = 1;
                txt_L_11.Visible = false;
                nud_L_11.Visible = false;
            }
        }
        private void chk_L_81_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_12.Checked)
            {
                txt_L_12.Visible = true;
                nud_L_12.Visible = true;
            }
            else
            {
                txt_L_12.Text = string.Empty;
                nud_L_12.Value = 1;
                txt_L_12.Visible = false;
                nud_L_12.Visible = false;
            }
        }
        private void chk_L_82_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_13.Checked)
            {
                txt_L_13.Visible = true;
                nud_L_13.Visible = true;
            }
            else
            {
                txt_L_13.Text = string.Empty;
                nud_L_13.Value = 1;
                txt_L_13.Visible = false;
                nud_L_13.Visible = false;
            }
        }
        private void chk_L_83_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_14.Checked)
            {
                txt_L_14.Visible = true;
                nud_L_14.Visible = true;
            }
            else
            {
                txt_L_14.Text = string.Empty;
                nud_L_14.Value = 1;
                txt_L_14.Visible = false;
                nud_L_14.Visible = false;
            }
        }
        private void chk_L_84_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_15.Checked)
            {
                txt_L_15.Visible = true;
                nud_L_15.Visible = true;
            }
            else
            {
                txt_L_15.Text = string.Empty;
                nud_L_15.Value = 1;
                txt_L_15.Visible = false;
                nud_L_15.Visible = false;
            }
        }
        private void chk_L_85_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_16.Checked)
            {
                txt_L_16.Visible = true;
                nud_L_16.Visible = true;
            }
            else
            {
                txt_L_16.Text = string.Empty;
                nud_L_16.Value = 1;
                txt_L_16.Visible = false;
                nud_L_16.Visible = false;
            }
        }
        private void chk_L_86_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_17.Checked)
            {
                txt_L_17.Visible = true;
                nud_L_17.Visible = true;
            }
            else
            {
                txt_L_17.Text = string.Empty;
                nud_L_17.Value = 1;
                txt_L_17.Visible = false;
                nud_L_17.Visible = false;
            }
        }
        private void chk_L_87_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_18.Checked)
            {
                txt_L_18.Visible = true;
                nud_L_18.Visible = true;
            }
            else
            {
                txt_L_18.Text = string.Empty;
                nud_L_18.Value = 1;
                txt_L_18.Visible = false;
                nud_L_18.Visible = false;
            }
        }
        private void chk_L_88_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_19.Checked)
            {
                txt_L_19.Visible = true;
                nud_L_19.Visible = true;
            }
            else
            {
                txt_L_19.Text = string.Empty;
                nud_L_19.Value = 1;
                txt_L_19.Visible = false;
                nud_L_19.Visible = false;
            }
        }
        private void chk_L_89_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_20.Checked)
            {
                txt_L_20.Visible = true;
                nud_L_20.Visible = true;
            }
            else
            {
                txt_L_20.Text = string.Empty;
                nud_L_20.Value = 1;
                txt_L_20.Visible = false;
                nud_L_20.Visible = false;
            }
        }
        private void chk_L_90_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_21.Checked)
            {
                txt_L_21.Visible = true;
                nud_L_21.Visible = true;
            }
            else
            {
                txt_L_21.Text = string.Empty;
                nud_L_21.Value = 1;
                txt_L_21.Visible = false;
                nud_L_21.Visible = false;
            }
        }
        private void chk_L_91_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_22.Checked)
            {
                txt_L_22.Visible = true;
                nud_L_22.Visible = true;
            }
            else
            {
                txt_L_22.Text = string.Empty;
                nud_L_22.Value = 1;
                txt_L_22.Visible = false;
                nud_L_22.Visible = false;
            }
        }

        //CheckBox Promociones
        private void chk_P_86_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_4.Checked)
            {
                nud_O_4.Visible = true;
                txt_O_4.Visible = true;
            }
            else
            {
                txt_O_4.Visible = false;
                nud_O_4.Visible = false;
                nud_O_4.Value = 1;
                txt_O_4.Text = string.Empty;
            }
        }
        private void chk_P_83_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_1.Checked)
            {
                nud_O_1.Visible = true;
                txt_O_1.Visible = true;
            }
            else
            {
                txt_O_1.Visible = false;
                nud_O_1.Visible = false;
                nud_O_1.Value = 1;
                txt_O_1.Text = string.Empty;
            }
        }

        private void chk_P_84_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_2.Checked)
            {
                nud_O_2.Visible = true;
                txt_O_2.Visible = true;
            }
            else
            {
                txt_O_2.Visible = false;
                nud_O_2.Visible = false;
                nud_O_2.Value = 1;
                txt_O_2.Text = string.Empty;
            }
        }

        private void chk_P_85_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_3.Checked)
            {
                nud_O_3.Visible = true;
                txt_O_3.Visible = true;
            }
            else
            {
                txt_O_3.Visible = false;
                nud_O_3.Visible = false;
                nud_O_3.Value = 1;
                txt_O_3.Text = string.Empty;
            }
        }
        private void chk_P_87_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_5.Checked)
            {
                nud_O_5.Visible = true;
                txt_O_5.Visible = true;
            }
            else
            {
                txt_O_5.Visible = false;
                nud_O_5.Visible = false;
                nud_O_5.Value = 1;
                txt_O_5.Text = string.Empty;
            }
        }

        private void chk_P_88_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_6.Checked)
            {
                nud_O_6.Visible = true;
                txt_O_6.Visible = true;
            }
            else
            {
                txt_O_6.Visible = false;
                nud_O_6.Visible = false;
                nud_O_6.Value = 1;
                txt_O_6.Text = string.Empty;
            }
        }

        private void chk_P_89_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_7.Checked)
            {
                nud_O_7.Visible = true;
                txt_O_7.Visible = true;
            }
            else
            {
                txt_O_7.Visible = false;
                nud_O_7.Visible = false;
                nud_O_7.Value = 1;
                txt_O_7.Text = string.Empty;
            }
        }

        private void chk_P_90_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_8.Checked)
            {
                nud_O_8.Visible = true;
                txt_O_8.Visible = true;
            }
            else
            {
                txt_O_8.Visible = false;
                nud_O_8.Visible = false;
                nud_O_8.Value = 1;
                txt_O_8.Text = string.Empty;
            }
        }

        private void chk_P_91_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_O_9.Checked)
            {
                nud_O_9.Visible = true;
                txt_O_9.Visible = true;
            }
            else
            {
                txt_O_9.Visible = false;
                nud_O_9.Visible = false;
                nud_O_9.Value = 1;
                txt_O_9.Text = string.Empty;
            }
        }


        decimal Total = 0;
        private void tbc_punto_venta_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpecialComponents();
            switch (tbc_punto_venta.SelectedIndex)
            {
                case 0:
                    SortComponents('E', 1, 29);
                    break;
                case 1:
                    SortComponents('F', 1, 33);
                    break;
                case 2:
                    SortComponents('I', 1, 3);
                    break;
                case 3:
                    SortComponents('B', 1, 24);
                    break;
                case 4:
                    SortComponents('L', 1, 22);
                    break;
                case 5:
                    SortComponents('P', 1, 5);
                    break;
                case 6:
                    SortComponents('O', 1, 9);
                    break;
                case 7:
                    SortComponents('C', 1, 7);
                    break;

            }
        }

        private void ManejarCheckBox(System.Windows.Forms.TextBox textBox, CheckBox checkBox, NumericUpDown numericUpDown, int id, List<CheckBox> checkBoxes, List<RadioButton> radioButtons)
        {
            if (checkBox.Checked)
            {
                string textToAdd = $"{numericUpDown.Value}x {checkBox.Text}(";

                if (checkBoxes != null && checkBoxes.Any(c => c.Checked))
                {
                    var checkedCheckBoxes = checkBoxes.Where(c => c.Checked);

                    foreach (var chk in checkedCheckBoxes)
                    {
                        textToAdd += chk.Text + ", ";
                    }
                }

                if (radioButtons != null && radioButtons.Any(r => r.Checked))
                {
                    var selectedRadioButton = radioButtons.FirstOrDefault(r => r.Checked);

                    if (selectedRadioButton != null)
                    {
                        textToAdd += selectedRadioButton.Text;
                    }
                }

                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    textToAdd += ", " + textBox.Text + ")";
                }
                else
                {
                    // Elimina la última coma y espacio
                    textToAdd = textToAdd.TrimEnd(' ', ',') + ")";
                }

                // Detectar letras designadas en el nombre del checkbox
                char[] letrasDesignadas = { 'E', 'F', 'B', 'L', 'P', 'O', 'C', 'I' };
                char checkboxLetra = checkBox.Name.FirstOrDefault(c => letrasDesignadas.Contains(c));

                if (checkboxLetra != '\0')
                {
                    string categoria = "";

                    // Mapear la letra a la categoría correspondiente
                    switch (checkboxLetra)
                    {
                        case 'E':
                            categoria = "Entradas";
                            break;
                        case 'F':
                            categoria = "Fuertes";
                            break;
                        case 'B':
                            categoria = "Bebidas";
                            break;
                        case 'L':
                            categoria = "Licores";
                            break;
                        case 'P':
                            categoria = "Postres";
                            break;
                        case 'O':
                            categoria = "Promociones";
                            break;
                        case 'C':
                            categoria = "Paquetes";
                            break;
                        case 'I':
                            categoria = "Infantil";
                            break;
                        default:
                            break;
                    }

                    using (OleDbCommand command = new OleDbCommand($"SELECT Precio FROM {categoria} WHERE id = {id}", conexion))
                    {
                        comida.Add($"{textToAdd}:{Convert.ToInt32(command.ExecuteScalar()) * Convert.ToInt32(numericUpDown.Value)}");
                        Total = (Convert.ToInt32(command.ExecuteScalar()) * Convert.ToInt32(numericUpDown.Value)) + Total;
                        checkBox.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("El nombre del checkbox no contiene ninguna letra designada.");
                }
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            List<List<CheckBox>> ListaDeCheckBoxs = new List<List<CheckBox>>();
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_20_1, chk_F_20_2, chk_F_20_3, chk_F_20_4, chk_F_20_5, chk_F_20_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_21_1, chk_F_21_2, chk_F_21_3, chk_F_21_4, chk_F_21_5, chk_F_21_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_22_1, chk_F_22_2, chk_F_22_3, chk_F_22_4, chk_F_22_5, chk_F_22_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_23_1, chk_F_23_2, chk_F_23_3, chk_F_23_4, chk_F_23_5, chk_F_23_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_24_1, chk_F_24_2, chk_F_24_3, chk_F_24_4, chk_F_24_5, chk_F_24_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_25_1, chk_F_25_2, chk_F_25_3, chk_F_25_4, chk_F_25_5, chk_F_25_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_26_1, chk_F_26_2, chk_F_26_3, chk_F_26_4, chk_F_26_5, chk_F_26_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_27_1, chk_F_27_2, chk_F_27_3, chk_F_27_4, chk_F_27_5, chk_F_27_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_28_1, chk_F_28_2, chk_F_28_3, chk_F_28_4, chk_F_28_5, chk_F_28_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_37_1, chk_F_37_2, chk_F_37_3, chk_F_37_4, chk_F_37_5, chk_F_37_6 });
            ListaDeCheckBoxs.Add(new List<CheckBox> { chk_F_41_1, chk_F_41_2, chk_F_41_3, chk_F_41_4, chk_F_41_5, chk_F_41_6 });
            List<List<RadioButton>> ListaDeRadioButtons = new List<List<RadioButton>>();
            ListaDeRadioButtons.Add(new List<RadioButton> { rdb_E_N_12, rdb_E_R_12, rdb_E_V_12 });
            ListaDeRadioButtons.Add(new List<RadioButton> { rdb_E_N_13, rdb_E_R_13, rdb_E_V_13 });
            ListaDeRadioButtons.Add(new List<RadioButton> { rdb_F_34_P_1, rdb_F_34_P_2, rdb_F_34_P_3, rdb_F_34_P_4, rdb_F_34_P_5, rdb_F_34_P_6 });
            ListaDeRadioButtons.Add(new List<RadioButton> { rdb_I_44_1, rdb_I_44_2, rdb_I_44_3 });

            //Agregar Entradas
            ManejarCheckBox(txt_E_1, chk_E_1, nud_E_1, 1, null, null);
            ManejarCheckBox(txt_E_2, chk_E_2, nud_E_2, 2, null, null);
            ManejarCheckBox(txt_E_3, chk_E_3, nud_E_3, 3, null, null);
            ManejarCheckBox(txt_E_4, chk_E_4, nud_E_4, 4, null, null);
            ManejarCheckBox(txt_E_5, chk_E_5, nud_E_5, 5, null, null);
            ManejarCheckBox(txt_E_6, chk_E_6, nud_E_6, 6, null, null);
            ManejarCheckBox(txt_E_7, chk_E_7, nud_E_7, 7, null, null);
            ManejarCheckBox(txt_E_8, chk_E_8, nud_E_8, 8, null, null);
            ManejarCheckBox(txt_E_9, chk_E_9, nud_E_9, 9, null, null);
            ManejarCheckBox(txt_E_10, chk_E_10, nud_E_10, 10, null, null);
            ManejarCheckBox(txt_E_11, chk_E_11, nud_E_11, 11, null, null);
            ManejarCheckBox(txt_E_12, chk_E_12, nud_E_12, 12, null, ListaDeRadioButtons[0]);
            ManejarCheckBox(txt_E_13, chk_E_13, nud_E_12, 13, null, ListaDeRadioButtons[1]);
            ManejarCheckBox(txt_E_14, chk_E_14, nud_E_14, 14, null, null);
            ManejarCheckBox(txt_E_15, chk_E_15, nud_E_15, 15, null, null);
            ManejarCheckBox(txt_E_16, chk_E_16, nud_E_16, 16, null, null);
            ManejarCheckBox(txt_E_17, chk_E_17, nud_E_17, 17, null, null);
            ManejarCheckBox(txt_E_18, chk_E_18, nud_E_18, 18, null, null);
            ManejarCheckBox(txt_E_19, chk_E_19, nud_E_19, 19, null, null);
            ManejarCheckBox(txt_E_20, chk_E_20, nud_E_20, 20, null, null);
            ManejarCheckBox(txt_E_21, chk_E_21, nud_E_21, 21, null, null);
            ManejarCheckBox(txt_E_22, chk_E_22, nud_E_22, 22, null, null);
            ManejarCheckBox(txt_E_23, chk_E_23, nud_E_23, 23, null, null);
            ManejarCheckBox(txt_E_24, chk_E_24, nud_E_24, 24, null, null);
            ManejarCheckBox(txt_E_25, chk_E_25, nud_E_25, 25, null, null);
            ManejarCheckBox(txt_E_26, chk_E_26, nud_E_26, 26, null, null);
            ManejarCheckBox(txt_E_27, chk_E_27, nud_E_27, 27, null, null);
            ManejarCheckBox(txt_E_28, chk_E_28, nud_E_28, 28, null, null);
            ManejarCheckBox(txt_E_29, chk_E_29, nud_E_29, 29, null, null);

            //Agregar Fuertes
            ManejarCheckBox(txt_F_1, chk_F_1, nud_F_1, 1, ListaDeCheckBoxs[0], null);
            ManejarCheckBox(txt_F_2, chk_F_2, nud_F_2, 2, ListaDeCheckBoxs[1], null);
            ManejarCheckBox(txt_F_3, chk_F_3, nud_F_3, 3, ListaDeCheckBoxs[2], null);
            ManejarCheckBox(txt_F_4, chk_F_4, nud_F_4, 4, ListaDeCheckBoxs[3], null);
            ManejarCheckBox(txt_F_5, chk_F_5, nud_F_5, 5, ListaDeCheckBoxs[4], null);
            ManejarCheckBox(txt_F_6, chk_F_6, nud_F_6, 6, ListaDeCheckBoxs[5], null);
            ManejarCheckBox(txt_F_7, chk_F_7, nud_F_7, 7, ListaDeCheckBoxs[6], null);
            ManejarCheckBox(txt_F_8, chk_F_8, nud_F_8, 8, ListaDeCheckBoxs[7], null);
            ManejarCheckBox(txt_F_9, chk_F_9, nud_F_9, 9, ListaDeCheckBoxs[8], null);
            ManejarCheckBox(txt_F_10, chk_F_10, nud_F_10, 10, null, null);
            ManejarCheckBox(txt_F_11, chk_F_11, nud_F_11, 11, null, null);
            ManejarCheckBox(txt_F_12, chk_F_12, nud_F_12, 12, null, null);
            ManejarCheckBox(txt_F_13, chk_F_13, nud_F_13, 13, null, null);
            ManejarCheckBox(txt_F_14, chk_F_14, nud_F_14, 14, null, null);
            ManejarCheckBox(txt_F_15, chk_F_15, nud_F_15, 15, null, ListaDeRadioButtons[2]);
            if (chk_F_16.Checked)
            {
                decimal precio;
                precio = Convert.ToDecimal(nud_F_35_gr.Value) / 1000;
                if (txt_F_16.Text == string.Empty)
                    comanda.Add(nud_F_16.Value + "x " + chk_F_16.Text);
                else
                    comanda.Add(nud_F_16.Value + "x " + chk_F_16.Text + "(" + txt_F_16.Text + ")");
                OleDbCommand comand = new OleDbCommand("Select Precio FROM Fuertes Where id=16", conexion);
                comida.Add(nud_F_16.Value + "x " + chk_F_16.Text + ":" + (Convert.ToDecimal(comand.ExecuteScalar()) * precio) * Convert.ToInt32(nud_F_16.Value));
                Total = Convert.ToDecimal((Convert.ToDecimal(comand.ExecuteScalar()) * precio) * Convert.ToInt32(nud_F_16.Value)) + Total;
                chk_F_16.Checked = false;
            }
            ManejarCheckBox(txt_F_17, chk_F_17, nud_F_17, 17, null, null);
            ManejarCheckBox(txt_F_18, chk_F_18, nud_F_18, 18, ListaDeCheckBoxs[9], null);
            ManejarCheckBox(txt_F_19, chk_F_19, nud_F_19, 19, null, null);
            ManejarCheckBox(txt_F_20, chk_F_20, nud_F_20, 20, null, null);
            ManejarCheckBox(txt_F_21, chk_F_21, nud_F_21, 21, null, null);
            if (chk_F_22.Checked)
            {
                string f_41;
                f_41 = nud_F_22.Value + "x " + chk_F_22.Text;
                if (txt_F_22.Text == string.Empty)
                {
                    if (rdb_F_41_1.Checked)
                    {
                        f_41 = f_41 + " (" + rdb_F_41_1.Text + ", ";
                        if (chk_F_41_1.Checked)
                            f_41 = f_41 + chk_F_41_1.Text + ", ";
                        if (chk_F_41_2.Checked)
                            f_41 = f_41 + chk_F_41_2.Text + ", ";
                        if (chk_F_41_3.Checked)
                            f_41 = f_41 + chk_F_41_3.Text + ", ";
                        if (chk_F_41_4.Checked)
                            f_41 = f_41 + chk_F_41_4.Text + ", ";
                        if (chk_F_41_5.Checked)
                            f_41 = f_41 + chk_F_41_5.Text + ", ";
                        if (chk_F_41_6.Checked)
                            f_41 = f_41 + chk_F_41_6.Text + ", ";
                    }
                    else
                    {
                        f_41 = f_41 + " (" + rdb_F_41_2.Text + ", ";
                        if (chk_F_41_1.Checked)
                            f_41 = f_41 + chk_F_41_1.Text + ", ";
                        if (chk_F_41_2.Checked)
                            f_41 = f_41 + chk_F_41_2.Text + ", ";
                        if (chk_F_41_3.Checked)
                            f_41 = f_41 + chk_F_41_3.Text + ", ";
                        if (chk_F_41_4.Checked)
                            f_41 = f_41 + chk_F_41_4.Text + ", ";
                        if (chk_F_41_5.Checked)
                            f_41 = f_41 + chk_F_41_5.Text + ", ";
                        if (chk_F_41_6.Checked)
                            f_41 = f_41 + chk_F_41_6.Text + ", ";
                    }
                    f_41 = f_41 + ")";
                    comanda.Add(f_41);
                }
                else
                {
                    if (rdb_F_41_1.Checked)
                    {
                        f_41 = f_41 + " (" + rdb_F_41_1.Text + ", ";
                        if (chk_F_41_1.Checked)
                            f_41 = f_41 + chk_F_41_1.Text + ", ";
                        if (chk_F_41_2.Checked)
                            f_41 = f_41 + chk_F_41_2.Text + ", ";
                        if (chk_F_41_3.Checked)
                            f_41 = f_41 + chk_F_41_3.Text + ", ";
                        if (chk_F_41_4.Checked)
                            f_41 = f_41 + chk_F_41_4.Text + ", ";
                        if (chk_F_41_5.Checked)
                            f_41 = f_41 + chk_F_41_5.Text + ", ";
                        if (chk_F_41_6.Checked)
                            f_41 = f_41 + chk_F_41_6.Text + ", ";
                    }
                    else
                    {
                        f_41 = f_41 + " (" + rdb_F_41_2.Text + ", ";
                        if (chk_F_41_1.Checked)
                            f_41 = f_41 + chk_F_41_1.Text + ", ";
                        if (chk_F_41_2.Checked)
                            f_41 = f_41 + chk_F_41_2.Text + ", ";
                        if (chk_F_41_3.Checked)
                            f_41 = f_41 + chk_F_41_3.Text + ", ";
                        if (chk_F_41_4.Checked)
                            f_41 = f_41 + chk_F_41_4.Text + ", ";
                        if (chk_F_41_5.Checked)
                            f_41 = f_41 + chk_F_41_5.Text + ", ";
                        if (chk_F_41_6.Checked)
                            f_41 = f_41 + chk_F_41_6.Text + ", ";
                    }
                    f_41 = f_41 + txt_F_22.Text + ")";
                    comanda.Add(f_41);
                }
                OleDbCommand comand = new OleDbCommand("Select Precio FROM Fuertes Where id=22", conexion);
                comida.Add(nud_F_22.Value + "x " + chk_F_22.Text + ":" + Convert.ToInt32(comand.ExecuteScalar()) * Convert.ToInt32(nud_F_22.Value));
                Total = (Convert.ToInt32(comand.ExecuteScalar()) * Convert.ToInt32(nud_F_22.Value)) + Total;
                chk_F_22.Checked = false;
            }
            ManejarCheckBox(txt_F_23, chk_F_23, nud_F_23, 23, null, null);
            ManejarCheckBox(txt_F_24, chk_F_24, nud_F_24, 24, null, null);
            ManejarCheckBox(txt_F_25, chk_F_25, nud_F_25, 25, null, null);
            ManejarCheckBox(txt_F_26, chk_F_26, nud_F_26, 26, null, null);
            ManejarCheckBox(txt_F_27, chk_F_27, nud_F_27, 27, null, null);
            ManejarCheckBox(txt_F_28, chk_F_28, nud_F_28, 28, null, null);
            ManejarCheckBox(txt_F_29, chk_F_29, nud_F_29, 29, null, null);
            ManejarCheckBox(txt_F_30, chk_F_30, nud_F_30, 30, null, null);
            ManejarCheckBox(txt_F_31, chk_F_31, nud_F_31, 31, null, null);
            ManejarCheckBox(txt_F_32, chk_F_32, nud_F_32, 32, null, null);
            ManejarCheckBox(txt_F_33, chk_F_33, nud_F_33, 33, null, null);

            //Agregar Menu Infantil
            ManejarCheckBox(txt_I_1, chk_I_1, nud_I_1, 1, null, null);
            ManejarCheckBox(txt_I_2, chk_I_2, nud_I_2, 2, null, null);
            ManejarCheckBox(txt_I_3, chk_I_3, nud_I_3, 3, null, ListaDeRadioButtons[3]);

            //Agregar Postres
            ManejarCheckBox(txt_P_1, chk_P_1, nud_P_1, 1, null, null);
            ManejarCheckBox(txt_P_2, chk_P_2, nud_P_2, 2, null, null);
            ManejarCheckBox(txt_P_3, chk_P_3, nud_P_3, 3, null, null);
            ManejarCheckBox(txt_P_4, chk_P_4, nud_P_4, 4, null, null);
            ManejarCheckBox(txt_P_5, chk_P_5, nud_P_5, 5, null, null);


            //Agregar Bebidas
            ManejarCheckBox(txt_B_1, chk_B_1, nud_B_1, 1, null, null);
            ManejarCheckBox(txt_B_2, chk_B_2, nud_B_2, 2, null, null);
            ManejarCheckBox(txt_B_3, chk_B_3, nud_B_3, 3, null, null);
            ManejarCheckBox(txt_B_4, chk_B_4, nud_B_4, 4, null, null);
            ManejarCheckBox(txt_B_5, chk_B_5, nud_B_5, 5, null, null);
            ManejarCheckBox(txt_B_6, chk_B_6, nud_B_6, 6, null, null);
            ManejarCheckBox(txt_B_7, chk_B_7, nud_B_7, 7, null, null);
            ManejarCheckBox(txt_B_8, chk_B_8, nud_B_8, 8, null, null);
            ManejarCheckBox(txt_B_9, chk_B_9, nud_B_9, 9, null, null);
            ManejarCheckBox(txt_B_10, chk_B_10, nud_B_10, 10, null, null);
            ManejarCheckBox(txt_B_11, chk_B_11, nud_B_11, 11, null, null);
            ManejarCheckBox(txt_B_12, chk_B_12, nud_B_12, 12, null, null);
            ManejarCheckBox(txt_B_13, chk_B_13, nud_B_13, 13, null, null);
            ManejarCheckBox(txt_B_14, chk_B_14, nud_B_14, 14, null, null);
            ManejarCheckBox(txt_B_15, chk_B_15, nud_B_15, 15, null, null);
            ManejarCheckBox(txt_B_16, chk_B_16, nud_B_16, 16, null, null);
            ManejarCheckBox(txt_B_17, chk_B_17, nud_B_17, 17, null, null);
            ManejarCheckBox(txt_B_18, chk_B_18, nud_B_18, 18, null, null);
            ManejarCheckBox(txt_B_19, chk_B_19, nud_B_19, 19, null, null);
            ManejarCheckBox(txt_B_20, chk_B_20, nud_B_20, 20, null, null);
            ManejarCheckBox(txt_B_21, chk_B_21, nud_B_21, 21, null, null);
            ManejarCheckBox(txt_B_22, chk_B_22, nud_B_22, 22, null, null);
            ManejarCheckBox(txt_B_23, chk_B_23, nud_B_23, 23, null, null);
            ManejarCheckBox(txt_B_24, chk_B_24, nud_B_24, 24, null, null);

            //Agregar Paquetes

            ManejarCheckBox(txt_C_1, chk_C_1, nud_C_1, 1, null, null);
            ManejarCheckBox(txt_C_2, chk_C_2, nud_C_2, 2, null, null);
            ManejarCheckBox(txt_C_3, chk_C_3, nud_C_3, 3, null, null);
            ManejarCheckBox(txt_C_4, chk_C_4, nud_C_4, 4, null, null);
            ManejarCheckBox(txt_C_5, chk_C_5, nud_C_5, 5, null, null);
            ManejarCheckBox(txt_C_6, chk_C_6, nud_C_6, 6, null, null);
            ManejarCheckBox(txt_C_7, chk_C_7, nud_C_7, 7, null, null);
            ManejarCheckBox(txt_C_8, chk_C_8, nud_C_8, 8, null, null);
            ManejarCheckBox(txt_C_9, chk_C_9, nud_C_9, 9, null, null);
            //Agregar Licores
            ManejarCheckBox(txt_L_1, chk_L_1, nud_L_1, 1, null, null);
            ManejarCheckBox(txt_L_2, chk_L_2, nud_L_2, 2, null, null);
            ManejarCheckBox(txt_L_3, chk_L_3, nud_L_3, 3, null, null);
            ManejarCheckBox(txt_L_4, chk_L_4, nud_L_4, 4, null, null);
            ManejarCheckBox(txt_L_5, chk_L_5, nud_L_5, 5, null, null);
            ManejarCheckBox(txt_L_6, chk_L_6, nud_L_6, 6, null, null);
            ManejarCheckBox(txt_L_7, chk_L_7, nud_L_7, 7, null, null);
            ManejarCheckBox(txt_L_8, chk_L_8, nud_L_8, 8, null, null);
            ManejarCheckBox(txt_L_9, chk_L_9, nud_L_9, 9, null, null);
            ManejarCheckBox(txt_L_10, chk_L_10, nud_L_10, 10, null, null);
            ManejarCheckBox(txt_L_11, chk_L_11, nud_L_11, 11, null, null);
            ManejarCheckBox(txt_L_12, chk_L_12, nud_L_12, 12, null, null);
            ManejarCheckBox(txt_L_13, chk_L_13, nud_L_13, 13, null, null);
            ManejarCheckBox(txt_L_14, chk_L_14, nud_L_14, 14, null, null);
            ManejarCheckBox(txt_L_15, chk_L_15, nud_L_15, 15, null, null);
            ManejarCheckBox(txt_L_16, chk_L_16, nud_L_16, 16, null, null);
            ManejarCheckBox(txt_L_17, chk_L_17, nud_L_17, 17, null, null);
            ManejarCheckBox(txt_L_18, chk_L_18, nud_L_18, 18, null, null);
            ManejarCheckBox(txt_L_19, chk_L_19, nud_L_19, 19, null, null);
            ManejarCheckBox(txt_L_20, chk_L_20, nud_L_20, 20, null, null);
            ManejarCheckBox(txt_L_21, chk_L_21, nud_L_21, 21, null, null);
            ManejarCheckBox(txt_L_22, chk_L_22, nud_L_22, 22, null, null);

            //Agregar Promociones
            ManejarCheckBox(txt_O_1, chk_O_1, nud_O_1, 1, null, null);
            ManejarCheckBox(txt_O_2, chk_O_2, nud_O_2, 2, null, null);
            ManejarCheckBox(txt_O_3, chk_O_3, nud_O_3, 3, null, null);
            ManejarCheckBox(txt_O_4, chk_O_4, nud_O_4, 4, null, null);
            ManejarCheckBox(txt_O_5, chk_O_5, nud_O_5, 5, null, null);
            ManejarCheckBox(txt_O_6, chk_O_6, nud_O_6, 6, null, null);
            ManejarCheckBox(txt_O_7, chk_O_7, nud_O_7, 7, null, null);
            ManejarCheckBox(txt_O_8, chk_O_8, nud_O_8, 8, null, null);
            ManejarCheckBox(txt_O_9, chk_O_9, nud_O_9, 9, null, null);

            //Agregar a la lista de la mesa
            switch (cmb_Mesas.SelectedIndex)
            {

                case 0:
                    Tt[0] = Tt[0] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.ToArray()[0] != "")
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[0]);
                            }
                            mesa1.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda1.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 1:
                    Tt[1] = Tt[1] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[1]);
                            }
                            mesa2.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda2.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 2:
                    Tt[2] = Tt[2] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[2]);
                            }
                            mesa3.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda3.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 3:
                    Tt[3] = Tt[3] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[3]);
                            }
                            mesa4.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda4.Add(comanda[i]);
                    Total = 0;
                    break;
                case 4:
                    Tt[4] = Tt[4] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[4]);
                            }
                            mesa5.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda5.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 5:
                    Tt[5] = Tt[5] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[5]);
                            }
                            mesa6.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda6.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 6:
                    Tt[6] = Tt[6] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[6]);
                            }
                            mesa7.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda7.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 7:
                    Tt[7] = Tt[7] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[7]);
                            }
                            mesa8.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda8.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 8:
                    Tt[8] = Tt[8] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[8]);
                            }
                            mesa9.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda9.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 9:
                    Tt[9] = Tt[9] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[9]);
                            }
                            mesa10.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda10.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 10:
                    Tt[10] = Tt[10] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[10]);
                            }
                            mesa11.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda11.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 11:
                    Tt[11] = Tt[11] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[11]);
                            }
                            mesa12.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda12.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 12:
                    Tt[12] = Tt[12] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[12]);
                            }
                            mesa13.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda13.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 13:
                    Tt[13] = Tt[13] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[13]);
                            }
                            mesa14.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda14.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 14:
                    Tt[14] = Tt[14] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[14]);
                            }
                            mesa15.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda15.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 15:
                    Tt[15] = Tt[15] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[15]);
                            }
                            mesa16.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda16.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 16:
                    Tt[16] = Tt[16] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[16]);
                            }
                            mesa17.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda17.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 17:
                    Tt[17] = Tt[17] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[17]);
                            }
                            mesa18.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda18.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 18:
                    Tt[18] = Tt[18] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[18]);
                            }
                            mesa19.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda19.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
                case 19:
                    Tt[19] = Tt[19] + Total;
                    do
                    {
                        if (comida.Count() != 0)
                        {
                            if (comida.Contains(comida.ElementAt(0)))
                            {
                                lsb_Cuenta.Items.Add(comida[0]);
                                lbl_Total.Text = "$" + Convert.ToString(Tt[19]);
                            }
                            mesa20.Add(comida[0]);
                            comida.RemoveAt(0);
                        }
                    } while (comida.Count() != 0);
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda20.Add(comanda[i]);
                    comanda.Clear();
                    Total = 0;
                    break;
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            decimal cambio = 0;
            string impresora = "POS-58(copy of 1)";
            switch (cmb_Mesas.SelectedIndex)
            {
                case 0:
                    if (mesa1.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }
                        clsFactura.CreaTicket.LineasGuion();
                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa1);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[0].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");


                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();

                        Ticket2.AgregaArticulo(mesa1);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[0].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[0] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[0] = 0;
                        mesa1.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;

                    }
                    break;

                case 1:
                    if (mesa2.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }
                        clsFactura.CreaTicket.LineasGuion();
                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa2);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[1].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa2);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[1].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        mesa2.Clear();
                        comanda.Clear();
                        cambio = +Tt[1] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[1] = 0;
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 2:
                    if (mesa3.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa3);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[2].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa3);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[2].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[2] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[2] = 0;
                        mesa3.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;

                    }
                    break;
                case 3:
                    if (mesa4.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa4);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[3].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa4);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[3].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[3] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[3] = 0;
                        mesa4.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 4:
                    if (mesa5.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa5);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[4].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa5);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[4].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[4] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[4] = 0;
                        mesa5.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 5:
                    if (mesa6.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa6);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[5].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa6);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[5].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[5] + Convert.ToInt32(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[5] = 0;
                        mesa6.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 6:
                    if (mesa7.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa7);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[6].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa7);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[6].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[6] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[6] = 0;
                        mesa7.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 7:
                    if (mesa8.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa8);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[7].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa8);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[7].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[7] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[7] = 0;
                        mesa8.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 8:
                    if (mesa9.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa9);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[8].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa9);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[8].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[8] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[8] = 0;
                        mesa9.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 9:
                    if (mesa10.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa10);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[9].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("**********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa10);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[9].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[9] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[9] = 0;
                        mesa10.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 10:
                    if (mesa11.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa11);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[10].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa11);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[10].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[10] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[10] = 0;
                        mesa11.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 11:
                    if (mesa12.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa12);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[11].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa12);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[11].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[11] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[11] = 0;
                        mesa12.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 12:
                    if (mesa13.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa13);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[12].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa13);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[12].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[12] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[12] = 0;
                        mesa13.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;

                    }
                    break;
                case 13:
                    if (mesa14.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa14);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[13].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa14);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[13].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[13] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[13] = 0;
                        mesa14.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 14:
                    if (mesa15.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa15);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[14].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa15);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[14].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[14] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[14] = 0;
                        mesa15.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 15:
                    if (mesa15.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa17);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[15].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa17);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[15].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[15] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[15] = 0;
                        mesa16.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 16:
                    if (mesa17.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa17);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[16].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa17);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[16].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[16] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[16] = 0;
                        mesa17.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 17:
                    if (mesa18.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa18);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[17].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa18);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[17].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[17] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[17] = 0;
                        mesa18.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 18:
                    if (mesa19.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa19);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[18].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa19);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[18].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[18] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[18] = 0;
                        mesa19.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
                case 19:
                    if (mesa20.Count() != 0)
                    {
                        clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                        Ticket1.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoIzquierda("RFC: GOGM561109417");
                        Ticket1.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket1.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket1.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket1.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket1.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket1.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket1.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaArticulo(mesa20);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total:", double.Parse(Tt[19].ToString()));
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket1.TextoCentro("********************************");
                        Ticket1.ImprimirTiket(impresora);
                        MessageBox.Show("Gracias por preferirnos");

                        clsFactura.CreaTicket Ticket2 = new clsFactura.CreaTicket();
                        Ticket2.TextoCentro("---------Mariscos Pepe----------"); //imprime una linea de descripcion
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoIzquierda("RFC: GOGM561109417");
                        Ticket2.TextoIzquierda("Telefono: 312 313 3053");
                        Ticket2.TextoIzquierda("Direccion: Maclovio Herrera 284");
                        Ticket2.TextoIzquierda("Colonia: Centro, Colima");
                        Ticket2.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());

                        if (ClaseCompartida.pedido)
                        {
                            Ticket2.TextoIzquierda("Pedido para: " + ClaseCompartida.Nombre);
                            Ticket2.TextoIzquierda("Ubicacion: " + ClaseCompartida.Calle + " " + ClaseCompartida.NE + ", " + ClaseCompartida.Colonia + ", " + ClaseCompartida.Ciudad);
                            Ticket2.TextoIzquierda("Contacto: " + ClaseCompartida.Telefono);
                            ClaseCompartida.pedido = false;
                        }
                        else
                        {
                            Ticket2.TextoIzquierda(cmb_Mesas.Text);
                        }

                        clsFactura.CreaTicket.LineasGuion();

                        clsFactura.CreaTicket.EncabezadoVenta();
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.AgregaArticulo(mesa20);
                        clsFactura.CreaTicket.LineasGuion();
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.AgregaTotales("Total:", double.Parse(Tt[19].ToString()));
                        Ticket2.TextoIzquierda(" ");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.TextoCentro("*    Gracias por preferirnos   *");
                        Ticket2.TextoCentro("********************************");
                        Ticket2.ImprimirTiket(impresora);

                        cambio = +Tt[19] + Convert.ToDecimal(new OleDbCommand("Select Caja From Facturas Where Fecha='" + Convert.ToString(DateTime.Now).Substring(0, 10) + "'", conexion).ExecuteScalar());
                        Tt[19] = 0;
                        mesa20.Clear();
                        comanda.Clear();
                        this.facturasTableAdapter.UpdateCaja(Convert.ToInt32(cambio), Convert.ToString(DateTime.Now).Substring(0, 10));
                        chk_Pedido.Checked = false;
                        txt_Telefono.Text = string.Empty;
                    }
                    break;
            }
            comanda.Clear();
            lsb_Cuenta.Items.Clear();
            lbl_Total.Text = string.Empty;
        }

        private void nud_E_1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chk_E_1_Click(object sender, EventArgs e)
        {

        }


        private void rdb_F_41_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_F_41_1.Checked)
            {
                chk_F_41_1.Visible = true;
                chk_F_41_2.Visible = true;
                chk_F_41_3.Visible = true;
                chk_F_41_4.Visible = true;
                chk_F_41_5.Visible = true;
                chk_F_41_6.Visible = true;
            }
            else
            {
                chk_F_41_1.Visible = false;
                chk_F_41_2.Visible = false;
                chk_F_41_3.Visible = false;
                chk_F_41_4.Visible = false;
                chk_F_41_5.Visible = false;
                chk_F_41_6.Visible = false;
                chk_F_41_1.Checked = false;
                chk_F_41_2.Checked = false;
                chk_F_41_3.Checked = false;
                chk_F_41_4.Checked = false;
                chk_F_41_5.Checked = false;
                chk_F_41_6.Checked = false;
            }
        }

        private void rdb_F_41_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_F_41_2.Checked)
            {
                chk_F_41_1.Visible = true;
                chk_F_41_2.Visible = true;
                chk_F_41_3.Visible = true;
                chk_F_41_4.Visible = true;
                chk_F_41_5.Visible = true;
                chk_F_41_6.Visible = true;
            }
            else
            {
                chk_F_41_1.Visible = false;
                chk_F_41_2.Visible = false;
                chk_F_41_3.Visible = false;
                chk_F_41_4.Visible = false;
                chk_F_41_5.Visible = false;
                chk_F_41_6.Visible = false;
                chk_F_41_1.Checked = false;
                chk_F_41_2.Checked = false;
                chk_F_41_3.Checked = false;
                chk_F_41_4.Checked = false;
                chk_F_41_5.Checked = false;
                chk_F_41_6.Checked = false;
            }
        }


        private void nud_P_45_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nud_P_46_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nud_P_47_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nud_P_48_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nud_P_49_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ptd_Comanda_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }


        private void tbp_Infantil_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_otros_Click(object sender, EventArgs e)
        {
            lbl_otros.Visible = true;
            lbl_otros_2.Visible = true;
            btn_otros_agregar.Visible = true;
            txt_otros_productos.Visible = true;
            nud_otros.Visible = true;
        }

        private void btn_otros_agregar_Click(object sender, EventArgs e)
        {
            lsb_Cuenta.Items.Clear();
            comanda.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
            switch (cmb_Mesas.SelectedIndex)
            {
                case 0:
                    mesa1.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[0] = Tt[0] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa1.ToArray()).Length - 1; i++)
                    {
                        if (mesa1[i] == null)
                            mesa1[i] = "";
                        else
                        {
                            if (mesa1[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa1[i]);
                                lbl_Total.Text = Convert.ToString(Tt[0] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda1.Add(comanda[i]);
                    comanda.Clear();

                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 1:
                    mesa2.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[1] = Tt[1] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa2.ToArray()).Length - 1; i++)
                    {
                        if (mesa2[i] == null)
                            mesa2[i] = "";
                        else
                        {
                            if (mesa2[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa2[i]);
                                lbl_Total.Text = Convert.ToString(Tt[1] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda2.Add(comanda[i]);
                    comanda.Clear();

                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 2:
                    mesa3.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[2] = Tt[2] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa3.ToArray()).Length - 1; i++)
                    {
                        if (mesa3[i] == null)
                            mesa3[i] = "";
                        else
                        {
                            if (mesa3[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa3[i]);
                                lbl_Total.Text = Convert.ToString(Tt[2] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda3.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 3:
                    mesa4.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[3] = Tt[3] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa4.ToArray()).Length - 1; i++)
                    {
                        if (mesa4[i] == null)
                            mesa4[i] = "";
                        else
                        {
                            if (mesa4[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa4[i]);
                                lbl_Total.Text = Convert.ToString(Tt[3] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda4.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 4:
                    mesa5.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[4] = Tt[4] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa5.ToArray()).Length - 1; i++)
                    {
                        if (mesa5[i] == null)
                            mesa5[i] = "";
                        else
                        {
                            if (mesa5[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa5[i]);
                                lbl_Total.Text = Convert.ToString(Tt[4] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda5.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 5:
                    mesa6.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[5] = Tt[5] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa6.ToArray()).Length - 1; i++)
                    {
                        if (mesa6[i] == null)
                            mesa6[i] = "";
                        else
                        {
                            if (mesa6[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa6[i]);
                                lbl_Total.Text = Convert.ToString(Tt[5] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda6.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 6:
                    mesa7.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[6] = Tt[6] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa7.ToArray()).Length - 1; i++)
                    {
                        if (mesa7[i] == null)
                            mesa7[i] = "";
                        else
                        {
                            if (mesa7[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa7[i]);
                                lbl_Total.Text = Convert.ToString(Tt[6] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda7.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 7:
                    mesa8.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[7] = Tt[7] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa8.ToArray()).Length - 1; i++)
                    {
                        if (mesa8[i] == null)
                            mesa8[i] = "";
                        else
                        {
                            if (mesa8[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa8[i]);
                                lbl_Total.Text = Convert.ToString(Tt[7] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda8.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 8:
                    mesa9.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[8] = Tt[8] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa9.ToArray()).Length - 1; i++)
                    {
                        if (mesa9[i] == null)
                            mesa9[i] = "";
                        else
                        {
                            if (mesa9[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa9[i]);
                                lbl_Total.Text = Convert.ToString(Tt[8] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda9.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 9:
                    mesa10.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[9] = Tt[9] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa10.ToArray()).Length - 1; i++)
                    {
                        if (mesa10[i] == null)
                            mesa10[i] = "";
                        else
                        {
                            if (mesa10[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa10[i]);
                                lbl_Total.Text = Convert.ToString(Tt[9] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda10.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 10:
                    mesa11.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[10] = Tt[10] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa11.ToArray()).Length - 1; i++)
                    {
                        if (mesa11[i] == null)
                            mesa1[i] = "";
                        else
                        {
                            if (mesa11[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa11[i]);
                                lbl_Total.Text = Convert.ToString(Tt[10] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda11.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 11:
                    mesa12.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[11] = Tt[11] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa12.ToArray()).Length - 1; i++)
                    {
                        if (mesa12[i] == null)
                            mesa12[i] = "";
                        else
                        {
                            if (mesa12[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa12[i]);
                                lbl_Total.Text = Convert.ToString(Tt[11] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda12.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 12:
                    mesa13.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[12] = Tt[12] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa13.ToArray()).Length - 1; i++)
                    {
                        if (mesa13[i] == null)
                            mesa13[i] = "";
                        else
                        {
                            if (mesa13[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa13[i]);
                                lbl_Total.Text = Convert.ToString(Tt[12] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda13.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 13:
                    mesa14.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[13] = Tt[13] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa14.ToArray()).Length - 1; i++)
                    {
                        if (mesa14[i] == null)
                            mesa14[i] = "";
                        else
                        {
                            if (mesa14[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa14[i]);
                                lbl_Total.Text = Convert.ToString(Tt[13] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda14.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 14:
                    mesa15.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[14] = Tt[14] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa15.ToArray()).Length - 1; i++)
                    {
                        if (mesa15[i] == null)
                            mesa15[i] = "";
                        else
                        {
                            if (mesa15[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa15[i]);
                                lbl_Total.Text = Convert.ToString(Tt[14] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda15.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 15:
                    mesa16.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[15] = Tt[15] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa16.ToArray()).Length - 1; i++)
                    {
                        if (mesa16[i] == null)
                            mesa16[i] = "";
                        else
                        {
                            if (mesa16[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa16[i]);
                                lbl_Total.Text = Convert.ToString(Tt[15] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda16.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 16:
                    mesa17.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[16] = Tt[16] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa17.ToArray()).Length - 1; i++)
                    {
                        if (mesa17[i] == null)
                            mesa17[i] = "";
                        else
                        {
                            if (mesa17[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa17[i]);
                                lbl_Total.Text = Convert.ToString(Tt[16] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda17.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 17:
                    mesa18.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[17] = Tt[17] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa18.ToArray()).Length - 1; i++)
                    {
                        if (mesa18[i] == null)
                            mesa18[i] = "";
                        else
                        {
                            if (mesa18[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa18[i]);
                                lbl_Total.Text = Convert.ToString(Tt[17] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda18.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 18:
                    mesa19.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[18] = Tt[18] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa19.ToArray()).Length - 1; i++)
                    {
                        if (mesa19[i] == null)
                            mesa19[i] = "";
                        else
                        {
                            if (mesa19[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa19[i]);
                                lbl_Total.Text = Convert.ToString(Tt[18] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda19.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
                case 19:
                    mesa20.Add("1x " + txt_otros_productos.Text + ": " + Convert.ToString(nud_otros.Value));
                    Tt[19] = Tt[19] + Convert.ToInt32(nud_otros.Value);

                    for (int i = 0; i <= (mesa20.ToArray()).Length - 1; i++)
                    {
                        if (mesa20[i] == null)
                            mesa20[i] = "";
                        else
                        {
                            if (mesa20[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa20[i]);
                                lbl_Total.Text = Convert.ToString(Tt[19] + "$");
                            }
                        }
                    }
                    for (int i = 0; i < comanda.ToArray().Length; i++)
                        comanda20.Add(comanda[i]);
                    comanda.Clear();
                    MessageBox.Show("Se Agrego un producto a la " + cmb_Mesas.Text, "Punto De Venta Mariscos Pepe");
                    lbl_otros.Visible = false;
                    lbl_otros_2.Visible = false;
                    btn_otros_agregar.Visible = false;
                    txt_otros_productos.Visible = false;
                    nud_otros.Visible = false;
                    nud_otros.Value = 1;
                    txt_otros_productos.Text = string.Empty;
                    break;
            }
        }

        private void lsb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsb_Cuenta_DoubleClick(object sender, EventArgs e)
        {
        }

        private void lsb_Cuenta_Click(object sender, EventArgs e)
        {
            if (lsb_Cuenta.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para poder eliminarlo", "Elimar producto");
            }
            else
            {
                btn_eliminar.Enabled = true;
            }
        }
        string n = "";

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            n = lsb_Cuenta.SelectedItem.ToString();

            switch (cmb_Mesas.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < mesa1.ToArray().Length; i++)
                    {
                        if (mesa1.ToArray()[i] == n)
                        {
                            Tt[0] = Tt[0] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa1.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa1.ToArray()).Length - 1; i++)
                    {
                        if (mesa1[i] == null)
                            mesa1[i] = "";
                        else
                        {
                            if (mesa1[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa1[i]);
                                lbl_Total.Text = Convert.ToString(Tt[0] + "$");
                            }
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < mesa2.ToArray().Length; i++)
                    {
                        if (mesa2.ToArray()[i] == n)
                        {
                            Tt[1] = Tt[1] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa2.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa2.ToArray()).Length - 1; i++)
                    {
                        if (mesa2[i] == null)
                            mesa2[i] = "";
                        else
                        {
                            if (mesa2[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa2[i]);
                                lbl_Total.Text = Convert.ToString(Tt[1] + "$");
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < mesa3.ToArray().Length; i++)
                    {
                        if (mesa3.ToArray()[i] == n)
                        {
                            Tt[2] = Tt[2] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa3.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa3.ToArray()).Length - 1; i++)
                    {
                        if (mesa3[i] == null)
                            mesa3[i] = "";
                        else
                        {
                            if (mesa3[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa3[i]);
                                lbl_Total.Text = Convert.ToString(Tt[2] + "$");
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < mesa4.ToArray().Length; i++)
                    {
                        if (mesa4.ToArray()[i] == n)
                        {
                            Tt[3] = Tt[3] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa4.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa4.ToArray()).Length - 1; i++)
                    {
                        if (mesa4[i] == null)
                            mesa4[i] = "";
                        else
                        {
                            if (mesa4[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa4[i]);
                                lbl_Total.Text = Convert.ToString(Tt[3] + "$");
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < mesa5.ToArray().Length; i++)
                    {
                        if (mesa5.ToArray()[i] == n)
                        {
                            Tt[4] = Tt[4] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa5.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa5.ToArray()).Length - 1; i++)
                    {
                        if (mesa5[i] == null)
                            mesa5[i] = "";
                        else
                        {
                            if (mesa5[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa5[i]);
                                lbl_Total.Text = Convert.ToString(Tt[4] + "$");
                            }
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < mesa6.ToArray().Length; i++)
                    {
                        if (mesa6.ToArray()[i] == n)
                        {
                            Tt[5] = Tt[5] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa6.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa6.ToArray()).Length - 1; i++)
                    {
                        if (mesa6[i] == null)
                            mesa6[i] = "";
                        else
                        {
                            if (mesa6[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa6[i]);
                                lbl_Total.Text = Convert.ToString(Tt[5] + "$");
                            }
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < mesa7.ToArray().Length; i++)
                    {
                        if (mesa7.ToArray()[i] == n)
                        {
                            Tt[6] = Tt[6] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa7.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa7.ToArray()).Length - 1; i++)
                    {
                        if (mesa7[i] == null)
                            mesa7[i] = "";
                        else
                        {
                            if (mesa7[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa7[i]);
                                lbl_Total.Text = Convert.ToString(Tt[6] + "$");
                            }
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < mesa8.ToArray().Length; i++)
                    {
                        if (mesa8.ToArray()[i] == n)
                        {
                            Tt[7] = Tt[7] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa8.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa8.ToArray()).Length - 1; i++)
                    {
                        if (mesa8[i] == null)
                            mesa8[i] = "";
                        else
                        {
                            if (mesa8[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa8[i]);
                                lbl_Total.Text = Convert.ToString(Tt[7] + "$");
                            }
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < mesa9.ToArray().Length; i++)
                    {
                        if (mesa9.ToArray()[i] == n)
                        {
                            Tt[8] = Tt[8] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa9.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa9.ToArray()).Length - 1; i++)
                    {
                        if (mesa9[i] == null)
                            mesa9[i] = "";
                        else
                        {
                            if (mesa9[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa9[i]);
                                lbl_Total.Text = Convert.ToString(Tt[8] + "$");
                            }
                        }
                    }
                    break;
                case 9:
                    for (int i = 0; i < mesa10.ToArray().Length; i++)
                    {
                        if (mesa10.ToArray()[i] == n)
                        {
                            Tt[9] = Tt[9] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa10.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa10.ToArray()).Length - 1; i++)
                    {
                        if (mesa10[i] == null)
                            mesa10[i] = "";
                        else
                        {
                            if (mesa10[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa10[i]);
                                lbl_Total.Text = Convert.ToString(Tt[9] + "$");
                            }
                        }
                    }
                    break;
                case 10:
                    for (int i = 0; i < mesa11.ToArray().Length; i++)
                    {
                        if (mesa11.ToArray()[i] == n)
                        {
                            Tt[10] = Tt[10] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa11.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa11.ToArray()).Length - 1; i++)
                    {
                        if (mesa11[i] == null)
                            mesa11[i] = "";
                        else
                        {
                            if (mesa11[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa11[i]);
                                lbl_Total.Text = Convert.ToString(Tt[10] + "$");
                            }
                        }
                    }
                    break;
                case 11:
                    for (int i = 0; i < mesa12.ToArray().Length; i++)
                    {
                        if (mesa12.ToArray()[i] == n)
                        {
                            Tt[11] = Tt[11] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa12.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa12.ToArray()).Length - 1; i++)
                    {
                        if (mesa12[i] == null)
                            mesa12[i] = "";
                        else
                        {
                            if (mesa12[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa12[i]);
                                lbl_Total.Text = Convert.ToString(Tt[11] + "$");
                            }
                        }
                    }
                    break;
                case 12:
                    for (int i = 0; i < mesa13.ToArray().Length; i++)
                    {
                        if (mesa13.ToArray()[i] == n)
                        {
                            Tt[12] = Tt[12] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa13.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa13.ToArray()).Length - 1; i++)
                    {
                        if (mesa13[i] == null)
                            mesa13[i] = "";
                        else
                        {
                            if (mesa13[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa13[i]);
                                lbl_Total.Text = Convert.ToString(Tt[12] + "$");
                            }
                        }
                    }
                    break;
                case 13:
                    for (int i = 0; i < mesa14.ToArray().Length; i++)
                    {
                        if (mesa14.ToArray()[i] == n)
                        {
                            Tt[13] = Tt[13] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa14.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa14.ToArray()).Length - 1; i++)
                    {
                        if (mesa14[i] == null)
                            mesa14[i] = "";
                        else
                        {
                            if (mesa14[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa14[i]);
                                lbl_Total.Text = Convert.ToString(Tt[13] + "$");
                            }
                        }
                    }
                    break;
                case 14:
                    for (int i = 0; i < mesa15.ToArray().Length; i++)
                    {
                        if (mesa15.ToArray()[i] == n)
                        {
                            Tt[14] = Tt[14] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa15.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa15.ToArray()).Length - 1; i++)
                    {
                        if (mesa15[i] == null)
                            mesa15[i] = "";
                        else
                        {
                            if (mesa15[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa15[i]);
                                lbl_Total.Text = Convert.ToString(Tt[14] + "$");
                            }
                        }
                    }
                    break;
                case 15:
                    for (int i = 0; i < mesa16.ToArray().Length; i++)
                    {
                        if (mesa16.ToArray()[i] == n)
                        {
                            Tt[15] = Tt[15] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa16.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa16.ToArray()).Length - 1; i++)
                    {
                        if (mesa16[i] == null)
                            mesa16[i] = "";
                        else
                        {
                            if (mesa16[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa16[i]);
                                lbl_Total.Text = Convert.ToString(Tt[15] + "$");
                            }
                        }
                    }
                    break;
                case 16:
                    for (int i = 0; i < mesa17.ToArray().Length; i++)
                    {
                        if (mesa17.ToArray()[i] == n)
                        {
                            Tt[16] = Tt[16] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa17.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa7.ToArray()).Length - 1; i++)
                    {
                        if (mesa17[i] == null)
                            mesa17[i] = "";
                        else
                        {
                            if (mesa17[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa17[i]);
                                lbl_Total.Text = Convert.ToString(Tt[16] + "$");
                            }
                        }
                    }
                    break;
                case 17:
                    for (int i = 0; i < mesa18.ToArray().Length; i++)
                    {
                        if (mesa18.ToArray()[i] == n)
                        {
                            Tt[17] = Tt[17] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa18.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa18.ToArray()).Length - 1; i++)
                    {
                        if (mesa18[i] == null)
                            mesa18[i] = "";
                        else
                        {
                            if (mesa18[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa18[i]);
                                lbl_Total.Text = Convert.ToString(Tt[17] + "$");
                            }
                        }
                    }
                    break;
                case 18:
                    for (int i = 0; i < mesa19.ToArray().Length; i++)
                    {
                        if (mesa19.ToArray()[i] == n)
                        {
                            Tt[18] = Tt[18] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa19.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa19.ToArray()).Length - 1; i++)
                    {
                        if (mesa19[i] == null)
                            mesa19[i] = "";
                        else
                        {
                            if (mesa19[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa19[i]);
                                lbl_Total.Text = Convert.ToString(Tt[18] + "$");
                            }
                        }
                    }
                    break;
                case 19:
                    for (int i = 0; i < mesa20.ToArray().Length; i++)
                    {
                        if (mesa20.ToArray()[i] == n)
                        {
                            Tt[19] = Tt[19] - Convert.ToDecimal(n.Substring(n.IndexOf(":") + 1));
                            lsb_Cuenta.Items.Remove(lsb_Cuenta.SelectedItem);
                            mesa20.Remove(n);
                            lsb_Cuenta.Items.Clear();
                            lbl_Total.Text = string.Empty;
                        }
                    }
                    MessageBox.Show(n + " Fue eliminado de la cuenta de " + cmb_Mesas.Text, "Eliminar Producto");
                    for (int i = 0; i <= (mesa20.ToArray()).Length - 1; i++)
                    {
                        if (mesa20[i] == null)
                            mesa20[i] = "";
                        else
                        {
                            if (mesa20[i] != "")
                            {
                                lsb_Cuenta.Items.Add(mesa20[i]);
                                lbl_Total.Text = Convert.ToString(Tt[19] + "$");
                            }
                        }
                    }
                    break;
            }

            btn_eliminar.Enabled = false;
        }

        private void lsb_Cuenta_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_comanda_Click(object sender, EventArgs e)
        {
            string Impresora;
            Impresora = "POS-58";
            comanda.Clear();
            switch (cmb_Mesas.SelectedIndex)
            {
                case 0:
                    if (comanda1.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda1);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda1.Clear();
                    }
                    break;
                case 1:
                    if (comanda2.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda2);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda2.Clear();
                    }
                    break;
                case 2:
                    if (comanda3.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda3);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda3.Clear();
                    }
                    break;
                case 3:
                    if (comanda4.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda4);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda4.Clear();
                    }
                    break;
                case 4:
                    if (comanda5.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda5);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda5.Clear();
                    }
                    break;
                case 5:
                    if (comanda6.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda6);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda6.Clear();
                    }
                    break;
                case 6:
                    if (comanda7.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda7);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda7.Clear();
                    }
                    break;
                case 7:
                    if (comanda8.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda8);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda8.Clear();
                    }
                    break;
                case 8:
                    if (comanda9.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda9);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda9.Clear();
                    }
                    break;
                case 9:
                    if (comanda10.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda10);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda10.Clear();
                    }
                    break;
                case 10:
                    if (comanda10.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda10);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda10.Clear();
                    }
                    break;
                case 11:
                    if (comanda12.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda12);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda12.Clear();
                    }
                    break;
                case 12:
                    if (comanda13.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda13);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda13.Clear();
                    }
                    break;
                case 13:
                    if (comanda14.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda14);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda14.Clear();
                    }
                    break;
                case 14:
                    if (comanda15.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda15);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda15.Clear();
                    }
                    break;
                case 15:
                    if (comanda16.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda16);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda16.Clear();
                    }
                    break;
                case 16:
                    if (comanda17.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda17);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda17.Clear();
                    }
                    break;
                case 17:
                    if (comanda18.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda18);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda18.Clear();
                    }
                    break;
                case 18:
                    if (comanda19.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda19);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda19.Clear();
                    }
                    break;
                case 19:
                    if (comanda20.Count() != 0)
                    {
                        clsComanda.CreaComanda Comanda = new clsComanda.CreaComanda();
                        Comanda.TextoCentro("---------Mariscos Pepe----------");
                        Comanda.TextoCentro("Comanda: " + cmb_Mesas.Text);
                        Comanda.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        clsComanda.CreaComanda.LineasGuion();
                        clsComanda.CreaComanda.EncabezadoVenta();
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.AgregaArticulo(comanda20);
                        clsComanda.CreaComanda.LineasGuion();
                        Comanda.ImprimirTiket(Impresora);
                        comanda20.Clear();
                    }
                    break;
            }
        }

        private void rdb_E_13_CheckedChanged(object sender, EventArgs e)
        {
            grb_E_S_13.Visible = true;
            rdb_E_V_13.Visible = true;
            rdb_E_R_13.Visible = true;
        }

        private void rdb_E_13_2_CheckedChanged(object sender, EventArgs e)
        {
            grb_E_S_13.Visible = true;
            rdb_E_V_13.Visible = true;
            rdb_E_R_13.Visible = true;
        }

        private void rdb_E_12_CheckedChanged(object sender, EventArgs e)
        {
            grb_E_S_12.Visible = true;
            rdb_E_V_12.Visible = true;
            rdb_E_R_12.Visible = true;
        }

        private void rdb_E_12_2_CheckedChanged(object sender, EventArgs e)
        {
            grb_E_S_12.Visible = true;
            rdb_E_V_12.Visible = true;
            rdb_E_R_12.Visible = true;
        }

        private void chk_Pedido_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Pedido.Checked)
            {
                txt_Telefono.Visible = true;
                btn_Buscar.Visible = true;
            }
            else
            {
                txt_Telefono.Visible = false;
                txt_Telefono.Text = string.Empty;
                btn_Buscar.Visible = false;
            }
        }

        private void txt_Telefono_TextChanged(object sender, EventArgs e)
        {
            txt_Telefono.MaxLength = 10;
        }

        private void rdb_E_V_13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb_E_R_13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb_E_N_13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb_E_V_12_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void lbl_Martes_Click(object sender, EventArgs e)
        {

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            OleDbCommand comand = new OleDbCommand("Select * FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion);
            OleDbDataReader leedb;
            leedb = comand.ExecuteReader();
            bool exist;
            exist = leedb.HasRows;
            if (exist)
            {
                if (Convert.ToInt32(new OleDbCommand("Select count(*) FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion).ExecuteScalar()) >= 2)
                {
                    frm_Seleccion_envios se = new frm_Seleccion_envios();
                    se.lbl_Telefono.Text = se.lbl_Telefono.Text + "\n" + txt_Telefono.Text;
                    se.Show();

                }
                else
                {
                    ClaseCompartida.Telefono = Convert.ToString((new OleDbCommand("Select Telefono FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion)).ExecuteScalar());
                    ClaseCompartida.Nombre = Convert.ToString((new OleDbCommand("Select Nombre FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion).ExecuteScalar()));
                    ClaseCompartida.Calle = Convert.ToString((new OleDbCommand("Select Calle FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion).ExecuteScalar()));
                    ClaseCompartida.Colonia = Convert.ToString((new OleDbCommand("Select Colonia FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion).ExecuteScalar()));
                    ClaseCompartida.NE = Convert.ToString((new OleDbCommand("Select Numero_Ext FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion).ExecuteScalar()));
                    ClaseCompartida.Ciudad = Convert.ToString((new OleDbCommand("Select Ciudad FROM Envios WHERE Telefono = '" + txt_Telefono.Text + "'", conexion).ExecuteScalar()));
                    ClaseCompartida.pedido = true;
                    MessageBox.Show("Peronsona Encontrada", "Pedidos", MessageBoxButtons.OK);
                    txt_Telefono.Text = string.Empty;
                    chk_Pedido.Checked = false;
                }
            }
            else
            {
                frm_Registro_Envios re = new frm_Registro_Envios();
                re.txt_Telefono.Text = txt_Telefono.Text;
                re.Show();


            }
            txt_Telefono.Text = string.Empty;
        }

        private void facturasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.facturasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mariscos_PepeDataSet);

        }

        private void lbl_total_caja_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nud_E_19_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nud_E_15_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_E_18_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbp_Entradas_Click(object sender, EventArgs e)
        {


        }

        private void tbp_Entradas_Scroll(object sender, ScrollEventArgs e)
        {
            tbp_Entradas.AutoScrollPosition = new Point(0, 0);
        }

        private void rdb_F_34_P_6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbc_punto_venta_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tbc_punto_venta_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }
    }
}
