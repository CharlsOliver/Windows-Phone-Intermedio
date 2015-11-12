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

namespace App07_Notificaciones
{
    public partial class pNotificaciones : PhoneApplicationPage
    {
        WebClient noti;
        StringBuilder builder;
        Uri uri;
        string vUrl = "http://www.isysc.net/winphone/notificaciones.php";

        public pNotificaciones()
        {
            InitializeComponent();
        }

        private void Btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            if (txBox_Tel.Text != string.Empty && txBox_Mensaje.Text != string.Empty) {
                if (chBox_Toast.IsChecked == true || chBox_Tie.IsChecked == true || chBox_TieToast.IsChecked == true) {
                    if (chBox_Tie.IsChecked == true)
                        EnviarNotificacion("2");
                    
                    if (chBox_Toast.IsChecked == true)
                        EnviarNotificacion("1");

                    if (chBox_TieToast.IsChecked == true)
                        EnviarNotificacion("3");
                }
            }
        }

        private void EnviarNotificacion(string vTipoNotificacion)
        {
            noti = new WebClient();
            builder = new StringBuilder();
            uri = new Uri(vUrl, UriKind.Absolute);

            builder.AppendFormat("{0}={1},{2},{3},{4},{5},{6}",
            "vCadena", HttpUtility.UrlEncode(txBox_Tel.Text),
            HttpUtility.UrlEncode("2"),HttpUtility.UrlEncode(""),
            HttpUtility.UrlEncode(txBox_Tel.Text),HttpUtility.UrlEncode(txBox_Mensaje.Text),
            HttpUtility.UrlEncode(vTipoNotificacion));

            noti.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            noti.Headers[HttpRequestHeader.ContentLength] = builder.Length.ToString();
            noti.UploadStringAsync(uri, "POST", builder.ToString());
            noti.UploadStringCompleted += noti_UploadStringCompleted;
        }

        void noti_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString(), "Notificación", MessageBoxButton.OK);
        }

        private void chBox_Toast_Checked(object sender, RoutedEventArgs e)
        {
            if(chBox_Toast.IsChecked == true)
            {
                chBox_Tie.IsChecked = false;
                chBox_TieToast.IsChecked = false;
            }
        }

        private void chBox_Tie_Checked(object sender, RoutedEventArgs e)
        {
            if (chBox_Tie.IsChecked == true)
            {
                chBox_Toast.IsChecked = false;
                chBox_TieToast.IsChecked = false;
            }
        }

        private void chBox_TieToast_Checked(object sender, RoutedEventArgs e)
        {
            if (chBox_TieToast.IsChecked == true)
            {
                chBox_Tie.IsChecked = false;
                chBox_Toast.IsChecked = false;
            }
        }


    }
}