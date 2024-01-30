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
        {
            get
            {
                var countryName = SelectedPlace?.GetType().GetProperty("CountryName")?.GetValue(SelectedPlace, null);
                if (countryName == null) return null;
                return new ObservableCollection<ProvincesModel>(Provinces.Where((p) => p.CountryName == countryName.ToString()));
            }
        }
        public object CurrentDistricts
        {
            get
            {
                var provinceID = SelectedPlace?.GetType().GetProperty("ProvinceID")?.GetValue(SelectedPlace, null);
                if (provinceID == null) return null;
                return new ObservableCollection<DistrictsModel>(Districts.Where((p) => p.ProvinceID == (int)provinceID));
            }
        }

        [ObservableProperty]
        object selectedPlace;
    }
}
