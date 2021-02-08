using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MVVMStarter.Core.Models;
using MVVMStarter.Core.Services;

namespace MVVMStarter.Core.ViewModels
{
    public class TodoItemViewModel : MvxViewModel<TodoItem, TodoItemResult>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IApiService _apiService;

        public TodoItemViewModel(IMvxNavigationService navigationService, IApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;

            SaveItemCommand = new MvxAsyncCommand(SaveItem);
            DeleteItemCommand = new MvxAsyncCommand(DeleteItem);
            CancelItemCommand = new MvxCommand(CancelItem);
        }

        public override void Prepare(TodoItem parameter)
        {
            Item = parameter;
        }

        private TodoItem _item;
        public TodoItem Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                RaisePropertyChanged(() => Item);
            }
        }

        // MVVM Commands
        public IMvxCommand SaveItemCommand { get; private set; }

        public IMvxCommand DeleteItemCommand { get; private set; }

        public IMvxCommand CancelItemCommand { get; private set; }

        // Private Methods
        private async Task SaveItem()
        {
            if (await _apiService.SaveItemAsync(Item))
            {
                await _navigationService.Close(this, new TodoItemResult
                {
                    Item = Item,
                    Updated = true
                });
            }            
        }

        private async Task DeleteItem()
        {
            if(await _apiService.DeleteItemAsync(Item))
            {
                await _navigationService.Close(this, new TodoItemResult
                {
                    Item = Item,
                    Deleted = true
                });
            }            
        }

        async void CancelItem()
        {
            await _navigationService.Close(this, new TodoItemResult());
        }
    }
}
