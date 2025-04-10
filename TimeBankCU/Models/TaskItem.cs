using System.Windows.Input;
using SQLite;

namespace TimeBankCU.Models
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        
        public string PublisherName { get; set; } = string.Empty;
        public string PublisherEmail { get; set; } = string.Empty;

        
        public string TaskType { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;

        
        public string Reward { get; set; } = string.Empty;
        public string Participants { get; set; } = string.Empty;
        public string TaskDetails { get; set; } = string.Empty;

        // UI 展示扩展
        public string ImageUrl { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Campus { get; set; } = string.Empty;

        // 评论/点赞（用于文章或展示）
        public string Likes { get; set; } = "0";
        public string Comments { get; set; } = "0";

        // 状态字段、时间
        public string Status { get; set; } = "待认领";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // 不保存至数据库的 UI 逻辑命令
        [Ignore]
        public ICommand TalkCommand { get; set; }

        // 构造函数
        public TaskItem(ICommand talkCommand)
        {
            TalkCommand = talkCommand;
        }

        public TaskItem()
        {
            TalkCommand = new Command(() => { });
        }
    }
}