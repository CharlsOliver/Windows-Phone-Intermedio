using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App05_LinqSQL.BaseDatos;

namespace App05_LinqSQL
{
    public partial class Todos : PhoneApplicationPage
    {
        public Todos()
        {
            InitializeComponent();
            mostrarTodos();
        }

        private void mostrarTodos()
        {
            
            datos.Text = "Datos Cliente \n";
            datos.Text += "=============================== \n";
            cContextData contexto = new cContextData("isostore:/WP8.sdf");

            if (!contexto.DatabaseExists())
            {
                if (MessageBox.Show("La base de datos está vacia, debes agregar por lo menos un registro. ¿Deseas agregar un registro?",
                                     "Vacio :(", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
            else {
                var vConsulta = from cliente in contexto.tClientes
                                select cliente;

                int contador = 0;

                foreach(var info in vConsulta) {
                    datos.Text += "Código: " + info.idCliente.ToString() + "\n";
                    datos.Text += "Nombre: " + info.nombre.ToString() + "\n";
                    datos.Text += "Teléfono: " + info.telefono.ToString() + "\n";
                    datos.Text += "Correo: " + info.correo.ToString() + "\n";
                    datos.Text += "=============================== \n";

                    contador += 1;
                }

                datos.Text += "\n\n\n" + "Total registrados: " + contador.ToString();
            }
        }
    }
}