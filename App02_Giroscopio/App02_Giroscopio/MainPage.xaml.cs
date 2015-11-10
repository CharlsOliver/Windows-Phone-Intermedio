using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App02_Giroscopio.Resources;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace App02_Giroscopio
{
    public partial class MainPage : PhoneApplicationPage
    {
        Gyroscope giroscopio;
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
            if(Gyroscope.IsSupported){ 
                
                if(!vEstado) {

                    giroscopio = new Gyroscope();
                    giroscopio.TimeBetweenUpdates = TimeSpan.FromMilliseconds(2);
                    giroscopio.CurrentValueChanged += giroscopio_CurrentValueChanged;
                    giroscopio.Start();
                    Btn_Iniciar.Content = "Apagar Giroscopio";
                    vEstado = true;

                } else {

                    Btn_Iniciar.Content = "Iniciar Giroscopio";
                    vEstado = false;
                    giroscopio.Stop();
    
                }
            } else {
                MessageBox.Show("El dispositivo no cuenta con Giroscopio", "Giroscopio", MessageBoxButton.OK);
            }
        }

        private void giroscopio_CurrentValueChanged(object sender, SensorReadingEventArgs<GyroscopeReading> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                Vector3 v3 = e.SensorReading.RotationRate;
                txBlock_x.Text += v3.X.ToString();
                txBlock_y.Text += v3.Y.ToString();
                txBlock_z.Text += v3.Z.ToString();

                lnx.X2 = lnx.X1 + v3.X * 200;
                lny.Y2 = lny.Y1 + v3.Y * 200;
                lnx.X2 = lnz.X1 + v3.Z * 100;
                lnz.Y2 = lnx.Y1 + v3.Z * 100;
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