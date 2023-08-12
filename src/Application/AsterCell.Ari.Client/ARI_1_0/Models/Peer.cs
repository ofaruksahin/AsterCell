﻿namespace AsterCell.Ari.Client.ARI_1_0.Models
{
    public class Peer
    {
        /// <summary>
        /// The current state of the peer. Note that the values of the status are dependent on the underlying peer technology.
        /// </summary>
        public string Peer_status { get; set; }

        /// <summary>
        /// An optional reason associated with the change in peer_status.
        /// </summary>
        public string Cause { get; set; }

        /// <summary>
        /// The IP address of the peer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The port of the peer.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// The last known time the peer was contacted.
        /// </summary>
        public string Time { get; set; }
    }
}
