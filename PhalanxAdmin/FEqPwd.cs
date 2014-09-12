using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FEqPwd : PhalanxAdmin.FModalBase
    {
        private object _equipo;
        private bool _ActivarEquipo;
        private string _Ambiente = "";
        public FEqPwd(object Equipo, bool Activar)
        {
            InitializeComponent();
            _equipo = Equipo;
            _ActivarEquipo = Activar;

        }

        private void FEqPwd_Load(object sender, EventArgs e)
        {
            // si es para activar el equipo muestra checkboxes para indicar que pwd se activan
            lvLista.CheckBoxes = _ActivarEquipo;
            lblDescAct.Visible = _ActivarEquipo;
            lblDescDesact.Visible = !_ActivarEquipo;
            pnlBotChk.Visible = _ActivarEquipo;


            if (_equipo is WinPCEntity || _equipo is AS400Entity || _equipo is UnixEntity)
            {
                _Ambiente = "Equipo";
            }
            else if (_equipo is DataBaseEntity)
            {
                _Ambiente = "Base de Datos";
            }
            else if (_equipo is ApplicationEntity)
            {
                _Ambiente = "Aplicativo";
            }
            else if (_equipo is CommunicationDeviceEntity)
                _Ambiente = "Equipo de Comunicación";

            lblAmbiente.Text = _Ambiente;
            if (_ActivarEquipo)
            {
                this.Title = "Activación de " + _Ambiente;
            }
            else
            {
                this.Title = "Desactivación de " + _Ambiente;
            }
            if (_equipo is WinPCEntity)
            {
                lblContenedorPwds.Text = ((WinPCEntity)_equipo).WinDomain.NtName + @"\"
                    + ((WinPCEntity)_equipo).Name;
            }
            else if (_equipo is UnixEntity)
            {
                lblContenedorPwds.Text = ((UnixEntity)_equipo).ServerName;
            }
            else if (_equipo is AS400Entity)
            {
                lblContenedorPwds.Text = ((AS400Entity)_equipo).ServerName;
            }
            else if (_equipo is DataBaseEntity)
            {
                lblContenedorPwds.Text = ((DataBaseEntity)_equipo).Type.Name + @"\"
                + ((DataBaseEntity)_equipo).Name;
            }
            else if (_equipo is ApplicationEntity)
            {
                lblContenedorPwds.Text = ((ApplicationEntity)_equipo).Name;
            }
            else if (_equipo is CommunicationDeviceEntity)
                lblContenedorPwds.Text = ((CommunicationDeviceEntity)_equipo).Name;

            // Cargar usuarios del equipo
            CargarUsuarios();
            // Si es para desactivarlo muestra los usuario y avisa que se van a desactivar
            // Si es para activarlo muestra los usuario con checkbox para que se especifique cuales se activan
        }
        private void CargarUsuarios()
        {
            if (_equipo is WinPCEntity)
            {
                WinLocalUserBusiness WinUsrsB = new WinLocalUserBusiness();
                WinLocalUserEntityCollection WinUsrs = WinUsrsB.GetPCUsers((WinPCEntity)_equipo);
                ListViewItem[] lviArr = new ListViewItem[WinUsrs.Count];
                int i = 0;
                foreach (WinLocalUserEntity WinUsrEnt in WinUsrs)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = WinUsrEnt.Username;
                    lviArr[i].ImageIndex = WinUsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = WinUsrEnt;
                    i++;
                }
                lvLista.Items.Clear();
                lvLista.Items.AddRange(lviArr);

            }
            else if (_equipo is UnixEntity)
            {
                UnixUserBusiness UnixUsrsB = new UnixUserBusiness();
                UnixUserEntityCollection UnixUsrs = UnixUsrsB.GetPCUsers((UnixEntity)_equipo);
                ListViewItem[] lviArr = new ListViewItem[UnixUsrs.Count];
                int i = 0;
                foreach (UnixUserEntity UnixUsrEnt in UnixUsrs)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = UnixUsrEnt.Username;
                    lviArr[i].ImageIndex = UnixUsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = UnixUsrEnt;
                    i++;
                }
                lvLista.Items.Clear();
                lvLista.Items.AddRange(lviArr);

            }
            else if (_equipo is AS400Entity)
            {
                AS400UserBusiness AS400UsrsB = new AS400UserBusiness();
                AS400UserEntityCollection AS400Usrs = AS400UsrsB.GetPCUsers((AS400Entity)_equipo);
                ListViewItem[] lviArr = new ListViewItem[AS400Usrs.Count];
                int i = 0;
                foreach (AS400UserEntity AS400UsrEnt in AS400Usrs)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = AS400UsrEnt.Username;
                    lviArr[i].ImageIndex = AS400UsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = AS400UsrEnt;
                    i++;
                }
                lvLista.Items.Clear();
                lvLista.Items.AddRange(lviArr);

            }
            else if (_equipo is DataBaseEntity)
            {
                DatabaseUserBusiness DataBaseUsrsB = new DatabaseUserBusiness();
                DatabaseUserEntityCollection DataBaseUsrs = DataBaseUsrsB.GetDBUsers((DataBaseEntity)_equipo);
                ListViewItem[] lviArr = new ListViewItem[DataBaseUsrs.Count];
                int i = 0;
                foreach (DatabaseUserEntity DataBaseUsrEnt in DataBaseUsrs)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = DataBaseUsrEnt.Username;
                    lviArr[i].ImageIndex = DataBaseUsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = DataBaseUsrEnt;
                    i++;
                }
                lvLista.Items.Clear();
                lvLista.Items.AddRange(lviArr);
            }
            else if (_equipo is ApplicationEntity)
            {
                ApplicationUserBusiness ApplicationUsrsB = new ApplicationUserBusiness();
                ApplicationUserEntityCollection ApplicationUsrs = ApplicationUsrsB.GetAppUsers((ApplicationEntity)_equipo);
                ListViewItem[] lviArr = new ListViewItem[ApplicationUsrs.Count];
                int i = 0;
                foreach (ApplicationUserEntity ApplicationUsrEnt in ApplicationUsrs)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = ApplicationUsrEnt.Username;
                    lviArr[i].ImageIndex = ApplicationUsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = ApplicationUsrEnt;
                    i++;
                }
                lvLista.Items.Clear();
                lvLista.Items.AddRange(lviArr);
            }
            else if (_equipo is CommunicationDeviceEntity)
            {
                CommunicationDeviceUserBusiness CDUsrsB = new CommunicationDeviceUserBusiness();
                CommunicationDeviceUserEntityCollection CDUsrs = CDUsrsB.GetCDUsers((CommunicationDeviceEntity)_equipo);
                ListViewItem[] lviArr = new ListViewItem[CDUsrs.Count];
                int i = 0;
                foreach (CommunicationDeviceUserEntity CDUsrEnt in CDUsrs)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = CDUsrEnt.Username;
                    lviArr[i].ImageIndex = CDUsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = CDUsrEnt;
                    i++;
                }
                lvLista.Items.Clear();
                lvLista.Items.AddRange(lviArr);

            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_ActivarEquipo)
            {
                // activa las contraseñas chequeadas
                if (_equipo is WinPCEntity)
                {
                    WinLocalUserEntityCollection Users = new WinLocalUserEntityCollection();
                    for (int i = 0; i < lvLista.CheckedItems.Count; i++)
                    {
                        Users.Add((WinLocalUserEntity)lvLista.Items[i].Tag);
                    }
                    WinLocalUserBusiness UsrsBL = new WinLocalUserBusiness();
                    UsrsBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is UnixEntity)
                {
                    UnixUserEntityCollection Users = new UnixUserEntityCollection();
                    for (int i = 0; i < lvLista.CheckedItems.Count; i++)
                    {
                        Users.Add((UnixUserEntity)lvLista.Items[i].Tag);
                    }
                    UnixUserBusiness UnixUsrBL = new UnixUserBusiness();
                    UnixUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is AS400Entity)
                {
                    AS400UserEntityCollection Users = new AS400UserEntityCollection();
                    for (int i = 0; i < lvLista.CheckedItems.Count; i++)
                    {
                        Users.Add((AS400UserEntity)lvLista.Items[i].Tag);
                    }
                    AS400UserBusiness AS400UsrBL = new AS400UserBusiness();
                    AS400UsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is DataBaseEntity)
                {
                    DatabaseUserEntityCollection Users = new DatabaseUserEntityCollection();
                    for (int i = 0; i < lvLista.CheckedItems.Count; i++)
                    {
                        Users.Add((DatabaseUserEntity)lvLista.Items[i].Tag);
                    }
                    DatabaseUserBusiness DBUsrBL = new DatabaseUserBusiness();
                    DBUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is ApplicationEntity)
                {
                    ApplicationUserEntityCollection Users = new ApplicationUserEntityCollection();
                    for (int i = 0; i < lvLista.CheckedItems.Count; i++)
                    {
                        Users.Add((ApplicationUserEntity)lvLista.Items[i].Tag);
                    }
                    ApplicationUserBusiness DBUsrBL = new ApplicationUserBusiness();
                    DBUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is CommunicationDeviceEntity)
                {
                    CommunicationDeviceUserEntityCollection Users = new CommunicationDeviceUserEntityCollection();
                    for (int i = 0; i < lvLista.CheckedItems.Count; i++)
                    {
                        Users.Add((CommunicationDeviceUserEntity)lvLista.Items[i].Tag);
                    }
                    CommunicationDeviceUserBusiness CDUsrBL = new CommunicationDeviceUserBusiness();
                    CDUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
            }
            else
            {
                // desactiva todas las contraseñas
                if (_equipo is WinPCEntity)
                {
                    WinLocalUserEntityCollection Users = new WinLocalUserEntityCollection();
                    for (int i = 0; i < lvLista.Items.Count; i++)
                    {
                        Users.Add((WinLocalUserEntity)lvLista.Items[i].Tag);
                    }
                    WinLocalUserBusiness UsrsBL = new WinLocalUserBusiness();
                    UsrsBL.SetPwdState(Users, _ActivarEquipo);

                }
                else if (_equipo is UnixEntity)
                {
                    UnixUserEntityCollection Users = new UnixUserEntityCollection();
                    for (int i = 0; i < lvLista.Items.Count; i++)
                    {
                        Users.Add((UnixUserEntity)lvLista.Items[i].Tag);
                    }
                    UnixUserBusiness UnixUsrBL = new UnixUserBusiness();
                    UnixUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is AS400Entity)
                {
                    AS400UserEntityCollection Users = new AS400UserEntityCollection();
                    for (int i = 0; i < lvLista.Items.Count; i++)
                    {
                        Users.Add((AS400UserEntity)lvLista.Items[i].Tag);
                    }
                    AS400UserBusiness AS400UsrBL = new AS400UserBusiness();
                    AS400UsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is DataBaseEntity)
                {
                    DatabaseUserEntityCollection Users = new DatabaseUserEntityCollection();
                    for (int i = 0; i < lvLista.Items.Count; i++)
                    {
                        Users.Add((DatabaseUserEntity)lvLista.Items[i].Tag);
                    }
                    DatabaseUserBusiness DBUsrBL = new DatabaseUserBusiness();
                    DBUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is ApplicationEntity)
                {
                    ApplicationUserEntityCollection Users = new ApplicationUserEntityCollection();
                    for (int i = 0; i < lvLista.Items.Count; i++)
                    {
                        Users.Add((ApplicationUserEntity)lvLista.Items[i].Tag);
                    }
                    ApplicationUserBusiness DBUsrBL = new ApplicationUserBusiness();
                    DBUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
                else if (_equipo is CommunicationDeviceEntity)
                {
                    CommunicationDeviceUserEntityCollection Users = new CommunicationDeviceUserEntityCollection();
                    for (int i = 0; i < lvLista.Items.Count; i++)
                    {
                        Users.Add((CommunicationDeviceUserEntity)lvLista.Items[i].Tag);
                    }
                    CommunicationDeviceUserBusiness CDUsrBL = new CommunicationDeviceUserBusiness();
                    CDUsrBL.SetPwdState(Users, _ActivarEquipo);
                }
            }
        }

        private void lnkMarcarTodo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MarcarTodo(true);
        }
        void MarcarTodo(bool Marcar)
        {
            for (int i = 0; i < lvLista.Items.Count; i++)
            {
                lvLista.Items[i].Checked = Marcar;
            }
        }

        private void lnkDesmarcarTodo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.MarcarTodo(false);
        }
    }
}

