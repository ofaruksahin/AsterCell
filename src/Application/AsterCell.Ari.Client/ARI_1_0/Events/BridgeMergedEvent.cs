using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Notification that one bridge has merged into another.
    /// </summary>
    public class BridgeMergedEvent : Event
    {
        /// <summary>
        /// no description provided
        /// </summary>
        public Bridge Bridge { get; set; }

        /// <summary>
        /// no description provided
        /// </summary>
        public Bridge Bridge_from { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
