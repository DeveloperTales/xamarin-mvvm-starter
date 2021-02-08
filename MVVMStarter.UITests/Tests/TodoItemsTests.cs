using MVVMStarter.UITests.Pages;
using NUnit.Framework;
using Xamarin.UITest;

namespace MVVMStarter.UITests.Tests
{
    public class TodoItemsTests : BaseTestFixture
    {
        public TodoItemsTests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void TestTodoItemsLoaded()
        {
            // Arrange
            var todoItemsPage = new TodoItemsPage();

            // Act
            var todoItems = todoItemsPage.WaitForTodoItemsPageToLoad();
            var titles = todoItems.ListTitles;

            // Assert
            Assert.True(titles.Length > 0);
            Assert.False(string.IsNullOrWhiteSpace(titles[0].Text));
        }

        [Test]
        public void TestSelectFirstMusicMessage()
        {
            // Arrange
            var todoItemsPage = new TodoItemsPage();

            // Act
            var todoItems = todoItemsPage.WaitForTodoItemsPageToLoad();
            var todoItem = todoItems.SelectFirstElement();

            // Assert
            Assert.True(todoItem.VerifyPageLoaded());
        }

        [Test]
        public void TestSelectLastMusicMessage()
        {
            // Arrange
            var todoItemsPage = new TodoItemsPage();

            // Act
            var todoItems = todoItemsPage.WaitForTodoItemsPageToLoad();
            todoItems.ScrollToLastElement();
            var todoItem = todoItems.SelectLastElement();

            // Assert
            Assert.True(todoItem.VerifyPageLoaded());
        }
    }
}
