using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.NetworkInformation;
using System.Windows.Input;
using MyWeather.ViewModels;

namespace MyWeather.Views
{
    public partial class SearchCityView : PhoneApplicationPage
    {
        SearchCityViewModel viewModel;

        public SearchCityView()
        {
            InitializeComponent();
            viewModel = new SearchCityViewModel();
            DataContext = viewModel;
        }

        private void CityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// if an item is selected
            //if (CityList.SelectedIndex != -1)
            //{
            //    // get the currently selected city and pass the information to the 
            //    // forecast details page
            //    City curCity = (City)CityList.SelectedItem;
            //    this.NavigationService.Navigate(new Uri("/Views/ForecastPage.xaml?City=" +
            //        curCity.CityName + "&Latitude=" + curCity.Latitude + "&Longitude=" +
            //        curCity.Longitude, UriKind.Relative));
            //}

        }

        private void txtFindCity_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                bool isConnected = NetworkInterface.GetIsNetworkAvailable();
                #if DEBUG
                    isConnected = true;
                #endif

                if (isConnected)
                {

                    if (!viewModel.IsDataLoaded)
                    {
                        if (this.txtFindCity.Text.ToString().Length > 2)
                        {
                            viewModel.FindCity(this.txtFindCity.Text);
                        }
                    }

                }
                else
                {

                    MessageBox.Show("No Internet connection was found.  Please check the settigns and try again.");
                }

            }
        }


    }
}