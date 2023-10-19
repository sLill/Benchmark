namespace Benchmark.Models
{
    public class UsersToNotification_Acknowledged : EntityBase
    {
        #region Properties..
        public Guid UsersToNotification_AcknowledgedId { get; set; }

        public int UsersId { get; set; }

        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }

        public Guid? NotificationResponseId { get; set; }
        public NotificationResponse? NotificationResponse { get; set; }

        public DateTimeOffset? AcknowledgedOnUtc { get; set; }
        public DateTimeOffset? Cash360_SentOnUtc { get; set; }
        public DateTimeOffset? Koyus_SentOnUtc { get; set; }
        #endregion Properties..
    }
}
