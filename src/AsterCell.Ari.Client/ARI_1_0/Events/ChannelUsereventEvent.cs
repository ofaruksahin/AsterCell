using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// User-generated event with additional user-defined fields in the object.
    /// </summary>
    public class ChannelUsereventEvent : Event
    {
        /// <summary>
        /// The name of the user event.
        /// </summary>
        public string Eventname { get; set; }

        /// <summary>
        /// A channel that is signaled with the user event.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// A bridge that is signaled with the user event.
        /// </summary>
        public Bridge Bridge { get; set; }

        /// <summary>
        /// A endpoint that is signaled with the user event.
        /// </summary>
        public Endpoint Endpoint { get; set; }

        /// <summary>
        /// Custom Userevent data
        /// </summary>
        public object Userevent { get; set; }
    }
}
