public class TaskScheduler<TTask, TPriority>
{
    public delegate void TaskExecution(TTask task);

    private readonly List<TaskItem> _tasks = new List<TaskItem>();
    private readonly List<TTask> _completedTasks = new List<TTask>();
    private readonly TaskExecution _execution;
    private readonly Comparison<TPriority> _priorityComparison;

    public TaskScheduler(TaskExecution execution, Comparison<TPriority> priorityComparison)
    {
        _execution = execution;
        _priorityComparison = priorityComparison;
    }

    public void AddTask(TTask task, TPriority priority)
    {
        var taskItem = new TaskItem(task, priority);

        int index = 0;
        while (index < _tasks.Count && _priorityComparison(priority, _tasks[index].Priority) > 0)
        {
            index++;
        }

        _tasks.Insert(index, taskItem);
    }

    public void ExecuteNext()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks to execute.");
            return;
        }

        var nextTask = _tasks[0].Task;
        _tasks.RemoveAt(0);
        _completedTasks.Add(nextTask);

        _execution(nextTask);

        Console.WriteLine($"Task executed: {nextTask}");
    }

    public void ViewCurrentTasks()
    {
        Console.WriteLine("Current Tasks:");
        foreach (var taskItem in _tasks)
        {
            Console.WriteLine($"Task: {taskItem.Task}, Priority: {taskItem.Priority}");
        }
    }

    public void ViewCompletedTasks()
    {
        Console.WriteLine("Completed Tasks:");
        foreach (var completedTask in _completedTasks)
        {
            Console.WriteLine($"Task: {completedTask}");
        }
    }

    public int TasksCount => _tasks.Count;

    public void ReturnTask(TTask task, TPriority priority)
    {
        AddTask(task, priority);
    }

    private class TaskItem
    {
        public TTask Task;
        public TPriority Priority;

        public TaskItem(TTask task, TPriority priority)
        {
            Task = task;
            Priority = priority;
        }
    }
}