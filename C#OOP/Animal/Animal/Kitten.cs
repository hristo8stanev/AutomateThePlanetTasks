using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal;
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender)
        : base(name, age, gender)
        {
        }

        public override string ProduceSount()
        {

            return "Meow Meow";
    }
}
