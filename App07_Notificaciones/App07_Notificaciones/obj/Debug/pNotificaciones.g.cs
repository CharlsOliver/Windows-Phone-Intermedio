﻿#pragma checksum "C:\Users\PC25\Documents\Oliver\App07_Notificaciones\App07_Notificaciones\pNotificaciones.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "26D7BE52D4D0275975766D5EBEE07CA6"
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


namespace App07_Notificaciones {
    
    
    public partial class pNotificaciones : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.CheckBox chBox_Toast;
        
        internal System.Windows.Controls.CheckBox chBox_Tie;
        
        internal System.Windows.Controls.CheckBox chBox_TieToast;
        
        internal System.Windows.Controls.TextBox txBox_Tel;
        
        internal System.Windows.Controls.TextBox txBox_Mensaje;
        
        internal System.Windows.Controls.Button Btn_Enviar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/App07_Notificaciones;component/pNotificaciones.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.chBox_Toast = ((System.Windows.Controls.CheckBox)(this.FindName("chBox_Toast")));
            this.chBox_Tie = ((System.Windows.Controls.CheckBox)(this.FindName("chBox_Tie")));
            this.chBox_TieToast = ((System.Windows.Controls.CheckBox)(this.FindName("chBox_TieToast")));
            this.txBox_Tel = ((System.Windows.Controls.TextBox)(this.FindName("txBox_Tel")));
            this.txBox_Mensaje = ((System.Windows.Controls.TextBox)(this.FindName("txBox_Mensaje")));
            this.Btn_Enviar = ((System.Windows.Controls.Button)(this.FindName("Btn_Enviar")));
        }
    }
}

