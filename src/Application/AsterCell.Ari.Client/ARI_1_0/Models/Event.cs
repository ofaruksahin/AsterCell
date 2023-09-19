using System.Text.Json;

namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    /// <summary>
    /// Base type for asynchronous events from Asterisk.
    /// </summary>
    public class Event : Message
    {
        /// <summary>
        /// Name of the application receiving the event.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Time at which this event was created.
        /// </summary>
        public DateTime Timestamp { get; set; }

        protected string ToString(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
