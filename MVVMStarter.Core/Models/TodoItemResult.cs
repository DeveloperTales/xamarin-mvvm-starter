namespace MVVMStarter.Core.Models
{
    public class TodoItemResult
    {
        public TodoItem Item { get; set; }
        public bool Updated { get; set; }
        public bool Deleted { get; set; }
    }
}
