using AirConditionerShop.BLL;
using AirConditionerShop.DAL.Models;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirConditionerShop_DuongVietHoang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool crudPermission { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<AirConditioner> airConditioners;


        private AirConditionerService _service = new();

        private void FillDataGridView()
        {
            try
            {
                airConditioners = _service.GetAllAirConditioners();
                AirConditionerDataGrid.ItemsSource = airConditioners;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                Console.WriteLine("Error loading data: " + ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGridView();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!crudPermission) {
                MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DetailWindow detailWindow = new();
            detailWindow.Show();
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!crudPermission)
            {
                MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (AirConditionerDataGrid.SelectedItem != null)
            {
                var selectedAirConditioner = AirConditionerDataGrid.SelectedItem as AirConditioner;
                if (selectedAirConditioner != null)
                {
                    DetailWindow detailWindow = new DetailWindow();
                    detailWindow.selectedAirConditioner = selectedAirConditioner;
                    detailWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to update.");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {


            if (!crudPermission)
            {
                MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var selectedAirConditioner = AirConditionerDataGrid.SelectedItem as AirConditioner;  // Replace 'Book' with your actual data type

            if (selectedAirConditioner != null)
            {
                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete the book '{selectedAirConditioner.AirConditionerName}'?",
                    "Delete Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                // If the user confirms, delete the book
                if (result == MessageBoxResult.Yes)
                {
                    AirConditionerService service = new();
                    service.DeleteAirConditionerFromUI(selectedAirConditioner);

                    // Optionally, refresh the data grid or perform other UI updates
                    RefreshBookList();
                }
            }
            else
            {
                // Show a message if no book is selected
                MessageBox.Show(
                    "Please select a book to delete.",
                    "No Selection",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        //private void SearchBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    string searchAirConditionerName = txtSearchAirConditionerName.Text.ToLower();
        //    string searchAirConditionerDesc = txtSearchAirConditionerDesc.Text.ToLower();

        //    var filteredAirConditioners = airConditioners.Where(airConditioner =>
        //        (string.IsNullOrEmpty(searchAirConditionerName) || airConditioner.AirConditionerName.ToLower().Contains(searchAirConditionerName)) &&
        //        (string.IsNullOrEmpty(searchAirConditionerDesc) || airConditioner.Supplier.SupplierName.ToLower().Contains(searchAirConditionerDesc))
        //    ).ToList();

        //    AirConditionerDataGrid.ItemsSource = filteredAirConditioners;
        //}

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchFeatureFunction = txtSearchFeatureFunction.Text.ToLower();
            string searchQuantityText = txtSearchQuantity.Text;

            int searchQuantity;
            bool isQuantity = int.TryParse(searchQuantityText, out searchQuantity);

            var filteredAirConditioners = airConditioners.Where(airConditioner =>
                (string.IsNullOrEmpty(searchFeatureFunction) || airConditioner.FeatureFunction.ToLower().Contains(searchFeatureFunction)) &&
                (!isQuantity || airConditioner.Quantity >= searchQuantity)  // Only filter by quantity if a valid number is entered
            ).ToList();

            AirConditionerDataGrid.ItemsSource = filteredAirConditioners;
        }


        private void RefreshBookList()
        {
            AirConditionerService service = new ();
            AirConditionerDataGrid.ItemsSource = service.GetAllAirConditioners();
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
