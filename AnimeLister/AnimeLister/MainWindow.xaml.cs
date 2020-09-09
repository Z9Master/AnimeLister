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

        // This load nesecery datas
        void Setup()
        {
            LB_ListAnime.ItemsSource = data.AnimeList;
        }

        #region Windows_Btn_Event
        // Those methods close/maximize/minimize the program
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
        // Those button can filter anime, if we saw it or not
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

        #region AnimeData_Function_Event
        // This store Id when we selected an anime in AnimeList
        int SelectCacheId = -1;

        // This event can cast our anime selection and we can get anime information here, like Id, name, etc
        private void LB_ListAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox LB = sender as ListBox;
            List<AnimeItem> an = new List<AnimeItem>();
            
            if (LB != null)
            {
                an.Add(LB.SelectedItem as AnimeItem);
                if(an[0] != null)
                {
                    anEdit.Clear();
                    anEdit.Add(LB.SelectedItem as AnimeItem);
                    SelectCacheId = an[0].animeId;
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

        // Add an anime
        private void Btn_Click_AddAnime(object sender, RoutedEventArgs e)
        {
            AddAnime addAnime = new AddAnime();
            addAnime.ShowDialog();
            data.LoadFile();
            LB_ListAnime.Items.Refresh();
        }

        // Remove an Anime
        private void Btn_Click_Remove(object sender, RoutedEventArgs e)
        {
            if (SelectCacheId != -1 && SelectCacheId >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Remove?", "Remove", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        data.RemoveAnime(SelectCacheId);
                        SelectCacheId = -1;
                        data.LoadFile();
                        LB_ListAnime.Items.Refresh();
                        break;
                    case MessageBoxResult.No:

                        break;
                }
            }
            else
            {
                MessageBox.Show("Select an anime to remove");
            }
        }
        #endregion

        List<AnimeItem> anEdit = new List<AnimeItem>();
        private void Btn_Click_Edit(object sender, RoutedEventArgs e)
        {
            if(anEdit != null && anEdit.Count > 0)
            {
                EditAnime edit = new EditAnime();
                edit.LoadAnimeDataToForm(anEdit[0].animeName, anEdit[0].animeYear, anEdit[0].animeYear, anEdit[0].animeNote, anEdit[0].animePictureUrl, anEdit[0].animeSeen, anEdit[0].animeId);
                edit.ShowDialog();
                data.LoadFile();
                LB_ListAnime.Items.Refresh();
                anEdit.Clear();
            }
            else
            {
                MessageBox.Show("Select an anime to edit");
            }
        }
    }
}
