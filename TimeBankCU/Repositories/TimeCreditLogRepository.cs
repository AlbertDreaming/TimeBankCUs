using SQLite;
using TimeBankCU.Models;

namespace TimeBankCU.Repositories
{
    public class TimeCreditLogRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public TimeCreditLogRepository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public Task<List<TimeCreditLog>> GetLogsForUserAsync(int userId) =>
            _db.Table<TimeCreditLog>().Where(log => log.UserId == userId)
                .OrderByDescending(log => log.Timestamp).ToListAsync();

        public Task<int> InsertAsync(TimeCreditLog log) => _db.InsertAsync(log);
    }
}