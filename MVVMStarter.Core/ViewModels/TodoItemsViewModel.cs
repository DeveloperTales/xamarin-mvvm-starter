using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MVVMStarter.Core.Models;
using MVVMStarter.Core.Services;
namespace MVVMStarter.Core.ViewModels
{
    public class TodoItemsViewModel : MvxNavigationViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IApiService _apiService;

        public TodoItemsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IApiService apiService)
            : base(logProvider, navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;

            Items = new MvxObservableCollection<TodoItem>();

            ItemSelectedCommand = new MvxAsyncCommand<TodoItem>(ItemSelected);
            RefreshItemsCommand = new MvxAsyncCommand(RefreshItems);
            NewItemCommand = new MvxAsyncCommand(NewContact);
        }
        
        public override Task Initialize()
        {
            LoadItemsTask = MvxNotifyTask.Create(LoadItems);

            return Task.FromResult(0);
        }

        // MVVM Properties
        public MvxNotifyTask LoadItemsTask { get; private set; }

        private MvxObservableCollection<TodoItem> _items;
        public MvxObservableCollection<TodoItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        // MVVM Commands
        public IMvxCommand<TodoItem> ItemSelectedCommand { get; private set; }

        public IMvxCommand RefreshItemsCommand { get; private set; }

        public IMvxCommand NewItemCommand { get; private set; }

        // Private methods
        private async Task LoadItems()
        {
            var result = await _apiService.GetTodoItemsAsync();
            Items.Clear();
            Items.AddRange(result);
        }

        private async Task ItemSelected(TodoItem item)
        {
            var result = await NavigationService.Navigate<TodoItemViewModel, TodoItem, TodoItemResult>(item);
            if (result != null && result.Updated)
            {
                var updatedList = Items.ToList();
                var updatedTodoItem = updatedList.Where(todoItem => todoItem.Id == result.Item.Id).FirstOrDefault();
                updatedTodoItem.Title = result.Item.Title;
                updatedTodoItem.Notes = result.Item.Notes;
                updatedTodoItem.Done = result.Item.Done;
                Items.Clear();
                Items.AddRange(updatedList);
            }
            else if (result != null && result.Deleted)
            {
                Items.Remove(result.Item);
            }
        }

        private async Task NewContact()
        {
            var result = await NavigationService.Navigate<TodoItemViewModel, TodoItem, TodoItemResult>(new TodoItem());
            if (result != null && result.Updated)
            {
                Items.Add(result.Item);
            }
        }

        private async Task RefreshItems()
        {
            await LoadItems();
        }
    }
}
