﻿#pragma checksum "..\..\..\Pages\AdminPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F516B72EBFB715AEC100AED69CEADF4D8F1BEEDE479CCEFCE3EAC6CB78C9AC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SurveyForSchool;
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


namespace SurveyForSchool {
    
    
    /// <summary>
    /// AdminPage
    /// </summary>
    public partial class AdminPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 11 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelCheck;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputNameFolder;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid data;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputNameFile;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox checkCategory;
        
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
            System.Uri resourceLocater = new System.Uri("/SurveyForSchool;component/pages/adminpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AdminPage.xaml"
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
            this.stackPanelCheck = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.inputNameFolder = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.data = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.inputNameFile = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\Pages\AdminPage.xaml"
            this.inputNameFile.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filteration);
            
            #line default
            #line hidden
            return;
            case 8:
            this.checkCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 58 "..\..\..\Pages\AdminPage.xaml"
            this.checkCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CheckIndexCategories);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 61 "..\..\..\Pages\AdminPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 64 "..\..\..\Pages\AdminPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddQuest);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 65 "..\..\..\Pages\AdminPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCategories);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 43 "..\..\..\Pages\AdminPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoTest);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 44 "..\..\..\Pages\AdminPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveTest);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
