namespace Benchmark.Models
{
    public class NotificationTitle : EntityBase
    {
        #region Properties..
        public Guid NotificationTitleId { get; set; }

        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }

        public string Text { get; set; }
        public string Locale { get; set; }
        #endregion Properties..
    }
}
