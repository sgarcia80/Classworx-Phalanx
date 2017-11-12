using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxDAL.Factories
{
    public class BaseFactory
    {
        protected string UserLogon = string.Empty;

        public BaseFactory()
        {
            this.UserLogon = string.Empty;
        }
        public BaseFactory(string userlogon)
        {
            this.UserLogon = userlogon;
        }
    }
}
