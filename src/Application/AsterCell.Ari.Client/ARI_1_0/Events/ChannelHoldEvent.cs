using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// A channel initiated a media hold.
    /// </summary>
    public class ChannelHoldEvent : Event
    {
        /// <summary>
        /// The channel that initiated the hold event.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// The music on hold class that the initiator requested.
        /// </summary>
        public string Musicclass { get; set; }
    }
}
