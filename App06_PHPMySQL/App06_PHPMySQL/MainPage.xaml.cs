using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App06_PHPMySQL.Resources;
using System.Text;

namespace App06_PHPMySQL
{
    public partial class MainPage : PhoneApplicationPage
    {

        Uri objUri;
        StringBuilder objBuilder;
        WebClient objCliente;
        string vUrl = "http://www.isysc.net/winphone/ABC.php";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Btn_Alta_Click(object sender, RoutedEventArgs e)
        {
            try {

                objCliente = new WebClient();
                objBuilder = new StringBuilder();
                objUri = new Uri(vUrl, UriKind.Absolute);

                objBuilder.AppendFormat("{0}={1},{2},{3},{4}",
                "vCadena", HttpUtility.UrlEncode(txBox_Nombre.Text),
                            HttpUtility.UrlEncode("1"), HttpUtility.UrlEncode(txBox_Telefono.Text),
                            HttpUtility.UrlEncode(txBox_Correo.Text));

                objCliente.Headers[HttpRequestHeader.ContentType] = 
                    "application/x-www-form-urlencoded";
                objCliente.Headers[HttpRequestHeader.ContentLength] =
                    objBuilder.Length.ToString();

                objCliente.UploadStringAsync(objUri, "POST", objBuilder.ToString());

                objCliente.UploadStringCompleted += objCliente_UploadStringCompleted;
            }
            catch (Exception ex) { 
            
            }
        }

        void objCliente_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
           /* if (e.ToString() == "OK")
            {*/
                MessageBox.Show("Registro creado correctamente", "Registro exitoso :)", MessageBoxButton.OK);
                BorrarDatos();
            /*}
            else
                MessageBox.Show("No se pudo conectar con el servidor, verifique su conexión e intente más tarde", "Error :(", MessageBoxButton.OK);
             * */
        }

        public void BorrarDatos() {

            txBox_Nombre.Text = string.Empty;
            txBox_Telefono.Text = string.Empty;
            txBox_Correo.Text = string.Empty;
        }

    }
}