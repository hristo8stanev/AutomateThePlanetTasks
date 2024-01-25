using System.Text;

namespace Books;
 public class Book
    {
        private  string errorMessageTitle => "Title is not valid!";
        private  string errorMessagePrice => "Price not valid!";
        private  int boundaryLength => 3;
        private  int price => 0;
        private  string errorMessageAuthor = "Author not valid!";
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
  
        return $"Type: {GetType().Name}{Environment.NewLine}" +
            $"Title: {Title}{Environment.NewLine}" +
            $"Author: {Author}{Environment.NewLine}" +
            $"Price: {Price:F1}$";
        }
    }   