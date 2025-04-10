using SQLite;
using TimeBankCU.Models;

namespace TimeBankCU.Services
{
    // ✅ 数据库连接类
    public class AppDatabase
    {
        public SQLiteAsyncConnection Connection { get; }

        public AppDatabase(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<User>().Wait();
            Connection.CreateTableAsync<TaskItem>().Wait();
            // 可扩展更多表格初始化
        }
    }

    // ✅ 用户数据访问类（仓储）
    public class UserRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public UserRepository(AppDatabase db)
        {
            _db = db.Connection;
        }

        public Task<List<User>> GetAllAsync() => _db.Table<User>().ToListAsync();

        public Task<User?> GetByEmailAsync(string email) =>
            _db.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync()!;
    }

    // ✅ 登录业务逻辑类（示例）
    public class AuthService
    {
        private readonly UserRepository _repo;

        public AuthService(UserRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> LoginAsync(string email) =>
            await _repo.GetByEmailAsync(email) is not null;
    }
}