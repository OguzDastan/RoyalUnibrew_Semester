using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Models;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ConsumerUWP.Custom_Controls
{
    public sealed partial class AdministerProcess : UserControl
    {
        #region Dependencies
        public static readonly DependencyProperty PoToAdministerProperty = DependencyProperty.Register(
            "PoToAdminister", typeof(ProcessOrdre), typeof(AdministerProcess),
            new PropertyMetadata(default(ProcessOrdre)));

        public ProcessOrdre PoToAdminister
        {
            get { return (ProcessOrdre)GetValue(PoToAdministerProperty); }
            set { SetValue(PoToAdministerProperty, value); }
        }
        #endregion

        public AdministerProcess()
        {
            this.InitializeComponent();
        }
    }
}