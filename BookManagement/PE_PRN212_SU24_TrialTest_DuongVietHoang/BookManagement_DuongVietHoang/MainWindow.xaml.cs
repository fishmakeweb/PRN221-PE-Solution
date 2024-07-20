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
using BookManagement.BLL;
using BookManagement.DAL.Models;
using Microsoft.Identity.Client;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookManagement_DuongVietHoang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Book> books;


        private BookService _service = new BookService();

        private void FillDataGridView()
        {
            try
            {
                books = _service.GetAllBooks();
                BookListDataGrid.ItemsSource = books;  
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
            BookDetailWindow bookDetailWindow = new BookDetailWindow();
            bookDetailWindow.Show();
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if any item is selected in the DataGrid
            if (BookListDataGrid.SelectedItem != null)
            {
                // Cast the SelectedItem to your book type, assuming it's 'Book' 
                var selectedBook = BookListDataGrid.SelectedItem as Book;  // Replace 'Book' with your actual data type

                if (selectedBook != null)
                {
                    BookDetailWindow bookDetailWindow = new BookDetailWindow();
                    bookDetailWindow.SelectedBook = selectedBook;
                    bookDetailWindow.Show();
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
            var selectedBook = BookListDataGrid.SelectedItem as Book;  // Replace 'Book' with your actual data type

            if (selectedBook != null)
            {
                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete the book '{selectedBook.BookName}'?",
                    "Delete Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                // If the user confirms, delete the book
                if (result == MessageBoxResult.Yes)
                {
                    BookService service = new BookService();
                    service.DeleteBookFromUI(selectedBook);

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

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchBookName = txtSearchBookName.Text.ToLower();
            string searchBookDesc = txtSearchBookDesc.Text.ToLower();

            var filteredBooks = books.Where(book =>
                (string.IsNullOrEmpty(searchBookName) || book.BookName.ToLower().Contains(searchBookName)) &&
                (string.IsNullOrEmpty(searchBookDesc) || book.Description.ToLower().Contains(searchBookDesc))
            ).ToList();

            BookListDataGrid.ItemsSource = filteredBooks;
        }


        private void RefreshBookList()
        {
            BookService service = new BookService();
            BookListDataGrid.ItemsSource = service.GetAllBooks();
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }


}