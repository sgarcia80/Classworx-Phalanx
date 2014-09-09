using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using System.Runtime.InteropServices;
using System.DirectoryServices;
using System.Collections;

using System.Reflection;

namespace PhalanxNAL
{
    public class NUser 
    {
        public NUser()
        { 
        
        }
        
        public WinLocalUserEntityCollection FindUsers(WinPCEntity winPc, string filter)
        {
            uint EntriesRead = 0;
            uint TotalEntries = 0;
            uint result;
            string _lastError;
            IntPtr bufPtr;
            //IntPtr ServerNamePtr;
            uint prefmaxlen = 0xFFFFFFFF;
            WinLocalUserEntityCollection resultUsers = new WinLocalUserEntityCollection();

            bufPtr = IntPtr.Zero;

            //ServerNamePtr = Marshal.StringToCoTaskMemAuto(m_PDCName);

            result = common.NetUserEnum(winPc.Name,
                                10,
                //common.FILTER_TEMP_DUPLICATE_ACCOUNT, 
                                common.FILTER_NORMAL_ACCOUNT,
                                ref bufPtr,
                                prefmaxlen,
                                ref EntriesRead,
                                ref TotalEntries,
                                IntPtr.Zero);
            if (result != 0)
            {
                switch (result)
                {
                    case common.ERROR_MORE_DATA:
                        _lastError = "More data is available";
                        break;
                    case common.ERROR_ACCESS_DENIED:
                        _lastError = "Access was denied";
                        break;
                    default:
                        _lastError = "Unknown error code " + result;
                        break;
                }
            }
            else
            {
                if (EntriesRead > 0)
                {
                    common.USER_INFO_10[] Users = new common.USER_INFO_10[EntriesRead];
                    IntPtr iter = bufPtr;
                    for (int i = 0; i < EntriesRead; i++)
                    {
                        Users[i] = (common.USER_INFO_10)Marshal.PtrToStructure(iter, typeof(common.USER_INFO_10));
                        iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(common.USER_INFO_10)));
                        //MessageBox.Show(Users[i].Username);
                        //CUserGlobal currGU = new CUserGlobal(m_ntName, Users[i].name);

                        bool validUser= true;
                        if (filter != null && filter.Length > 0)
                        {
                            if (Users[i].name.ToUpper().IndexOf(filter.ToUpper()) == -1)
                                validUser= false;
                        }
                        if (validUser)
                        {
                            WinLocalUserEntity wlue = new WinLocalUserEntity();
                            wlue.Username = Users[i].name;
                            if (Users[i].comment.Length > 100)
                                wlue.Desc = Users[i].comment.Substring(1, 100);
                            else
                                wlue.Desc = Users[i].comment;
                            wlue.ActiveUser = true;
                            wlue.WinPc = winPc;
                            resultUsers.Add(wlue);
                        }
                    }
                    common.NetApiBufferFree(bufPtr);
                }
            }
            return resultUsers;
        }

        public void ChangePassword(string computername, string username, string newpassword)
        {
            ///string Title = "Change Password WinNT://" + m_domainname + "/" + m_computername + "/" + m_username;
            string errorMsg = string.Empty;

            DirectoryEntry obDirEntry = null;
            try
            {
                //obDirEntry = new DirectoryEntry("WinNT://" + m_domainname + "/" + m_computername + "/" + m_username + ",User");
                obDirEntry = new DirectoryEntry("WinNT://"+computername+"/"+username+",User");
                obDirEntry.AuthenticationType = AuthenticationTypes.Secure;

                object[] oPassword = new object[] { newpassword };
                obDirEntry.Invoke("setPassword", oPassword);
                //obDirEntry.Invoke("ChangePassword", new object[]{m_password, newpassword });
                obDirEntry.CommitChanges();
                obDirEntry.Close();
            }
            catch (COMException ex)
            {
                ///retu = (uint)ex.ErrorCode;
                errorMsg = ex.Message;
                //currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
                throw new SystemException(errorMsg);
            }
            catch (TargetInvocationException et)
            {
                //retu = common.CPASS_ERR_INVALID_PASSWORD;
                errorMsg = et.InnerException.Message;
                //currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
                throw new SystemException(errorMsg);
            }
            catch (Exception e)
            {
                //retu = common.CPASS_ERR_UNKNOWN;
                errorMsg = "Unknown Exception";
                //currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
                throw new SystemException(errorMsg);
            }
        }
        public uint validatePassword(string domainname, string computername, string username, string password)
        {
            return this.ChangePassword(domainname, computername, username, password, password);
        }
        public bool FindUser(string domainname, string computername, string username)
        {
            DirectoryEntry dirEntryLocalMachine = new DirectoryEntry("WinNT://" + domainname + "/" + computername + ",computer");
            bool UserExists = false;
            try
            {
                UserExists = (dirEntryLocalMachine.Children.Find(username, "user") != null);
            }
            catch (Exception e)
            {
            }
            return UserExists;
        }
        public uint ChangePassword(string domainname, string computername, string username, string oldpassword, string newpassword)
        {
            uint retu = common.CPASS_ERR_UNKNOWN;
            //string Title = "Check Password WinNT://" + m_domainname + "/" + m_computername + "/" + m_username;
            string errorMsg = string.Empty;

            DirectoryEntry obDirEntry = null;
            try
            {
                obDirEntry = new DirectoryEntry("WinNT://" + domainname + "/" + computername + "/" + username + ",User");
                //obDirEntry = new DirectoryEntry("WinNT://" + computername + "/" + username + ",User");
                obDirEntry.AuthenticationType = AuthenticationTypes.Secure;
                obDirEntry.Invoke("ChangePassword", new object[] { oldpassword, newpassword });
                obDirEntry.CommitChanges();
                obDirEntry.Close();
                retu = 0;
            }
            catch (COMException ex)
            {
                retu = (uint)ex.ErrorCode;
                errorMsg = ex.Message;
                //currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
            }
            catch (TargetInvocationException et)
            {
                errorMsg = et.InnerException.Message;
                int ErrorDeDirectivas = errorMsg.IndexOf("no cumple con los requisitos de la directiva");
                if (ErrorDeDirectivas < 0)
                {
                    // chequea en inglés
                    ErrorDeDirectivas = errorMsg.IndexOf("does not meet the password policy requirements");
                }
                if (ErrorDeDirectivas > -1)
                {
                    // si da error de requisitos de directiva de contraseña, es porque el chequeo ya lo hizo y fue OK
                    // si el pwd pasado es NOK no llega a dar este error sino directamente dice pwd NOK
                    // 2147942401
                    // "La contraseña no cumple con los requisitos de la directiva de contraseña. Compruebe los requisitos de longitud mínima, complejidad e historial de la contraseña."
                    // "The password does not meet the password policy requirements. Check the minimum password length, password complexity and password history requirements."
                    retu = 0;
                }
                else
                {
                    retu = common.CPASS_ERR_INVALID_PASSWORD;
                    //currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
                }
            }
            catch (Exception e)
            {
                retu = common.CPASS_ERR_UNKNOWN;
                errorMsg = "Unknown Exception";
                //currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
            }
            return retu;
        }
		

    }


}
