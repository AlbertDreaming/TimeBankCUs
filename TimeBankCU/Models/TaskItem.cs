namespace TimeBankCU.Models
{
    public class TaskItem
    {
        public string PublisherName { get; set; } = string.Empty;
        public string PublisherEmail { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Reward { get; set; } = string.Empty;
        public string Participants { get; set; } = string.Empty;
        
        public string TaskDetails { get; set; }  = string.Empty;
        // 添加新的属性以匹配绑定
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}