using AsterCell.Ari.Client.ARI_1_0.Models;


namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Talking is no longer detected on the channel.
    /// </summary>
    public class ChannelTalkingFinishedEvent : Event
    {
        /// <summary>
        /// The channel on which talking completed.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// The length of time, in milliseconds, that talking was detected on the channel
        /// </summary>
        public int Duration { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
