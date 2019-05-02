using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(Name);
            output.Append(", ");
            output.Append(SellIn);
            output.Append(", ");
            output.Append(Quality);
                
            return output.ToString();
        }
    }

   
}
