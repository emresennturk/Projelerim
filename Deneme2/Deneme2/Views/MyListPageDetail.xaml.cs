using Deneme2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Deneme2.Views
{    
    public partial class MyListPageDetail : ContentPage
    {
        TransactionMode _mode;
        public MyListPageDetail(TransactionMode mode, MyListModel user = null)
        {
            InitializeComponent();
            Button1.Text = mode == TransactionMode.Insert ? "Ekle" : "Güncelle";
            _mode = mode;

            BindingContext = mode == TransactionMode.Insert ? new ViewModel.MyListPageViewModel() : 
            new ViewModel.MyListPageViewModel
            {
                SelectedUser = user               
            };
            
        }
        private async void Button1_Clicked(object sender, EventArgs e)
        {
            if (_mode == TransactionMode.Insert)
            {
                Constract.PersonList.Add(new MyListModel() { Age = MyItemAgeShow.Text, Name = MyItemNameShow.Text, Surname = MyItemSurnameShow.Text });
            }
            await Navigation.PushAsync(new MylistPage());            
        }
    }

    public enum TransactionMode
    {
        Insert,
        Update
    }
}