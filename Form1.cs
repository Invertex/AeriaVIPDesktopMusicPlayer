using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aeria_VIP_Desktop_Music_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadSWF(axShockwaveFlash1, Aeria_VIP_Desktop_Music_Player.Resource1.vip);        
        }

        private void loadSWF(AxShockwaveFlashObjects.AxShockwaveFlash flashController, byte[] SWF)
        {
            using (MemoryStream stm = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stm))
                {
                    /* Write length of stream for AxHost.State */
                    writer.Write(8 + SWF.Length);
                    /* Write Flash magic 'fUfU' */
                    writer.Write(0x55665566);
                    /* Length of swf file */
                    writer.Write(SWF.Length);
                    writer.Write(SWF);
                    stm.Seek(0, SeekOrigin.Begin);
                    /* 1 == IPeristStreamInit */
                    flashController.OcxState = new AxHost.State(stm, 1, false, null);
                }
            }
        }
    }
}
