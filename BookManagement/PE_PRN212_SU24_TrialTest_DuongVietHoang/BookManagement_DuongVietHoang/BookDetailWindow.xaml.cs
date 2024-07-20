//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using BookManagement.BLL;
//using BookManagement.DAL.Models;

//namespace BookManagement_DuongVietHoang
//{
//    /// <summary>
//    /// Interaction logic for BookDetailWindow.xaml
//    /// </summary>
//    /// 
//    public partial class BookDetailWindow : Window
//    {
//        public BookDetailWindow()
//        {
//            InitializeComponent();
//        }

//        public Book SelectedBook { get; set; }

//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {
//            BookCategoryService cat = new BookCategoryService();

//            //đổ full data vào cbo
//            bookCategorySelect.ItemsSource = cat.GetAllCategories(); //hàm số II

//            //chọn cột để hiển thị trên cbo
//            bookCategorySelect.DisplayMemberPath = "BookGenreType"; // Change to the appropriate property name
//            bookCategorySelect.SelectedValuePath = "BookCategoryId"; 

//            //vi diệu
//            //nhảy đến giá trị bất kì nào mình thích trong cbo
//            //mặc định là đầu danh sách xổ 1 
//            //cboBookCategoryId.SelectedValue = 5; //default với mình là sách Self Help  

//            //CHECK HÀNG, CÓ PHẢI LÀ EDIT HAY KO
//            //CHECK BIẾN SELECTEDBOOK COI CÓ ĐC SET KHÁC NULL KO
//            //NẾU CÓ SÁCH THÌ FILL VÀO CÁC Ô
//            if (SelectedBook != null)
//            {
//                BookDetailTittle.Content = "Update selected book";
//                bookIdText.Text = SelectedBook.BookId.ToString();
//                bookIdText.IsEnabled = false;
//                bookNameText.Text = SelectedBook.BookName.ToString();
//                bookDescText.Text = SelectedBook.Description.ToString();
//                bookDateSelect.Text = SelectedBook.PublicationDate.ToString();
//                bookDateSelect.SelectedDate = SelectedBook.PublicationDate;
//                bookPriceText.Text = SelectedBook.Price.ToString();
//                bookQuantityText.Text = SelectedBook.Quantity.ToString();
//                bookAuthorText.Text = SelectedBook.Author.ToString();
//                bookCategorySelect.SelectedItem = SelectedBook.BookCategory;
//            }
//            else
//                BookDetailTittle.Content = "Create a new book";
//        }

//        private void SaveBtn_Click(object sender, RoutedEventArgs e)
//        {
//            Book book = new Book()
//            {
//                BookId = int.Parse(bookIdText.Text),
//                BookName = bookNameText.Text,
//                Description = bookDescText.Text,
//                PublicationDate = bookDateSelect.SelectedDate,
//                Quantity = int.Parse(bookQuantityText.Text),
//                Price = double.Parse(bookPriceText.Text),
//                Author = bookAuthorText.Text,
//                BookCategoryId = int.Parse(bookCategorySelect.SelectedValue.ToString())
//            };
//            BookService service = new();

//            if (SelectedBook != null) 
//                service.UpdateBookFromUI(book);
//            else
//                service.AddBookFromUI(book);

//            Close();
//        }

//        private void CloseBtn_Click(object sender, RoutedEventArgs e)
//        {
//            Close();
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BookManagement.BLL;
using BookManagement.DAL.Models;

namespace BookManagement_DuongVietHoang
{
    /// <summary>
    /// Interaction logic for BookDetailWindow.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {
        public Book SelectedBook { get; set; }

        public BookDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();

            if (SelectedBook != null)
            {
                BookDetailTittle.Content = "Update selected book";
                FillBookDetails();
            }
            else
            {
                BookDetailTittle.Content = "Create a new book";
            }
        }

        private void LoadCategories()
        {
            BookCategoryService cat = new BookCategoryService();
            var categories = cat.GetAllCategories();
            bookCategorySelect.ItemsSource = categories;
            bookCategorySelect.DisplayMemberPath = "BookGenreType"; // Adjust property name as needed
            bookCategorySelect.SelectedValuePath = "BookCategoryId";
            if (categories.Any())
            {
                bookCategorySelect.SelectedIndex = 0; // Default to the first category
            }
        }

        private void FillBookDetails()
        {
            bookIdText.Text = SelectedBook.BookId.ToString();
            bookIdText.IsEnabled = false;
            bookNameText.Text = SelectedBook.BookName;
            bookDescText.Text = SelectedBook.Description;
            bookDateSelect.SelectedDate = SelectedBook.PublicationDate;
            bookPriceText.Text = SelectedBook.Price.ToString();
            bookQuantityText.Text = SelectedBook.Quantity.ToString();
            bookAuthorText.Text = SelectedBook.Author;
            bookCategorySelect.SelectedValue = SelectedBook.BookCategoryId;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book()
            {
                BookId = int.Parse(bookIdText.Text),
                BookName = bookNameText.Text,
                Description = bookDescText.Text,
                PublicationDate = bookDateSelect.SelectedDate,
                Quantity = int.Parse(bookQuantityText.Text),
                Price = double.Parse(bookPriceText.Text),
                Author = bookAuthorText.Text,
                BookCategoryId = int.Parse(bookCategorySelect.SelectedValue.ToString())
            };

            BookService service = new BookService();
            if (SelectedBook != null)
            {
                service.UpdateBookFromUI(book);
            }
            else
            {
                service.AddBookFromUI(book);
            }

            MainWindow mainWindow = new();
            mainWindow.Show();

            Close();


        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new();
            mainWindow.Show();

            Close();
        }
    }
}
