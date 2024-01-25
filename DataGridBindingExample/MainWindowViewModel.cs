using DataGridBindingExample.Models;
using MaterialDesignFixedHintTextBox;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataGridBindingExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PlacesOfInterest> PlacesOfInterest { get; set; }
        public ObservableCollection<CountriesModel> Countries { get; set; }
        public ObservableCollection<ProvincesModel> Provinces { get; set; }
        public ObservableCollection<DistrictsModel> Districts { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {   
            this.PlacesOfInterest = new ObservableCollection<PlacesOfInterest>(DAL.LoadPlacesOfInterest());
            this.Countries = new ObservableCollection<CountriesModel>(DAL.LoadCountries());
            this.Provinces = new ObservableCollection<ProvincesModel>(DAL.LoadProvinces());
            this.Districts = new ObservableCollection<DistrictsModel>(DAL.LoadDistricts());
        }

    }

}
