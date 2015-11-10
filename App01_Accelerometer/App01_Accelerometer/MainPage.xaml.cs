using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App01_Accelerometer.Resources;
using Microsoft.Devices.Sensors;

namespace App01_Accelerometer
{
    public partial class MainPage : PhoneApplicationPage
    {

        Accelerometer acelerometro;
        bool vEstado = false;


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Btn_Iniciar_Click(object sender, RoutedEventArgs e)
        {
            if (Accelerometer.IsSupported)
            {
                if (!vEstado) {

                    acelerometro = new Accelerometer();
                    acelerometro.TimeBetweenUpdates = TimeSpan.FromMilliseconds(100);
                    acelerometro.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(LeerEstado);
                    Btn_Iniciar.Content = "Apagar Acelerómetro";
                    acelerometro.Start();
                    vEstado = true;

                } else {
                    
                    Btn_Iniciar.Content = "Iniciar Acelerómetro";
                    vEstado = false;
                    acelerometro.Stop();
                }
            } else {
                MessageBox.Show("El dispositivo no cuenta con acelerómetro :( ","Acelerómetro",MessageBoxButton.OK);
            }
        }


        private void LeerEstado(object sender, SensorReadingEventArgs<AccelerometerReading> e) {
            Dispatcher.BeginInvoke(() =>
                {
                    txbox_x.Text = e.SensorReading.Acceleration.X.ToString();
                    txbox_y.Text = e.SensorReading.Acceleration.Y.ToString();
                    txbox_z.Text = e.SensorReading.Acceleration.Z.ToString();
                });
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}