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
        private EtikketSingleView et;

        private ObservableCollection<ProcessOrderArk> singleArk = new ObservableCollection<ProcessOrderArk>();
        private ObservableCollection<ProcessOrderArk> alleProcesser = ProcessOrderArk.LoadAllArks();
        public List<PalleCheck> Entries { get; set; }
        public EtiketteArk()
        {
            this.InitializeComponent();
            PalleCheckManager p = new PalleCheckManager();
            Entries = p.Entries;


        }

        public void GetSingeItem()
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /// TODO: 
            /// CAST PARAM AS DESIRED MODEL
            /// SELECT SINGLE FROM MODEL LIST
            /// BIND LIST TO XAML
            var parameters = e.Parameter as ProcessOrderArk;
            Id = parameters.ProcessOrderNR;
            Debug.WriteLine(Id);



        }

    }
}
