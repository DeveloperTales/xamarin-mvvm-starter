using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MVVMStarter.Core.ViewModels;

namespace MVVMStarter.Views
{
    // If opening from login add NoHistory = true
    [MvxTabbedPagePresentation(TabbedPosition.Root)]
    public partial class HomeTabbedPage : MvxTabbedPage<HomeTabbedViewModel>
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
        }

        private bool _firstTime = true;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstTime)
            {
                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);
                _firstTime = false;
            }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }
    }
}
