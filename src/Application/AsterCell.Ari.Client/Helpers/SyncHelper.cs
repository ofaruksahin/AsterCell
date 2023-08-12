using AsterCell.Ari.Client.ARI_1_0;
using AsterCell.Ari.Client.ARI_1_0.Events;
using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.Helpers
{
    public static class SyncHelper
    {
        public static PlaybackFinishedEvent Wait(this Playback playback, IAriEventClient client)
        {
            var playbackFinished = new AutoResetEvent(false);
            PlaybackFinishedEvent rtn = null;
            client.OnPlaybackFinishedEvent += (s, e) =>
            {
                rtn = e;
                playbackFinished.Set();
            };

            playbackFinished.WaitOne();
            return rtn;
        }
    }
}
