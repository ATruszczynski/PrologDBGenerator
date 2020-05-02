using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrologDBGenerator.PrologElements;
using static PrologDBGenerator.PrologElements.SymptomEnum;
using static PrologDBGenerator.PrologElements.DiagnosisEnum;
using static System.Math;
using System.IO;

namespace PrologDBGenerator
{
    class PrologFileGenerator
    {
        static Value SeverityOfMainDiagnosis = new Value(new List<double>() { 0, 0, 30 });
        //static Dictionary<int, string> painScale = new Dictionary<int, string>()
        //{
        //    { 0, "brak" },
        //    { 1, "lekki" },
        //    { 2, "silny" },
        //    { 3, "bardzo_silny" }
        //};

        //static Dictionary<int, string> feverScale = new Dictionary<int, string>()
        //{
        //    { 0, "brak" },
        //    { 1, "stan_podgorączkowy" },
        //    { 2, "gorączka" },
        //    { 3, "hiperpyreksja" }
        //};

        //static Dictionary<int, string> binaryScale = new Dictionary<int, string>()
        //{
        //    { 0, "nie" },
        //    { 1, "tak" }
        //};

        //static Dictionary<SymptomEnum, Dictionary<int, string>> scaleDict = new Dictionary<SymptomEnum, Dictionary<int, string>>()
        //{
        //    { Katar, binaryScale },
        //    { Kaszel, binaryScale },
        //    { Slabosc, binaryScale },
        //    { Bol_gardla, painScale },
        //    { Goraczka, feverScale },
        //    { Dreszcze, binaryScale },
        //    { Bol_glowy, painScale },
        //    { Bol_miesni, painScale },
        //    { Drgawki, binaryScale },
        //    { Bol_w_klatce, painScale },
        //    { Trudnosc_w_oddychaniu, binaryScale },
        //    { Krwioplucie, binaryScale },
        //};

        //static Dictionary<int, string> diagnosisScale = new Dictionary<int, string>()
        //{
        //    {0, "bardzo_niskie" },
        //    {1, "niskie" },
        //    {2, "wysokie" },
        //    {3, "bardzo_wysokie" }
        //};

        //static List<SymptomEnum> SymList = new List<SymptomEnum>()
        //{
        //    Katar,
        //    Kaszel,
        //    Slabosc,
        //    Bol_gardla,
        //    Goraczka,
        //    Dreszcze,
        //    Bol_glowy,
        //    Bol_miesni,
        //    Drgawki,
        //    Bol_w_klatce,
        //    Trudnosc_w_oddychaniu,
        //    Krwioplucie
        //};

        //static List<DiagnosisEnum> IllList = new List<DiagnosisEnum>()
        //{
        //    Alergia,
        //    Astma,
        //    Przeziebienie,
        //    Angina,
        //    Grypa,
        //    Zapalenie_oskrzeli,
        //    Zapalenie_pluc
        //};

        static Random random;

        public static void GeneratePrologFile(SymptomDiagnosisMatrix sdMatrix, DiagnosisOverlapMatrix doMatrix, int amount, string path = "res.pl", int? seed = null)
        {
            random = new Random();
            if (seed != null)
             random = new Random(seed.Value);
            var matrix = sdMatrix.matrix;

            string prologContent = $"{Diagnosis.PrologComment}{Environment.NewLine}{Diagnosis.PrologDeclatarion}{Environment.NewLine}{Symptom.PrologComment}{Environment.NewLine}{Symptom.PrologDeclatarion}{Environment.NewLine}";

            for (int i = 0; i < amount; i++)
            {
                DiagnosisEnum mainDiag = Diagnosis.DiagnosisList[random.Next(Diagnosis.DiagnosisList.Count)];
                var diagnosis = GetDiagnosis(i, mainDiag, doMatrix);

                var symptoms = GetSymptoms(i, sdMatrix, diagnosis);

                prologContent += diagnosis.GetPrologFact() + $"%{mainDiag.ToString()}" + Environment.NewLine + symptoms.GetPrologFact() + Environment.NewLine;

                prologContent += Environment.NewLine;

                //prologContent += "diagnoza(";

                //int ill = random.Next(0, IllList.Count);
                //DiagnosisEnum illness = IllList[ill];

                //string[] diagns = new string[7];
                //for (int jj = 0; jj < diagns.Length; jj++)
                //{
                //    diagns[jj] = diagnosisScale[0];
                //}

                //for (int sick = Max(0, ill-1); sick < Min(IllList.Count, ill+2) ; sick++)
                //{
                //    diagns[sick] = diagnosisScale[2];
                //}

                //diagns[ill] = diagnosisScale[3];

                //for (int s = 0; s < SymList.Count; s++)
                //{
                //    var val = matrix[illness][SymList[s]];
                //    var scale = scaleDict[SymList[s]];
                //    int ff = val.GetValue();
                //    prologContent += scale[ff] + ",";
                //}

                //for (int l = 0; l < IllList.Count; l++)
                //{
                //    prologContent += diagns[l];
                //    if (l != IllList.Count-1)
                //        prologContent += ",";
                //}
                //prologContent += ")." + Environment.NewLine;
            }

            StreamWriter sw = new StreamWriter(path);
            sw.Write(prologContent);
            sw.Flush();
            sw.Close();
        }

        static Diagnosis GetDiagnosis(int id, DiagnosisEnum mainDiagnosis, DiagnosisOverlapMatrix dom)
        {
            var overlapDict = dom.matrix[mainDiagnosis];
            List<int> degrees = new List<int>();

            for (int i = 0; i < Diagnosis.DiagnosisList.Count; i++)
            {
                var diag = Diagnosis.DiagnosisList[i];
                if (diag != mainDiagnosis)
                    degrees.Add(overlapDict[diag].GetValue());
                else
                    degrees.Add(SeverityOfMainDiagnosis.GetValue());
            }

            return new Diagnosis(id, degrees);
        }

        static Symptom GetSymptoms(int id, SymptomDiagnosisMatrix sdm, Diagnosis d)
        {
            int rep = random.Next(1,6);

            int totalSum = 0;

            List<Dictionary<SymptomEnum, Value>> ddd = new List<Dictionary<SymptomEnum, Value>>();
            foreach (var item in d.DiagnosisDegree)
            {
                DiagnosisEnum de = item.Key;
                int repMul = item.Value + 1;

                int degree = item.Value;
                for (int i = 0; i < repMul*rep; i++)
                {
                    ddd.Add(sdm.matrix[de]);
                    totalSum ++;
                }
            }

            Dictionary<SymptomEnum, double> symDegrees = new Dictionary<SymptomEnum, double>();
            for (int i = 0; i < Symptom.SymList.Count; i++)
            {
                symDegrees.Add(Symptom.SymList[i],0);
            }

            foreach (var item in ddd)
            {
                var symDict = item;
                foreach (var sym in symDict)
                {
                    symDegrees[sym.Key] += sym.Value.GetValue();
                }
            }

            List<int> degrees = new List<int>();

            for (int i = 0; i < Symptom.SymList.Count; i++)
            {
                symDegrees[Symptom.SymList[i]] /= totalSum;
                degrees.Add((int)Round(symDegrees[Symptom.SymList[i]]));
            }

            return new Symptom(id, degrees);
        }
    }
}
