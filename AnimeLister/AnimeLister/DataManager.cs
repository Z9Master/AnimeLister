using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using AnimeLister.Properties;

namespace AnimeLister
{
    public class DataManager
    {
        public DataManager()
        {
            filePath = Settings.Default.FilePath;
            LoadFile();
        }

        #region Methods_LoadFiles

        // Path to the data task file, it will be store in the program
        string filePath = "";

        // List to store anime for procesing
        public List<AnimeItem> AnimeList = new List<AnimeItem>();

        // The list to load file text to parse to the ListOneTimeEvents
        public List<string> lines;

        // Simple Load file data to the program and check if the filepath is valid, if not, it will ask to find the path
        public void LoadFile()
        {
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
                AnimeList.Clear();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(';');
                    AnimeItem items = new AnimeItem();

                    items.animeId = Int32.Parse(entries[0]);
                    items.animeName = entries[1];
                    items.animeYear = entries[2];
                    items.animeGenre = entries[3];
                    items.animeSeen = Int32.Parse(entries[4]);
                    items.animePictureUrl = entries[5];
                    items.animeNote = entries[6];

                    AnimeList.Add(items);
                }
            }
            catch
            {
                MessageBox.Show("Can´t load data file", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                FindData();
                LoadFile();
            }
        }

        // This simple load file again, but it filter anime, if we saw or not
        public void Seen()
        {
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
                AnimeList.Clear();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(';');
                    AnimeItem items = new AnimeItem();


                    items.animeId = Int32.Parse(entries[0]);
                    items.animeName = entries[1];
                    items.animeYear = entries[2];
                    items.animeGenre = entries[3];
                    items.animeSeen = Int32.Parse(entries[4]);
                    items.animePictureUrl = entries[5];
                    items.animeNote = entries[6];

                    if (items.animeSeen == 1)
                    {
                        AnimeList.Add(items);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can´t load data file", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        // This simple load file again, but it filter anime, if we saw or not
        public void UnSeen()
        {
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
                AnimeList.Clear();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(';');
                    AnimeItem items = new AnimeItem();


                    items.animeId = Int32.Parse(entries[0]);
                    items.animeName = entries[1];
                    items.animeYear = entries[2];
                    items.animeGenre = entries[3];
                    items.animeSeen = Int32.Parse(entries[4]);
                    items.animePictureUrl = entries[5];
                    items.animeNote = entries[6];

                    if (items.animeSeen == 0)
                    {
                        AnimeList.Add(items);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can´t load data file", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        #endregion

        #region Methods_DataProcesing

        // This will get the biggest Id in the list
        public int GetBiggestId()
        {
            int BanimeId = 0;
            foreach (var anime in AnimeList)
            {
                if (BanimeId <= anime.animeId)
                {
                    BanimeId = anime.animeId;
                }
            }
            return BanimeId;
        }

        // This will add an anime
        public void addData(string _animeName, string _animeGenre, string _animeYear, int _animeSaw, string _animeText, string _animePictureUrl)
        {
            LoadFile();
            List<string> output = new List<string>();
            AnimeList.Add(new AnimeItem
            {
                animeId = (GetBiggestId() + 1),
                animeName = _animeName,
                animeGenre = _animeGenre,
                animeNote = _animeText,
                animeSeen = _animeSaw,
                animePictureUrl = _animePictureUrl,
                animeYear = _animeYear
            });
            foreach (var item in AnimeList)
            {
                output.Add($"{item.animeId};{item.animeName};{item.animeYear};{item.animeGenre};{item.animeSeen};{item.animePictureUrl};{item.animeNote}");
            }
            File.WriteAllLines(filePath, output);
        }

        // This will remove an anime
        public void RemoveAnime(int animId)
        {
            LoadFile();
            List<string> output = new List<string>();
            AnimeList.Remove(new AnimeItem { animeId = animId });
            foreach (var item in AnimeList)
            {
                output.Add($"{item.animeId};{item.animeName};{item.animeYear};{item.animeGenre};{item.animeSeen};{item.animePictureUrl};{item.animeNote}");
            }
            File.WriteAllLines(filePath, output);
        }

        // If filepath cant be found, it will ask the location, then it will save filepath to aplication
        private void FindData()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select data file";
            op.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (op.ShowDialog() == true)
            {
                filePath = op.FileName.ToString();
            }
            savePath();
        }

        public void EditData(string _animeName, string _animeGenre, string _animeYear, int _animeSaw, string _animeText, string _animePictureUrl, int _animeId)
        {
            RemoveAnime(_animeId);
            LoadFile();
            List<string> output = new List<string>();
            AnimeList.Add(new AnimeItem
            {
                animeId = _animeId,
                animeName = _animeName,
                animeGenre = _animeGenre,
                animeNote = _animeText,
                animeSeen = _animeSaw,
                animePictureUrl = _animePictureUrl,
                animeYear = _animeYear
            });
            foreach (var item in AnimeList)
            {
                output.Add($"{item.animeId};{item.animeName};{item.animeYear};{item.animeGenre};{item.animeSeen};{item.animePictureUrl};{item.animeNote}");
            }
            File.WriteAllLines(filePath, output);
        }

        // This will save filepath to the application
        void savePath()
        {
            Settings.Default.FilePath = filePath;
            Settings.Default.Save();
        }
        #endregion
    }

   
    // This class is like an dictionary to translate the datafile
    public class AnimeItem : IEquatable<AnimeItem>
    {
        public string animeName { get; set; }
        public int animeId { get; set; }
        public string animeYear { get; set; }
        public int animeSeen { get; set; }
        public string animeGenre { get; set; }
        public string animePictureUrl { get; set; }
        public string animeNote { get; set; }

        // Those overrides set that animeId will be the key
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            AnimeItem objAsPart = obj as AnimeItem;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return animeId;
        }

        public bool Equals(AnimeItem other)
        {
            if (other == null) return false;
            return (this.animeId.Equals(other.animeId));
        }
    }
}
