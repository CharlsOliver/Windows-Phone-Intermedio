using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App05_LinqSQL.Resources;
using App05_LinqSQL.BaseDatos;

namespace App05_LinqSQL
{
    public partial class MainPage : PhoneApplicationPage
    {
        cContextData contexto = new cContextData("isostore:/WP8.sdf");

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ConectarBD();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ConectarBD() {

            if (!contexto.DatabaseExists())
                contexto.CreateDatabase();
        }

        private void Btn_Alta_Click(object sender, RoutedEventArgs e)
        {
            if(txBox_Nombre.Text != string.Empty && txBox_Telefono.Text != string.Empty && txBox_Correo.Text != string.Empty) {

                tCliente cliente = new tCliente();
                cliente.nombre = this.txBox_Nombre.Text;
                cliente.telefono = this.txBox_Telefono.Text;
                cliente.correo = this.txBox_Correo.Text;

                contexto.tClientes.InsertOnSubmit(cliente);
                contexto.SubmitChanges();

                MessageBox.Show("Registro creado correctamente", "Alta", MessageBoxButton.OK);
            } else {

                MessageBox.Show("Hay campos obligatorios vacios", "No se puede insertar :(", MessageBoxButton.OK);
            }
        }

        private void Btn_Baja_Click(object sender, RoutedEventArgs e)
        {
            if(txBox_Nombre.Text != string.Empty) {

                var vConsulta = from cliente in contexto.tClientes
                                where cliente.nombre.Contains(this.txBox_Nombre.Text)
                                select cliente;

                tCliente borrarCliente = vConsulta.First();
                contexto.tClientes.DeleteOnSubmit(borrarCliente);
                contexto.SubmitChanges();
                MessageBox.Show("Registro borrado con éxito","Eliminado :)", MessageBoxButton.OK);

            } else {
                MessageBox.Show("Hay campos obligatorios vacios", "No se puede eliminar :(", MessageBoxButton.OK);
            }
        }

        private void Btn_Consulta_Click(object sender, RoutedEventArgs e)
        {
            if(txBox_Nombre.Text != string.Empty){

                var vConsulta = from cliente in contexto.tClientes
                                where cliente.nombre.Contains(txBox_Nombre.Text)
                                select cliente;

                foreach (var info in vConsulta) {
                    txBox_Nombre.Text = info.nombre.ToString();
                    txBox_Correo.Text = info.correo.ToString();
                    txBox_Telefono.Text = info.telefono.ToString();
                }

                MessageBox.Show("Consulta realizada con éxito", "Consulta exitosa :)", MessageBoxButton.OK);
            } else {
                MessageBox.Show("Hay campos obligatorios vacios", "No se puede consultar :(", MessageBoxButton.OK);
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