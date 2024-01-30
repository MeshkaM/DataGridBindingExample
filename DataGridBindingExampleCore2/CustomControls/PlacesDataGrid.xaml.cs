using DataGridBindingExampleCore2.Models;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataGridBindingExampleCore2.CustomControls
{
    public partial class PlacesDataGrid : UserControl
    {
        public PlacesDataGrid()
        {
            InitializeComponent();
            this.Loaded += PlacesDataGrid_Loaded;
        }

        public static readonly DependencyProperty DataGridItemsSourceProperty =
                DependencyProperty.Register("DataGridItemsSource", typeof(IEnumerable), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public IEnumerable DataGridItemsSource
        {
            get { return (IEnumerable)GetValue(DataGridItemsSourceProperty); }
            set { SetValue(DataGridItemsSourceProperty, value); }
        }

        public string CountryPathValue { get; set; }
        public string CountrySelectedValue { get; set; }
        public string ProvincePathValue { get; set; }
        public string ProvinceSelectedValue { get; set; }
        public string ProvinceIDValue { get; set; }
        public string DistrictPathValue { get; set; }
        public string DistrictSelectedValue { get; set; }
        public string DistrictIDValue { get; set; }
        private void PlacesDataGrid_Loaded(object sender, RoutedEventArgs e) => SetColumns();

        private void SetColumns()
        {
            // First column CountryPathvalue
            DataGridTemplateColumn col1 = new() { Header = "Country", Width = 150 };
            DataTemplate dt1 = new DataTemplate();
            FrameworkElementFactory cb1 = new FrameworkElementFactory(typeof(ComboBox));
            cb1.SetValue(ComboBox.DisplayMemberPathProperty, CountryPathValue);
            cb1.SetBinding(ComboBox.ItemsSourceProperty, new Binding("Countries") { Source = grid.DataContext, Mode = BindingMode.OneWay });
            cb1.SetBinding(ComboBox.SelectedValueProperty, new Binding(CountrySelectedValue) { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            cb1.SetValue(ComboBox.SelectedValuePathProperty, CountryPathValue);
            dt1.VisualTree = cb1;
            col1.CellTemplate = dt1;
            dg.Columns.Add(col1);

            // Second column
            DataGridTemplateColumn col2 = new() { Header = "Province", Width = 150 };
            DataTemplate dt2a = new DataTemplate();
            FrameworkElementFactory tb2 = new FrameworkElementFactory(typeof(TextBlock));
            MultiBinding mb2 = new MultiBinding() { Mode = BindingMode.OneWay };
            mb2.Converter = new ConvProvinceID();
            mb2.Bindings.Add(new Binding(ProvinceIDValue));
            mb2.Bindings.Add(new Binding("Provinces") { Source = grid.DataContext });
            tb2.SetBinding(TextBlock.TextProperty, mb2);
            dt2a.VisualTree = tb2;
            col2.CellTemplate = dt2a;
            // SecondCellEditingTemplate
            DataTemplate dt2b = new DataTemplate();
            FrameworkElementFactory cb2 = new FrameworkElementFactory(typeof(ComboBox));
            cb2.SetValue(ComboBox.DisplayMemberPathProperty, ProvincePathValue);
            cb2.SetBinding(ComboBox.ItemsSourceProperty, new Binding("CurrentProvinces") { Source = grid.DataContext, Mode = BindingMode.OneWay });
            cb2.SetBinding(ComboBox.SelectedValueProperty, new Binding(ProvinceIDValue) { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            cb2.SetValue(ComboBox.SelectedValuePathProperty, ProvinceSelectedValue);
            dt2b.VisualTree = cb2;
            col2.CellEditingTemplate = dt2b;
            dg.Columns.Add(col2);

            // Third column
            DataGridTemplateColumn col3 = new() { Header = "District", Width = 150 };
            DataTemplate dt3a = new DataTemplate();
            FrameworkElementFactory tb3 = new FrameworkElementFactory(typeof(TextBlock));
            MultiBinding mb3 = new MultiBinding() { Mode = BindingMode.OneWay };
            mb3.Converter = new ConvDistrictID();
            mb3.Bindings.Add(new Binding(DistrictIDValue));
            mb3.Bindings.Add(new Binding("Districts") { Source = grid.DataContext });
            tb3.SetBinding(TextBlock.TextProperty, mb3);
            dt3a.VisualTree = tb3;
            col3.CellTemplate = dt3a;
            // SecondCellEditingTemplate
            DataTemplate dt3b = new DataTemplate();
            FrameworkElementFactory cb3 = new FrameworkElementFactory(typeof(ComboBox));
            cb3.SetValue(ComboBox.DisplayMemberPathProperty, DistrictPathValue);
            cb3.SetBinding(ComboBox.ItemsSourceProperty, new Binding("CurrentDistricts") { Source = grid.DataContext, Mode = BindingMode.OneWay });
            cb3.SetBinding(ComboBox.SelectedValueProperty, new Binding(DistrictIDValue) { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            cb3.SetValue(ComboBox.SelectedValuePathProperty, DistrictSelectedValue);
            dt3b.VisualTree = cb3;
            col3.CellEditingTemplate = dt3b;
            dg.Columns.Add(col3);
        }
    }

    public class ConvProvinceID : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue || values[1] == null) return string.Empty;
            int i = (int)values[0];
            IList<ProvincesModel> l = (IList<ProvincesModel>)values[1];
            return i > 0 && (l.Count > 0) ? l[i - 1].ProvinceName : string.Empty;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ConvDistrictID : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue || values[1] == null) return string.Empty;
            int i = (int)values[0];
            IList<DistrictsModel> l = (IList<DistrictsModel>)values[1];
            return (i > 0 && l.Count > 0) ? l[i - 1].DistrictName : string.Empty;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
