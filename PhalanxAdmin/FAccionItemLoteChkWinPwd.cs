using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FAccionItemLoteChkWinPwd : PhalanxAdmin.FModalBase
    {
        ItemLoteChkWinLocalUsersEntity _ItemLote;
        public FAccionItemLoteChkWinPwd(ItemLoteChkWinLocalUsersEntity ItemLote)
        {
            InitializeComponent();
            _ItemLote = ItemLote;

        }

        private void FAccionItemLoteChkWinPwd_Load(object sender, EventArgs e)
        {
            // cargar datos items
            ItemLoteChkWinLocalUsersBusiness ItemLoteBL = new ItemLoteChkWinLocalUsersBusiness();
            ItemLoteBL.Refresh(_ItemLote);
            txtFolio.Text = _ItemLote.WinLocalUser.Key;
            txtUsuario.Text = _ItemLote.WinLocalUser.NetPath;
            // cuando no coincide equipo o usuario no habilita la reparación
            // cuando chk pwd ok, no habilita la reparación

            bool bReparaPwdEnable = true;

            if (_ItemLote.ChkPwd != null)
            {
                txtChkPwd.Text = (_ItemLote.ChkPwd.Value ? "OK" : "Falló");
                if (_ItemLote.ChkPwd.Value)
                {
                    bReparaPwdEnable = false;
                }
            }
            if (_ItemLote.ChkPingNombreEquipo != null)
            {
                txtNombreEquipo.Text = (_ItemLote.ChkPingNombreEquipo.Value ? "OK" : "Falló");
                if (!_ItemLote.ChkPingNombreEquipo.Value)
                {
                    bReparaPwdEnable = false;
                }

            }
            if (_ItemLote.ChkPingIPEquipo != null)
            {
                txtAccIP.Text = (_ItemLote.ChkPingIPEquipo.Value ? "OK" : "Falló");
            }
            if (_ItemLote.ChkUsername != null)
            {
                txtAccNombre.Text = (_ItemLote.ChkUsername.Value ? "OK" : "Falló");
                if (!_ItemLote.ChkUsername.Value)
                {
                    bReparaPwdEnable = false;
                }
            }
            if (_ItemLote.NombreEquipoPingIP != null)
            {
                txtNombreEquipo.Text = _ItemLote.NombreEquipoPingIP;
            }
            btnRepararPwd.Enabled = bReparaPwdEnable;

            // habilitar acciones en función de lo que permita el resultado
            //btnDesactEquipo.Enabled = _ItemLote.WinLocalUser.WinPc.Active && ;
            //btnSacarChkEquipo.Enabled = _ItemLote.WinLocalUser.WinPc.Checkable;
        }

        private void btnDesactEquipo_Click(object sender, EventArgs e)
        {
            ItemLoteChkWinLocalUsersBusiness ItmBL = new ItemLoteChkWinLocalUsersBusiness();
            if (MessageBox.Show("Se va a desactivar el equipo. Desea continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ItmBL.DesactivarEquipo(_ItemLote))
                {
                    MessageBox.Show("Se desactivó el equipo");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Hubo un error en la acción");
                }
            }
        }

        private void btnSacarChkEquipo_Click(object sender, EventArgs e)
        {
            ItemLoteChkWinLocalUsersBusiness ItmBL = new ItemLoteChkWinLocalUsersBusiness();
            if (MessageBox.Show("Se va a sacar la marca de chequeo del equipo. Desea continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ItmBL.SacarChkWinPC(_ItemLote))
                {
                    MessageBox.Show("Se sacó la marca de chequeo del equipo");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Hubo un error en la acción");
                }
            }

        }

        private void btnRepararPwd_Click(object sender, EventArgs e)
        {
            ItemLoteChkWinLocalUsersBusiness ItmBL = new ItemLoteChkWinLocalUsersBusiness();
            if (MessageBox.Show("Se va a reparar la contraseña. Desea continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (ItmBL.RepararPwd(_ItemLote))
                    {
                        MessageBox.Show("Se reparó la contraseña");
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error en la acción");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error en la acción: " + ex.Message);
                }
            }


        }

        private void btnSacarChkPwd_Click(object sender, EventArgs e)
        {
            ItemLoteChkWinLocalUsersBusiness ItmBL = new ItemLoteChkWinLocalUsersBusiness();
            if (MessageBox.Show("Se va a sacar la marca de chequeo de la contraseña. Desea continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ItmBL.SacarChkPwd(_ItemLote))
                {
                    MessageBox.Show("Se sacó la marca de chequeo de la contraseña");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Hubo un error en la acción");
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            return;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            return;

        }
    }
}

