using System.Threading.Tasks;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;
using NUnit.Framework;

namespace Bds.TechTest.Tests
{
    public class WikipediaEngineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var engine = new WikipediaEngine();

            TestDelegate td = ()=>engine.GetResults("xxx").GetAwaiter().GetResult();

            Assert.DoesNotThrow(td);
        }
    }
}