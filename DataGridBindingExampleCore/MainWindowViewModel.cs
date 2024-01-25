﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGridBindingExampleCore.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataGridBindingExampleCore
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isLoading;

        [ObservableProperty]
        ObservableCollection<StudentsModel> students;
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
        StudentsModel selectedStudent;

        [ObservableProperty]
        PlacesOfInterest selectedPlace;


        int currentIndex = 0;

        [RelayCommand]
        private void NavigateStudents(string ButtonName)
        {
            switch (ButtonName)
            {
                case "NavigateNextButton":
                    currentIndex = Math.Min(currentIndex + 1, Students.Count - 1);
                    break;
                case "NavigateBeforeButton":
                    currentIndex = Math.Max(currentIndex - 1, 0);
                    break;
                default:
                    break;
            }

            this.SelectedStudent = Students[currentIndex];
        }

        public MainWindowViewModel()
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            IsLoading = true;

            this.Students = new ObservableCollection<StudentsModel>(await DAL.LoadStudentsAsync());
            this.Countries = new ObservableCollection<CountriesModel>(await DAL.LoadCountriesAsync());
            this.Provinces = new ObservableCollection<ProvincesModel>(await DAL.LoadProvincesAsync());
            this.Districts = new ObservableCollection<DistrictsModel>(await DAL.LoadDistrictsAsync());

            this.SelectedStudent = Students.FirstOrDefault();
            OnPropertyChanged(nameof(SelectedStudent));  // Notify the UI that SelectedStudent has changed

            IsLoading = false;
        }
    }
}
