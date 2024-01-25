using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace DataGridBindingExampleCore2.CustomControls
{
    public partial class PlacesDataGrid : UserControl
    {
        public PlacesDataGrid()
        {
            InitializeComponent();
        }



        public static readonly DependencyProperty DataGridItemsSourceProperty = 
            DependencyProperty.Register("DataGridItemsSource", typeof(IEnumerable), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public IEnumerable DataGridItemsSource
        {
            get { return (IEnumerable)GetValue(DataGridItemsSourceProperty);}
            set { SetValue(DataGridItemsSourceProperty, value);}
        }


        public static readonly DependencyProperty CountryPathvalueProperty =
            DependencyProperty.Register("CountryPathvalue", typeof(string), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public string CountryPathvalue
        {
            get { return (string)GetValue(CountryPathvalueProperty); }
            set { SetValue(CountryPathvalueProperty, value); }
        }

        public static readonly DependencyProperty CountrySelectedValueProperty =
            DependencyProperty.Register("CountrySelectedValue", typeof(object), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public object CountrySelectedValue
        {
            get { return (object)GetValue(CountrySelectedValueProperty); }
            set { SetValue(CountrySelectedValueProperty, value); }
        }

        public static readonly DependencyProperty ProvincePathValueProperty =
            DependencyProperty.Register("ProvincePathValue", typeof(string), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public string ProvincePathValue
        {
            get { return (string)GetValue(ProvincePathValueProperty); }
            set { SetValue(ProvincePathValueProperty, value); }
        }

        public static readonly DependencyProperty ProvinceSelectedValueProperty =
            DependencyProperty.Register("ProvinceSelectedValue", typeof(object), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public object ProvinceSelectedValue
        {
            get { return (object)GetValue(ProvinceSelectedValueProperty); }
            set { SetValue(ProvinceSelectedValueProperty, value); }
        }

        public static readonly DependencyProperty ProvinceIDvalueProperty =
            DependencyProperty.Register("ProvinceIDvalue", typeof(string), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public string ProvinceIDvalue
        {
            get { return (string)GetValue(ProvinceIDvalueProperty); }
            set { SetValue(ProvinceIDvalueProperty, value); }
        }


        public static readonly DependencyProperty DistrictPathValueProperty =
            DependencyProperty.Register("DistrictPathValue", typeof(string), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public string DistrictPathValue
        {
            get { return (string)GetValue(DistrictPathValueProperty); }
            set { SetValue(DistrictPathValueProperty, value); }
        }

        public static readonly DependencyProperty DistrictSelectedValueProperty =
            DependencyProperty.Register("DistrictSelectedValue", typeof(object), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public object DistrictSelectedValue
        {
            get { return (object)GetValue(DistrictSelectedValueProperty); }
            set { SetValue(DistrictSelectedValueProperty, value); }
        }

        public static readonly DependencyProperty DistrictIDvalueProperty =
            DependencyProperty.Register("DistrictIDvalue", typeof(string), typeof(PlacesDataGrid), new PropertyMetadata(null));
        public string DistrictIDvalue
        {
            get { return (string)GetValue(DistrictIDvalueProperty); }
            set { SetValue(DistrictIDvalueProperty, value); }
        }
    }
}
