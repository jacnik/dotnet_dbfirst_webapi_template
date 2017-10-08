using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTemplate.SpecFlow
{
    public class Calculator
    {
        private List<int> operands = new List<int>();
        private int result = 0;

        public int EnterNumber(int number)
        {
            operands.Add(number);
            return number;
        }

        public int PressAdd()
        {
            result = operands.Sum();
            operands.Clear();
            operands.Add(result);
            return result;
        }

        public int GetResult()
        {
            return result;
        }
    }
}
