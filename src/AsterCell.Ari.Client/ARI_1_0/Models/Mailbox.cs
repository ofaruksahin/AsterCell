namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    /// <summary>
    /// Represents the state of a mailbox.
    /// </summary>
    public class Mailbox
    {
        /// <summary>
        /// Name of the mailbox.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Count of old messages in the mailbox.
        /// </summary>
        public int Old_messages { get; set; }

        /// <summary>
        /// Count of new messages in the mailbox.
        /// </summary>
        public int New_messages { get; set; }
    }
}
