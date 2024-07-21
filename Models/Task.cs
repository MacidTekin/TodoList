namespace TodoList.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; } = string.Empty;
        
        public bool Status { get; set; }

        public DateTime Deadline { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; } 

    }

}