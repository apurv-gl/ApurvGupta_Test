using ImportFeeds.Services.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFeeds.Test
{
    [TestFixture]
    public class FeedConversion
    {
        [TestCase(@"D:\Apurv\ApurvGupta_Test\ImportFeeds.Test\feed-products\softwareadvice.json")]
        [TestCase(@"D:\Apurv\ApurvGupta_Test\ImportFeeds.Test\feed-products\capterra.yaml")]
        public void CheckJsonConversion(string filePath)
        {
            FeedJson obj = new FeedJson();
            var result = obj.Import(filePath);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].category.Count, 2);
            Assert.AreEqual(result[1].category.Count, 2);
            Assert.IsNotNull(result[0].twitter);
            Assert.IsNull(result[1].twitter);
        }

        [TestCase(@"D:\Apurv\ApurvGupta_Test\ImportFeeds.Test\feed-products\softwareadvice.json")]
        [TestCase(@"D:\Apurv\ApurvGupta_Test\ImportFeeds.Test\feed-products\capterra.yaml")]
        public void CheckYamlConversion(string filePath)
        {
            FeedYaml obj = new FeedYaml();
            var result = obj.Import(filePath);
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].category.Count, 2);
            Assert.AreEqual(result[1].category.Count, 3);
            Assert.AreEqual(result[2].category.Count, 3);
        }
    }
}
