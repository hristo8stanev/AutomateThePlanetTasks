using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Animal;
    public class Animals
    {
        private string invalidInputMessage => "Invalid input";
        private int age => 0;
       
       public enum Genders
       {
        Male,
        Female
       };

    private string _name;
    private int _age;
    private Genders _gender;

    public Animals(string name, int age, Genders gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
    }

    

    public virtual string Name
        {
            get
            {
                return this._name;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(invalidInputMessage);
                }

                this._name = value;
            }
        }

        public virtual int Age
        {
            get { return _age; }
            set
            {
                if (value <= age)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), invalidInputMessage);
                }

                _age = value;
            }
    }

    public virtual Genders Gender
    {
        get { return _gender; }
        set { _gender = value; }
    }


    public virtual string ProduceSount()
        {
            return string.Empty;
    }

    public override string ToString()
    {

        return $"Type: {GetType().Name}{Environment.NewLine}" +
            $"{Name} {Age} {Gender}{Environment.NewLine}" +
            $"{ProduceSount()}";
    }
}

