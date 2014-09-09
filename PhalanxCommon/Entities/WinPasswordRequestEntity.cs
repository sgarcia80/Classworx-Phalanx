using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Entities
{
    public sealed class WinPasswordRequestEntity : PasswordRequestEntity
    {
        public string PCName
        {
            get
            {
                return this.User.PCName;
            }
        }
        private WinLocalUserEntity User
        {
            get
            {
                return (WinLocalUserEntity)base.UserPassword.UsersList[0];
            }
        }
        public string Domain
        {
            get
            {
                return this.User.Domain;
            }
        }

    }
}
