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
using Microsoft.Win32;
using System.Windows.Shapes;

namespace AnimeLister
{
    /// <summary>
    /// Interaction logic for EditAnime.xaml
    /// </summary>
    public partial class EditAnime : Window
    {
        DataManager data = new DataManager();
        public EditAnime()
        {
            InitializeComponent();
        }

        #region Event_Button
        // This will close the addAnime windows
        private void Btn_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // This will open dialog to load the image
        private void Btn_Click_Browse(object sender, RoutedEventArgs e)
        {
            LoadImage();
            Lb_PictureUrl.Content = ImageURLsplited;
        }

        // This will convert data and add an anime
        private void Btn_Click_Save(object sender, RoutedEventArgs e)
        {
            GetTrueData();
            data.EditData(animeName_, animeGenre_, animeYear_, animeSaw_, animeText_, animePictureUrl_, animeId);
            this.Close();
        }
        #endregion

        #region Variable_Methods_DataOperation

        // Variable to cache data from addAnime windows
        string animeName_;
        string animePictureUrl_;
        string animeGenre_;
        string animeText_;
        int animeSaw_;
        string animeYear_;

        // This will get data from the addAnime windows
        void GetTrueData()
        {
            if ((TBl_AnimeName.Text == null || TBl_AnimeName.Text == "" || TBl_AnimeName.Text.Contains(";")))
            {
                animeName_ = "unavaiable";
            }
            else
            {
                animeName_ = TBl_AnimeName.Text;
            }

            if (!TBl_AnimeGenre.Text.Contains(";"))
            {
                animeGenre_ = TBl_AnimeGenre.Text;
            }
            else
            {
                animeGenre_ = "unavaiable";
            }

            if (!TBl_AnimeText.Text.Contains(";"))
            {
                animeText_ = TBl_AnimeText.Text;
            }
            else
            {
                animeText_ = "unavaiable";
            }

            if (!TBl_AnimeYear.Text.Contains(";"))
            {
                animeYear_ = TBl_AnimeYear.Text;
            }
            else
            {
                animeYear_ = "unavaiable";
            }


            if (ImageURL == "" || ImageURL.Contains(";"))
            {
                animePictureUrl_ = "null";
            }
            else
            {
                animePictureUrl_ = ImageURL;
            }
            if (ChB_AnimeSaw.IsChecked == true)
            {
                animeSaw_ = 1;
            }
            else
            {
                animeSaw_ = 0;
            }
        }

        string ImageURL = "";
        string ImageURLsplited = "";

        // This will load the image location
        private void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImageURL = new BitmapImage(new Uri(op.FileName)).ToString();
            }
            int startindex = 8;
            int length = ImageURL.Length - startindex;
            ImageURLsplited = ImageURL.Substring(startindex, length);
        }
        #endregion

        int animeId;
        public void LoadAnimeDataToForm(string _animeName, string _animeYear, string _animeGenre, string _animeNote, string _animePictureUrl, int _animeSaw, int _animeId)
        {
            TBl_AnimeName.Text = _animeName;
            TBl_AnimeYear.Text = _animeYear;
            TBl_AnimeText.Text = _animeNote;
            TBl_AnimeGenre.Text = _animeGenre;
            Lb_PictureUrl.Content = _animePictureUrl;
            ImageURL = _animePictureUrl;
            animeId = _animeId;
            if(animeSaw_ == 1)
            {
                ChB_AnimeSaw.IsChecked = true;
            }
            else
            {
                ChB_AnimeSaw.IsChecked = false;
            }
        }
    }
}
