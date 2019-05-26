using Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ConsumerUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EtiketteArk : Page
    {
        public int Id { get; set; }

        
        public List<PalleCheck> Entries { get; set; }
        public EtiketteArk()
        {
            this.InitializeComponent();
        }

        public void GetSingeItem()
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = e.Parameter as ProcessOrderArk;
            Id = parameters.ProcessOrderNR;
            this.ET = new EtiketteArkVM(Id);
            // showing parsed ID
            Debug.WriteLine(Id);
        }

        #region dependency
        public static readonly DependencyProperty ETProperty = DependencyProperty.Register(
            "ET", typeof(EtiketteArkVM), typeof(EtiketteArk), new PropertyMetadata(default(EtiketteArkVM)));

        public EtiketteArkVM ET
        {
            get { return (EtiketteArkVM) GetValue(ETProperty); }
            set { SetValue(ETProperty, value); }
        }

        #endregion

        private async void OpenPopup(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await termsOfUseContentDialog.ShowAsync();
            if (txtbox_Label.Text == "" 
                || txtbox_ExpireDate.Text == "")
            {
                termsOfUseContentDialog.IsPrimaryButtonEnabled = false;
            }
            else
            {
                // GEM TIL DATABASE HER
                termsOfUseContentDialog.IsPrimaryButtonEnabled = true;
            }
        }

        

        private void Txtbox_Label_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbox_Label.Text.Length != 5
                || txtbox_ExpireDate.Text.Length != 5)
            {
                Debug.WriteLine("Error in " + txtbox_Label.Header + " or " + txtbox_ExpireDate.Header);
                termsOfUseContentDialog.IsPrimaryButtonEnabled = false;
            }
            else
            {
                termsOfUseContentDialog.IsPrimaryButtonEnabled = true;
            }
        }

        private void TermsOfUseContentDialog_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (txtbox_Label.Text != ""
                || txtbox_ExpireDate.Text != "")
            {
                //// TODO
                //// GEM DATA
                //// ELLER GØR DET FRA VM
            }
            else
            {
                //// TODO
                //// ERROR MSG
            }
        }
        public class StringFormatConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                var format = parameter as string;
                if (!String.IsNullOrEmpty(format))
                    return String.Format(format, value);

                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
    }
}
