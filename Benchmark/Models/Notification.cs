using System.ComponentModel.DataAnnotations.Schema;

namespace Benchmark.Models
{
    public class Notification : EntityBase
    {
        #region Properties..
        public Guid NotificationId { get; set; }

        public string Source { get; set; }
        public string SourceId { get; set; }

        public string Name { get; set; }
        public bool ResponseRequired { get; set; }
        public int? DisplayTimeSeconds { get; set; }
        public string? QrCode { get; set; }
        public DateTimeOffset DeliveredDateUtc { get; set; }
        public DateTimeOffset? ExpirationDateUtc { get; set; }

        public List<NotificationTitle> NotificationTitles { get; set; }
        public List<NotificationBody> NotificationBodies { get; set; }
        public List<NotificationResponse> NotificationResponses { get; set; }

        #region Shadow..
        [NotMapped]
        public List<UsersToNotification> UsersToNotification { get; set; }
        #endregion Shadow..
        #endregion Properties..
    }
}
