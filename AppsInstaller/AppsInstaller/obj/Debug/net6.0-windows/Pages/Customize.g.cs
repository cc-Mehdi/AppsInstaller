﻿#pragma checksum "..\..\..\..\Pages\Customize.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8B9BF4AB665D652F771DA860DBCFBA8D880CDABB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppsInstaller.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace AppsInstaller.Pages {
    
    
    /// <summary>
    /// Customize
    /// </summary>
    public partial class Customize : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\..\Pages\Customize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chAgreeRules;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Pages\Customize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtInstallLocation;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Pages\Customize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInstallLocation;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\Pages\Customize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chCreateShortcut;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppsInstaller;component/pages/customize.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Customize.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.chAgreeRules = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\..\..\Pages\Customize.xaml"
            this.chAgreeRules.Checked += new System.Windows.RoutedEventHandler(this.chCreateShortcut_Checked);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\Pages\Customize.xaml"
            this.chAgreeRules.Unchecked += new System.Windows.RoutedEventHandler(this.chCreateShortcut_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtInstallLocation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnInstallLocation = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\Pages\Customize.xaml"
            this.btnInstallLocation.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnInstallLocation_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.chCreateShortcut = ((System.Windows.Controls.CheckBox)(target));
            
            #line 156 "..\..\..\..\Pages\Customize.xaml"
            this.chCreateShortcut.Checked += new System.Windows.RoutedEventHandler(this.chCreateShortcut_Checked);
            
            #line default
            #line hidden
            
            #line 157 "..\..\..\..\Pages\Customize.xaml"
            this.chCreateShortcut.Unchecked += new System.Windows.RoutedEventHandler(this.chCreateShortcut_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

