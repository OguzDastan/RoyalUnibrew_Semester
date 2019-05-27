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
using System.Net;
using ConsumerUWP.Annotations;
using System.Runtime.CompilerServices;
using Windows.Devices.Usb;

namespace ConsumerUWP.ViewModels
{
    public class EtiketteArkVM : ProcessActivity
    {
        public ObservableCollection<PalleCheck> PalleChecks { get; set; }
        public ObservableCollection<LabelCheck> LabelChecks { get; set; }
        public string comment { get; set; }


        public EtiketteArkVM(int ProcessOrderNummer)
        {
            PalleChecks = new ObservableCollection<PalleCheck>();
            LabelChecks = new ObservableCollection<LabelCheck>();
            comment = LoadComment(ProcessOrderNummer).Comment;

            LoadArk(ProcessOrderNummer);
        }

        public EtiketteArkVM()
        {

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
                        Worker = w
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
                        Worker = w
                    });
                }
            }
        }

        public static bool SavePalleCheck(PalletCheck palletCheck)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(palletCheck);
                StringContent content = new StringContent(json, Encoding.ASCII, "Application/json");
                Task<HttpResponseMessage> response = client.PostAsync("http://localhost:54926/api/PalletCheck", content);

                return response.Result.StatusCode == HttpStatusCode.OK;
            }
        }

        public static bool SaveLabelCheck(Labeling labeling)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(labeling);
                StringContent content = new StringContent(json, Encoding.ASCII, "Application/json");
                Task<HttpResponseMessage> response = client.PostAsync("http://localhost:54926/api/Labeling", content);

                return response.Result.StatusCode == HttpStatusCode.OK;
            }
        }

        public static LabelingComment LoadComment(int ProcessOrderNummer)
        {
            LabelingComment comment = new LabelingComment();

            using (HttpClient client = new HttpClient())
            {
                Task<string> response =
                    client.GetStringAsync("http://localhost:54926/api/LabelingComment/" + ProcessOrderNummer);
                comment = JsonConvert.DeserializeObject<LabelingComment>(response.Result);
            }
            return comment;
        }

        public static bool SaveComment(string comment, int ProcessOrderNummer)
        {
            using (HttpClient client = new HttpClient())
            {
                if (LoadComment(ProcessOrderNummer) is null)
                {
                    string json = JsonConvert.SerializeObject(new LabelingComment()
                    {
                        Comment = comment,
                        ProcessOrderNR = ProcessOrderNummer,
                        WorkerID = 3
                    });
                    StringContent content = new StringContent(json, Encoding.ASCII, "Application/json");
                    Task<HttpResponseMessage> response = client.PostAsync("http://localhost:54926/api/LabelingComment", content);
                    return response.Result.StatusCode == HttpStatusCode.OK;
                }
                else
                {
                    string json = JsonConvert.SerializeObject(new LabelingComment()
                    {
                        Comment = comment,
                        ProcessOrderNR = ProcessOrderNummer,
                        WorkerID = 3
                    });
                    StringContent content = new StringContent(json, Encoding.ASCII, "Application/json");
                    Task<HttpResponseMessage> response = client.PutAsync("http://localhost:54926/api/LabelingComment", content);
                    return response.Result.StatusCode == HttpStatusCode.OK;
                }
            }
        }

        public class PalleCheck : INotifyPropertyChanged
        {
            public TimeSpan TimeOfTest { get; set; }
            public string Pallet
            {
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
            public Worker Worker { get; set; }
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
            public Worker Worker { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;


            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
