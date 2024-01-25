using System.Text;

namespace Books
{
 public class Book
    {
        private const string errorMessageTitle = "Title is not valid!";
        private const string errorMessagePrice = "Price not valid!";
        private string _author;
        private string _title;
        private double _price;

        public Book(String _author, String _title,double _price)
        {
            this.SetAuthor(_author);
            this.SetPrice(_price);
            this.SetTitle(_title);
        }
        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                this.Author = value;

            }
        }
        public void SetAuthor(string author)
        {
            this._author = author;
        }
        public string Title 
        {
            get 
            {
                return this._title;
            }
            set
            {
                if (this.Title.Length < 3)
                {
                    throw new ArgumentException(errorMessageTitle);
                    }
                this.Title = value;
            }
        }
        private void SetTitle(string title)
        {
            this._title = title;
        }
        public virtual double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (_price <= 9)
                {
                    throw new ArgumentException(errorMessagePrice);
                }
                this._price = value;
            }
        }
        private void SetPrice(double price)
        {
            this._price = price;
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