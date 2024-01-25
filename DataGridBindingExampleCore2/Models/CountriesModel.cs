using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridBindingExampleCore2.Models
{
    public partial class CountriesModel : ObservableObject
    {
        [ObservableProperty]
        string countryName;
    }
}
