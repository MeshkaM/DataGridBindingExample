using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridBindingExampleCore2.Models
{
    public partial class DistrictsModel : ObservableObject
    {
        [ObservableProperty]
        int provinceID;
        [ObservableProperty]
        int districtID;
        [ObservableProperty]
        string districtName;
    }
}