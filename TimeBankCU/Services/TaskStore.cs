using TimeBankCU.Models;
using System.Collections.ObjectModel;

namespace TimeBankCU.Services;

public class TaskStore : ITaskStore
{
    public ObservableCollection<TaskItem> Tasks { get; } = new();

    public void Add(TaskItem item)
    {
        Tasks.Add(item);
    }
}
