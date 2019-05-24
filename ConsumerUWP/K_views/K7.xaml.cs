using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ConsumerUWP.ViewModels;
using ConsumerUWP;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ConsumerUWP.K_views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class K7 : Page
    {
        public K7()
        {
            this.InitializeComponent();
            ControlPopUp.Visibility = Visibility.Collapsed;
            GaaTilArk.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /// TODO: session check for admin clearence
            if (ControlPopUp.Visibility == Visibility.Collapsed)
            {
                ControlPopUp.Visibility = Visibility.Visible;
                GaaTilArk.Visibility = Visibility.Collapsed;
            }
            else
            {
                ControlPopUp.Visibility = Visibility.Collapsed;
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            /// TODO: session check for admin clearence
            if (GaaTilArk.Visibility == Visibility.Collapsed)
            {
                GaaTilArk.Visibility = Visibility.Visible;
                ControlPopUp.Visibility = Visibility.Collapsed;
            }
            else
            {
                GaaTilArk.Visibility = Visibility.Collapsed;
            }
        }
        private OverviewVM ovm;
        /*
        private void ListView_ItemClick(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(EtiketteArk), ovm.SelectedArk.ProcessOrderNR);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        */
    }
}
