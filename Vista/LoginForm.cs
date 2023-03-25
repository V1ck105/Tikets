using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if(UsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un usuario");
                UsuarioTextBox.Focus();
                return; 
            }
            errorProvider1.Clear();
            if (ContrasenaTextBox.Text == string.Empty) 
            {
                errorProvider1.SetError(ContrasenaTextBox, "Ingrese una contrasena");
                ContrasenaTextBox.Clear();
                ContrasenaTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            Login login = new Login(UsuarioTextBox.Text, ContrasenaTextBox.Text);
            Usuario usuario = new Usuario();
            TicketDB usuarioDB = new TicketDB();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {
                if (usuario.EstaActivo)
                {
                    System.Security.Principal.GenericIdentity identidad = new System.Security.Principal.GenericIdentity(usuario.CodigoUsuario);
                    System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identidad, new string[] { usuario.Rol });
                    System.Threading.Thread.CurrentPrincipal = principal;

                    //Montramos el Menu
                    //MessageBox.Show("Bienvenido al Sistema");
                    Menu menuFormulario = new Menu();
                    Hide();
                    menuFormulario.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no esta activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarContrasenaButton_Click(object sender, EventArgs e)
        {
            if (ContrasenaTextBox.PasswordChar == '*')
            {
                ContrasenaTextBox.PasswordChar = '\0';
            }
            else
            {
                ContrasenaTextBox.PasswordChar = '*';
            }
        }
    }
}
