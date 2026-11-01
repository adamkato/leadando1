using zambo_project_11__01.Services;
using System.Windows;
using System.Windows.Controls;

namespace zambo_project_11__01
{
    public partial class DietWindow : Window
    {
        public DietWindow()
        {
            InitializeComponent();
            LoadDiets("Tömegelés");
        }

        private async void LoadDiets(string category)
        {
            DietGrid.ItemsSource = await ApiService.GetDietsAsync(category);
        }

        private void CategoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryCombo.SelectedItem is ComboBoxItem item && item.Content is string cat)
            {
                LoadDiets(cat);
            }
        }
    }
}