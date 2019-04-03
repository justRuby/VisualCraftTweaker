using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using VisualCraftTweaker.Models.Base;

namespace VisualCraftTweaker.Models
{
    public class MShapedRecipe : MRecipe
    {
        public MCraft[] MCraftGrid { get; private set; }
        public MCraft MCraftResult { get; private set; }

        public MShapedRecipe(int id)
        {
            MCraftGrid = new MCraft[9];

            for (int i = 0; i < 9; i++)
            {
                MCraftGrid[i] = new MCraft();
            }

            this.Id = id;

            MCraftResult = new MCraft();
        }
    }
}
