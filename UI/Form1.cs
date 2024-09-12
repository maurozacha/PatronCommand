using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        UsuarioBLL usuarioBLL;
        public Form1()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
        }

        private void LlenarComboTipoSubscripcion()
        {
            List<TipoSubscripcion> tiposSubscripcion = usuarioBLL.ObtenerTiposSubscripcion();

            tipoSubscripcionComboBox.Items.Clear(); 
            foreach (var tipo in tiposSubscripcion)
            {
                tipoSubscripcionComboBox.Items.Add(tipo.nombre);
            }

            if (tipoSubscripcionComboBox.Items.Count > 0)
            {
                tipoSubscripcionComboBox.SelectedIndex = 0;
            }
        }

        private void LlenarUsuarioSubscriptorLB()
        {

            List<Usuario> usuarios = usuarioBLL.ObtenerUsuariosConSuscripciones();

            UsuarioSubscriptorLB.Items.Clear();

            foreach (Usuario usuario in usuarios)
            {
                string usuarioInfo = $"{usuario.nomUsuario} - {usuario.subscripcion.tipoSubscripcion.nombre}";

                UsuarioSubscriptorLB.Items.Add(usuarioInfo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (UsuarioSubscriptorLB.SelectedItem != null)
            {
                string selectedItem = UsuarioSubscriptorLB.SelectedItem.ToString();

                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    string usuarioNombre = parts[0];
                    string tipoSubscripcion = parts[1];

                    Usuario usuario = usuarioBLL.ObtenerUsuarioPorNombre(usuarioNombre); 
                    Subscripcion subscripcion = usuarioBLL.ObtenerSubscripcionPorTipo(tipoSubscripcion); 

                    if (usuario != null && subscripcion != null)
                    {
                        Receiver receiver = new Receiver(usuario, subscripcion);

                        ICommand command = new CancelarSubscripcionUsuarioCommand(receiver);

                        Invoker invoker = new Invoker();
                        invoker.SetCommand(command);

                        invoker.ExecuteCommand();
                        LlenarUsuarioSubscriptorLB();

                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario o la suscripción.");
                    }
                }
                else
                {
                    MessageBox.Show("Formato del texto seleccionado no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarUsuarioSubscriptorLB();
            LlenarComboTipoSubscripcion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipoSubscripcion = tipoSubscripcionComboBox.SelectedItem.ToString();
            int edad = (int)edadNumericUpDown.Value;
            string nomUsuario = nomUsuarioTB.Text;
            string correo = correoTB.Text;
            string nombreCompleto = nombreCompletoTB.Text;

            if (string.IsNullOrEmpty(nomUsuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(nombreCompleto) || string.IsNullOrEmpty(tipoSubscripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                nombre = nombreCompleto,
                nomUsuario = nomUsuario,
                mail = correo,
                edad = edad,
                subscripcion = new Subscripcion
                {
                    tipoSubscripcion = new TipoSubscripcion { nombre = tipoSubscripcion },
                    activa = true 
                }
            };

            Receiver receiver = new Receiver(nuevoUsuario, nuevoUsuario.subscripcion);

            ICommand command = new SubscribirUsuarioCommand(receiver);

            Invoker invoker = new Invoker();
            invoker.SetCommand(command);

            try
            {
                invoker.ExecuteCommand();
                MessageBox.Show("Usuario registrado con éxito.");

                LlenarUsuarioSubscriptorLB();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}");
            }
        }

        private void UsuarioSubscriptorLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsuarioSubscriptorLB.SelectedItem != null)
            {
                string selectedItem = UsuarioSubscriptorLB.SelectedItem.ToString();

                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);

                UsuarioSubLB.Text = parts[0];
                label8.Visible = true;
                SubsLB.Text = parts[1];
                label9.Visible = true;
            }
        }

    }
}
