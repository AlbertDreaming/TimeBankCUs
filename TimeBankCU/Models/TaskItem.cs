namespace TimeBankCU.Models
{
    public class TaskItem
    {
        public required string PublisherName { get; set; }
        public required string PublisherEmail { get; set; }
        public required string TaskType { get; set; }
        public required string Rating { get; set; }
        public required string Reward { get; set; }
        public required string Participants { get; set; }

        // 如果有默认构造函数，请确保在其中初始化所有required属性
        public TaskItem()
        {
            PublisherName = string.Empty;
            PublisherEmail = string.Empty;
            TaskType = string.Empty;
            Rating = string.Empty;
            Reward = string.Empty;
            Participants = string.Empty;
        }
    }
}