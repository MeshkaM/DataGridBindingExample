using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridBindingExampleCore.Models
{
    public partial class PlacesOfInterest : ObservableObject
    {
        public int ID { get; set; }

        public int StudentID { get; set; }


        string _countryName;
        public string CountryName
        {
            get => this._countryName;
            set { this._countryName = value; ProvinceID = 0; DistrictID = 0; OnPropertyChanged(); }
        }

        int _provinceID;
        public int ProvinceID
        {
            get => this._provinceID;
            set { this._provinceID = value; DistrictID = 0; OnPropertyChanged(); }
        }

        int _districtID;
        public int DistrictID
        {
            get => this._districtID;
            set { this._districtID = value; OnPropertyChanged(); }
        }
    }
}
