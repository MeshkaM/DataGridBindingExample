using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGridBindingExampleCore2.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataGridBindingExampleCore2
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isLoading;

        [ObservableProperty]
        ObservableCollection<StudentsModel> students;

        [ObservableProperty]
        StudentsModel selectedStudent;

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

            this.SelectedStudent = Students.FirstOrDefault();
            OnPropertyChanged(nameof(SelectedStudent));  // Notify the UI that SelectedStudent has changed

            IsLoading = false;
        }
    }
}
