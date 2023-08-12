using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Channel changed Connected Line.
    /// </summary>
    public class ChannelConnectedLineEvent : Event
    {
        /// <summary>
        /// The channel whose connected line has changed.
        /// </summary>
        public Channel Channel { get; set; }
    }
}
