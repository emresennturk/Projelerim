using Deneme2.Models;
using Deneme2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Deneme2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MylistPage : ContentPage
    {
        public MylistPage()
        {
            InitializeComponent();          
            BindingContext = new MyListPageViewModel();
        }
        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as MyListModel;
            await Navigation.PushAsync(new MyListPageDetail(TransactionMode.Update , mydetails));
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchBarr.Text;
           
            MainListView.ItemsSource = Constract.PersonList.Where(name => name.Name.ToLower().Contains(keyword.ToLower()) || name.Surname.ToLower().Contains(keyword.ToLower()) || name.Age.ToLower().Contains(keyword.ToLower()));
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {          
            await Navigation.PushAsync(new MyListPageDetail(TransactionMode.Insert));
        }
    }
}