using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Attributes
{
    public static class AuthenticateData
    {
        private static string secretKey = "EO1rZOR-a05q3Q7wKBXA_UmdMHYSGw13_mJUXhUJiS4=";
        private static string issuer = "silivribilsem.com";
        private static string audience = "silivribilsem.com";
        private static string loginPage = "/";
        private static string accessDenidedPage = "/AccessDenided";
        private static string cookiHeaderText = "AuthToken";

        public static string SecretKey { get => secretKey; }
        public static string Issuer { get => issuer;  }
        public static string Audience { get => audience; }
        public static string LoginPage { get => loginPage; }
        public static string AccessDenidedPage { get => accessDenidedPage;  }
        public static string CookiHeaderText { get => cookiHeaderText;  }

        
    }
}
