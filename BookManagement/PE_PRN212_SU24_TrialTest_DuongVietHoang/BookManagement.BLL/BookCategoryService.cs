using BookManagement.DAL.Models;
using BookManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL
{
    public class BookCategoryService
    {
        private BookCategoryRepository _repo = new();
        public List<BookCategory> GetAllCategories()
        {
            return _repo.GetBookCategories();
        }  

    }
}
