using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TopPlaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PlacesData placesData = new PlacesData();
            this.listBoxPhotos.DataContext = placesData.PlacesList;
            this.ButtonJaime.Source = placesData.ImageJaime;
            FirstLoading(placesData.PlacesList.FirstOrDefault());

        }

        private void FirstLoading(Place DefaultPlace)
        {
            image1.Source = DefaultPlace.Image;
            description_value.Content = DefaultPlace.Description;
            uri_value.Content = DefaultPlace.PathImageFile;
            votes_value.Content = DefaultPlace.NVotes;

        }

        private void listBoxPhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
                //Marche aussi bien
                //image1.Source = place.Image;
            BitmapSource photo = BitmapFrame.Create(new Uri(place.PathImageFile));
            image1.Source = photo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            place.Vote();
        }
    }
}
