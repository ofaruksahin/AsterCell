﻿using System;

namespace IdentityServerHost.Quickstart.UI
{
    public class AccountOptions
    {
        public static bool AllowLocalLogin = true;
        public static bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        public static bool ShowLogoutPrompt = false;
        public static bool AutomaticRedirectAfterSignOut = true;

        public static string InvalidCredentialsErrorMessage = "Email veya şifre hatalı";
    }
}
