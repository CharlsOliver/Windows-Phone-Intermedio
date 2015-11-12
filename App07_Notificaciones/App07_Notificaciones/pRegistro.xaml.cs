using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using Microsoft.Phone.Notification;

namespace App07_Notificaciones
{
    public partial class pRegistro : PhoneApplicationPage
    {
        WebClient notificacion;
        StringBuilder builder;
        Uri uri;

        HttpNotificationChannel uriChannel;
        string vUrl = "http://www.isysc.net/winphone/notificaciones.php";
        string vNombreCanal = "Congreso";
        string vUriMPNS = "";

        public pRegistro()
        {
            InitializeComponent();
            txBlock_Notificacion.Text = "Obteniendo UriChannel MPNS";
            abrirCanalMPNS();
        }

        private void abrirCanalMPNS() 
        {
            uriChannel = HttpNotificationChannel.Find(vNombreCanal);
            if (uriChannel == null) 
            {
                uriChannel = new HttpNotificationChannel(vNombreCanal);
                uriChannel.Open();
                uriChannel.BindToShellToast();
                uriChannel.BindToShellTile();
            }

            uriChannel.ChannelUriUpdated += uriChannel_ChannelUriUpdated;
            uriChannel.ErrorOccurred += uriChannel_ErrorOccurred;
        }

        void uriChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            txBlock_Notificacion.Text = "Obteniendo UriChannel MPNS...";
            abrirCanalMPNS();
        }

        void uriChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            if (e.ChannelUri.ToString() != string.Empty) {
                txBlock_Notificacion.Text = "UriChannel OK";
               // Btn_Alta.IsEnabled = true;
                vUriMPNS = e.ChannelUri.ToString();
            }
            
        }

        void notificacion_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.ToString() == "OK")
            {
                MessageBox.Show("El regristro se creó correctamente", "Registro exitoso :)", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else {
                MessageBox.Show("Error al agregar el registro", "Error :(", MessageBoxButton.OK);
            }
        }

        private void altaRegistro() {

            if (txBox_Tel.Text != string.Empty)
            {
                if (vUriMPNS != string.Empty)
                {

                    notificacion = new WebClient();
                    builder = new StringBuilder();
                    uri = new Uri(vUrl, UriKind.Absolute);

                    builder.AppendFormat("{0}={1},{2},{3}", "vCadena",
                        HttpUtility.UrlEncode(txBox_Tel.Text),
                        HttpUtility.UrlEncode("1"),
                        HttpUtility.UrlEncode(vUriMPNS));

                    notificacion.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    notificacion.Headers[HttpRequestHeader.ContentLength] = builder.Length.ToString();

                    notificacion.UploadStringAsync(uri, "POST", builder.ToString());
                    notificacion.UploadStringCompleted += notificacion_UploadStringCompleted;

                }
                else
                {
                    abrirCanalMPNS();
                    altaRegistro();
                }
            }
        }

        private void Btn_Alta_Click(object sender, RoutedEventArgs e)
        {
            altaRegistro();
        }

       
    }
}