namespace AsterCell.AuthenticationServer.ViewModels
{
    public class LoginViewModel : LoginInputModel
    {
        public LoginViewModel()
        {
        }

        public LoginViewModel(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }
    }
}
