using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace project_rocket_launcher.Models
{
    public class TheSpaceLaunch
    {
        static private string getFromAPI(string url)
        {
            using (HttpClient httpClient = new HttpClient()) {
                Uri endpoint = new Uri(url);
                return httpClient.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
            }
        }

        static public IList<Launch> getUpcomingLaunches(uint number_of_launches = 10) 
        {
            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?limit={number_of_launches}");
            LaunchList launchList = JsonConvert.DeserializeObject<LaunchList>(response);

            return launchList.results;
        }

        static public Launch getUpcomingLaunchById(string id)
        {
            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?id={id}");
            //Console.WriteLine(response);
            return JsonConvert.DeserializeObject<LaunchList>(response).results[0];    
        }
    }
}
