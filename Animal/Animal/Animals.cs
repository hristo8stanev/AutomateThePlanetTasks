using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    public class Animals
    {
        private const string invalidInputMessage = "Invalid input";
        private const int age = 0;
        private const string maleGender = "Male";
        private const string femaleGender = "Female";
        private string _name;
        private int _age;
        private string _gender;
        public Animals(string name, int age, string gender)
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
        public virtual string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                if (value == maleGender || value == femaleGender)
                {
                    this._gender = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), invalidInputMessage);
                }
            }
        }
        public virtual string ProduceSount()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSount());
            return sb.ToString().Trim();
        }
    }
}