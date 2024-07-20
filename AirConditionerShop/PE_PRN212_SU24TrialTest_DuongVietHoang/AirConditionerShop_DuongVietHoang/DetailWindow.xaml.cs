using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AirConditionerShop.BLL;
using AirConditionerShop.DAL.Models;

namespace AirConditionerShop_DuongVietHoang
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {

        public AirConditioner? selectedAirConditioner { get; set; }

        public DetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSupplierCompanies();

            if (selectedAirConditioner != null)
            {
                DetailTittle.Content = "Update selected AirConditioner";
                FillBookDetails();
            }
            else
            {
                DetailTittle.Content = "Create a new AirConditioner";
            }
        }

        private void LoadSupplierCompanies()
        {
            SupplierCompanyService service = new();
            var supplierCompanies = service.GetAllSupplierCompanies();
            selectSupplierCompany.ItemsSource = supplierCompanies;
            selectSupplierCompany.DisplayMemberPath = "SupplierName"; // Adjust property name as needed
            selectSupplierCompany.SelectedValuePath = "SupplierId";
            if (supplierCompanies.Any())
            {
                selectSupplierCompany.SelectedIndex = 0;
            }
        }

        private void FillBookDetails()
        {
            txtAirConditionerId.Text = selectedAirConditioner.AirConditionerId.ToString();
            txtAirConditionerId.IsEnabled = false;
            txtAirConditionerName.Text = selectedAirConditioner.AirConditionerName;
            txtWarranty.Text = selectedAirConditioner.Warranty;
            txtSoundPressureLevel.Text = selectedAirConditioner.SoundPressureLevel;
            txtFeatureFunction.Text = selectedAirConditioner.FeatureFunction;
            txtDollarPrice.Text = selectedAirConditioner.DollarPrice.ToString();
            txtQuantity.Text = selectedAirConditioner.Quantity.ToString();
            selectSupplierCompany.SelectedValue = selectedAirConditioner.SupplierId;
        }

        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    AirConditioner airConditioner = new()
        //    {
        //        AirConditionerId = int.Parse(txtAirConditionerId.Text),
        //        AirConditionerName = txtAirConditionerName.Text,
        //        Warranty = txtWarranty.Text,
        //        SoundPressureLevel = txtSoundPressureLevel.Text,
        //        FeatureFunction = txtFeatureFunction.Text,
        //        DollarPrice = double.Parse(txtDollarPrice.Text),
        //        Quantity = int.Parse(txtQuantity.Text),
        //        SupplierId = selectSupplierCompany.SelectedValue.ToString()
        //    };

        //    AirConditionerService service = new ();
        //    if (selectedAirConditioner != null)
        //    {
        //        service.UpdateAirConditionerFromUI(airConditioner);
        //    }
        //    else
        //    {
        //        service.AddAirConditionerFromUI(airConditioner);
        //    }

        //    MainWindow mainWindow = new();
        //    mainWindow.crudPermission = true;

        //    mainWindow.Show();

        //    Close();


        //}

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check for empty fields
            if (string.IsNullOrWhiteSpace(txtAirConditionerId.Text) ||
                string.IsNullOrWhiteSpace(txtAirConditionerName.Text) ||
                string.IsNullOrWhiteSpace(txtWarranty.Text) ||
                string.IsNullOrWhiteSpace(txtSoundPressureLevel.Text) ||
                string.IsNullOrWhiteSpace(txtFeatureFunction.Text) ||
                string.IsNullOrWhiteSpace(txtDollarPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                selectSupplierCompany.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate AirConditionerName for length and character constraints
            Regex nameRegex = new Regex(@"^\s*([A-Z0-9][\w\W]{4,89})$");
            if (!nameRegex.IsMatch(txtAirConditionerName.Text))
            {
                MessageBox.Show("AirConditioner Name must be 5-90 characters long and start each word with a capital letter or digit.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate DollarPrice and Quantity
            if (!double.TryParse(txtDollarPrice.Text, out double dollarPrice) || dollarPrice < 0 || dollarPrice >= 4000000 ||
                !int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0 || quantity >= 4000000)
            {
                MessageBox.Show("Dollar Price and Quantity must be a number between 0 and 3,999,999.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // If validations pass, proceed with creating or updating the AirConditioner object
            AirConditioner airConditioner = new()
            {
                AirConditionerId = int.Parse(txtAirConditionerId.Text),
                AirConditionerName = txtAirConditionerName.Text,
                Warranty = txtWarranty.Text,
                SoundPressureLevel = txtSoundPressureLevel.Text,
                FeatureFunction = txtFeatureFunction.Text,
                DollarPrice = dollarPrice,
                Quantity = quantity,
                SupplierId = selectSupplierCompany.SelectedValue.ToString()
            };

            AirConditionerService service = new();
            if (selectedAirConditioner != null)
            {
                service.UpdateAirConditionerFromUI(airConditioner);
            }
            else
            {
                service.AddAirConditionerFromUI(airConditioner);
            }

            // Optionally, refresh or close the current window and open the main window
            MainWindow mainWindow = new();
            mainWindow.crudPermission = true;
            mainWindow.Show();
            Close();
        }


        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new();
            mainWindow.crudPermission = true;
            mainWindow.Show();

            Close();
        }
    }
}
