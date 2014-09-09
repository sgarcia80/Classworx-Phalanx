using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using Microsoft.Web.Services3.Security.Tokens;

namespace NDCCommon
{
    public class Autenticador : UsernameTokenManager
    {
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override string AuthenticateToken(UsernameToken token)
        {
            throw new Exception();

            if (token == null)
                throw new ArgumentNullException();

            if (token.Username == "vamsi")
                return "mypassword";
            else
                return null;
        }
    }
}
