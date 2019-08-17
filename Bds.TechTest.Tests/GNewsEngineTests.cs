using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bds.TechTest.Wpf.SearchService.GNews;
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
    }
}
