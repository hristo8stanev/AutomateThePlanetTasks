using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal;
    public class Cat : Animals
    {
        public Cat(string name, int age, Genders gender) :
            base(name, age, gender)
        {
        }

        public override string ProduceSount()
        {

            return "MEOW";
        }
}
