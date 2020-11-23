using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class RedRims : IComposite
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public RedRims()
        {
            Name = "Red rims";
            Price = 500;
        }
        public void AddElement(IComposite el)
        {
        }
    }
}
