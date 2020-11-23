using System;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            VisionExpress visionexpress2 = new VisionExpress();
            GlassesBuilder glassesbuilder2 = new MultifocalBuilder();
            visionexpress2.constructGlasses(glassesbuilder2);
            glassesbuilder2.Glasses.Display();
            Console.WriteLine(); //pusty wiersz
            GlassProduct testglass = new GlassProduct(glassesbuilder2.Glasses);
            var testuv = new UVFilter();
            testglass.AddElement(testuv);
            var testrims = new RedRims();
            glassesbuilder2.Glasses.Rims = testrims.Name;
            glassesbuilder2.Glasses.RimsPrice = testrims.Price;
            glassesbuilder2.Glasses.Price += testuv.Price;
            
            //dupa.ShowList();
            testglass.AddToGlasses(glassesbuilder2.Glasses);
            glassesbuilder2.Glasses.Display();
        }
    }
}
