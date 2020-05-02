using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrologDBGenerator.PrologElements;
using static PrologDBGenerator.PrologElements.SymptomEnum;
using static PrologDBGenerator.PrologElements.DiagnosisEnum;

namespace PrologDBGenerator
{
    class Parser
    {
        public static Dictionary<string, SymptomEnum> dict = new Dictionary<string, SymptomEnum>
        {
            {"katar", Katar },
            {"kaszel", Kaszel },
            {"slabosc", Slabosc },
            {"bol_gardla", Bol_gardla },
            {"goraczka", Goraczka },
            {"dreszcze", Dreszcze },
            {"bol_glowy", Bol_glowy },
            {"bol_miesni", Bol_miesni },
            {"drgawki", Drgawki },
            {"bol_w_klatce", Bol_w_klatce },
            {"trudnosci_odd", Trudnosc_w_oddychaniu },
            {"krwioplucie", Krwioplucie }
         };
        public static Dictionary<string, DiagnosisEnum> diagnosisDict = new Dictionary<string, DiagnosisEnum>
        {
            {"alergia", Alergia },
            {"astma", Astma },
            {"przeziebienie", Przeziebienie },
            {"angina", Angina },
            {"grypa", Grypa },
            {"zapalenie_oskrzeli", Zapalenie_oskrzeli },
            {"zapalenie_pluc", Zapalenie_pluc }
         };
        public static SymptomDiagnosisMatrix GetSDMatrix(string file)
        {
            var matrix = new SymptomDiagnosisMatrix();

            StreamReader sr = new StreamReader(file);

            var headerLine = sr.ReadLine();

            Dictionary<int, SymptomEnum> trans = new Dictionary<int, SymptomEnum>();

            string[] separ = headerLine.Split(',');

            for (int i = 1; i < separ.Length; i++)
            {
                trans.Add(i, dict[separ[i]]);
            }

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                separ = line.Split(',');
                DiagnosisEnum ie = diagnosisDict[separ[0]];
                var symDic = new Dictionary<SymptomEnum, Value>();

                for (int i = 1; i < separ.Length; i++)
                {
                    string[] values = separ[i].Split(';');
                    List<double> vals = new List<double>();
                    for (int jj = 0; jj < values.Length; jj++)
                    {
                        vals.Add(double.Parse(values[jj]));
                    }
                    symDic.Add(trans[i], new Value(vals));
                }

                matrix.matrix.Add(ie, symDic);

            }

            return matrix;
        }

        public static DiagnosisOverlapMatrix GetDOMatrix(string file)
        {
            var matrix = new DiagnosisOverlapMatrix();

            StreamReader sr = new StreamReader(file);

            var headerLine = sr.ReadLine();

            Dictionary<int, DiagnosisEnum> trans = new Dictionary<int, DiagnosisEnum>();

            string[] separ = headerLine.Split(',');

            for (int i = 1; i < separ.Length; i++)
            {
                trans.Add(i, diagnosisDict[separ[i]]);
            }

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                separ = line.Split(',');
                DiagnosisEnum mainDiag = diagnosisDict[separ[0]];
                var symDic = new Dictionary<DiagnosisEnum, Value>();

                for (int i = 1; i < separ.Length; i++)
                {
                    string[] values = separ[i].Split(';');
                    List<double> vals = new List<double>();
                    for (int jj = 0; jj < values.Length; jj++)
                    {
                        vals.Add(double.Parse(values[jj]));
                    }
                    symDic.Add(trans[i], new Value(vals));
                }

                matrix.matrix.Add(mainDiag, symDic);
            }

            return matrix;
        }
    }
}
