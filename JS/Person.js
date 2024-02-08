const errorMessageAge = "Age must be a positive number!";
const childBoundary = "Child's age must be less than or equal to 15!";
const maxChildAge = 15;

class Person {

    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        this._name = value;
    }

    get age() {
        return this._age;
    }

    set age(value) {
        if (value < 0 || isNaN(value)) {
            throw new Error(errorMessageAge);
        }
        this._age = value;
    }
}


class Child extends Person {
    constructor(name, age) {
        super(name, age);
    }

    set age(value) {
        if (value < 0 || value > maxChildAge || isNaN(value)) {
            throw new Error(childBoundary);
        }
        this._age = value;
    }
}

var person = new Person('Ivan', 17);
console.log(person);
var child = new Child("Michael", 14);
console.log(child);
