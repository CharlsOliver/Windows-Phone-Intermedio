﻿#pragma checksum "C:\Users\PC25\Documents\Oliver\App05_LinqSQL\App05_LinqSQL\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "899BD1C7DADD3032B717F85485D2BEC3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace App05_LinqSQL {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox txBox_Nombre;
        
        internal System.Windows.Controls.TextBox txBox_Telefono;
        
        internal System.Windows.Controls.TextBox txBox_Correo;
        
        internal System.Windows.Controls.Button Btn_Alta;
        
        internal System.Windows.Controls.Button Btn_Baja;
        
        internal System.Windows.Controls.Button Btn_Consulta;
        
        internal System.Windows.Controls.Button Btn_Todos;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/App05_LinqSQL;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txBox_Nombre = ((System.Windows.Controls.TextBox)(this.FindName("txBox_Nombre")));
            this.txBox_Telefono = ((System.Windows.Controls.TextBox)(this.FindName("txBox_Telefono")));
            this.txBox_Correo = ((System.Windows.Controls.TextBox)(this.FindName("txBox_Correo")));
            this.Btn_Alta = ((System.Windows.Controls.Button)(this.FindName("Btn_Alta")));
            this.Btn_Baja = ((System.Windows.Controls.Button)(this.FindName("Btn_Baja")));
            this.Btn_Consulta = ((System.Windows.Controls.Button)(this.FindName("Btn_Consulta")));
            this.Btn_Todos = ((System.Windows.Controls.Button)(this.FindName("Btn_Todos")));
        }
    }
}

