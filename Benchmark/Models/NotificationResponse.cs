using System.ComponentModel.DataAnnotations.Schema;

namespace Benchmark.Models
{
    public class NotificationResponse : EntityBase
    {
        #region Properties..
        public Guid NotificationResponseId { get; set; }

        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }

        public string Text { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public string Locale { get; set; }

        #region Shadow..
        [NotMapped]
        public List<UsersToNotification> UsersToNotification { get; set; }
        #endregion Shadow..
        #endregion Properties..
    }
}
