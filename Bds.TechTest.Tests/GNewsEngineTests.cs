using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bds.TechTest.Wpf.SearchService.GNews;
using Bds.TechTest.Wpf.SearchService.Wikipedia;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Bds.TechTest.Tests
{
    [TestFixture]
    class GNewsEngineTests
    {
        [Test]
        public void GetResults_ShouldNotThrow()
        {
            var engine = new GNewsEngine();

            Task act() => engine.GetSearchResults("Blackdot");

            Assert.DoesNotThrowAsync(act);
        }

        [Test]
        public void ValidateResponseModel()
        {
            var example = @"{  
            ""status"":""ok"",
            ""totalResults"":37,
            ""articles"":[
            {  
                ""source"":{  
                    ""id"":""fox-news"",
                    ""name"":""Fox News""
                },
                ""author"":""Bradford Betz"",
                ""title"":""Dozens .."",
                ""description"":""Dozens .."",
                ""url"":""https://www.foxnews.com/some"",
                ""urlToImage"":""https://static.foxnews.com/some.png"",
                ""publishedAt"":""2019-08-17T20:07:57Z"",
                ""content"":""Dozens of people were killed or wounded Saturday after an explosion ripped through a wedding hall in Afghanistan's capital, local officials say. \r\nThere was no immediate information on the cause of the blast at the Dubai City wedding hall in western Kabul, In… [+2905 chars]""
            }]
            }";
            var result = JsonConvert.DeserializeObject<GNewsResult>(example);

            Assert.Multiple(() =>
            {
                Assert.That(result.Articles, Is.EquivalentTo(new[]{new GNewsEntry()
                {
                    Author = "Bradford Betz",
                    Title = "Dozens ..",
                    Description = "Dozens ..",
                    SourceUrl= "https://www.foxnews.com/some",
                    Source = new GNewsSource(){Name = "Fox News"}
                }, }));
            });
        }
    }
}
