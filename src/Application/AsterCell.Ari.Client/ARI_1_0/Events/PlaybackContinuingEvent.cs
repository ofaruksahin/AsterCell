using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Event showing the continuation of a media playback operation from one media URI to the next in the list.
    /// </summary>
    public class PlaybackContinuingEvent : Event
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
