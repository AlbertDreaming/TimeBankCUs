using SQLite;

namespace TimeBankCU.Models
{
    public class TaskParticipant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int UserId { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.Now;
    }
}