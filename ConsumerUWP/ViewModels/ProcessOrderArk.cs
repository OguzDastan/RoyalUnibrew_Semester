using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ConsumerUWP.Annotations;
using Models;
using Newtonsoft.Json;

namespace ConsumerUWP.ViewModels
{
    public class ProcessOrderArk : INotifyPropertyChanged
    {
        private char _process;
        private DateTime _processDate;
        private int _endproductNR;
        private string _endProductName;
        private int _ColumnNR;
        private int _processOrderNR;

        public ObservableCollection<ProcessActivity> activities { get; set; }

        public char Process
        {
            get { return _process; }
            set
            {
                _process = value;
                OnPropertyChanged();
            }
        }

        public DateTime ProcessDate
        {
            get { return _processDate; }
            set
            {
                _processDate = value;
                OnPropertyChanged();
            }
        }

        public int EndproductNR
        {
            get { return _endproductNR; }
            set
            {
                _endproductNR = value;
                OnPropertyChanged();
            }
        }

        public string EndProductName
        {
            get { return _endProductName; }
            set
            {
                _endProductName = value;
                OnPropertyChanged();
            }
        }

        public int ColumnNR
        {
            get { return _ColumnNR; }
            set
            {
                _ColumnNR = value;
                OnPropertyChanged();
            }
        }

        public int ProcessOrderNR
        {
            get { return _processOrderNR; }
            set
            {
                _processOrderNR = value;
                OnPropertyChanged();
            }
        }

        public ProcessOrderArk()
        {
            activities = new ObservableCollection<ProcessActivity>();

            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync("http://localhost:54926/api/ProcessActivity/" + this.ProcessOrderNR);
                List<ProcessActivity> loadedProcessActivities = JsonConvert.DeserializeObject<List<ProcessActivity>>(response.Result);

                if (loadedProcessActivities != null)
                {
                    foreach (ProcessActivity Activity in loadedProcessActivities)
                    {
                        if (Activity.ActivityID == 10) activities.Add(new EtiketteArkVM(this.ProcessOrderNR));
                    }
                }

            }
        }

        public ProcessOrderArk(int ProcessOrderNummer)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync("http://localhost:54926/api/ProcessOrder/" + ProcessOrderNummer);
                ProcessOrdre loaded = JsonConvert.DeserializeObject<ProcessOrdre>(response.Result);

                this.ColumnNR = loaded.ColumnNR;
                this.EndProductName = loaded.EndProductName;
                this.EndproductNR = loaded.EndproductNR;
                this.ProcessDate = loaded.ProcessDate.Date;
                this.Process = loaded.Process;

                activities = new ObservableCollection<ProcessActivity>();

                Task<string> Activityresponse = client.GetStringAsync("http://localhost:54926/api/ProcessActivity/" + this.ProcessOrderNR);
                List<ProcessActivity> loadedProcessActivities = JsonConvert.DeserializeObject<List<ProcessActivity>>(Activityresponse.Result);

                foreach (ProcessActivity Activity in loadedProcessActivities)
                {
                    if (Activity.ActivityID == 10) activities.Add(new EtiketteArkVM(this.ProcessOrderNR));
                }
            }
        }

        public static ObservableCollection<ProcessOrderArk> LoadAllArks()
        {
            ObservableCollection<ProcessOrderArk> arks = new ObservableCollection<ProcessOrderArk>();

            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync("http://localhost:54926/api/ProcessOrder");
                List<ProcessOrdre> loaded = JsonConvert.DeserializeObject<List<ProcessOrdre>>(response.Result);

                foreach (ProcessOrdre po in loaded)
                {

                    arks.Add(new ProcessOrderArk()
                    {
                        ProcessOrderNR = po.ProcessOrderNR,
                        ColumnNR = po.ColumnNR,
                        EndProductName = po.EndProductName,
                        EndproductNR = po.EndproductNR,
                        ProcessDate = po.ProcessDate.Date,
                        Process = po.Process
                    });
                }
            }
            return arks;

        }

        public static bool SaveArk(ProcessOrderArk savePo)
        {
            using (HttpClient client = new HttpClient())
            {
                ProcessOrdre PO = new ProcessOrdre()
                {
                    ProcessOrderNR = savePo.ProcessOrderNR,
                    ColumnNR = savePo.ColumnNR,
                    EndproductNR = savePo.EndproductNR,
                    EndProductName = savePo.EndProductName,
                    ProcessDate = savePo.ProcessDate,
                    Process = savePo.Process
                };

                string jsonString = JsonConvert.SerializeObject(PO);
                StringContent content = new StringContent(jsonString, Encoding.ASCII, "application/json");

                Task<HttpResponseMessage> response = client.PutAsync("http://localhost:54926/api/ProcessOrder/" + PO.ProcessOrderNR, content);
                
                return response.Result.IsSuccessStatusCode;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}