using SQLite;
using TimeBankCU.Models;

namespace TimeBankCU.Repositories
{
    public class TaskParticipantRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public TaskParticipantRepository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public Task<List<TaskParticipant>> GetByTaskIdAsync(int taskId) =>
            _db.Table<TaskParticipant>().Where(p => p.TaskId == taskId).ToListAsync();

        public Task<List<TaskParticipant>> GetByUserIdAsync(int userId) =>
            _db.Table<TaskParticipant>().Where(p => p.UserId == userId).ToListAsync();

        public Task<int> InsertAsync(TaskParticipant participant) =>
            _db.InsertAsync(participant);
    }
}