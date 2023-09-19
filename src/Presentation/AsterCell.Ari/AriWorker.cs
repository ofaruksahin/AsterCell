using AsterCell.Ari.Client;
using AsterCell.Ari.Client.ARI_1_0.Events;
using AsterCell.Ari.Client.ARI_1_0.Models;
using AsterCell.Ari.Client.Middleware;

namespace AsterCell.Ari
{
    public class AriWorker : BackgroundService
    {
        private AriClient _ariClient;

        private readonly ILogger<AriWorker> _logger;   

        public AriWorker(ILogger<AriWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var endpoint = new StasisEndpoint("192.168.1.115", 8088, "root", "123456789");

            _ariClient = new AriClient(endpoint, "astercell");

            _ariClient.Connect();

            _ariClient.OnDeviceStateChangedEvent += OnDeviceStateChangedEvent;
            _ariClient.OnPlaybackStartedEvent += OnPlaybackStartedEvent;
            _ariClient.OnPlaybackContinuingEvent += OnPlaybackContinuingEvent;
            _ariClient.OnPlaybackFinishedEvent += OnPlaybackFinishedEvent;
            _ariClient.OnRecordingStartedEvent += OnRecordingStartedEvent;
            _ariClient.OnRecordingFinishedEvent += OnRecordingFinishedEvent;
            _ariClient.OnRecordingFailedEvent += OnRecordingFailedEvent;
            _ariClient.OnApplicationReplacedEvent += OnApplicationReplacedEvent;
            _ariClient.OnBridgeCreatedEvent += OnBridgeCreatedEvent;
            _ariClient.OnBridgeDestroyedEvent += OnBridgeDestroyedEvent;
            _ariClient.OnBridgeMergedEvent += OnBridgeMergedEvent;
            _ariClient.OnBridgeBlindTransferEvent += OnBridgeBlindTransferEvent;
            _ariClient.OnBridgeAttendedTransferEvent += OnBridgeAttendedTransferEvent;
            _ariClient.OnChannelCreatedEvent += OnChannelCreatedEvent;
            _ariClient.OnChannelDestroyedEvent += OnChannelDestroyedEvent;
            _ariClient.OnChannelEnteredBridgeEvent += OnChannelEnteredBridgeEvent;
            _ariClient.OnChannelLeftBridgeEvent += OnChannelLeftBridgeEvent;
            _ariClient.OnChannelStateChangeEvent += OnChannelStateChangeEvent;
            _ariClient.OnChannelDtmfReceivedEvent += OnChannelDtmfReceivedEvent;
            _ariClient.OnChannelDialplanEvent += OnChannelDialplanEvent;
            _ariClient.OnChannelCallerIdEvent += OnChannelCallerIdEvent;
            _ariClient.OnChannelUsereventEvent += OnChannelUsereventEvent;
            _ariClient.OnChannelHangupRequestEvent += OnChannelHangupRequestEvent;
            _ariClient.OnChannelVarsetEvent += OnChannelVarsetEvent;
            _ariClient.OnChannelHoldEvent += OnChannelHoldEvent;
            _ariClient.OnChannelUnholdEvent += OnChannelUnholdEvent;
            _ariClient.OnChannelTalkingStartedEvent += OnChannelTalkingStartedEvent;
            _ariClient.OnChannelTalkingFinishedEvent += OnChannelTalkingFinishedEvent;
            _ariClient.OnContactStatusChangeEvent += OnContactStatusChangeEvent;
            _ariClient.OnPeerStatusChangeEvent += OnPeerStatusChangeEvent;
            _ariClient.OnEndpointStateChangeEvent += OnEndpointStateChangeEvent;
            _ariClient.OnDialEvent += OnDialEvent;
            _ariClient.OnStasisEndEvent += OnStasisEndEvent;
            _ariClient.OnStasisStartEvent += OnStasisStartEvent;
            _ariClient.OnTextMessageReceivedEvent += OnTextMessageReceivedEvent;
            _ariClient.OnChannelConnectedLineEvent += OnChannelConnectedLineEvent;
            _ariClient.OnUnhandledEvent += OnUnhandledEvent;
            _ariClient.OnUnhandledException += OnUnhandledException;

            _logger.LogInformation("Ari client connection state {connectionState}", _ariClient.ConnectionState);

            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            while(!cancellationTokenSource.IsCancellationRequested && _ariClient.ConnectionState != ConnectionState.Open)
            {
            }

            _logger.LogInformation("Ari client connection state {connectionState}", _ariClient.ConnectionState);

            if (_ariClient.ConnectionState != ConnectionState.Open)
                throw new Exception("Ari client not connected");

            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }

        private void OnDeviceStateChangedEvent(IAriClient sender, DeviceStateChangedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}",nameof(OnDeviceStateChangedEvent),e);
        }

        private void OnPlaybackStartedEvent(IAriClient sender, PlaybackStartedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnPlaybackStartedEvent), e);
        }

        private void OnPlaybackContinuingEvent(IAriClient sender, PlaybackContinuingEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnPlaybackContinuingEvent), e);
        }

        private void OnPlaybackFinishedEvent(IAriClient sender, PlaybackFinishedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnPlaybackFinishedEvent), e);
        }

        private void OnRecordingStartedEvent(IAriClient sender, RecordingStartedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnRecordingStartedEvent), e);
        }

        private void OnRecordingFinishedEvent(IAriClient sender, RecordingFinishedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnRecordingFinishedEvent), e);
        }

        private void OnRecordingFailedEvent(IAriClient sender, RecordingFailedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnRecordingFailedEvent), e);
        }

        private void OnApplicationReplacedEvent(IAriClient sender, ApplicationReplacedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnApplicationReplacedEvent), e);
        }

        private void OnBridgeCreatedEvent(IAriClient sender, BridgeCreatedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnBridgeCreatedEvent), e);
        }

        private void OnBridgeDestroyedEvent(IAriClient sender, BridgeDestroyedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnBridgeDestroyedEvent), e);
        }

        private void OnBridgeMergedEvent(IAriClient sender, BridgeMergedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnBridgeMergedEvent), e);
        }

        private void OnBridgeBlindTransferEvent(IAriClient sender, BridgeBlindTransferEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnBridgeBlindTransferEvent), e);
        }

        private void OnBridgeAttendedTransferEvent(IAriClient sender, BridgeAttendedTransferEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnBridgeAttendedTransferEvent), e);
        }

        private void OnChannelCreatedEvent(IAriClient sender, ChannelCreatedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelCreatedEvent), e);
        }

        private void OnChannelDestroyedEvent(IAriClient sender, ChannelDestroyedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelDestroyedEvent), e);
        }

        private void OnChannelEnteredBridgeEvent(IAriClient sender, ChannelEnteredBridgeEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelEnteredBridgeEvent), e);
        }

        private void OnChannelLeftBridgeEvent(IAriClient sender, ChannelLeftBridgeEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelLeftBridgeEvent), e);
        }

        private void OnChannelStateChangeEvent(IAriClient sender, ChannelStateChangeEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelStateChangeEvent), e);
        }

        private void OnChannelDtmfReceivedEvent(IAriClient sender, ChannelDtmfReceivedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelDtmfReceivedEvent), e);
        }

        private void OnChannelDialplanEvent(IAriClient sender, ChannelDialplanEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelDialplanEvent), e);
        }

        private void OnChannelCallerIdEvent(IAriClient sender, ChannelCallerIdEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelCallerIdEvent), e);
        }

        private void OnChannelUsereventEvent(IAriClient sender, ChannelUsereventEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelUsereventEvent), e);
        }

        private void OnChannelHangupRequestEvent(IAriClient sender, ChannelHangupRequestEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelHangupRequestEvent), e);
        }

        private void OnChannelVarsetEvent(IAriClient sender, ChannelVarsetEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelVarsetEvent), e);
        }

        private void OnChannelHoldEvent(IAriClient sender, ChannelHoldEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelHoldEvent), e);
        }

        private void OnChannelUnholdEvent(IAriClient sender, ChannelUnholdEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelUnholdEvent), e);
        }

        private void OnChannelTalkingStartedEvent(IAriClient sender, ChannelTalkingStartedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelTalkingStartedEvent), e);
        }

        private void OnChannelTalkingFinishedEvent(IAriClient sender, ChannelTalkingFinishedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelTalkingFinishedEvent), e);
        }

        private void OnContactStatusChangeEvent(IAriClient sender, ContactStatusChangeEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnContactStatusChangeEvent), e);
        }

        private void OnPeerStatusChangeEvent(IAriClient sender, PeerStatusChangeEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnPeerStatusChangeEvent), e);
        }

        private void OnEndpointStateChangeEvent(IAriClient sender, EndpointStateChangeEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnEndpointStateChangeEvent), e);
        }

        private void OnDialEvent(IAriClient sender, DialEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnDialEvent), e);
        }

        private void OnStasisEndEvent(IAriClient sender, StasisEndEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnStasisEndEvent), e);
        }

        private void OnStasisStartEvent(IAriClient sender, StasisStartEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}",nameof(OnStasisStartEvent),e);
        }

        private void OnTextMessageReceivedEvent(IAriClient sender, TextMessageReceivedEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnTextMessageReceivedEvent), e);
        }

        private void OnChannelConnectedLineEvent(IAriClient sender, ChannelConnectedLineEvent e)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnChannelConnectedLineEvent), e);
        }

        private void OnUnhandledEvent(object sender, Event eventMessage)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnUnhandledEvent), eventMessage);
        }

        private void OnUnhandledException(object sender, Exception exception)
        {
            _logger.LogInformation("{eventName} {eventArgs}", nameof(OnUnhandledException), exception);
        }
    }
}