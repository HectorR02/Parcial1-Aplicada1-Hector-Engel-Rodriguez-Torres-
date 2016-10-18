using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1_Ap1_Hector_Engel_Rodriguez_Torres.Consultas
{
    public partial class ConsultaCLientes : Form
    {
        public ConsultaCLientes()
        {
            InitializeComponent();
            HastaDateTimePicker.Value = DesdeDateTimePicker.Value;
            BLL.ClientesBLL.Insertar(new Clientes()
            {
                ClienteId = 1,
                Nombres = "Juan Alberto Mena",
                FechaNacimiento = DateTime.Today, //FechaNacimientoDateTimePicker.Value,
                LimiteCredito = 1500
            });
            BLL.ClientesBLL.Insertar(new Clientes()
            {
                ClienteId = 1,
                Nombres = "Joselito Mateo",
                FechaNacimiento = DateTime.Today, //FechaNacimientoDateTimePicker.Value,
                LimiteCredito = 1900
            });
            CargarClientes();
        }

        public void CargarClientes()
        {
            var clientes = BLL.ClientesBLL.GetList();
            foreach(Clientes cliente in clientes)
                NombresComboBox.Items.Add(cliente.Nombres);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NombresComboBox.SelectedItem == null)
                ClientesDataGridView.DataSource = BLL.ClientesBLL.GetList();
            else
            if (NombresComboBox.SelectedItem != null && DesdeDateTimePicker.Value != HastaDateTimePicker.Value)
                ClientesDataGridView.DataSource = BLL.ClientesBLL.GetList(NombresComboBox.SelectedItem.ToString(), DesdeDateTimePicker.Value, HastaDateTimePicker.Value);
        }

        private void HastaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
