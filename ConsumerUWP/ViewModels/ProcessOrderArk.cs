using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace ConsumerUWP.ViewModels
{
    class ProcessOrderArk : ProcessOrdre
    {
        public ObservableCollection<ProcessActivity> activities { get; set; }

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

                response = client.GetStringAsync("http://localhost:54926/api/ProcessActivity/" + ProcessOrderNummer);
                List<ProcessActivity> loadedProcessActivities = JsonConvert.DeserializeObject<List<ProcessActivity>>(response.Result);

                foreach(ProcessActivity Activity in loadedProcessActivities)
                {
                    activities.Add(Activity);
                }
            }
        }
    }
}
