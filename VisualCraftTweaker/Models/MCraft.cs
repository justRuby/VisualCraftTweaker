using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VisualCraftTweaker.Models
{
    public class MCraft : INotifyPropertyChanged
    {
        private string _modName;

        public string ModName
        {
            get { return _modName; }
            set { _modName = value; OnPropertyChanged("ModName"); }
        }

        private string _itemType;

        public string ItemType
        {
            get { return _itemType; }
            set { _itemType = value; OnPropertyChanged("ItemType"); }
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public bool IsCreated { get; private set; }

        public MCraft() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

            if (!IsCreated)
                IsCreated = true;
        }
    }
}
