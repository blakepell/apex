﻿#pragma checksum "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0AFFFFEA5729C011B74FCFBE3B6CC7CDF8C1EC1D42296151A67E8C75796A63B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Apex.Controls;
using Apex.DragAndDrop;
using Apex.MVVM;
using Gallery.DragAndDrop.ItemsControlSample;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Gallery.DragAndDrop.ItemsControlSample {
    
    
    /// <summary>
    /// ItemsControlSampleView
    /// </summary>
    public partial class ItemsControlSampleView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gallery.DragAndDrop.ItemsControlSample.ItemsControlSampleViewModel viewModel;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Apex.DragAndDrop.DragAndDropHost dragAndDropHost;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl listTopLeft;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl listTopRight;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl listBottomLeft;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl listBottomRight;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Gallery.WPF;component/draganddrop/itemscontrolsample/itemscontrolsampleview.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\DragAndDrop\ItemsControlSample\ItemsControlSampleView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.viewModel = ((Gallery.DragAndDrop.ItemsControlSample.ItemsControlSampleViewModel)(target));
            return;
            case 2:
            this.dragAndDropHost = ((Apex.DragAndDrop.DragAndDropHost)(target));
            return;
            case 3:
            this.listTopLeft = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 4:
            this.listTopRight = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 5:
            this.listBottomLeft = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 6:
            this.listBottomRight = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

