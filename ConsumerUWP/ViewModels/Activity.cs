using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumerUWP.ViewModels
{
    public class Activity
    {
        public static ObservableCollection<Models.Activity> LoadActivities()
        {
            ObservableCollection<Models.Activity> activities = new ObservableCollection<Models.Activity>();

            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(new Uri("http://localhost:54926/api/Activity/"));
                foreach (Models.Activity activity in JsonConvert.DeserializeObject<List<Models.Activity>>(response.Result))
                {
                    activities.Add(activity);
                }
            }

            return activities;
        }
    }
}
