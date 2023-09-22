namespace AsterCell.Application.Common.Exceptions
{
    public class UserIsNotAuthenticatedException : Exception
    {
        public UserIsNotAuthenticatedException() : base ("Kullanıcı oturum açmamış")
        {
            
        }
    }
}
