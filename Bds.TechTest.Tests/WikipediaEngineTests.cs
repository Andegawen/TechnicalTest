using Bds.TechTest.Wpf.SearchService;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;
using Bds.TechTest.Wpf.SearchService.Wikipedia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Bds.TechTest.Tests
{
    [TestClass]
    public class WikipediaEngineTests
    {
        [Test]
        public void ValidateResponseModel()
        {
            var example = @"{
                ""batchcomplete"":"""",
                ""continue"":{
                    ""sroffset"":10,
                    ""continue"":""-||""
                },
                ""query"":{
                    ""searchinfo"":{
                        ""totalhits"":13060
                    },
                    ""search"":[
                    {
                        ""ns"":0,
                        ""title"":""Some"",
                        ""pageid"":1,
                        ""wordcount"":341,
                        ""snippet"":""<span class=\""searchmatch\"">Some</span> may refer to ...""
                    }]
                }
            }";
            var result = JsonConvert.DeserializeObject<WikipediaResult>(example);

            Assert.Multiple(() =>
            {
                Assert.That(result.Query.Results, Is.EquivalentTo(new[]{new WikipediaSearchResult
                {
                    PageId = 1,
                    Snippet = "<span class=\"searchmatch\">Some</span> may refer to ...",
                    Title = "Some",
                    WordCount = 341
                }, }));
            });
        }

        [Test]
        public void GetResults_ShouldNotThrow()
        {
            var engine = new WikipediaEngine();

            AsyncTestDelegate td = async () => await engine.GetSearchResults("xxx");

            Assert.DoesNotThrowAsync(td);
        }
    }
}
