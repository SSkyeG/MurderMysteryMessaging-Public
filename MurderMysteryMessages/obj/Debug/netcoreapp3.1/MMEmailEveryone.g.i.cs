﻿#pragma checksum "..\..\..\MMEmailEveryone.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3275AB0F4AE8482DA133A46BBC86FBB80CAC9E9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MurderMysteryMessages;
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


namespace MurderMysteryMessages {
    
    
    /// <summary>
    /// MMEmailEveryone
    /// </summary>
    public partial class MMEmailEveryone : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subjectTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendMeButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendEveryoneButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SelectedData;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectAll;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MMEmailEveryone.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendSelectedButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MurderMysteryMessages;V1.0.0.0;component/mmemaileveryone.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MMEmailEveryone.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.subjectTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\MMEmailEveryone.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.clearButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sendMeButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\MMEmailEveryone.xaml"
            this.sendMeButton.Click += new System.Windows.RoutedEventHandler(this.sendMeButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sendEveryoneButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\MMEmailEveryone.xaml"
            this.sendEveryoneButton.Click += new System.Windows.RoutedEventHandler(this.sendEveryoneButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\MMEmailEveryone.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SelectedData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.SelectAll = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.sendSelectedButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\MMEmailEveryone.xaml"
            this.sendSelectedButton.Click += new System.Windows.RoutedEventHandler(this.sendSelectedButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

