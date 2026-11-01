using zambo_project_11__01.Services;
using System.Windows;
using System.Windows.Controls;

namespace zambo_project_11__01
{
    public partial class WorkoutWindow : Window
    {
        public WorkoutWindow()
        {
            InitializeComponent();
            LoadWorkouts(null, null);
        }

        private async void LoadWorkouts(object? sender, RoutedEventArgs? e)
        {
            WorkoutsGrid.ItemsSource = await ApiService.GetWorkoutsAsync();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoalComboBox.SelectedItem is ComboBoxItem item && item.Content is string goal)
            {
                await ApiService.GenerateWorkoutsAsync(goal);
                LoadWorkouts(null, null);
                MessageBox.Show("Sikeresen generálva új edzésterv!", "Kész", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}