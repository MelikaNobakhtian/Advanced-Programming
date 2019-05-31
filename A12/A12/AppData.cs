using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace A12
{
    public class AppData
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
        public long Reviews { get; set; }
        public double Size { get; set; }
        public long Installs { get; set; }
        public bool IsFree { get; set; }
        public double Price { get; set; }
        public string ContentRating { get; set; }
        public List<string> Genres { get; set; }
        public DateTime LastUpdate { get; set; }
        public string CurrentVersion { get; set; }
        public string AndroidVersion { get; set; }


        public AppData(string[] fields)
        {
            double _rating;
            Name = fields[0];
            Category = fields[1];
            Rating = double.TryParse(fields[2],out _rating) ? _rating : 0;
            Reviews = long.Parse(fields[3]);
            Size = fields[4].Contains("with") ? 0 :
                fields[4].Contains("k") ? double.Parse(fields[4].Remove(fields[4].Length - 1)) :
                double.Parse(fields[4].Remove(fields[4].Length - 1)) * 1024;
            Installs= long.Parse(fields[5].Trim('+'), NumberStyles.AllowThousands);
            IsFree = fields[6].Contains("Free") ? true : false;
            Price = fields[7].Contains("$") ? double.Parse(fields[7].Remove(0, 1)) : 0;
            ContentRating = fields[8];
            Genres = (fields[9].Split(';')).ToList();
            LastUpdate = Convert.ToDateTime(fields[10]);
            CurrentVersion = fields[11];
            AndroidVersion = fields[12];
        }

        
    }
}