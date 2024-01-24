namespace StoringData
{
    public class Person : IEquatable<Person>, IComparable<Person>
    {

        private static int nextId = 1;
        public int Id { get; }
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            Id = nextId++;
            _name = name;
            Age = age;
        }

        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public virtual int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age must be a positive number!");
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
}