using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Notification that a channel has been created.
    /// </summary>
    public class ChannelCreatedEvent : Event
    {
        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Channel { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
