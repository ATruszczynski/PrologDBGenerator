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

        public static void GeneratePrologFile(SymptomDiagnosisMatrix mmatrix, int amount, string path = "res.pl", int? seed = null)
        {
            Random random = new Random();
            if (seed != null)
             random = new Random(seed.Value);
            var matrix = mmatrix.matrix;

            string prologContent = "%diagnoza(katar,kaszel,slabosc,bol_gardla,goraczka,dreszcze,bol_glowy,bol_miesni,drgawki,bol_w_klatce,trudnosc_w_oddychaniu,krwioplucie,alergia,astma,przeziebienie,angina,grypa,zapalenie_oskrzeli,zapalenie_pluc)" + Environment.NewLine +
                ":- diagnoza/19";

            for (int i = 0; i < amount; i++)
            {
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
    }
}
