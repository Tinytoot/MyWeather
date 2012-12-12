using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWeather.Models
{
    public class GeoFeatures
    {
        public int geolookup { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string country_name { get; set; }
        public string zmw { get; set; }
        public string l { get; set; }
    }

    public class GeoLocations
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public GeoFeatures features { get; set; }
        public List<City> results { get; set; }
    }

    public class GeoSearch
    {
        public GeoLocations response { get; set; }
    }
}
