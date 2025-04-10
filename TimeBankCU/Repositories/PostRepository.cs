using SQLite;
using TimeBankCU.Models;

namespace TimeBankCU.Repositories
{
    public class PostRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public PostRepository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public Task<List<Post>> GetAllAsync() =>
            _db.Table<Post>().OrderByDescending(p => p.CreatedAt).ToListAsync();

        public Task<int> InsertAsync(Post post) => _db.InsertAsync(post);
        public Task<int> UpdateAsync(Post post) => _db.UpdateAsync(post);
        public Task<int> DeleteAsync(Post post) => _db.DeleteAsync(post);
    }
}