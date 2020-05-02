using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrologDBGenerator.PrologElements.DiagnosisEnum;

namespace PrologDBGenerator.PrologElements
{
    class Diagnosis
    {
        public static string DiagnosisName = "diagnoza";
        public static string PrologDeclatarion = $":- dynamic {DiagnosisName}/8.";
        public static string PrologComment = $"%{DiagnosisName}(id,alergia,astma,przeziebienie,angina,grypa,zapalenie oskrzeli, zapalenie pluc)";

        public static List<DiagnosisEnum> DiagnosisList = new List<DiagnosisEnum>()
        {
            Alergia,
            Astma,
            Przeziebienie,
            Angina,
            Grypa,
            Zapalenie_oskrzeli,
            Zapalenie_pluc
        };

        public static Dictionary<int, string> diagnosisScale = new Dictionary<int, string>()
        {
            {0, "bardzo_niskie" },
            {1, "niskie" },
            {2, "wysokie" },
            {3, "bardzo_wysokie" }
        };

        public Dictionary<DiagnosisEnum, int> DiagnosisDegree;

        public int Id { get; set; }

        public Diagnosis(int id, List<int> degrees)
        {
            Id = id;
            DiagnosisDegree = new Dictionary<DiagnosisEnum, int>();
            for (int i = 0; i < DiagnosisList.Count; i++)
            {
                DiagnosisDegree[DiagnosisList[i]] = degrees[i];
            }
        }

        public string GetPrologFact()
        {
            string result = PrologComment + Environment.NewLine + DiagnosisName + $"({Id},";

            for (int i = 0; i < DiagnosisList.Count; i++)
            {
                result += $"{diagnosisScale[DiagnosisDegree[DiagnosisList[i]]]}";
                if (i != DiagnosisList.Count - 1)
                    result += ",";
            }

            result += ").";
            return result;
        }
    }
}
