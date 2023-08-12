using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Event showing failure of a recording operation.
    /// </summary>
    public class RecordingFailedEvent : Event
    {
        /// <summary>
        /// Recording control object
        /// </summary>
        public LiveRecording Recording { get; set; }
    }
}
