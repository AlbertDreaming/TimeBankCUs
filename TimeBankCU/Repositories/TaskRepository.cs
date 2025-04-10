using TimeBankCU.Models;
using SQLite;

namespace TimeBankCU.Repositories
{
    public class TaskRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public TaskRepository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public Task<List<TaskItem>> GetAllAsync() =>
            _db.Table<TaskItem>().OrderByDescending(t => t.CreatedAt).ToListAsync();

        public Task<int> InsertAsync(TaskItem task) =>
            _db.InsertAsync(task);

        public Task<int> UpdateAsync(TaskItem task) =>
            _db.UpdateAsync(task);

        public Task<int> DeleteAsync(TaskItem task) =>
            _db.DeleteAsync(task);
    }
}