using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Bds.TechTest.Wpf.SearchService;
using Bds.TechTest.Wpf.UiUtils;

namespace Bds.TechTest.Wpf
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _phrase;

        public MainViewModel(SearchAggregatorService searchAggregatorService)
        {
            SearchCommand = new DelegateCommand(
                async _=>
                {
                    Pending = true;
                    SearchResults = (await searchAggregatorService.GetResult(Phrase)).ToList();
                    Pending = false;
                }, 
                _=>true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Phrase
        {
            get => _phrase;
            set
            {
                _phrase = value;
                OnPropertyChanged();
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        public bool Pending { get; set; } = false;

        public IList<SearchResult> SearchResults { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
