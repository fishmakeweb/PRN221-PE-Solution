using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DAL;
using BookManagement.DAL.Models;


namespace BookManagement.BLL
{
    public class BookService
    {
        private BookRepository _repo = new BookRepository();

        public List<Book> GetAllBooks()
        {
            return _repo.GetBooks();
        }

        public void AddBookFromUI(Book book)
        {
            _repo.AddBook(book);
        }  

        public void UpdateBookFromUI(Book book)
        {
            _repo.UpdateBook(book);
        }

        public void DeleteBookFromUI(Book book)
        {
            _repo.DeleteBook(book); 
        }
    }
}
