using Microsoft.EntityFrameworkCore.Query;
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

        static public IList<Launch> getUpcomingLaunches() 
        {
            string response = getFromAPI("https://lldev.thespacedevs.com/2.2.0/launch/upcoming");
            Console.WriteLine(response);
            JObject parsed_launches = JObject.Parse(response);
            IList<JToken> launches_token = parsed_launches["results"].Children().ToList();
            IList<Launch> result_launches = new List<Launch>();
            foreach (JToken launches in launches_token)
            {
                result_launches.Add(launches.ToObject<Launch>());
            }

            return result_launches;
        }
    }
}
