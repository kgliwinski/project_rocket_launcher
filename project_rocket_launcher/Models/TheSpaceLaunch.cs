using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_rocket_launcher.Controllers;

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


        static public IList<LaunchDetails> getUpcomingLaunches(uint number_of_launches = 10) 
        {

            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?limit={number_of_launches}");
            LaunchList launchList = JsonConvert.DeserializeObject<LaunchList>(response);

            return launchList.results;
        }

        static public LaunchDetails getUpcomingLaunchById(string id)
        {
            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?id={id}");
            return JsonConvert.DeserializeObject<LaunchList>(response).results[0];    
        }

        static public LaunchDetails getLaunchById(string id)
        {
            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/?id={id}");
            return JsonConvert.DeserializeObject<LaunchList>(response).results[0];
        }

        static public LaunchDetails RetrieveFromDatabaseById(int id)
        {
            // return a LaunchDetails from database
            using (var database = new DataContext())
            {
                return database.FavouritesLaunches.LaunchDetails;
            }
        }

        static public IList<Launch> convertToLaunch(IList<LaunchDetails> details, IQueryable<FavouriteLaunch> favourites) 
        { 
            IList<Launch> launches = new List<Launch>();
            foreach(var launchDetail in details)
            {
                Launch launch = new Launch();
                launch.details = launchDetail;
                if (favourites.Any(x => x.LaunchId.Equals(launchDetail.id)) == true) {
                    launch.isFavourite = true;
                } else
                {
                    launch.isFavourite = false;
                }
                launches.Add(launch);    
            }
            return launches;
        }

        static public IList<LaunchDetails> getFavouriteLaunches(IQueryable<FavouriteLaunch> favourites)
        {
            IList<LaunchDetails> favLaunches = new List<LaunchDetails>();
            foreach(var favInfo in favourites)
            {
                var tempLaunch = getLaunchById(favInfo.LaunchId);
                if (tempLaunch != null) {
                    favLaunches.Add(tempLaunch);
                }
                else
                {
                    favLaunches.Add(RetrieveFromDatabaseById(favInfo.Id));
                }
            }
            return favLaunches;
        }
    }
}
