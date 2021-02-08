// Aliases Func<AppQuery, AppQuery> with Query
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MVVMStarter.UITests.Pages
{
    public class TodoItemsPage : BasePage
    {
        private readonly Query _todoItemLayout;
        private readonly Query _todoItemLastLayout;
        private readonly Query _todoItemFirstLayout;
        private readonly Query _titles;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TodoItemsListView"),
            iOS = x => x.Marked("TodoItemsListView")
        };

        public TodoItemsPage()
        {
            _todoItemLayout = x => x.Marked("TodoItemListViewLayout").Child(0);
            _todoItemLastLayout = x => x.Marked("TodoItemListViewLayout")
            .Child(app.Query(q => q.Marked("TodoItemsListView").Child()).Length - 1);
            _titles = x => x.Marked("TodoItemsListTitle");
            _todoItemFirstLayout = x => x.Marked("TodoItemsListView").Child(0);
        }

        public TodoItemsPage WaitForTodoItemsPageToLoad()
        {
            app.WaitForElement(_todoItemLayout);
            app.Screenshot("TodoItems Page");

            return this;
        }

        public AppResult[] ListTitles
        {
            get
            {
                app.WaitForElement(_titles);

                return app.Query(_titles);
            }
        }

        public TodoItemPage SelectFirstElement()
        {
            app.WaitForElement(_todoItemFirstLayout);
            app.Tap(_todoItemFirstLayout);
            return new TodoItemPage();
        }

        public TodoItemsPage ScrollToLastElement()
        {
            app.ScrollDownTo(_todoItemLastLayout);
            app.WaitForElement(_todoItemLastLayout);

            return this;
        }

        public TodoItemPage SelectLastElement()
        {
            app.WaitForElement(_todoItemLastLayout);
            app.Screenshot("TodoItems Last element");
            app.Tap(_todoItemLastLayout);

            return new TodoItemPage();
        }
    }
}
