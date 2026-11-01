using zambo_project_11__01.Services;
using System.Windows;

namespace zambo_project_11__01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            BodyPartsListBox.ItemsSource = await ApiService.GetBodyPartsAsync();
        }

        private async void TrainButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is int id)
            {
                await ApiService.TrainBodyPartAsync(id);
                LoadData();
            }
        }

        private void OpenWorkoutWindow(object sender, RoutedEventArgs e)
        {
            new WorkoutWindow().Show();
        }

        private void OpenDietWindow(object sender, RoutedEventArgs e)
        {
            new DietWindow().Show();
        }

        private void RefreshData(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}