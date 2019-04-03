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
using VisualCraftTweaker.Controllers;
using VisualCraftTweaker.Core;
using VisualCraftTweaker.CUIElements;

using VisualCraftTweaker.Enums;
using VisualCraftTweaker.Models;

namespace VisualCraftTweaker.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private DataController dataController;
        //private List<TicketBlock> TicketBlockList;

        private List<MTicket> TicketList;
        private Dictionary<RecipeType, List<object>> RecipeDictionary;

        private int _ticketId, _recipeId;

        public Main()
        {
            InitializeComponent();

            TicketList = new List<MTicket>();
            RecipeDictionary = new Dictionary<RecipeType, List<object>>();

            dataController = new DataController();

            this.DataContext = dataController;

            _ticketId = 0;
            _recipeId = 0;
        }

        #region Ticket 

        private object _preTicket;
        private int _preTicketId;

        private void OnTicketClick(object sender, int id)
        { 
            if (_preTicket != null)
                (_preTicket as Button).BorderBrush = null;

            (sender as Button).BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

            _preTicket = sender;
            _preTicketId = id;

            dataController.MTicket = TicketList.Where(x => x.Id == id).SingleOrDefault();
        }

        private void OnTicketDoubleClick(object sender, int id)
        {
            var tempTicket = TicketList.Where(x => x.Id == id).SingleOrDefault();

            if (tempTicket != null)
            {
                RecipeDictionary = tempTicket.RecipeDictionary;
                ViewRecipes();

                dataController.TicketVisibility = Visibility.Hidden;
                dataController.RecipeVisibility = Visibility.Visible;
            }
        }

        private void AddTicketBlock(object sender, EventArgs e)
        {
            var tempMTicket = new MTicket(_ticketId++);
            var tempTicket = new TicketBlock(tempMTicket, OnTicketClick, OnTicketDoubleClick);

            TicketList.Add(tempMTicket);
            TicketBlockViewer.Children.Add(tempTicket);
        }

        private void RemoveTicketBlock(object sender, EventArgs e)
        {
            if (_preTicket == null)
            {
                MessageBox.Show("Выберите скрипт");
            }
            else
            {
                var temp = TicketList.Where(x => x.Id == _preTicketId).SingleOrDefault();

                if (temp != null)
                {
                    TicketList.Remove(temp);

                    var tempBlock = TicketBlockViewer.Children.Cast<TicketBlock>().Where(x => x.MTicket.Id == _preTicketId).SingleOrDefault();
                    TicketBlockViewer.Children.Remove(tempBlock);

                    _preTicket = null;
                }
            }
        }

        #endregion

        #region Recipe

        private object _preRecipeBlock;
        private int _preRecipeId;
        private RecipeType _preRecipeType;

        private void ViewRecipes()
        {
            foreach (var typeName in Enum.GetNames(typeof(RecipeType)))
            {
                RecipeType tempType = (RecipeType)Enum.Parse(typeof(RecipeType), typeName);

                if (!RecipeDictionary.ContainsKey(tempType))
                    continue;

                if (RecipeDictionary[tempType] == null)
                    continue;

                foreach (var recipe in RecipeDictionary[tempType])
                {
                    RecipeBlock recipeBlock = new RecipeBlock(recipe, tempType, OnRecipeClick, OnRecipeDoubleClick);
                    RecipeBlockViewer.Children.Add(recipeBlock);
                }
            }
        }

        private void AddShapedRecipe(object sender, EventArgs e)
        {
            if (!RecipeDictionary.ContainsKey(RecipeType.Shaped))
                RecipeDictionary.Add(RecipeType.Shaped, new List<object>());

            var tempShapedRecipe = new MShapedRecipe(_recipeId);
            var tempShapedRecipeBlock = new RecipeBlock(tempShapedRecipe, RecipeType.Shaped, OnRecipeClick, OnRecipeDoubleClick);

            _recipeId++;

            RecipeDictionary[RecipeType.Shaped].Add(tempShapedRecipe);

            RecipeBlockViewer.Children.Add(tempShapedRecipeBlock);
        }

        private void DeleteRecipe(object sender, EventArgs e)
        {
            if (_preRecipeBlock == null)
            {
                MessageBox.Show("Выберите рецепт");
            }
            else
            {
                var tempObj = RecipeDictionary[_preRecipeType].Where(x => (x as dynamic).Id == _preRecipeId).SingleOrDefault();

                if (tempObj != null)
                {
                    RecipeDictionary[_preRecipeType].Remove(tempObj);

                    var tempRecipeBlock = RecipeBlockViewer.Children.Cast<RecipeBlock>().Where(x => (x.MRecipe as dynamic).Id == _preRecipeId).SingleOrDefault();
                    RecipeBlockViewer.Children.Remove(tempRecipeBlock);

                    _preRecipeBlock = null;
                }
            }
        }

        private void OnRecipeClick(object sender, int id, RecipeType recipeType)
        {
            if (_preRecipeBlock != null)
                (_preRecipeBlock as Button).BorderBrush = null;

            (sender as Button).BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

            _preRecipeBlock = sender;
            _preRecipeId = id;
            _preRecipeType = recipeType;

            dataController.MRecipe = RecipeDictionary[_preRecipeType].Where(x => (x as dynamic).Id == _preRecipeId).SingleOrDefault();
        }

        private void OnRecipeDoubleClick(object sender, int id, RecipeType recipeType)
        {

        }

        private void BackToTicketsClick(object sender, EventArgs e)
        {
            RecipeBlockViewer.Children.Clear();

            dataController.TicketVisibility = Visibility.Visible;
            dataController.RecipeVisibility = Visibility.Hidden;
        }

        #endregion

    }
}
