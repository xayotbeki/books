using Book.Models;
using System.Collections;
using System.Collections.Generic;

namespace Book.ViewModels
{
    public class HomeKitoblarViewModel
    {
        public IEnumerable<Books> Books { get; set; }
    }
}
