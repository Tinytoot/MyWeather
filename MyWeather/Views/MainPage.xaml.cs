using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MyWeather.Views;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using MyWeather.Models;
using System.Windows.Navigation;

namespace MyWeather
{
    public partial class MainPage : PhoneApplicationPage
    {
        private FrontLiveTile frontTile = new FrontLiveTile();
        private BackLiveTile backTile = new BackLiveTile();
        const char DegreeSign = (char)176;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //CityList.ItemsSource = App.cityList;

            this.frontTile.SetCityName("No City Selected");
            this.radHubTile.Height = 173;
            this.radHubTile.Width = 173;
            this.frontTile.SetProperties(new BitmapImage(new Uri("../Images/sunny.png", UriKind.RelativeOrAbsolute)),
                String.Format("25{0}", DegreeSign));

            this.backTile.SetProperties(new BitmapImage(new Uri("../Images/sunny-back.png", UriKind.RelativeOrAbsolute)),
              "test");
            this.radHubTile.FrontContent = this.frontTile;
            this.radHubTile.BackContent = this.backTile;

        }


        private void PinToStart_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.frontTile.SetCityName("No City Selected");
            this.radHubTile.Height = 173;
            this.radHubTile.Width = 173;
            this.frontTile.SetProperties(new BitmapImage(new Uri("../Images/sunny.png", UriKind.RelativeOrAbsolute)),
                String.Format("25{0}", DegreeSign));

            this.backTile.SetProperties(new BitmapImage(new Uri("../Images/sunny-back.png", UriKind.RelativeOrAbsolute)),
              "test");
            this.radHubTile.FrontContent = this.frontTile;


            RadExtendedTileData tileData = new RadExtendedTileData()
            {
                VisualElement = Tile,
                BackVisualElement =  this.backTile
            };
            Uri tileUri = new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute);
            ShellTile tile = Telerik.Windows.Controls.LiveTileHelper.GetTile(tileUri);

            if (tile != null)
            {
                tile.Delete();
            }

            Telerik.Windows.Controls.LiveTileHelper.CreateTile(tileData, tileUri);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/SearchCityView.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
