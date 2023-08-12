using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Notification that a channel has left a Stasis application.
    /// </summary>
    public class StasisEndEvent : Event
    {
        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Channel { get; set; }
    }
}
