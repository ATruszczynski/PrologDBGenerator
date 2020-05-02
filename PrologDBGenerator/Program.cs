using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologDBGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mat = Parser.GetMatrix(@"C:\Users\aleks\Desktop\ilness.csv");
            PrologFileGenerator.GeneratePrologFile(mat, 10, seed: 1001);
        }
    }
}
