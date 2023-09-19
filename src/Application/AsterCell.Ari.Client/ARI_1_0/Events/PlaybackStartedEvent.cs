using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Event showing the start of a media playback operation.
    /// </summary>
    public class PlaybackStartedEvent : Event
    {
        /// <summary>
        /// Playback control object
        /// </summary>
        public Playback Playback { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
