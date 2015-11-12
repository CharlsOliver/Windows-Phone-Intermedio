using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App04_Vibrador.Resources;
using Microsoft.Devices;

namespace App04_Vibrador
{
    public partial class MainPage : PhoneApplicationPage
    {
        VibrateController objVibrador;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btn3s_Click(object sender, RoutedEventArgs e)
        {
            TiempoVibracion(3);
        }

        private void btn5s_Click(object sender, RoutedEventArgs e)
        {
            TiempoVibracion(5);
        }

        private void TiempoVibracion(double tiempo)
        {
            objVibrador = VibrateController.Default;
            objVibrador.Start(TimeSpan.FromSeconds(tiempo));
        }
    }
}