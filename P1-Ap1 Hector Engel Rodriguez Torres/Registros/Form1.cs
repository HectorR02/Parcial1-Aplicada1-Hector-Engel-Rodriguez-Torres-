using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1_Ap1_Hector_Engel_Rodriguez_Torres
{
    public partial class RegistroClientes : Form
    {
        public RegistroClientes()
        {
            InitializeComponent();
            BLL.ClientesBLL.Insertar(new Clientes()
            {
                ClienteId = 1,
                Nombres = "Juan Alberto Mena",
                FechaNacimiento = DateTime.Today, //FechaNacimientoDateTimePicker.Value,
                LimiteCredito = 1500
            });
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ClienteIdMaskedTextBox.Text))
            {
                var cliente = BLL.ClientesBLL.Buscar(Convert.ToInt32(ClienteIdMaskedTextBox.Text));
                if (cliente != null)
                {
                    NombresTextBox.Text = cliente.Nombres;
                    FechaNacimientoDateTimePicker.Value = cliente.FechaNacimiento;
                    LimiteCreditoTextBox.Text = cliente.LimiteCredito.ToString();
                }
                else
                    MessageBox.Show("El Cliente Id, que ha insertado no\nexiste en nuestra Base de Datos", "-- Error en la Consulta --");
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios");
                ClienteIdMaskedTextBox.Focus();
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NombresTextBox.Text))
            {
                if(!string.IsNullOrEmpty(LimiteCreditoTextBox.Text))
                {
                    BLL.ClientesBLL.Insertar(new Clientes()
                    {
                        ClienteId = Convert.ToInt32(ClienteIdMaskedTextBox.Text),
                        Nombres = NombresTextBox.Text,
                        FechaNacimiento = FechaNacimientoDateTimePicker.Value,
                        LimiteCredito = Convert.ToInt32(LimiteCreditoTextBox.Text)
                    });
                }
                else
                {
                    MessageBox.Show("No puedes dejar campos vacios", "Error");
                    LimiteCreditoTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios", "Error");
                NombresTextBox.Focus();
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            int id = BLL.ClientesBLL.UltimoCliente()+1;
            NombresTextBox.Clear();
            LimiteCreditoTextBox.Clear();
            FechaNacimientoDateTimePicker.Value = DateTime.Today;
            ClienteIdMaskedTextBox.Text = id.ToString();
            ClienteIdMaskedTextBox.Enabled = BuscarButton.Enabled = false;
            NombresTextBox.Enabled = FechaNacimientoDateTimePicker.Enabled = LimiteCreditoTextBox.Enabled = GuardarButton.Enabled = EliminarButton.Enabled = true;
            NombresTextBox.Focus();
        }
    }
}
