﻿namespace StoringData;
    public class Person : IEquatable<Person>, IComparable<Person>
    {
        private string errorMessageAge => "Age must be a positive number!";
        private int age => 0;
        private static int nextId = 1;
        public int Id { get; }
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            Id = nextId++;
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return this._name; }
            protected set { this._name = value; }
        }

        public virtual int Age
        {
            get { return _age; }
            set
            {
                if (value < age)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), errorMessageAge);
                }

                _age = value;
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {_name}, Age: {_age}";
        }

        public bool Equals(Person value)
        {
            if (value is null) return false;
            return Id == value.Id;
        }

       public int CompareTo(Person other)
       {

           return Age.CompareTo(other.Age);
       }
    }