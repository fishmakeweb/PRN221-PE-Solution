using BookManagement.BLL;
using BookManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookManagement_DuongVietHoang
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Closes the current window
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Pleae input both email & password", "Input plz.",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            UserAccountService service = new();
            UserAccount? acc = service.CheckLogin(txtEmail.Text, txtPassword.Password);

            if (acc == null)
            {
                MessageBox.Show("Login failed. Check the email and password again!", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (acc.Role != 1)
            {
                MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }
    }
}
