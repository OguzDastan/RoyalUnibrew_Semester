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
            ContentDialogResult result = await labelPopup.ShowAsync();
            if (txtbox_Label.Text == "" 
                || txtbox_ExpireDate.Text == "")
            {
                labelPopup.IsPrimaryButtonEnabled = false;
            }
            else
            {
                labelPopup.IsPrimaryButtonEnabled = true;
            }
        }
        private async void OpenPopup2(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await pallePopup.ShowAsync();
            if (txtbox_Palle.Text == "")
            {
                pallePopup.IsPrimaryButtonEnabled = false;
            }
            else
            {
                pallePopup.IsPrimaryButtonEnabled = true;
            }
        }
        private void Txt_Palle_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbox_Palle.Text.Length <= 8)
            {
                Debug.WriteLine("Error in " + txtbox_Palle.Header);
                pallePopup.IsPrimaryButtonEnabled = false;
            }
            else
            {
                pallePopup.IsPrimaryButtonEnabled = true;
            }
        }


        private void Txtbox_Label_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbox_Label.Text.Length <= 5
                || txtbox_ExpireDate.Text.Length <= 9)
            {
                Debug.WriteLine("Error in " + txtbox_Label.Header + " or " + txtbox_ExpireDate.Header);
                labelPopup.IsPrimaryButtonEnabled = false;
            }
            else
            {
                labelPopup.IsPrimaryButtonEnabled = true;
            }
        }

        private void TermsOfUseContentDialog_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (txtbox_Label.Text != ""
                || txtbox_ExpireDate.Text != "")
            {
                Labeling l = new Labeling()
                {
                    ExpireyDate = DateTime.Now,
                    LableNR = Int32.Parse(txtbox_Label.Text),
                    ProcessOrderNR = this.Id,
                    TimeOfTest = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    WorkerToSign = 3
                };
                EtiketteArkVM.SaveLabelCheck(l);
                ET.LabelChecks.Add(new EtiketteArkVM.LabelCheck()
                {
                    ExpireDate = DateTime.Now,
                    LabelNumber = Int32.Parse(txtbox_Label.Text),
                    TimeOfTest = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    Worker = new Worker() { WorkerID = 3, WorkerSign = "BOB"}
                });
            }
            else
            {
                //// TODO
                //// ERROR MSG
            }
        }

        private void PallePopup_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (txtbox_Palle.Text != "")
            {
                PalletCheck p = new PalletCheck()
                {
                    Pallet = txtbox_Palle.Text,
                    ProcessOrderNR = this.Id,
                    TimeOfTest = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    WorkerID = 3
                };
                EtiketteArkVM.SavePalleCheck(p);
                ET.PalleChecks.Add(new EtiketteArkVM.PalleCheck()
                {
                    Pallet = txtbox_Palle.Text,
                    TimeOfTest = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    Worker = new Worker() { WorkerID = 3 }
                });
            }
            else
            {
                //// TODO
                //// ERROR MSG
            }
        }
    }
}
