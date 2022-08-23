using Deneme2.Models;
using Deneme2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
using Windows.System;

namespace Deneme2.ViewModel
{
    public class MyListDetailPageViewModel : BaseViewModel
    {
      
        #region Properties

        public MyListModel SelectedUser { get; set; }      

        private TransactionMode _Mode;
        public TransactionMode Mode
        {
            get { return _Mode; }
            set 
            { 
                _Mode = value; 
                OnPropertyChanged(nameof(Mode)); 
                OnPropertyChanged(nameof(ButtonText)); 
            }
        }        

        public string ButtonText => Mode == TransactionMode.Insert ? "Ekle" : "Güncelle";     


        #endregion

        public MyListDetailPageViewModel()
        {            
        }

        #region commands

        public ICommand SelectCommand 
        {
            get
            {
                return new Command(async () =>
                {
                    if (Mode == TransactionMode.Insert)
                    {
                        SelectedUser.Id = Constract.PersonList.Count() + 1;
                        Constract.PersonList.Add(SelectedUser);
                    }

                    else
                    {
                        var item = Constract.PersonList.FirstOrDefault(x => x.Id == SelectedUser.Id);
                        if (item != null)
                            item = SelectedUser;
                    }

                    await App.Current.MainPage.Navigation.PushAsync(new MyListPage(TransactionMode.Insert));
                });
            } 
        }
        #endregion
        

    }
    public enum TransactionMode
    {
        Insert,
        Update
    }


}
