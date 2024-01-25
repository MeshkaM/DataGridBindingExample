using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataGridBindingExample.Models
{
    public class CountriesModel : INotifyPropertyChanged
    {
        private string _CountryName;
        public string CountryName
        {
            get => this._CountryName;
            set
            {
                if (value == this._CountryName) return;
                this._CountryName = value;
                OnPropertyChanged(nameof(CountryName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
