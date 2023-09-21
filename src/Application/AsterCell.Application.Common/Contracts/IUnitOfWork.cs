namespace AsterCell.Application.Common.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteTransaction(string user = "SYSTEM");
    }
}
