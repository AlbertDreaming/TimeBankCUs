using SQLite;

namespace TimeBankCU.Models
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public int PublisherId { get; set; }

        public string PublisherName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}