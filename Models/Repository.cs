namespace TodoList.Models
{
    public class Repository
    {
        private static readonly List<Task> _tasks = new();

        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _tasks.Add(new Task{TaskId = 1, TaskName = "Task 1", Status=true, Deadline = new DateTime(2024,7,23)});
            _tasks.Add(new Task{TaskId = 2, TaskName = "Task 2", Status=false, Deadline = new DateTime(2024,9,24)});
            _tasks.Add(new Task{TaskId = 3, TaskName = "Task 3", Status=false, Deadline = new DateTime(2024,8,25)});
            _tasks.Add(new Task{TaskId = 4, TaskName = "Task 4", Status=true, Deadline = new DateTime(2024,10,26)});

            _categories.Add(new Category{CategoryId = 1, Name ="Biten",CategoryStatus = true});
            _categories.Add(new Category{CategoryId = 2, Name ="Bekleyen",CategoryStatus = false});
            
        }

        public static List<Task> Tasks
        {
            get
            {
                return _tasks;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public static void DeleteTask(Task deletedTask)
        {
            var entity = _tasks.FirstOrDefault(t => t.TaskId == deletedTask.TaskId);
            if(entity != null){
                _tasks.Remove(entity);
            }
            
        }
    }
}