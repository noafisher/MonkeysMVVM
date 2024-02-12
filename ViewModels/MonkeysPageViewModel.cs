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
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public ICommand LoadMonkeyCommand { get; private set; }


        public MonkeysPageViewModel()
        {
           Monkeys = new ObservableCollection<Monkey>();
           LoadMonkeyCommand = new Command(LoadMonkeys);

        }

        private void LoadMonkeys()
        {
           MonkeysService monkeysService = new MonkeysService();
            var list = monkeysService.GetMonkeys();
            for (int i = 0; i < list.Count; i++)
            {
                Monkeys.Add(list[i]);
            }
        }
    }
}
