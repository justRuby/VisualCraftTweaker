using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCraftTweaker.Enums;

namespace VisualCraftTweaker.Models
{
    public class MTicket
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public Dictionary<RecipeType, List<object>> RecipeDictionary { get; private set; }

        public MTicket() { }
        public MTicket(int id)
        {
            Id = id;

            RecipeDictionary = new Dictionary<RecipeType, List<object>>();
        }
    }
}
