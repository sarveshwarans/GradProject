using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using System.Windows;
using System.Collections.ObjectModel;
using LabAssignment7A.Model;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LabAssignment7A.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string KEY = "c3eb740edc2fd819ec14eaa0b66ab00e";
        WebClient fClient = new WebClient();
        Task<string> fTask;
        public Image pBox;

        private  string title;
        private string url;
        private ObservableCollection<FlickerImage> fList=new ObservableCollection<FlickerImage>();
        private List<string> titleName=new List<string>();
        FlickerImage fi = new FlickerImage();
        private FlickerImage selectedItem;

        /// <summary>
        /// Constructor for MainViewModel Class
        /// </summary>
        /// <param name="image"></param>
        public MainViewModel(Image image)
        {
            pBox = image;
            SearchEngine = new RelayCommand(SeachTag);
            SelectedItemCommand = new RelayCommand(SelectedPhoto);
        }

        /// <summary>
        /// Displays the image based on the selected item
        /// </summary>
        private async void SelectedPhoto()
        {
            if (SelectedItem != null)
            {
                var selectedURL =
                   ((FlickerImage)SelectedItem).Url;
                WebClient client = new WebClient();
                Task<byte[]> downloadTask = client.DownloadDataTaskAsync(new Uri(selectedURL));
                byte[] imageBytes = await downloadTask;
                MemoryStream stream = new MemoryStream(imageBytes);
                var imagesource = new BitmapImage();
                imagesource.BeginInit();
                imagesource.StreamSource = stream;
                imagesource.EndInit();
                pBox.Source = imagesource;
            }
        }

        /// <summary>
        /// Displays the first image on searching for the keyword in the search box
        /// </summary>
        /// <param name="selectedURL"></param>
        private async void DisplayPicture(string selectedURL)
        {
            if (selectedURL != null)
            {
                try
                {
                    WebClient client = new WebClient();
                    Task<byte[]> downloadTask = client.DownloadDataTaskAsync(new Uri(selectedURL));
                    byte[] imageBytes = await downloadTask;
                    MemoryStream stream = new MemoryStream(imageBytes);
                    var imagesource = new BitmapImage();
                    imagesource.BeginInit();
                    imagesource.StreamSource = stream;
                    imagesource.EndInit();
                    pBox.Source = imagesource;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "No Result Found!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No Result Found!");
                pBox.Source = null;
            }
        }

        /// <summary>
        /// Search for the keyword in the application
        /// </summary>
        private async void SeachTag()
        {
            if (fTask != null &&
               fTask.Status != TaskStatus.RanToCompletion)
            {
                var result = MessageBox.Show("Cancel the Flicker Search?", "Are you sure?", 
                             MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                    return;
                else
                {
                    fClient.CancelAsync();
                }
            }
            var flickrUrl = string.Format("https://api.flickr.com/services/rest/?method=flickr.photos.search&tags={0}&api_key={1}&privacy_filter=1",Title.Replace(" ",","),KEY);
            FlickerList.Clear();
            try
            {
                fTask = fClient.DownloadStringTaskAsync(new Uri(flickrUrl));
                XDocument doc = XDocument.Parse(await fTask);
                var flickrPhotos =
                       from photo in doc.Descendants("photo")
                       let id = photo.Attribute("id").Value.ToString()
                       let title = photo.Attribute("title").Value.ToString()
                       let secret = photo.Attribute("secret").Value.ToString()
                       let server = photo.Attribute("server").Value.ToString()
                       let farm = photo.Attribute("farm").Value.ToString()
                       select new FlickerImage
                       {
                           Title = title,
                           Url = string.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", farm, server, id, secret)
                       };
                FlickerList.Clear();

                if (flickrPhotos.Any())
                {
                    foreach (var list in flickrPhotos)
                    {
                        FlickerList.Add(new FlickerImage() { Title = list.Title, Url = list.Url });
                    }

                }
                else
                {
                    fi.Title = "No Match Found!";
                    FlickerList.Add(fi);
                }
            }
            catch(WebException)
            {
                if (fTask.Status == TaskStatus.Faulted)
                    MessageBox.Show("Unable to get results from Flickr",
                       "Flickr Error", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                FlickerList.Clear();
                fi.Title = "Error Occured";
                FlickerList.Add(fi);
            }

            var selectedURL =
                  ((FlickerImage)FlickerList[0]).Url;
            DisplayPicture(selectedURL);

        }

        /// <summary>
        /// Getters and Setters 
        /// </summary>
        public ICommand SearchEngine { get; private set; }
        public ICommand SelectedItemCommand { get; private set; }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                RaisePropertyChanged("Url");
            }
        }

        public List<string> TitleName
        {
            get
            {
                return titleName;
            }
            set
            {
                titleName = value;
                RaisePropertyChanged("TitleName");
            }
        }
        public ObservableCollection<FlickerImage> FlickerList
        {
            get
            {
                return fList;
            }
            set
            {
                fList = value;
                RaisePropertyChanged("FlickerList");
            }
        }

        public FlickerImage SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public string Display
        {
            get
            {
                return Title;
            }
        }

    }
}