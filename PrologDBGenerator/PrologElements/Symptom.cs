using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrologDBGenerator.PrologElements.SymptomEnum;
using static PrologDBGenerator.PrologElements.DiagnosisEnum;

namespace PrologDBGenerator.PrologElements
{
    class Symptom
    {
        public static string SymptomName = "symptomy";
        public static string PrologDeclatarion = $":- dynamic {SymptomName}/13.";
        public static string PrologComment = $"%{SymptomName}(id, katar,kaszel,slabosc,bol gardla, goraczka, dreszcze, bol glowy, bol miesni, drgawki, bol w klatece, trudnosc w oddychaniu, krwioplucie)";

        public static List<SymptomEnum> SymList = new List<SymptomEnum>()
        {
            Katar,
            Kaszel,
            Slabosc,
            Bol_gardla,
            Goraczka,
            Dreszcze,
            Bol_glowy,
            Bol_miesni,
            Drgawki,
            Bol_w_klatce,
            Trudnosc_w_oddychaniu,
            Krwioplucie
        };

        public static Dictionary<int, string> painScale = new Dictionary<int, string>()
        {
            { 0, "brak" },
            { 1, "lekki" },
            { 2, "silny" },
            { 3, "bardzo_silny" }
        };

        public static Dictionary<int, string> feverScale = new Dictionary<int, string>()
        {
            { 0, "brak" },
            { 1, "stan_podgorączkowy" },
            { 2, "gorączka" },
            { 3, "hiperpyreksja" }
        };

        public static Dictionary<int, string> binaryScale = new Dictionary<int, string>()
        {
            { 0, "nie" },
            { 1, "tak" }
        };

        public static Dictionary<SymptomEnum, Dictionary<int, string>> scaleDict = new Dictionary<SymptomEnum, Dictionary<int, string>>()
        {
            { Katar, binaryScale },
            { Kaszel, binaryScale },
            { Slabosc, binaryScale },
            { Bol_gardla, painScale },
            { Goraczka, feverScale },
            { Dreszcze, binaryScale },
            { Bol_glowy, painScale },
            { Bol_miesni, painScale },
            { Drgawki, binaryScale },
            { Bol_w_klatce, painScale },
            { Trudnosc_w_oddychaniu, binaryScale },
            { Krwioplucie, binaryScale },
        };

        public int Id { get; set; }

        Dictionary<SymptomEnum,int> SymptomsDegree;
        
        public Symptom(int id, List<int> degrees)
        {
            Id = id;
            SymptomsDegree = new Dictionary<SymptomEnum, int>();
            for (int i = 0; i < SymList.Count; i++)
            {
                SymptomsDegree[SymList[i]] = degrees[i];
            }
        }

        public string GetPrologFact()
        {
            string result = PrologComment + Environment.NewLine + SymptomName + $"({Id},";

            for (int i = 0; i < SymList.Count; i++)
            {
                var scale = scaleDict[SymList[i]];
                result += $"{scale[SymptomsDegree[SymList[i]]]}";
                if (i != SymList.Count - 1)
                    result += ",";
            }

            result += ").";
            return result;
        }
    }
}
