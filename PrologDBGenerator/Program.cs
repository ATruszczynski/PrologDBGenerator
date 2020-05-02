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
            var mat = Parser.GetSDMatrix(@"C:\Users\aleks\Desktop\ilness.csv");
            var mat2 = Parser.GetDOMatrix(@"C:\Users\aleks\Desktop\diagnoses.csv");
            PrologFileGenerator.GeneratePrologFile(mat, mat2, 50, seed: 1001);
        }
    }
}
