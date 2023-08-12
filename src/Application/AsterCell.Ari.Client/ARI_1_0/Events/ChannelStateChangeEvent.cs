using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Notification of a channel's state change.
    /// </summary>
    public class ChannelStateChangeEvent : Event
    {
        /// <summary>
        /// no description provided
        /// </summary>
        public Channel Channel { get; set; }
    }
}
