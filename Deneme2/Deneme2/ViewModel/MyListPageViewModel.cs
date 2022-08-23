using Deneme2.Models;
using Deneme2.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using static Deneme2.ViewModel.MyListDetailPageViewModel;

namespace Deneme2.ViewModel
{
    public class MyListPageViewModel : BaseViewModel
    {

        public MyListModel SelectedUser { get; set; }


        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MyListModel> _PersonList;
        public ObservableCollection<MyListModel> PersonList
        {
            get { return _PersonList; }
            set
            {
                _PersonList = value;
                OnPropertyChanged();
            }
        }


        public MyListPageViewModel()
        {

            if (Constract.IsIlkGiris == false)
            {
                Constract.PersonList = new ObservableCollection<MyListModel>();
                Constract.PersonList.Add(item: new MyListModel { Name = " Emre ", Surname = " Şentürk ", Age = " 21 ", Homeland = "Ordu", School = "Bilgisayar Programcılığı", Id = 0 });
                Constract.PersonList.Add(item: new MyListModel { Name = " Burak", Surname = " Kayacı ", Age = " 20 ", Homeland = "Rize", School = "Uluslar Arası Ticaret", Id = 1 });
                Constract.PersonList.Add(item: new MyListModel { Name = " Tolga", Surname = " Yılmaz ", Age = " 22 ", Homeland = "Rize", School = "Gastronomi", Id = 2 });
                Constract.PersonList.Add(item: new MyListModel { Name = " Enes ", Surname = " Dicel ", Age = " 20 ", Homeland = "Giresun", School = "Anestezi", Id = 3 });
                Constract.IsIlkGiris = true;
            }
            PersonList = Constract.PersonList;
        }

        #region Commands


        public ICommand ItemTappedCommand
        {
            get
            {
                return new Command<MyListModel>(async (item) =>
                {
                    if (item == null)
                        return;

                    await App.Current.MainPage.Navigation.PushAsync(new MyListPageDetail(TransactionMode.Update, item));
                });
            }
        }

        public ICommand AddUserCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new MyListPageDetail(TransactionMode.Insert));
                });
            }
        }
        public ICommand SearchCommand => new Command(() =>
        {
            var searchedList = Constract.PersonList.Where(name => name.Name.ToLower().Contains(SearchText.ToLower()) || name.Surname.ToLower().Contains(SearchText.ToLower()) || name.Age.ToLower().Contains(SearchText.ToLower()) || name.Homeland.ToLower().Contains(SearchText.ToLower()) || name.School.ToLower().Contains(SearchText.ToLower()));
            PersonList = new ObservableCollection<MyListModel>(searchedList);
        });

        
        #endregion



    }
}
