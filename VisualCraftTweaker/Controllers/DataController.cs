using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VisualCraftTweaker.Models;

namespace VisualCraftTweaker.Controllers
{
    public class DataController : INotifyPropertyChanged
    {
        #region Visibility

        private Visibility _ticketVisibility;

        public Visibility TicketVisibility
        {
            get { return _ticketVisibility; }
            set { _ticketVisibility = value; OnPropertyChanged("TicketVisibility"); }
        }

        private Visibility _recipeVisibility;

        public Visibility RecipeVisibility
        {
            get { return _recipeVisibility; }
            set { _recipeVisibility = value; OnPropertyChanged("RecipeVisibility"); }
        }

        private Visibility _craftVisibility;

        public Visibility CraftVisibility
        {
            get { return _craftVisibility; }
            set { _craftVisibility = value; OnPropertyChanged("CraftVisibility"); }
        }
        #endregion

        #region Data

        private MTicket _mTicket;

        public MTicket MTicket
        {
            get { return _mTicket; }
            set { _mTicket = value; OnPropertyChanged("MTicket"); }
        }

        private object _mRecipe;

        public object MRecipe
        {
            get { return _mRecipe; }
            set { _mRecipe = value; OnPropertyChanged("MRecipe"); }
        } 
            
        #endregion

        public DataController()
        {
            TicketVisibility = Visibility.Visible;
            RecipeVisibility = Visibility.Hidden;
            CraftVisibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
