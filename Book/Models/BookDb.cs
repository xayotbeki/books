using Book.Data;
using System.Collections.Generic;
using System.Linq;

namespace Book.Models
{
    public class BookDb : IBookDb
    {
        private readonly AppDbContext db;

        public BookDb(AppDbContext db)
        {
            this.db = db;
        }

        public Books Create(Books books)
        {
            db.Books.Add(books);
            db.SaveChanges();
            return books;
        }

        public Books Delete(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return book;
        }

        public IEnumerable<Books> GetAll()
        {
            return db.Books;
        }

        //public Books GetById(int id)
        //{
        //    var result = db.Books.FirstOrDefault(x => x.Id == id);
        //    return result;
        //}
    }
}
