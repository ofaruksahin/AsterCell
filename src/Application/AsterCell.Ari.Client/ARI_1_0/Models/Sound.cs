namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    public class Sound
    {
        /// <summary>
        /// Sound's identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Text description of the sound, usually the words spoken.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The formats and languages in which this sound is available.
        /// </summary>
        public List<FormatLangPair> Formats { get; set; }
    }
}
