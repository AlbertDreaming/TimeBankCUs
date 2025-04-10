using SQLite;
using TimeBankCU.Models;

namespace TimeBankCU.Repositories
{
    public class UserRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public UserRepository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        // 获取全部用户列表
        public Task<List<User>> GetAllAsync() =>
            _db.Table<User>().ToListAsync();

        // 根据邮箱查找用户，返回可能为 null 的结果
        public Task<User?> GetByEmailAsync(string email) =>
            _db.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();

        // 插入新用户
        public Task<int> InsertAsync(User user) =>
            _db.InsertAsync(user);

        // 更新已有用户
        public Task<int> UpdateAsync(User user) =>
            _db.UpdateAsync(user);

        // 删除用户
        public Task<int> DeleteAsync(User user) =>
            _db.DeleteAsync(user);
    }
}