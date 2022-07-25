using System;
using System.Collections.Generic;
using System.Text;

namespace Deneme2
{
    public static class Constract
    {
        public static System.Collections.ObjectModel.ObservableCollection<Models.MyListModel> PersonList { get; set; }
        public static bool IsIlkGiris { get; set; } = false;
    }
}
