namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    /// <summary>
    /// A key/value pair variable in a text message.
    /// </summary>
    public class TextMessageVariable
    {
        /// <summary>
        /// A unique key identifying the variable.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The value of the variable.
        /// </summary>
        public string Value { get; set; }
    }
}
