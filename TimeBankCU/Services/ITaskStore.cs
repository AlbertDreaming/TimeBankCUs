namespace TimeBankCU.Services;

using System.Collections.ObjectModel;
using TimeBankCU.Models;

public interface ITaskStore
{
    ObservableCollection<TaskItem> Tasks { get; }
    void Add(TaskItem item);
}
