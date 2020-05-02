using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologDBGenerator
{
    class Value
    {
        static protected Random Random;
        public List<double> Treshholds;
        public Value(List<double> tresh)
        {
            Treshholds = tresh;
            Treshholds.Add(100);
            if(Random == null)
                Random = new Random();

        }

        public int GetValue()
        {
            double val = Random.NextDouble() * 100;
            int i = 0;

            for(; i < Treshholds.Count; i++)
            {
                if (val < Treshholds[i])
                    break;
            }

            return i;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Treshholds.Count; i++)
            {
                result += Treshholds[i];
                if (i != Treshholds.Count - 1)
                    result += ",";
            }
            return result;
        }
    }
}
