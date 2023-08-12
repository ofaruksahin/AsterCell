using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Talking was detected on the channel.
    /// </summary>
    public class ChannelTalkingStartedEvent : Event
    {
        /// <summary>
        /// The channel on which talking started.
        /// </summary>
        public Channel Channel { get; set; }
    }
}
