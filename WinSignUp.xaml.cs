using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace PrimerLoginWPF
{
    /// <summary>
    /// Lógica de interacción para WinSignUp.xaml
    /// </summary>
    public partial class WinSignUp : Window
    {
        private readonly string rutaYnombreArch = "C:\\Logins\\Logins.txt";
        public WinSignUp()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtApPat.Text = "";
            txtApMat.Text = "";
            txtEmail.Text = "";
            txtCel.Text = "";
            txtAñoNac.Text = "";
            txtContra.Password = "";
            txBResultado.Text = "";

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtApPat.Text == "" || txtApMat.Text == "" || txtEmail.Text == "" || txtCel.Text == "" || txtAñoNac.Text == "" || txtContra.Password == "")
            {
                lblMensajes.Content = "Deb completar TODOS los datos";
                lblMensajes.Foreground = Brushes.Red;
                if (txtContra.Password.Length < 8)
                {
                    MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Contraseña ingresada válida.");
                }
                string textoAnio = txtAñoNac.Text;

                if (int.TryParse(textoAnio, out int anio))
                {
                    if (anio > 2025)
                    {
                        MessageBox.Show("El año no puede ser mayor que 2025.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else if (anio < 1930)
                    {
                        MessageBox.Show("El año no puede ser menor que 1930.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un año válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }


            else
            {
                try
                {
                    lblMensajes.Content = "Bienvenido al sistema NN" + txtNombre.Text + "..";

                    txBResultado.Text =  txtNombre.Text + ","  + txtApPat.Text + "," +
                        txtApMat.Text + "," +  txtEmail.Text + ","
                        + txtCel.Text + "," +  txtAñoNac.Text + ","
                        + txtContra.Password + "\n";
                    string datos = txBResultado.Text;
                    File.AppendAllText(rutaYnombreArch, datos);
                    WinPrincipal winP = new WinPrincipal();
                    winP.Show();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo " + ex.Message);
                }


            }
        }





        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexNombre = new Regex("^[a-zA-Z ]$");
            e.Handled = !regexNombre.IsMatch(e.Text);
        }

        private void txtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[a-zA-Z0-9@.]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
        }

        private void txtCel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexCelular = new Regex("^[0-9-]+$");
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void txtApPat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexApPat = new Regex("^[a-zA-Z ]$");
            e.Handled = !regexApPat.IsMatch(e.Text);
        }

        private void txtApMat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexApMat = new Regex("^[a-zA-Z ]$");
            e.Handled = !regexApMat.IsMatch(e.Text);
        }

        private void txtAñoNac_PreviewTextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexCelular = new Regex("^[0-9-]+$");
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
