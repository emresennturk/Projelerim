using Deneme2.Models;
using Deneme2.ViewModel;
using System;

using Xamarin.Forms;


namespace Deneme2.Views
{
    public partial class MyListPageDetail : ContentPage
    {
        
        public MyListPageDetail(TransactionMode mode, MyListModel user = null)
        {
            InitializeComponent();
          
            BindingContext = new MyListDetailPageViewModel()
            {
                SelectedUser = mode == TransactionMode.Insert ? new MyListModel(): user,
                Mode = mode
            };
           
            
        }
       
    }

    
}