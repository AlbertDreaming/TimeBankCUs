using SQLite;

namespace TimeBankCU.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public float TimeCredits { get; set; } = 0;

        public DateTime RegisteredAt { get; set; } = DateTime.Now;
    }
}