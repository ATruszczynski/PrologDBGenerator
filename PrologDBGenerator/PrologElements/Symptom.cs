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
        
        public Symptom(int id, SymptomDiagnosisMatrix sdm, Diagnosis d)
        {
            Id = id;
            SymptomsDegree = new Dictionary<SymptomEnum, int>();
            GenerateSymptoms(sdm, d);
        }

        void GenerateSymptoms(SymptomDiagnosisMatrix sdm, Diagnosis d)
        {
            
        }

        public string GetPrologFact()
        {
            throw new NotImplementedException();
        }
    }
}
