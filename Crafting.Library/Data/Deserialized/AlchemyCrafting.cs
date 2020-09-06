using System.Collections.Generic;

namespace Crafting.Library.Data.Deserialized
{
    public class AlchemyCrafting
    {
        public Recipe Recipe { get; set; }
        public Dictionary<Reagent,int> Reagents { get; set; }
    }
}
