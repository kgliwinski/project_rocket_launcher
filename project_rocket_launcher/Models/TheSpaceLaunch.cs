﻿using Azure;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_rocket_launcher.Controllers;

namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Api handling
    /// </summary>
    public class TheSpaceLaunch
    {
        /// <summary>
        /// Get data from api
        /// </summary>
        /// <param name="url">specific url address</param>
        /// <returns>Api result</returns>
        static private string getFromAPI(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri endpoint = new Uri(url);
                return httpClient.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Get upcoming launches from API
        /// </summary>
        /// <param name="number_of_launches">Number of launches to read</param>
        /// <returns>List of launches</returns>
        static public IList<LaunchDetails> getUpcomingLaunches(uint number_of_launches = 10)
        {

            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?limit={number_of_launches}");
            LaunchList launchList = JsonConvert.DeserializeObject<LaunchList>(response);

            return launchList.results;
        }

        /// <summary>
        /// Get specific upcoming launch
        /// </summary>
        /// <param name="id">Launch id</param>
        /// <returns>Launch details</returns>
        static public LaunchDetails getUpcomingLaunchById(string id)
        {
            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?id={id}");
            return JsonConvert.DeserializeObject<LaunchList>(response).results[0];
        }

        //static public LaunchDetails getUpcomingLaunchById(string id, DataContext dbContext)
        //{
        //    // Check if the launch details are already in the database
        //    FavouriteLaunch existingLaunch = dbContext.FavouritesLaunches.FirstOrDefault(x => x.LaunchId == id);
        //    if (existingLaunch != null)
        //    {
        //        // If the launch details are already in the database, return the stored LaunchDetails
        //        return JsonConvert.DeserializeObject<LaunchDetails>(existingLaunch.Data);
        //    }
        //
        //    // If the launch details are not in the database, retrieve them from the API
        //    string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/upcoming/?id={id}");
        //    LaunchDetails launchDetails = JsonConvert.DeserializeObject<LaunchList>(response).results[0];
        //
        //    // Save the launch details to the database
        //    FavouriteLaunch newLaunch = new FavouriteLaunch
        //    {
        //        LaunchId = id,
        //        Data = JsonConvert.SerializeObject(launchDetails)
        //    };
        //    dbContext.FavouritesLaunches.Add(newLaunch);
        //    dbContext.SaveChanges();
        //
        //    return launchDetails;
        //}

        /// <summary>
        /// Get specific launch details
        /// </summary>
        /// <param name="id">launch id</param>
        /// <returns></returns>
        static public LaunchDetails getLaunchById(string id)
        {
            string response = getFromAPI($"https://lldev.thespacedevs.com/2.2.0/launch/?id={id}");
            return JsonConvert.DeserializeObject<LaunchList>(response).results[0];
        }

        /// <summary>
        /// Convert launch details to rocket launch class, 
        /// This method chceck if launch is in the favorutie launch list
        /// </summary>
        /// <param name="details">Launches details</param>
        /// <param name="favourites">Favourite launches</param>
        /// <returns></returns>
        static public IList<Launch> convertToLaunch(IList<LaunchDetails> details, IQueryable<FavouriteLaunch> favourites)
        {
            IList<Launch> launches = new List<Launch>();
            foreach (var launchDetail in details)
            {
                Launch launch = new Launch();
                launch.details = launchDetail;
                if (favourites.Any(x => x.LaunchId.Equals(launchDetail.id)) == true)
                {
                    launch.isFavourite = true;
                }
                else
                {
                    launch.isFavourite = false;
                }
                launches.Add(launch);
            }
            return launches;
        }

        /// <summary>
        /// Get favourite launches from API
        /// </summary>
        /// <param name="favourites">Favourite launches</param>
        /// <returns>List of favourite launches details</returns>
        static public IList<LaunchDetails> getFavouriteLaunches(IQueryable<FavouriteLaunch> favourites)
        {
            IList<LaunchDetails> favLaunches = new List<LaunchDetails>();
            foreach (var favInfo in favourites)
            {
                var tempLaunch = getLaunchById(favInfo.LaunchId);
                if (tempLaunch != null)
                {
                    favLaunches.Add(tempLaunch);
                }
                else
                {
                    favLaunches.Add(JsonConvert.DeserializeObject<LaunchDetails>(favInfo.LaunchDetailsJson));
                }
            }
            return favLaunches;
        }
    }
}
