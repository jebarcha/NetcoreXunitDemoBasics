using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Calculations
    {
        public List<int> FiboList => new List<int> { 1, 1, 2, 3, 5, 8, 13 };

        public bool IsOdd(int value)
        {
            return (value % 2) == 1;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
        public double AddDouble(double a, double b)
        {
            return a + b;
        }
    }
}
