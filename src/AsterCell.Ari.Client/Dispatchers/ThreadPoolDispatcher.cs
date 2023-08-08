namespace AsterCell.Ari.Client.Dispatchers
{
    sealed class ThreadPoolDispatcher : IAriDispatcher
    {
        public void Dispose()
        {
        }

        public void QueueAction(Action action)
        {
            ThreadPool.QueueUserWorkItem(_ => action());
        }
    }
}
