using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace A12.Tests
{
    [TestClass()]
    public class AppAnalysisTests
    {
        private AppAnalysis _instance;
        public AppAnalysis Instance
        {
            get
            {
                if (_instance == null)
                    _instance = AppAnalysis.AppAnalysisFactory(@"../../googleplaystore.csv");
                return _instance;
            }
        }

        

        [TestMethod()]
        public void AppAnalysisFactoryTest()
        {
            var instance = AppAnalysis.AppAnalysisFactory(@"../../googleplaystore.csv");
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.Apps);
            Assert.AreEqual(10840, instance.Apps.Count);
        }

        [TestMethod()]
        public void AllAppsCountTest()
        {
            Assert.AreEqual(10840, Instance.AllAppsCount());
        }

        [TestMethod()]
        public void AppsAboveXRatingCountTest()
        {
            Assert.AreEqual("CB79F8FA58B91D3AF6C9C991F63962D3",
                CalcMD5(Instance.AppsAboveXRatingCount(4.6).ToString()));

            Assert.AreEqual("B0928F2D4BA7EA33B05024F21D937F48",
                CalcMD5(Instance.AppsAboveXRatingCount(3.5).ToString()));
        }

        [TestMethod()]
        public void RecentlyUpdatedCountTest()
        {
            Assert.AreEqual("7CAF5E22EA3EB8175AB518429C8589A4",
                CalcMD5(Instance.RecentlyUpdatedCount(new DateTime(2018, 3, 12))));

            Assert.AreEqual("958ADB57686C2FDEC5796398DE5F317A",
                CalcMD5(Instance.RecentlyUpdatedCount(new DateTime(2018, 7, 28))));
        }

        [TestMethod()]
        public void RecentlyUpdatedFreqCatTest()
        {
            Assert.AreEqual("499A1FE16898531E2422C704A0288797",
                CalcMD5(Instance.RecentlyUpdatedFreqCat(new DateTime(2018, 3, 12))));

            Assert.AreEqual("499A1FE16898531E2422C704A0288797",
                CalcMD5(Instance.RecentlyUpdatedFreqCat(new DateTime(2018, 7, 28))));
        }

        [TestMethod()]
        public void MostRatedCategoriesTest()
        {
            var result = Instance.MostRatedCategories(4.6, 4);
            Assert.AreEqual(4, result.Count);
            CollectionAssert.AreEqual(new List<string> { "FAMILY", "GAME", "MEDICAL", "TOOLS" }, result);
        }

        [TestMethod()]
        public void ExtremeMeanUpdateElapseTest()
        {
            var result = Instance.ExtremeMeanUpdateElapse(new DateTime(2019, 5, 27));

            Assert.AreEqual("F85D08F4609CB9F5D750707713CDF335", CalcMD5(result.Item1));
  
			Assert.AreEqual("40F71CE559D3F33A58B3305BA9780261", CalcMD5(result.Item2));
        }
        [TestMethod()]
        public void TopQuarterBoundaryTest()
        {
            Assert.AreEqual("C33AB40F1472EF16492879F9A7BBF170",
                CalcMD5(Instance.TopQuarterBoundary().ToString()));
        }

        [TestMethod()]
        public void XMostProfitablesTest()
        {
            var result = Instance.XMostProfitables(4);
            for (int i = 0; i < result.Count; i++)
                result[i] = CalcMD5(result[i]);
            CollectionAssert.AreEqual(new List<string> {
                "E3416675E3A20772D0B78F45F4CE995D",
                "E3416675E3A20772D0B78F45F4CE995D",
                "74C811A5C507DC91032720C83027DA44",
                "5F87EC767D10A2EBFA5417865B8C8617"
            }, result);
        }

        [TestMethod()]
        public void XCoolestAppsTest()
        {
            Func<AppData, double> criteria = (app) => app.Rating * app.Installs / 1000;
            var result = Instance.XCoolestApps(4, criteria);
            for (int i = 0; i < result.Count; i++)
                result[i] = CalcMD5(result[i]);

            CollectionAssert.AreEqual(new List<string> {
                "9300082449FC854D9AE0D135BB26B66F",
                "65159B968B0BA61BEAB639D1DF498BD5",
                "7030E0CC8D4F833FF6654281F8BEC840",
                "13D22222B77A27DEB241D398E95C043B"
            }, result);
        }
		
		#region HelperMethods
		
			private string CalcMD5(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private string CalcMD5(long input)
        {
            return CalcMD5(input.ToString());
        }

        #endregion
    }
}