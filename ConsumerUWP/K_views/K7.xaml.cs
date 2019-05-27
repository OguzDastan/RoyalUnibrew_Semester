using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using Template10.Utils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ConsumerUWP.K_views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class K7 : Page
    {
        public TextBlock getId
        {
            get { return sendId; }
            set { sendId = value; }
        }
        public string Id
        {
            get
            {
                return sendId.Text;
            }
            set
            {
                sendId.Text = value;
            }
        }

        public ProcessOrderArk po { get; set; }
        private OverviewVM ovm;
        public K7()
        {
            this.InitializeComponent();
            ControlPopUp.Visibility = Visibility.Collapsed;
            GaaTilArk.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_ItemClick1(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EtiketteArk), ovm.SelectedArk.ProcessOrderNR);
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            /// TODO: session check for admin clearence
            if (GaaTilArk.Visibility == Visibility.Collapsed)
            {
                GaaTilArk.Visibility = Visibility.Visible;
            }

        }



        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var parameters = new ProcessOrderArk { ProcessOrderNR = Convert.ToInt32(Id) };
            //Debug.WriteLine(Id);
            Frame.Navigate(typeof(EtiketteArk), parameters);
            // int id = po.ProcessOrderNR;
            // this.Frame.Navigate(typeof(EtiketteArkVM), OverviewListFront.SelectedValue);
        }
    }
}
