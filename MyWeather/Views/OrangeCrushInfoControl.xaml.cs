using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Tasks;
using System.Reflection;
using Microsoft.Phone.Controls;

namespace MyWeather.Views
{
    public partial class OrangeCrushInfoControl : UserControl
    {
        public OrangeCrushInfoControl()
        {
            InitializeComponent();
        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly().FullName;
            string version = assembly.Split('=')[1].Split(',')[0];

            EmailComposeTask emailcomposer = new EmailComposeTask();
            emailcomposer.To = "orangecrushie@gmail.com";
            emailcomposer.Subject = "Support Request from Short Cuts " + version;
            emailcomposer.Body = "";
            emailcomposer.Show();
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            frame.Navigate(new Uri("/Views/About.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MoreApps_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceSearchTask markeplace = new MarketplaceSearchTask();
            markeplace.SearchTerms = "Orange Crush";
            markeplace.Show();
        }

        private void PrivacyPolicy_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://orangesodacodepolicy.azurewebsites.net/";
            webBrowserTask.Show();
        }
    }
}
