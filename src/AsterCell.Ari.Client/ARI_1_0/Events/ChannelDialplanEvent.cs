using AsterCell.Ari.Client.ARI_1_0.Models;


namespace AsterCell.Ari.Client.ARI_1_0.Events
{
    /// <summary>
    /// Channel changed location in the dialplan.
    /// </summary>
    public class ChannelDialplanEvent : Event
    {
        /// <summary>
        /// The channel that changed dialplan location.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// The application about to be executed.
        /// </summary>
        public string Dialplan_app { get; set; }

        /// <summary>
        /// The data to be passed to the application.
        /// </summary>
        public string Dialplan_app_data { get; set; }
    }
}
