﻿using AsterCell.Ari.Client.ARI_1_0.Models;

namespace AsterCell.Ari.Client.ARI_1_0.Actions
{
    public interface IPlaybacksActions
    {
        /// <summary>
        /// Get a playback's details.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        Playback Get(string playbackId);
        /// <summary>
        /// Stop a playback.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        void Stop(string playbackId);
        /// <summary>
        /// Control a playback.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        /// <param name="operation">Operation to perform on the playback.</param>
        void Control(string playbackId, string operation);

        /// <summary>
        /// Get a playback's details.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        Task<Playback> GetAsync(string playbackId);
        /// <summary>
        /// Stop a playback.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        Task StopAsync(string playbackId);
        /// <summary>
        /// Control a playback.. 
        /// </summary>
        /// <param name="playbackId">Playback's id</param>
        /// <param name="operation">Operation to perform on the playback.</param>
        Task ControlAsync(string playbackId, string operation);
    }
}
