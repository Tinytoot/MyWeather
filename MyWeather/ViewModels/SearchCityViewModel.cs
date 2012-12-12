using MyWeather.Library;
using MyWeather.Models;
using MyWeather.Phone.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MyWeather.ViewModels
{
    public class SearchCityViewModel : ViewModelBase
    {
        private GeoLookup client = new GeoLookup();

        public SearchCityViewModel()
        {
            ListCities = new ObservableCollection<City>();
            client.success += client_success;
            client.failure += client_failure;
        }


        public void FindCity(string findThisCity)
        {
            client.FindCity(findThisCity);
        }
        void client_failure(string failure)
        {
            throw new System.NotImplementedException();
        }

        void client_success(GeoSearch results)
        {
            if (results.response.results != null)
            {
                foreach (City m in results.response.results)
                {
                    ListCities.Add(m);
                }
                this.IsDataLoaded = true;
            }
            else
            {
                this.IsDataLoaded = false;      
            }
        }
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public ObservableCollection<City> ListCities { get; private set; }
    }

}
