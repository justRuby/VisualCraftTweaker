using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VisualCraftTweaker.Enums;
using VisualCraftTweaker.Models;

namespace VisualCraftTweaker.CUIElements
{
    /// <summary>
    /// Логика взаимодействия для RecipeBlock.xaml
    /// </summary>
    public partial class RecipeBlock : UserControl
    {
        public RecipeType RecipeType { get; private set; }
        public object MRecipe { get; private set; }

        public RecipeBlock()
        {
            InitializeComponent();
        }

        public RecipeBlock(object recipe, RecipeType recipeType, Action<object, int, RecipeType> onClick, Action<object, int, RecipeType> onDoubleClick)
        {
            InitializeComponent();

            this.RecipeType = recipeType;
            this.MRecipe = recipe;

            dynamic obj = MRecipe;
            
            Recipe.Click += (s, e) => { onClick(s, GetId, RecipeType); };
            Recipe.MouseDoubleClick += (s, e) => { onDoubleClick(s, GetId, RecipeType); };
        }


        #region Getter/Setter

        public int GetId
        {
            get { return (MRecipe as dynamic).Id; }
        }

        #endregion

    }
}
