using System.Collections.Generic;

namespace Book.Models
{
    public interface IBookDb
    {
        IEnumerable<Books> GetAll();
        Books Create(Books books);

        Books Delete(int id);
        
    }
}
