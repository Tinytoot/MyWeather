using MyWeather.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MyWeather.Library
{
    public class GeoLookup
    {
        string webApiKey = "c6012e95cc789b08";

        public delegate void CitiesLoaded(GeoSearch citiesFound);
        public delegate void CitiesLoadError(string failure);

        public event CitiesLoaded success;
        public event CitiesLoadError failure;

        public void   GeoLocation()
        {
        }
        public void FindCity(string cityName)
        {
            string RequestUri = "http://api.wunderground.com/api/{0}/geolookup/q/{1}.json";
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(String.Format(RequestUri, webApiKey,cityName)));
        }


        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            var results = JsonConvert.DeserializeObject<GeoSearch>(e.Result.ToString().Trim());
            CitiesLoaded eventHandler = success;
            if (eventHandler != null)
                eventHandler(results);
        }
    }
}
