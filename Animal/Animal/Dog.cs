using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    public class Dog : Animals
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }
        public override string ProduceSount()
        {
            return "Woof";
        }
    }
}
