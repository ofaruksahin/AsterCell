using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Event showing the completion of a media playback operation.
    /// </summary>
    public class PlaybackFinishedEvent : Event
    {
        /// <summary>
        /// Playback control object
        /// </summary>
        public Playback Playback { get; set; }
    }
}
