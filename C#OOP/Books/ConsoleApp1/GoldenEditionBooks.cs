using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;

namespace _02.Book_Shop;
    public class GoldenEditionBook : Book
{
    public override double Price => base.Price * 1.3;

    public GoldenEditionBook(string title, string author, double price)
        : base(title, author, price)
    {
    }
}
