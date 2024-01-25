using CommunityToolkit.Mvvm.ComponentModel;
using DataGridBindingExampleCore2.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataGridBindingExampleCore2.CustomControls
{
    public partial class PlacesDataGridViewModel : ObservableObject
    {
        public PlacesDataGridViewModel()
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            this.Countries = new ObservableCollection<CountriesModel>(await DAL.LoadCountriesAsync());
            this.Provinces = new ObservableCollection<ProvincesModel>(await DAL.LoadProvincesAsync());
            this.Districts = new ObservableCollection<DistrictsModel>(await DAL.LoadDistrictsAsync());
        }

        [ObservableProperty]
        ObservableCollection<CountriesModel> countries;
        [ObservableProperty]
        ObservableCollection<ProvincesModel> provinces;
        [ObservableProperty]
        ObservableCollection<DistrictsModel> districts;

        public object CurrentProvinces
        { get => new ObservableCollection<ProvincesModel>(Provinces.Where((p) => p.CountryName == SelectedPlace.CountryName)); }
        public object CurrentDistricts
        { get => new ObservableCollection<DistrictsModel>(Districts.Where((p) => p.ProvinceID == SelectedPlace.ProvinceID)); }

        [ObservableProperty]
        PlacesOfInterest selectedPlace;
    }
}
