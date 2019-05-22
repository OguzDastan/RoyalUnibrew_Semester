using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Models;
using System.ComponentModel;
using ConsumerUWP.Annotations;
using System.Runtime.CompilerServices;

namespace ConsumerUWP.ViewModels
{
    class EtiketteArk
    {
        public ObservableCollection<PalleCheck> PalleChecks { get; set; }
        public ObservableCollection<LabelCheck> LabelChecks { get; set; }
        

        public EtiketteArk(int ProcessOrderNummer)
        {
            PalleChecks = new ObservableCollection<PalleCheck>();
            LabelChecks = new ObservableCollection<LabelCheck>();

            LoadArk(ProcessOrderNummer);
        }

        private void LoadArk(int ProcessOrderNummer)
        {

            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(new Uri("http://localhost:54926/api/Labeling/" + ProcessOrderNummer));
                string JsonString = response.Result;
                List<Labeling> labels = JsonConvert.DeserializeObject<List<Labeling>>(JsonString);

                foreach (Labeling l in labels)
                {
                    Task<string> responseWorker = client.GetStringAsync(new Uri("http://localhost:54926/api/Worker/" + l.WorkerToSign));
                    Worker w = JsonConvert.DeserializeObject<Worker>(responseWorker.Result);

                    LabelChecks.Add(new LabelCheck()
                    {
                        TimeOfTest = l.TimeOfTest,
                        LabelNumber = l.LableNR,
                        ExpireDate = l.ExpireyDate.Date,
                        WorkerSignature = w.WorkerSign
                    });
                }

                Task<string> responsePallets = client.GetStringAsync(new Uri("http://localhost:54926/api/PalletCheck/" + ProcessOrderNummer));
                List<PalletCheck> pallets = JsonConvert.DeserializeObject<List<PalletCheck>>(responsePallets.Result);

                foreach (PalletCheck item in pallets)
                {
                    Task<string> responseWorker = client.GetStringAsync(new Uri("http://localhost:54926/api/Worker/" + item.WorkerID));
                    Worker w = JsonConvert.DeserializeObject<Worker>(responseWorker.Result);

                    PalleChecks.Add(new PalleCheck()
                    {
                        TimeOfTest = item.TimeOfTest,
                        Pallet = item.Pallet,
                        WorkerSign = w.WorkerSign
                    });
                }
            }
        }

        public class PalleCheck : INotifyPropertyChanged
        {
            public TimeSpan TimeOfTest { get; set; }
            public string Pallet {
                get
                {
                    return _pallet;
                }
                set
                {
                    _pallet = value;
                    OnPropertyChanged();
                }
                    }
            private string _pallet;
            public string WorkerSign { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;


            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class LabelCheck : INotifyPropertyChanged
        {
            public TimeSpan TimeOfTest { get; set; }
            public DateTime ExpireDate { get; set; }
            public int LabelNumber { get; set; }
            public string WorkerSignature { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;


            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
