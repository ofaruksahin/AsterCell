using AsterCell.Ari.Client.ARI_1_0.Actions;

namespace AsterCell.Ari.Client
{
    public interface IAriActionClient
    {
        IAsteriskActions Asterisk { get; set; }
        IApplicationsActions Applications { get; set; }
        IBridgesActions Bridges { get; set; }
        IChannelsActions Channels { get; set; }
        IDeviceStatesActions DeviceStates { get; set; }
        IEndpointsActions Endpoints { get; set; }
        IEventsActions Events { get; set; }
        IMailboxesActions Mailboxes { get; set; }
        IPlaybacksActions Playbacks { get; set; }
        IRecordingsActions Recordings { get; set; }
        ISoundsActions Sounds { get; set; }
    }
}
