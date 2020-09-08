using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace AnimeLister
{
    public class DataManager
    {
        // Unique id for indentify one time tasks
        private int id = 0;

        // Path to the data task file
        string filePath = @"E:\Project\C#\AnimeLister\AnimeLister\AnimeLister\AnimeLister\Data\AnimeListData.txt";

        // List to store task to save to the file
        public List<AnimeItem> AnimeList = new List<AnimeItem>();

        // The list to load file text to parse to the ListOneTimeEvents
        public List<string> lines;

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
                    items.animeYear = Int32.Parse(entries[2]);
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
            }
        }

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
                    items.animeYear = Int32.Parse(entries[2]);
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
                    items.animeYear = Int32.Parse(entries[2]);
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

        public DataManager()
        {
            LoadFile();
        }

    }

   

    public class AnimeItem : IEquatable<AnimeItem>
    {
        public string animeName { get; set; }
        public int animeId { get; set; }
        public int animeYear { get; set; }
        public int animeSeen { get; set; }
        public string animeGenre { get; set; }
        public string animePictureUrl { get; set; }
        public string animeNote { get; set; }

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
