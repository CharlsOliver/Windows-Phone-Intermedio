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
                MessageBox.Show("Registro creado correctamente", "Registro exitoso :)", MessageBoxButton.OK);
                BorrarDatos();
        }

        public void BorrarDatos() {

            txBox_Nombre.Text = string.Empty;
            txBox_Telefono.Text = string.Empty;
            txBox_Correo.Text = string.Empty;
        }

        private void Btn_Baja_Click(object sender, RoutedEventArgs e)
        {
            if(txBox_Nombre.Text != string.Empty){

                WebClient eliminar = new WebClient();

                objBuilder = new StringBuilder();
                objUri = new Uri(vUrl, UriKind.Absolute);
                objBuilder.AppendFormat("{0}={1},{2}","vCadena",
                    HttpUtility.UrlEncode(txBox_Nombre.Text),
                    HttpUtility.UrlEncode("2"));

                eliminar.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                eliminar.Headers[HttpRequestHeader.ContentLength] = objBuilder.Length.ToString();

                eliminar.UploadStringAsync(objUri, "POST", objBuilder.ToString());
                eliminar.UploadStringCompleted += eliminar_UploadStringCompleted;
            } else { }
        }

        void eliminar_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if(e.ToString() == "OK"){
                MessageBox.Show("El registro se eliminó correctamente", "Registro eliminado :)", MessageBoxButton.OK);
            } else {
                MessageBox.Show("No se pudo eliminar el registro, intentalo mas tarde", "Error :(", MessageBoxButton.OK);
            }
            
        }

        private void Btn_Consulta_Click(object sender, RoutedEventArgs e)
        {
            if (txBox_Nombre.Text != string.Empty)
            {

                WebClient eliminar = new WebClient();

                objBuilder = new StringBuilder();
                objUri = new Uri(vUrl, UriKind.Absolute);
                objBuilder.AppendFormat("{0}={1},{2}", "vCadena",
                    HttpUtility.UrlEncode(txBox_Nombre.Text),
                    HttpUtility.UrlEncode("3"));

                eliminar.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                eliminar.Headers[HttpRequestHeader.ContentLength] = objBuilder.Length.ToString();

                eliminar.UploadStringAsync(objUri, "POST", objBuilder.ToString());
                eliminar.UploadStringCompleted += consultar_UploadStringCompleted;
            }
            else { }
        }

        private void consultar_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            String[] aRresultado = e.Result.ToString().Split(',');

            if (aRresultado[0].ToString() == "001")
            {
                MessageBox.Show("No se pudo obtener los datos de la consulta", "Ocurrió un error :(", MessageBoxButton.OK);
            }
            else {
                txBox_Telefono.Text = aRresultado[1].ToString();
                txBox_Correo.Text = aRresultado[2].ToString();
            }
        }

    }
}