using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Event showing the completion of a recording operation.
    /// </summary>
    public class RecordingFinishedEvent : Event
    {
        /// <summary>
        /// Recording control object
        /// </summary>
        public LiveRecording Recording { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
