using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App03_Brújula.Resources;
using Microsoft.Devices.Sensors;
using System.Windows.Media;
using System.Windows.Threading;

namespace App03_Brújula
{
    public partial class MainPage : PhoneApplicationPage
    {

        Compass objBrujula;
        RotateTransform objMovimiento;
        DispatcherTimer objCalibracion;
        double vTrueHeading = 0;
        double vReciproco = 0;
        double vHeadingAcurrency = 0;
        bool vBrujula = false;
        bool vAlfa = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Btn_Brujula_Click(object sender, RoutedEventArgs e)
        {
            if(Compass.IsSupported) {
                if (!vBrujula)
                {
                    objBrujula = new Compass();
                    objBrujula.TimeBetweenUpdates = TimeSpan.FromMilliseconds(100);
                    objBrujula.CurrentValueChanged += objBrujula_CurrentValueChanged;
                    objBrujula.Start();
                    Btn_Brujula.Content = "Apagar Brújula";
                }
                else {
                    vBrujula = false;
                    Btn_Brujula.Content = "Iniciar Brújula";
                    objBrujula.Stop();
                }
            } else {
                MessageBox.Show("El dispositivo no tiene brújula","Brújula", MessageBoxButton.OK);
            }
        }

        void objBrujula_CurrentValueChanged(object sender, SensorReadingEventArgs<CompassReading> e)
        {
            if(objBrujula.IsDataValid){

                Dispatcher.BeginInvoke(() =>
                {
                    vHeadingAcurrency = e.SensorReading.HeadingAccuracy;
                    vTrueHeading = e.SensorReading.TrueHeading;
                    objMovimiento = new RotateTransform();

                    if ((180 <= vTrueHeading) && (vTrueHeading >= 360))
                        vReciproco = vTrueHeading - 180;
                    else
                        vReciproco = vTrueHeading + 180;

                    brujula.RenderTransformOrigin = new Point(0.5, 0.5);

                    objMovimiento.Angle = 360 - vTrueHeading;
                    brujula.RenderTransform = objMovimiento;

                    if (!vAlfa)
                    {

                        vTrueHeading = Math.Round(vTrueHeading, 2);
                        txBlock_grados.Text = "Grados: " + vTrueHeading.ToString();

                        vReciproco = Math.Round(vReciproco, 2);
                        txBlock_reciproco.Text = "Reciproco: " + vReciproco.ToString();
                    }
                    else {
                        if (((337 <= vTrueHeading) && (vTrueHeading < 360)) || ((0 <= vTrueHeading) && (vTrueHeading < 22))) {
                            txBlock_grados.Text = "Norte";
                            txBlock_reciproco.Text = "Sur";
                        }
                        else if ((22 <= vTrueHeading) && (vTrueHeading < 67)) {
                            txBlock_grados.Text = "Nor-Oeste";
                            txBlock_reciproco.Text = "Sur-Oeste";
                        }
                        else if ((67 <= vTrueHeading) && (vTrueHeading < 112)) {
                            txBlock_grados.Text = "Este";
                            txBlock_reciproco.Text = "Oeste";
                        }
                        else if ((112 <= vTrueHeading) && (vTrueHeading < 152)) {
                            txBlock_grados.Text = "Sur-Este";
                            txBlock_reciproco.Text = "Nor-Este";
                        }
                        else if ((152 <= vTrueHeading) && (vTrueHeading < 202))
                        {
                            txBlock_grados.Text = "Sur";
                            txBlock_reciproco.Text = "Norte";
                        }
                        else if ((202 <= vTrueHeading) && (vTrueHeading < 247))
                        {
                            txBlock_grados.Text = "Sur-Oeste";
                            txBlock_reciproco.Text = "Nor-Oeste";
                        }
                        else if ((247 <= vTrueHeading) && (vTrueHeading < 292))
                        {
                            txBlock_grados.Text = "Oeste";
                            txBlock_reciproco.Text = "Este";
                        }
                        else if ((292 <= vTrueHeading) && (vTrueHeading < 337))
                        {
                            txBlock_grados.Text = "Nor-Oeste";
                            txBlock_reciproco.Text = "Sur-Este";
                        }
                    }
                });
            }
        }

        private void Btn_Alfa_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Btn_Alfa.Content == "Numerico")
            {

                vAlfa = false;
                Btn_Alfa.Content = "Alfa";
            }
            else {

                vAlfa = true;
                Btn_Alfa.Content = "Numerico";
            }
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