using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridBindingExampleCore2.Models
{
    public partial class ProvincesModel : ObservableObject
    {
        [ObservableProperty]
        string countryName;
        [ObservableProperty]
        int provinceID;
        [ObservableProperty]
        string provinceName;
    }
}
