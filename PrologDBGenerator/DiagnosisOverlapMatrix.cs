using PrologDBGenerator.PrologElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologDBGenerator
{
    class DiagnosisOverlapMatrix
    {
        public Dictionary<DiagnosisEnum, Dictionary<DiagnosisEnum, Value>> matrix;

        public DiagnosisOverlapMatrix()
        {
            matrix = new Dictionary<DiagnosisEnum, Dictionary<DiagnosisEnum, Value>>();
        }

        public Value this[DiagnosisEnum d1, DiagnosisEnum d2]
        {
            get { return matrix[d1][d2]; }
        }


    }
}
