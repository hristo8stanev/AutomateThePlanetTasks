namespace StoringData;
    public class Child : Person
    {
        private string errorMessageChildAge => "Child's age must be less than or equal to 15!";
        private int childBoundaryAge => 15;

        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > childBoundaryAge)
                {
                    throw new ArgumentException(errorMessageChildAge);
                }

                base.Age = value;
        }
    }
}