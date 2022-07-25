using Deneme2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Deneme2.ViewModel
{
    public class MyListPageViewModel
    {
       
        public ObservableCollection<MyListModel> PersonList { get; set; }

        public MyListModel SelectedUser { get; set; }

        


        public MyListPageViewModel()
        {
            
            if(Constract.IsIlkGiris == false)
            {
                Constract.PersonList = new ObservableCollection<MyListModel>();
                Constract.PersonList.Add(item: new MyListModel { Name = " Emre ",  Surname = " Şentürk ", Age = " 21 " });
                Constract.PersonList.Add(item: new MyListModel { Name = " Burak",  Surname = " Kayacı ",  Age = " 20 " });
                Constract.PersonList.Add(item: new MyListModel { Name = " Tolga",  Surname = " Yılmaz ",  Age = " 22 " });
                Constract.PersonList.Add(item: new MyListModel { Name = " Enes ",  Surname = " Dicel ",   Age = " 20 "});
                Constract.IsIlkGiris = true;
            }
            PersonList = Constract.PersonList;
        }  
       
        
    }
}
