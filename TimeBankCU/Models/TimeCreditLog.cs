using SQLite;

namespace TimeBankCU.Models
{
    public class TimeCreditLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public float Amount { get; set; }

        public string Type { get; set; }  

        public string Note { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}