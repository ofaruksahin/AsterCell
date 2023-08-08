namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    /// <summary>
    /// Info about Asterisk status
    /// </summary>
    public class StatusInfo
    {
        /// <summary>
        /// Time when Asterisk was started.
        /// </summary>
        public DateTime Startup_time { get; set; }

        /// <summary>
        /// Time when Asterisk was last reloaded.
        /// </summary>
        public DateTime Last_reload_time { get; set; }
    }
}
