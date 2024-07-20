using BookManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL
{
    public class BookCategoryRepository
    {
        private BookManagementDbContext _context;
        public List<BookCategory> GetBookCategories()
        {
            _context = new();
            return _context.BookCategories.ToList();
        }
    }
}
