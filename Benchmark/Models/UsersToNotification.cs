namespace Benchmark.Models
{
    public class UsersToNotification : EntityBase
    {
        #region Properties..
        public Guid UsersToNotificationId { get; set; }

        public int UsersId { get; set; }

        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }
        #endregion Properties..
    }
}
