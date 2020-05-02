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
        public static string DignosisName = "diagnoza";

        public static List<DiagnosisEnum> IllList = new List<DiagnosisEnum>()
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
            for (int i = 0; i < IllList.Count; i++)
            {
                DiagnosisDegree[IllList[i]] = degrees[i];
            }
        }

        public string GetPrologFact()
        {
            throw new NotImplementedException();
        }
    }
}
