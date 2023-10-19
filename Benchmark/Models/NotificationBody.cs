namespace Benchmark.Models
{
    public class NotificationBody : EntityBase
    {
        #region Properties..
        public Guid NotificationBodyId { get; set; }

        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }

        public string Text { get; set; }
        public string Color { get; set; }
        public string Locale { get; set; }
        #endregion Properties..
    }
}
