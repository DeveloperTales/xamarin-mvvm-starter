using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MVVMStarter.Core.ViewModels;

namespace MVVMStarter.Views
{
    [MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "Contacts")]
    public partial class TodoItemsPage : MvxContentPage<TodoItemsViewModel>
    {
        public TodoItemsPage()
        {
            InitializeComponent();
        }
    }
}
