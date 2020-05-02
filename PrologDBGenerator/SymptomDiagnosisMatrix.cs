using PrologDBGenerator.PrologElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologDBGenerator
{
    class SymptomDiagnosisMatrix
    {
        public Dictionary<DiagnosisEnum, Dictionary<SymptomEnum,Value>> matrix;

        public SymptomDiagnosisMatrix()
        {
            matrix = new Dictionary<DiagnosisEnum, Dictionary<SymptomEnum, Value>>();
        }
    }
}
