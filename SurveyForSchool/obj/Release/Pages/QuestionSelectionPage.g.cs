﻿#pragma checksum "..\..\..\Pages\QuestionSelectionPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0629D6B2C15A52D9C6E981438979A9C90E0A9973E4495562B20919B50DD343E5"
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
    /// QuestionSelectionPage
    /// </summary>
    public partial class QuestionSelectionPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 25 "..\..\..\Pages\QuestionSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView checkQuestionList;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\QuestionSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nameStudentCheck;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\QuestionSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputNameFile;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Pages\QuestionSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox checkCategory;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\QuestionSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label textLabel;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\QuestionSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputCountQuestion;
        
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
            System.Uri resourceLocater = new System.Uri("/SurveyForSchool;component/pages/questionselectionpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\QuestionSelectionPage.xaml"
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
            this.checkQuestionList = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.nameStudentCheck = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.inputNameFile = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\..\Pages\QuestionSelectionPage.xaml"
            this.inputNameFile.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filteration);
            
            #line default
            #line hidden
            return;
            case 5:
            this.checkCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\..\Pages\QuestionSelectionPage.xaml"
            this.checkCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CheckIndexCategories);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.inputCountQuestion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 65 "..\..\..\Pages\QuestionSelectionPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit);
            
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
            case 2:
            
            #line 28 "..\..\..\Pages\QuestionSelectionPage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.StartTestClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

