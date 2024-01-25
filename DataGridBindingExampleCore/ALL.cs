

namespace DataGridBindingExampleCore
{
    //MainWindow
                <DataGrid AutoGenerateColumns = "False" ItemsSource="{Binding PlacesOfInterest}">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header = "Country" >
                        < DataGridTemplateColumn.CellTemplate >
                            < DataTemplate >
                                < ComboBox
                                    Width="120"
                                    DisplayMemberPath="CountryName"
                                    ItemsSource="{Binding DataContext.Countries, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}}"
                                    SelectedItem="{Binding DataContext.SelectedCountry, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Mode=TwoWay}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTemplateColumn Header = "Province" >
                        < DataGridTemplateColumn.CellTemplate >
                            < DataTemplate >
                                < ComboBox
                                    Width="120"
                                    DisplayMemberPath="ProvinceName"
                                    ItemsSource="{Binding DataContext.Provinces, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}}"
                                    SelectedItem="{Binding DataContext.SelectedProvince, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Mode=TwoWay}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTemplateColumn Header = "District" >
                        < DataGridTemplateColumn.CellTemplate >
                            < DataTemplate >
                                < ComboBox
                                    Width="120"
                                    DisplayMemberPath="DistrictName"
                                    ItemsSource="{Binding DataContext.Districts, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}}"
                                    SelectedItem="{Binding DataContext.SelectedDistrict, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Mode=TwoWay}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>


    //MainViewModel
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<PlacesOfInterest> placesOfInterest;
        [ObservableProperty]
        ObservableCollection<CountriesModel> countries;
        [ObservableProperty]
        ObservableCollection<ProvincesModel> provinces;
        [ObservableProperty]
        ObservableCollection<DistrictsModel> districts;

        public MainWindowViewModel()
        {
            this.PlacesOfInterest = new ObservableCollection<PlacesOfInterest>(DAL.LoadPlacesOfInterest());
            this.Countries = new ObservableCollection<CountriesModel>(DAL.LoadCountries());
            this.Provinces = new ObservableCollection<ProvincesModel>(DAL.LoadProvinces());
            this.Districts = new ObservableCollection<DistrictsModel>(DAL.LoadDistricts());
        }
    }

    //CountriesModel
    public partial class CountriesModel : ObservableObject
    {
        [ObservableProperty]
        string countryName;
    }

    //ProvincesModel
    public partial class ProvincesModel : ObservableObject
    {
        [ObservableProperty]
        string countryName;

        [ObservableProperty]
        int provinceID;

        [ObservableProperty]
        string provinceName;
    }

    //DistrictsModel
    public partial class DistrictsModel : ObservableObject
    {
        [ObservableProperty]
        int provinceID;

        [ObservableProperty]
        int districtID;

        [ObservableProperty]
        string districtName;
    }

    //PlacesOfInterest
        public partial class PlacesOfInterest : ObservableObject
    {
        [ObservableProperty]
        int iD;

        [ObservableProperty]
        string countryName;

        [ObservableProperty]
        int provinceID;

        [ObservableProperty]
        int districtID;
    }

    //DAL (Data Access Layer)
    public class DAL
    {
        private static readonly string ConnString = "Data Source=(local);Initial Catalog=CollegeDB;Integrated Security=True";

        //**************************************************************************************************

        public static List<PlacesOfInterest> LoadPlacesOfInterest()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<PlacesOfInterest>("SELECT * FROM PlacesOfInterest").ToList();
            }
        }

        public static List<CountriesModel> LoadCountries()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<CountriesModel>("SELECT * FROM Countries").ToList();
            }
        }

        public static List<ProvincesModel> LoadProvinces()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<ProvincesModel>("SELECT * FROM Provinces").ToList();
            }
        }

        public static List<DistrictsModel> LoadDistricts()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<DistrictsModel>("SELECT * FROM Districts").ToList();
            }
        }
    }

}
