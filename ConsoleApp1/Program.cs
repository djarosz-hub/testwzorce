using System;
using System.IO;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VisionExpress visionexpress2 = new VisionExpress();
            GlassesBuilder glassesbuilder2 = new MultifocalBuilder();
            visionexpress2.ConstructGlasses(glassesbuilder2);
            glassesbuilder2.Glasses.Display();
            Console.WriteLine(); //pusty wiersz
            GlassProduct testglass = new GlassProduct();
            var testuv = new Filters(FiltersEnum.UV);
            testglass.AddElement(testuv);
            var testDefect = new DefectValue(10, -10);
            testglass.AddElement(testDefect);
            var testrims = new Rims(RimTypesEnum.Gucci);
            glassesbuilder2.Glasses.Rims = testrims.Name;
            glassesbuilder2.Glasses.RimsPrice = testrims.Price;
            glassesbuilder2.Glasses.Price += testuv.Price;
            glassesbuilder2.Glasses.Price += testDefect.Price;

            //dupa.ShowList();
            testglass.AddToGlasses(glassesbuilder2.Glasses);
            glassesbuilder2.Glasses.Display();
            string path = @"Test.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Orders:");
                    sw.WriteLine("-------------");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("typ:" + glassesbuilder2.Glasses._type);
                sw.WriteLine("lenses:" + glassesbuilder2.Glasses.Lenses);
                sw.WriteLine("lenses price:" + glassesbuilder2.Glasses.LensesPrice);
                sw.WriteLine("Rims:" + glassesbuilder2.Glasses.Rims);
                sw.WriteLine("Rims price:" + glassesbuilder2.Glasses.RimsPrice);
                foreach (IComposite el in glassesbuilder2.Glasses.AdditionList)
                {
                    sw.WriteLine(el.Name + " " + el.Price);
                }
                sw.WriteLine("Total price:" + (glassesbuilder2.Glasses.LensesPrice + glassesbuilder2.Glasses.RimsPrice + glassesbuilder2.Glasses.Price));
                sw.WriteLine("-------------");

            }
        }
    }
}
