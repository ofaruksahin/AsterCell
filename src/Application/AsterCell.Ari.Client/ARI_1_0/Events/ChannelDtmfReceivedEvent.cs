using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// DTMF received on a channel.  This event is sent when the DTMF ends. There is no notification about the start of DTMF
    /// </summary>
    public class ChannelDtmfReceivedEvent : Event
    {
        /// <summary>
        /// DTMF digit received (0-9, A-E, # or *)
        /// </summary>
        public string Digit { get; set; }

        /// <summary>
        /// Number of milliseconds DTMF was received
        /// </summary>
        public int Duration_ms { get; set; }

        /// <summary>
        /// The channel on which DTMF was received
        /// </summary>
        public Channel Channel { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
