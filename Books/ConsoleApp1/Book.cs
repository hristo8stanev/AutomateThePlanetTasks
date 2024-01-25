using System.Text;

namespace Books
{
 public class Book
    {
        private const string errorMessageTitle = "Title is not valid!";
        private const string errorMessagePrice = "Price not valid!";
        private const int boundaryLength = 3;
        private const int price = 0;
        private const string errorMessageAuthor = "Author not valid!";
        private string _author;
        private string _title;
        private double _price;
        public Book(String author, String title,double price)
        {
            Author = author;
            Title = title;
            Price = price;
        }
        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                string[] names = value.Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
                if (names.Length > 1)
                {
                    if (char.IsDigit(names[1][0]))
                    {
                        throw new ArgumentException(errorMessageAuthor);
                    }
                }
                this._author = value;
            }
        }
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                if (value.Length < boundaryLength)
                {
                    throw new ArgumentException(errorMessageTitle);
                }
                this._title = value;
            }
        }     
        public virtual double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (value <= price)
                {
                    throw new ArgumentException(errorMessagePrice);
                }
                this._price = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name)
                .Append(Environment.NewLine)
                .Append("Title: ").Append(this.Title)
                .Append(Environment.NewLine)
                .Append("Author: ").Append(this.Author)
                .Append(Environment.NewLine)
                .Append(String.Format("Price: {0:F1}$", this.Price));
            return sb.ToString().Trim();
        }
    }
}   