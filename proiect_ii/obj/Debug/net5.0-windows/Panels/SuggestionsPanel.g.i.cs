﻿#pragma checksum "..\..\..\..\Panels\SuggestionsPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DAC08CFE50CEBC440491B5DB7976379AAF5BB170"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using proiect_ii.Panels;


namespace proiect_ii.Panels {
    
    
    /// <summary>
    /// SuggestionsPanel
    /// </summary>
    public partial class SuggestionsPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Panels\SuggestionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Panels\SuggestionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox firstComboBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Panels\SuggestionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox secondComboBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Panels\SuggestionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox thirdComboBox;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Panels\SuggestionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label testLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/proiect_ii;component/panels/suggestionspanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Panels\SuggestionsPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\..\Panels\SuggestionsPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextButton);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\..\Panels\SuggestionsPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PreviousButton);
            
            #line default
            #line hidden
            return;
            case 3:
            this.confirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Panels\SuggestionsPanel.xaml"
            this.confirmButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmSelection);
            
            #line default
            #line hidden
            return;
            case 4:
            this.firstComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.secondComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.thirdComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.testLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

