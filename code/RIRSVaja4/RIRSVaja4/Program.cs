using System;
using System.IO;
using System.Linq;

namespace RIRSVaja4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Prvih koliko vrstic želite obdelati? ");
            var isNumber = int.TryParse(Console.ReadLine(), out var numberOfLines);
            if (!isNumber)
            {
                Environment.Exit(0);
            }

            var path = @"C:\temp\DURS_zavezanci_PO.txt";
            var lines = File.ReadAllLines(path).ToList();


            var parser = new Parser();

            // registracija opazovalcev
            new RacunalniskaDejavnostObserver(parser);
            new MariborskoPodjetjeObserver(parser);
            //new VrstaZavezancaObserver(parser);
            //new ZavezanostZaDDVObserver(parser);
            new DavcnaStevilkaObserver(parser);
            new MaticnaStevilkaObserver(parser);

            int vrstica = 1;
            foreach (var zavezanec in lines.Select((line, index) => new Zavezanec()
            {
                Vrstica = vrstica++,
                VrstaZavezanca = line.Substring(0, 1).Trim(),
                ZavezanostZaDDV = line.Substring(2, 1).Trim(),
                DavcnaStevilka = line.Substring(4, 8).Trim(),
                MaticnaStevilka = line.Substring(13, 10).Trim(),
                DatumRegistracije = line.Substring(24, 10).Trim(),
                SifraDejavnosti = line.Substring(35, 6).Trim(),
                ImeZavezanca = line.Substring(42, 100).Trim(),
                NaslovZavezanca = line.Substring(143, 113).Trim(),
                FinancniUrad = line.Substring(257, 2).Trim(),
            }))
            {
                parser.PodatkiPrebrani(zavezanec);

                if (string.IsNullOrWhiteSpace(zavezanec.DavcnaStevilka) ||
                    string.IsNullOrWhiteSpace(zavezanec.MaticnaStevilka) ||
                    string.IsNullOrWhiteSpace(zavezanec.DatumRegistracije) ||
                    string.IsNullOrWhiteSpace(zavezanec.SifraDejavnosti) ||
                    string.IsNullOrWhiteSpace(zavezanec.ImeZavezanca) ||
                    string.IsNullOrWhiteSpace(zavezanec.NaslovZavezanca) ||
                    string.IsNullOrWhiteSpace(zavezanec.FinancniUrad)
                )
                {
                    parser.NaletelNaNapako(zavezanec.Vrstica.ToString());
                }
                else
                {
                    Console.WriteLine();
                }

                if (vrstica == numberOfLines)
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}