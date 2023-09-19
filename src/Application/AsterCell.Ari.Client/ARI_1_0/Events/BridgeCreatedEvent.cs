using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    public class BridgeCreatedEvent : Event
    {
        /// <summary>
        /// no description provided
        /// </summary>
        public Bridge Bridge { get; set; }

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
