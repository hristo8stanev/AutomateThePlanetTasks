const errorMessagePrice = "Price not valid";
const errorMessageTitleLength = "Title is not valid";
const length = 3;
const errorMessageAuthor = "Author not valid!";

class Book {
    constructor(title,author,price) {
        this.title = title
        this.author = author
        this.price = price
        }
        
        get title(){
            return this._title;
        }
        
        set title(value) {
        
            if (value.length < length ) { 
          throw new Error (errorMessageTitleLength)
            }
            this._title = value;
        }
        
        get author(){
            return this._author;
        }
        
        set author(value) {
            if (/\d/.test(value.split(' ').pop())) {
                throw new Error(errorMessageAuthor);
            }
            this._author = value;
        }
        
        get price(){
            return this._price;
        }
        
        set price(value) {
        
            if (value < 0 || value === 0 || isNaN(value) ) {
                throw new Error(errorMessagePrice);
            }
            this._price = value
        }
        toString() {
            return `Title: ${this.title}\n
            Author: ${this.author}\n
            Price: ${this.price.toFixed(1)}`;
        }
    }

class GoldenEditionBook extends Book{
    constructor(title,author,price){
        super(title,author,price * 1.3)
    }
}

const book = new Book("Aster Alex", "Thief", 13.99)
console.log(book.toString());

var goldenBook = new GoldenEditionBook("Stephen King", "IT", 13.99);
console.log(goldenBook.toString());