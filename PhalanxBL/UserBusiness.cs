using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class UserBusiness
    {

        //public UserEntityCollection GetAllUsers()
        //{
        //    UsersFactory PhxUsrFac = new UsersFactory();
        //    return PhxUsrFac.GetUserByPwdId(AUTH_PWDRQST);
        //    return null;
        //}

        public UserEntity GetUserByID( int userId )
        {
            UsersFactory PhxUsrFac = new UsersFactory();
            return PhxUsrFac.GetUserByID(userId);
        }

        public string GetUserString(UserEntity User)
        {
            string UsuarioCompleto = "";
            if(User is WinLocalUserEntity)
            {
                WinLocalUserEntity WinUsr = (WinLocalUserEntity) User;
                UsuarioCompleto = WinUsr.WinPc.WinDomain.NtName;
                UsuarioCompleto += @"\";
                UsuarioCompleto += WinUsr.WinPc.Name;
            }
            else if(User is UnixUserEntity)
            {
                UnixUserEntity UnixUsr = (UnixUserEntity)User;
                UsuarioCompleto += UnixUsr.Unix.ServerName;
            }
            else if(User is DatabaseUserEntity)
            {
                DatabaseUserEntity DBUsr = (DatabaseUserEntity)User;
                UsuarioCompleto = DBUsr.DBType;
                UsuarioCompleto += @"\";
                UsuarioCompleto += DBUsr.DBName;
            }
            else if(User is ApplicationUserEntity)
            {
                ApplicationUserEntity AppUsr = (ApplicationUserEntity)User;
                UsuarioCompleto += AppUsr.ApplicationName;
            }
            else if(User is AS400UserEntity)
            {
                AS400UserEntity AS400Usr = (AS400UserEntity)User;
                UsuarioCompleto += AS400Usr.AS400.ServerName;
            }
            else if (User is CommunicationDeviceUserEntity)
            {
                CommunicationDeviceUserEntity CDUsr = (CommunicationDeviceUserEntity)User;
                UsuarioCompleto = CDUsr.CommunicationDeviceType;
                UsuarioCompleto += @"\";
                UsuarioCompleto += CDUsr.CommunicationDeviceName;
            }

            UsuarioCompleto += @"\";
            UsuarioCompleto += User.Username;
            return UsuarioCompleto;
        }
        //public UserEntityCollection GetUsersByType( int code )
        //{
        //    return null;
        //}
    }
}
