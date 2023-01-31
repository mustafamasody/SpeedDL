using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedDL
{
    public partial class frmAddUrl : MetroFramework.Forms.MetroForm
    {
        public frmAddUrl()
        {
            InitializeComponent();
        }

        private void frmAddUrl_Load(object sender, EventArgs e)
        {

        }

        public string Url { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Url = txtUrl.Text;
        }
    }
}
