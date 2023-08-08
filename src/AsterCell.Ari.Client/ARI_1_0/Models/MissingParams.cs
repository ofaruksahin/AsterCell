namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    /// <summary>
    /// Error event sent when required params are missing.
    /// </summary>
    public class MissingParams : Message
    {
        /// <summary>
        /// A list of the missing parameters
        /// </summary>
        public List<string> Params { get; set; }
    }
}
