// Aliases Func<AppQuery, AppQuery> with Query
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MVVMStarter.UITests.Pages
{
    public class TodoItemPage : BasePage
    {
        private readonly Query _todoItemMainLayout;                

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TodoItemLayout"),
            iOS = x => x.Marked("TodoItemLayout")
        };

        public TodoItemPage()
        {
            _todoItemMainLayout = x => x.Marked("TodoItemLayout");
        }

        public bool VerifyPageLoaded()
        {
            if (WaitForMusicMessageToPageLoad() != null)
            {
                return true;
            }

            return false;
        }

        public TodoItemPage WaitForMusicMessageToPageLoad()
        {
            app.WaitForElement(_todoItemMainLayout);
            app.Screenshot("TodoItem Page");

            return this;
        }        
    }
}
