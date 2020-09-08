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

namespace AnimeLister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
                //MessageBox.Show("Debug");
    public partial class MainWindow : Window
    {
        DataManager data = new DataManager();
        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        void Setup()
        {
            LB_ListAnime.ItemsSource = data.AnimeList;
        }

        #region Windows_Btn_Event
        private void Btn_Click_Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Btn_Click_Maximize(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void Btn_Click_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        #region Btn_Filter
        private void Btn_Click_FilterAll(object sender, RoutedEventArgs e)
        {
            data.LoadFile();
            LB_ListAnime.Items.Refresh();
        }

        private void Btn_Click_FilterSaw(object sender, RoutedEventArgs e)
        {
            data.Seen();
            LB_ListAnime.Items.Refresh();
        }

        private void Btn_Click_FilterNew(object sender, RoutedEventArgs e)
        {
            data.UnSeen();
            LB_ListAnime.Items.Refresh();
        }
        #endregion

        #region event_LoadInformation
        private void LB_ListAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox LB = sender as ListBox;
            List<AnimeItem> an = new List<AnimeItem>();
            if(LB != null)
            {
                an.Add(LB.SelectedItem as AnimeItem);
                if(an[0] != null)
                {
                    TBk_AnimeName.Text = an[0].animeName.ToString();
                    TBk_AnimeYear.Text = an[0].animeYear.ToString();
                    TBk_AnimeGenre.Text = an[0].animeGenre.ToString();
                    TBk_AnimeNote.Text = an[0].animeNote.ToString();
                    if (an[0].animeSeen.ToString().Equals("1"))
                    {
                        TBk_AnimeSeen.Text = "Saw";
                    }
                    else
                    {
                        TBk_AnimeSeen.Text = "Not seen";
                    }
                    if (!an[0].animePictureUrl.ToString().Equals("null"))
                    {
                        try
                        {
                            BitmapImage ImageCache = new BitmapImage();
                            ImageCache.BeginInit();
                            ImageCache.UriSource = new Uri(an[0].animePictureUrl.ToString());
                            ImageCache.EndInit();
                            Img_AnimeImage.Source = ImageCache;
                            Img_AnimeImage.Opacity = 255;
                        }
                        catch
                        {
                            Img_AnimeImage.Opacity = 0;
                            MessageBox.Show("Picture not found");
                        }
                    }
                    else
                    {
                        Img_AnimeImage.Opacity = 0;
                    }
                }
            }
        }
        #endregion
    }
}
