namespace AsterCell.Ari.Client
{
    interface IAriDispatcher : IDisposable
    {
        void QueueAction(Action action);
    }
}
