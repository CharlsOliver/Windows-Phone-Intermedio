using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App07_Notificaciones.Resources;

namespace App07_Notificaciones
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Btn_RegistrarN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pRegistro.xaml", UriKind.Relative));
        }

        private void Btn_Notificar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pNotificaciones.xaml", UriKind.Relative));
        }
    }
}