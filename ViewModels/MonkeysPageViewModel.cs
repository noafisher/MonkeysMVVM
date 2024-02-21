using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class MonkeysPageViewModel: ViewModel
    {
        private Monkey selectedMonkey;

        private bool isRefreshing;
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public ICommand LoadMonkeyCommand { get; private set; }
        public ICommand GoToMonkeysPageCommand {  get; private set; }
        public ICommand DeleteMonkeyCommand {  get; private set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public Monkey SelectedMonkey { get => selectedMonkey; set { selectedMonkey = value; OnPropertyChanged(); ((Command)GoToMonkeysPageCommand).ChangeCanExecute(); } }
        public MonkeysPageViewModel()
        {
           Monkeys = new ObservableCollection<Monkey>();
           LoadMonkeyCommand = new Command(LoadMonkeys);
           DeleteMonkeyCommand = new Command(DeleteMonkey);
           GoToMonkeysPageCommand = new Command(GoToMonkeysPage,()=>SelectedMonkey!=null);


        }

        private async void GoToMonkeysPage()
        {
           bool answer= await AppShell.Current.DisplayAlert("Show Monkey", "Ugly Monkey Are You Sure You want to see it?", "Yes", "No");
            if(answer) 
            {
                Dictionary<string,object> navData= new Dictionary<string,object>();
                navData.Add("Monkey", SelectedMonkey);
                await AppShell.Current.GoToAsync($"ShowMonkey?Title={SelectedMonkey.Name}",navData);
            }
        }

        private void DeleteMonkey( object delete)
        {

          Monkeys.Remove((Monkey)delete);
        }

        private void LoadMonkeys()
        {
            IsRefreshing = true;
            MonkeysService monkeysService = new MonkeysService();
            var list = monkeysService.GetMonkeys();
            Monkeys.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Monkeys.Add(list[i]);
            }
                IsRefreshing = false; 
        }
    }
}
