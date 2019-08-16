using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bds.TechTest.Wpf
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Search = new RoutedCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Phrase { get; set; }

        public ICommand Search { get; set; }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
