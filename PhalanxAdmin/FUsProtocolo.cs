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
    public partial class FUsProtocolo : PhalanxAdmin.FModalBase
    {
        private IDictionary<CommunicationDeviceProtocolEntity, CommunicationDeviceUserEntityCollection> _usuarios;

        public FUsProtocolo(IDictionary<CommunicationDeviceProtocolEntity, CommunicationDeviceUserEntityCollection> usuarios)
        {
            InitializeComponent();

            _usuarios = usuarios;
        }

        private void FUsProtocolo_Load(object sender, EventArgs e)
        {
            lblContenedorPwds.Text = "Desactivación de Protocolos";

            CargarUsuarios();
        }


        private void CargarUsuarios()
        {
            IList<ListViewItem> lviArr = new List<ListViewItem>();
            
            foreach(CommunicationDeviceProtocolEntity protocol in _usuarios.Keys)
                foreach (CommunicationDeviceUserEntity user in _usuarios[protocol])
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = user.Username;
                    lvi.SubItems.Add(protocol.Name);

                    lvLista.Items.Add(lvi);
                }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
    }
}

