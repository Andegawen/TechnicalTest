using Autofac;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;
using Bds.TechTest.Wpf.SearchService.Wikipedia;

namespace Bds.TechTest.Wpf.SearchService
{
    internal class SearchModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WikipediaEngine>().As<ISearchEngine>().SingleInstance();
            builder.RegisterType<SearchAggregatorService>().AsSelf().SingleInstance();
        }
    }
}
