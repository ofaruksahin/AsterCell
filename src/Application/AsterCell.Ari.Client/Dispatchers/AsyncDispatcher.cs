namespace AsterCell.Ari.Client.Dispatchers
{
    sealed class AsyncDispatcher : IAriDispatcher
    {
        public void Dispose()
        {

        }

        public async void QueueAction(Action action)
        {
            await Task.Run(action);
        }
    }
}
