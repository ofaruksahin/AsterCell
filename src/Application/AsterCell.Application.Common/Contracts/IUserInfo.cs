namespace AsterCell.Application.Common.Contracts
{
    public interface IUserInfo
    {
        int Id { get; }
        string TenantId { get; }
        public string PhoneNumber { get; }
        public string Email { get;  }
        public List<string> Roles { get;  }
        Task<bool> IsAuthenticated();
    }
}
