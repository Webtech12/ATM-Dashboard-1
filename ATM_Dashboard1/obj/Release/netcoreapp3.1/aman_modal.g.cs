﻿#pragma checksum "..\..\..\aman_modal.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6AB4C89EAECFE74CC0E96E3D7F0609DA089A693D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ATM_Dashboard1;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ATM_Dashboard1 {
    
    
    /// <summary>
    /// aman_modal
    /// </summary>
    public partial class aman_modal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txinitial;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtdate;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker txttime;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtOnbehalf;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtsubject;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtrate;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtstatus;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txdesc;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\aman_modal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtrosi;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ATM_Dashboard1;component/aman_modal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\aman_modal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txinitial = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtdate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.txttime = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 4:
            this.txtOnbehalf = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtsubject = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtrate = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txtstatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.txdesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtrosi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 118 "..\..\..\aman_modal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.aman_submit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

