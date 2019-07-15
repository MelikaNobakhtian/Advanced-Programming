using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A12
{
    public class AppAnalysis
    {
        public List<AppData> Apps { get; set; }

        public AppAnalysis()
        {
            Apps = new List<AppData>();
        }
        public static AppAnalysis AppAnalysisFactory(string AppDatapath)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(AppDatapath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;

        }

        private void AppendApp(string[] fields)
        {
            Apps.Add(new AppData(fields));
        }

        public long AllAppsCount()
        {
            return Apps.Count;
        }

        public long AppsAboveXRatingCount(double x)
        {
            var above = Apps
                .Where(a => a.Rating >= x)
                .ToList();
            return above.Count;

        }

        public long RecentlyUpdatedCount(DateTime boundary)
        {
            var time = Apps
                .Where(a => a.LastUpdate >= boundary)
                .ToList();
            return time.Count;
        }

        public string RecentlyUpdatedFreqCat(DateTime boundary)
        {
            var time = Apps
               .Where(a => a.LastUpdate >= boundary)
               .GroupBy(g => g.Category)
               .OrderByDescending(g => g.Count())
               .First()
               .Key;
            return time;
        }

        public List<string> MostRatedCategories(double ratingboundary, int n)
        {

            var above = Apps
                .Where(a => a.Rating > ratingboundary)
                .GroupBy(g => g.Category)
                .OrderByDescending(g => g.Count())
                .Select(a => a.Key)
                .Take(n)
                .ToList();

            return above;
        }

        public double TopQuarterBoundary()
        {
            var firstmean = Apps
                          .Where(a => a.Category == "PHOTOGRAPHY")
                          .OrderByDescending(o => o.Rating)
                          .Take(Apps.Where(s => s.Category == "PHOTOGRAPHY").Count() / 4)
                          .Last()
                          .Rating;

            return firstmean;
        }

        public Tuple<string, string> ExtremeMeanUpdateElapse(DateTime today)
        {
            Tuple<string, string> v;
            DateTime current = new DateTime(2019, 5, 25);
            
            var updates = Apps
                .Select(s => new { Cat = s.Category, UpdateDays = (s.LastUpdate - current).Days })
                .GroupBy(g => g.Cat)
                .OrderBy(o => o.Average(a => a.UpdateDays))
                .Select(x => x.Key);


            v = new Tuple<string, string>(updates.Last(), updates.First());

            return v;



        }

        public List<string> XMostProfitables(int x)
        {
            var mostprofit = Apps
             .Where(a => a.Price != 0)
             .OrderByDescending(s => (s.Installs) * (s.Price))
             .Take(x)
             .Select(b => b.Name)
             .ToList();

            return mostprofit;
        }

        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
        {
            var coolest = Apps
                .OrderBy(o => criteria(o))
                .Take(x)
                .Select(d => d.Name)
                .ToList();

            return coolest;

        }
    }
}