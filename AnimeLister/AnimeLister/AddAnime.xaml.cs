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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace AnimeLister
{
    /// <summary>
    /// Interaction logic for AddAnime.xaml
    /// </summary>
    public partial class AddAnime : Window
    {
        DataManager data = new DataManager();
        public AddAnime()
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
            data.addData(animeName_, animeGenre_, animeYear_, animeSaw_, animeText_, animePictureUrl_);
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

            
            if(ImageURL == "" || ImageURL.Contains(";"))
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
    }
}
